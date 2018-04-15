Ext.define('WebClient.common.filters.FilterBinder', {
    requires: [
        'WebClient.common.binding.Binder',
        'WebClient.common.filters.FilterBinding'
    ],

    statics: {
        /**
         * Связывает filterable с компонентами - источниками фильтров.
         * @param {Ext.data.AbstractStore} filterable
         * @param {Object[]} bindings
         * @param {Number=600} filterDelay
         * @returns {WebClient.common.filters.FilterBinder}
         */
        bind: function(filterable, bindings, filterDelay) {
            var cfg = {
                filterable: filterable,
                bindings: bindings
            };
            if (filterDelay)
                cfg.filterDelay = filterDelay;
            return new WebClient.common.filters.FilterBinder(cfg);
        },

        /**
         * Функция для получения массива настроек WebClient.common.filters.FilterBinding для компонентов заданного контейнера.
         * Фильтрами считаются компоненты, у которых задано свойство __filterBinding.
         * Сам компонент при этом становится свойством source.
         * Кроме того могут быть заданы все остальные поля свойства WebClient.common.filters.FilterBinding в __filterBinding.
         * @param {Ext.container.Container} container
         * @returns {Object[]}
         */
        getFilterBindings: function(container) {
            var filterBindings = [],
                filterBindingComponents = Ext.ComponentQuery.query('*[__filterBinding]', container);

            if (filterBindingComponents == null)
                return filterBindings;

            Ext.Array.each(filterBindingComponents, function(component) {
                var filterBinding = component['__filterBinding'];
                filterBinding.source = component;
                filterBindings.push(filterBinding);
            });

            return filterBindings;
        }
    },

    config: {
        /**
         * @cfg {Number} filterDelay
         * Задержка между нажатиями букв на клавиатуре и применением новых фильтров. мсек.
         */
        filterDelay: 600,

        /**
         * @cfg {Ext.data.AbstractStore}
         * Объект, который содержит коллекцию фильтров, которая будет модифицироваться при изменении значений в компонентах-источниках фильтров.
         */
        filterable: undefined,

        /**
         * @type {Ext.util.MixedCollection}
         * Коллекция связок WebClient.common.filters.FilterBinding.
         */
        bindings: undefined
    },


    /** 
     * @private 
     * @type {Function}
     */
    filterDebouncedFn: undefined,

    /**
     * @private
     * @type {Number}
     */
    filteringSuspended: 0,

    /**
     * @private 
     */
    applyFilterable: function(filterable) {
        if (!filterable)
            return filterable;

        if (!Ext.isFunction(filterable.loadPage) || !Ext.isFunction(filterable.getFilters))
            Ext.Error.raise('Переданный filterable не подходящего типа. У него должен быть метод loadPage и коллекция фильтров');

        return filterable;
    },

    /**
     * @private 
     */
    updateFilterDelay: function(newFilterDelay, oldFilterDelay) {
        this.filterDebouncedFn = WebClient.debounce(this.filter, this, newFilterDelay);
    },

    /**
     * @private
     */
    applyBindings: function(bindings) {
        var me = this,
            coll = new Ext.util.MixedCollection();

        if (!bindings) {
            return coll;
        } else if (bindings instanceof Ext.util.MixedCollection) {
            bindings.each(function(b) {
                b = me.createFilterBinding(b);
                coll.add(b.getId(), b);
            });
            return coll;
        } else {
            if (!Ext.isArray(bindings))
                bindings = [bindings];
            Ext.each(bindings, function(b) {
                b = me.createFilterBinding(b);
                coll.add(b.getId(), b);
            });
            return coll;
        }
    },

    /**
     * @private
     */
    updateBindings: function(newBindings, oldBindings) {
        if (oldBindings)
            oldBindings.each(function(b) { Ext.destroy(b); });
    },

    /**
     * @private 
     */
    updateFilterable: function(newFilterable, oldFilterable) {
        var bindings = this.getBindings();

        if (oldFilterable) {
            oldFilterable.un('destroy', this.destroy, this);
            var oldExistingFilters = oldFilterable.getFilters();

            bindings.each(function(filterBinding) {
                 // Удаляем фильтры из старого Store
                oldExistingFilters.each(function(f, i) {
                    if (f.getId() === filterBinding.getId())
                        oldExistingFilters.removeAt(i);
                    return true;
                });
            });
        }

        if (newFilterable) {
            newFilterable.on('destroy', this.destroy, this);
            var newExistingFilters = newFilterable.getFilters();

            bindings.each(function(filterBinding) {
                var value = filterBinding.getBinding().source.get(),
                    filters = filterBinding.getFilterConvertor().apply(this, [filterBinding, value]); //this may be array

                // Потом заменяем в новом
                newExistingFilters.each(function(f, i) {
                    if (f.getId() === filterBinding.getId())
                        newExistingFilters.removeAt(i);
                    return true;
                });

                if (!Ext.isArray(filters))
                    filters = [filters];

                for (var i = 0, l = filters.length; i < l; i++) {
                    if (filters[i])
                        newExistingFilters.add(filters[i]);
                }
            });
        }
    },

    constructor: function(config) {
        this.initConfig(config);
        return this;
    },

    /**
     * Создает WebClient.common.filters.FilterBinding по настройкам
     * @param {Object} options объект со структурой
     * @param {Ext.Component/WebClient.common.binding.HasValue} options.source компонент, который служит источником для собирания элемента фильтров.
     * Из него будет браться itemId как ключ элемента фильтров. При изменении значения в source будет модифицироваться именно этот элемент в коллекции фильтров.
     * Также, это может быть объект {@link {WebClient.common.binding.HasValue}}, тогда sourceValue игнорируется.
     * @param {String=} options.sourceValue имя свойства HasValue из которого будут забираться значения для фильтра. См {@link WebClient.common.binding.Binder#bind}.
     * @param {String=} options.dataIndex поле в таблице, к которому применяется оператор фильтра и значение. Если не указано, используется itemId компонента.
     * @param {WebClient.FilterOps=} оператор фильтра. Если не указан, используется такое свойство у компонента, или WebClient.FilterOps.EQ.
     * @param {Function=} options.convertor функция, которая конвертирует значение из source перед тем, как отдавать в элемент фильтров. function(Object value) возвращает Object.
     * @param {Function=} options.filterConvertor функция, которая конвертирует значение из source в элемент (или массив) фильтров. Используется для нестандартных случаев. function(WebClient.common.filters.FilterBinding binding, Object value) возвращает Ext.util.Filter.
     */
    createFilterBinding: function(options) {
        if (options instanceof WebClient.common.filters.FilterBinding)
            return options;

        var scomp = options.source,
            binding = WebClient.common.binding.Binder.bind(scomp, options.sourceValue);

        if (options.convertor) {
            binding.convert(options.convertor);
            delete options.convertor;
        }

        if (!options.filterConvertor)
            options.filterConvertor = this.defaultFilterConverter;

        Ext.applyIf(options, {
            id: scomp.itemId,
            dataIndex: scomp.dataIndex,
            operator: scomp.operator || WebClient.FilterOps.EQ
        });

        if (!options.dataIndex)
            options.dataIndex = options.id;
        else if (!options.id)
            options.id = options.dataIndex;

        if (!options.id)
            Ext.Error.raise('itemId или dataIndex должны быть указаны либо в контроле либо в параметре binding-а');

        options.binding = binding;
        var filterBinding = new WebClient.common.filters.FilterBinding(options);

        var target = new WebClient.common.binding.HasValue({
            set: Ext.Function.pass(this.onSourceValueChange, [filterBinding], this)
        });

        binding.to(target);

        return filterBinding;
    },

    /**
     * Связывает filterable с неким компонентом - источником фильтра(ов). Для компонента должно быть возможно достать HasValue (@link {WebClient.common.binding.Binder#bind}).
     * Если какая-либо из опций (кроме source и sourceValue) опущена, метод попытается взять соответсвующие свойство у source-а.
     * 
     * Пример: {source: myGrid1, itemId: "CustomerId", convertor: function(row) {return row.getId();} }
     * 
     * @param {Object} options объект со структурой. См. createFilterBinding
     */
    addBinding: function(options) {
        var bindings = this.getBindings(),
            filterBinding = this.createFilterBinding(options);

        var old = bindings.get(filterBinding.getId());
        if (old)
            old.destroy();

        bindings.add(filterBinding.getId(), filterBinding);
    },

    /**
     * @private 
     */
    filter: function() {
        var filterable = this.getFilterable();
        if (!filterable)
            Ext.Error.raise('filterable не установлен');

        if (filterable instanceof Ext.data.TreeStore)
            filterable.setRootNode({});
        else
            filterable.loadPage(1);
    },

    /**
     * @private
     */
    onSourceValueChange: function(filterBinding, value) {
        var filterable = this.getFilterable();
        if (!filterable)
            Ext.Error.raise('filterable не установлен');

        var existingFilters = filterable.getFilters(),
            filters = filterBinding.getFilterConvertor().apply(this, [filterBinding, value]); // может быть массивом

        existingFilters.each(function(f, i) {
            if (f.getId() === filterBinding.getId())
                existingFilters.removeAt(i);
            return true;
        });

        if (!Ext.isArray(filters))
            filters = [filters];

        for (var i = 0, l = filters.length; i < l; i++) {
            if (filters[i])
                existingFilters.add(filters[i]);
        }

        if (!this.filteringSuspended)
            this.filterDebouncedFn(); // вызывается filterable.filter без параметров чтобы пере-применить модифицированный фильтр
    },

    /**
     * Функция, используемая по-умолчанию, преобразует значение из компонента-источника в Ext.util.Filter.
     * Допустимо, чтобы компонент возвращал уже объект или массив фильтров - тогда они уйдут как есть в filterable.
     * Пустое значение value (но не 0) вернет null - по этому полю фильтровки больше не будет
     * @private
     * @param {WebClient.common.filters.FilterBinding} filterBinding
     * @param {Object} value значение из компонента-источника
     * @returns {Ext.util.Filter} Объект-фильтр или их массив
     */
    defaultFilterConverter: function(filterBinding, value) {
        if (value === undefined || value === null || value === '')
            return null;

        // Если value это уже фильтр (или их массив) - возвращаем напрямую 
        if (Ext.isArray(value)) {
            var i,
                l = value.length;

            if (l > 0 && value[0] instanceof Ext.util.Filter) {
                for (i = 0; i < l; i++) {
                    // необходимо для правильной синхронизации с существующей коллекцией фильтров 
                    value[i].setId(filterBinding.getId());
                }
                return value;
            }
        } else if (value instanceof Ext.util.Filter) {
            value.setId(filterBinding.getId());
            return value;
        }

        var f = filterBinding.filter;
        if (!f) {
            // кэшируем объект дабы не расходовать память
            f = filterBinding.filter = new Ext.util.Filter({
                id: filterBinding.getId(),
                property: filterBinding.getDataIndex(),
                operator: filterBinding.getOperator()
            });
        }

        f.setValue(Ext.isArray(value) ? value : [value]);
        return f;
    },

    /**
     * Приостановить фильтрацию при изменении значений в полях фильтров.
     */
    suspendFiltering: function() {
        ++this.filteringSuspended;
    },

    /**
     * Возобновить фильтрацию после остановки.
     * @param {Boolean} filterNow отфильтровать сразу.
     */
    resumeFiltering: function(filterNow) {
        var me = this;

        if (!me.filteringSuspended)
            Ext.log.warn('Несоответствие вызовов resumeAutoSync - автоматическая фильтрация в настоящее время не приостанавлена.');
        
        if (me.filteringSuspended && !--me.filteringSuspended) {
            if (filterNow)
                me.filter();
        }
    },

    /**
     * @private
     */
    destroy: function() {
        this.getBindings().each(function(b) { Ext.destroy(b); });
    }
});
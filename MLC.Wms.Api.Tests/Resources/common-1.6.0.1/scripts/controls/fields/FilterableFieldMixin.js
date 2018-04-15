Ext.define('WebClient.common.controls.fields.FilterableFieldMixin', {

    extend: 'Ext.Mixin',

    mixinConfig: {
        after: {
            destroy: 'destroy'
        }
    },

    /**
     * Объект для привязывания фильтров
     * @private
     * @type 
     */
    filterable: undefined,

    /**
     * Описание вложенного на форму filterable
     * @type String
     */
    filterableFieldDescriptor: undefined,

    /**
     * @private
     * @type WebClient.common.filters.FilterBinder
     */
    filterBinder: undefined,

    constructor: function (cfg) {
        if (cfg.filters) {
            this.getFilterable().filters.addAll(cfg.filters);
            delete cfg.filters;
        }
    },


    /**
     * Получает объект для привязывания фильтров.
     * @public
     * @return {}
     */
    getFilterable: function () {
        var me = this;
        if (!me.filterable) {
            var filters = new Ext.util.MixedCollection();
            // При добавлении фильтров надо очищать значение, поскольку неизвестно,
            // попадает ли оно под новый фильтр
            filters.on({
                add: me.clearValue,
                replace: me.clearValue,
                scope: me
            });
            me.filterable = {
                getFilters: function () { return filters; },
                filter: function (filters) {
                    if (filters) {
                        this.filters.clear();
                        this.filters.addAll(filters);
                    }
                },
                loadPage: function () {
                    return;
                },
                on: function (event, callback, scope) {
                    me.on(event, callback, scope);
                }
            };
        }

        return me.filterable;
    },

    initFilterBinder: function () {
        var me = this;
        if (me.filterBinder)
            return;

        if (!me.filterableFieldDescriptor || !me.filterableFieldDescriptor.externalFilterFields.length)
            return;

        var site = WebClient.common.Site.getSite(this),
            card = site.getService('WebClient.common.view.ICardView'),
            bindings = Ext.Array.map(me.filterableFieldDescriptor.externalFilterFields, function (f) {
                return {
                    source: card.getHasValue(f.fieldName, f.fieldValueName),
                    itemId: f.fieldName,
                    dataIndex: f.fieldName,
                    operator: WebClient.FilterOps.EQ
                };
            });

        me.filterBinder = WebClient.common.filters.FilterBinder.bind(me.getFilterable(), bindings);
    },

    /**
     * Применяет фильтр, заданный через привязки, к указанному хранилищу и полям фильтра
     * @protected
     * @param {Ext.data.AbstractStore} store
     * @param {function} filterFieldResolver
     */
    applyFilterable: function (store, filterFieldResolver) {
        // вообще применение зависит от контрола, так что правильно делать его в самом контроле
        // но пока для имеющихся применений достаточно этой стандартной реализации
        var filterable = this.getFilterable();
        if (filterable.getFilters().getCount() > 0) {
            filterable.getFilters().each(function (filter) {
                var field = Ext.isFunction(filterFieldResolver) ? filterFieldResolver(filter.getProperty()) : null;
                if (field && filter.getValue()) {
                    if (Ext.Array.contains([WebClient.FilterOps.EQ, WebClient.FilterOps.IN], filter.getOperator()) && filter.getValue().length == 1) {
                        field.setValue(filter.getValue()[0]);
                        field.disable();
                        return;
                    } else if (filter.getOperator() == WebClient.FilterOps.IN && Ext.isFunction(field.getFilterable)) {
                        // почему-то Ext.merge и Ext.clone возвращают исходный объект фильтра, поэтому он меняется 
                        var fieldFilter = new Ext.util.Filter({
                            property: filter.getProperty(),
                            root: filter.getRoot(),
                            operator: filter.getOperator(),
                            value: filter.getValue()
                        });
                        field.getFilterable().getFilters().add(fieldFilter);
                    }
                }

                store.getFilters().add(filter);
            });
        }
    },

    /**
     * Очищает значение поля
     * @private
     */
    clearValue: function () {
        this.setValue(null);
    }
});
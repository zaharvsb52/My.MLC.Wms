Ext.define('WebClient.common.ComponentConfigEnricher', {
    requires: [
        'WebClient.common.layout.EditorFactory',
        'WebClient.common.layout.ColumnFactory',
        'WebClient.common.layout.FilterFactory',
        'WebClient.common.data.StructureExtender'
    ],
    singleton: true,

    /**
     * Заполняет недостающие параметры редакторов полей из метаинформации.
     * В качестве функции создания контрола из метаинформации о поле используется функция WebClient.common.layout.EditorFactory.getInstance().createConfig(field).
     *  
     * @param {object} config
     * @param {Ext.data.Model} structure
     */
    populateEditors: function (config, structure) {
        var fields = WebClient.common.data.StructureExtender.getFields(structure);
        var controlConfigProvider = Ext.isFunction(config.controlConfigProvider)
            ? config.controlConfigProvider
            : function (fieldname) {
                var field = Ext.Array.findBy(fields, function (f) { return f.getName() === fieldname; });
                if (field)
                    return WebClient.common.layout.EditorFactory.getInstance().createConfig(field);
                else
                    Ext.Error.raise('Field requested in autoform not found: ' + fieldname);
            };

        this.enrichConfig(config, 'items', 'name', Ext.Function.pass(controlConfigProvider, [], this));
        return config;
    },

    /**
     * Заполняет недостающие параметры просмотрщиков полей из метаинформации.
     * В качестве функции создания контрола из метаинформации о поле используется функция WebClient.common.layout.ViewerFactory.getInstance().createConfig(field).
     *  
     * @param {object} config
     * @param {Ext.data.Model} structure
     */
    populateViewers: function (config, structure) {
        var fields = WebClient.common.data.StructureExtender.getFields(structure);
        var controlConfigProvider = Ext.isFunction(config.controlConfigProvider)
            ? config.controlConfigProvider
            : function (fieldname) {
                var field = Ext.Array.findBy(fields, function (f) { return f.getName() === fieldname; });
                if (field)
                    return WebClient.common.layout.ViewerFactory.getInstance().createConfig(field);
                else
                    Ext.Error.raise('Field requested in autoform not found: ' + fieldname);
            };

        this.enrichConfig(config, 'items', 'name', Ext.Function.pass(controlConfigProvider, [], this));
        return config;
    },

    /**
     * Заполняет недостающие параметры автофильтров из метаинформации.
     * В качестве функции создания контрола из метаинформации о поле используется функция WebClient.common.layout.FilterFactory.getInstance().createConfig(field).
     *  
     * @param {object} config
     * @param {Ext.data.Model} structure
     */
    populateAutoFilters: function (config, structure) {
        var fields = WebClient.common.data.StructureExtender.getFilterFields(structure);

        var controlConfigProvider = Ext.isFunction(config.controlConfigProvider)
            ? config.controlConfigProvider
            : function (fieldname) {
                var field = Ext.Array.findBy(fields, function (f) { return f.getName() === fieldname; });
                if (field)
                    return WebClient.common.layout.FilterFactory.getInstance().createConfig(field);
                else
                    Ext.Error.raise('Field requested in autoform not found: ' + fieldname);
            };

        this.enrichConfig(config, 'items', 'dataIndex', Ext.Function.pass(controlConfigProvider, [], this));
        return config;
    },

    /**
     * Заполняет недостающие параметры рендереров ячеек из метаинформации.
     * В качестве функции создания контрола из метаинформации о поле используется функция WebClient.common.layout.ColumnFactory.getInstance().createConfig(field).
     *  
     * @param {object} config
     * @param {Ext.data.Model} structure
     */
    populateColumns: function (config, structure) {
        var fields = WebClient.common.data.StructureExtender.getFields(structure);
        var controlConfigProvider = Ext.isFunction(config.controlConfigProvider)
            ? config.controlConfigProvider
            : function (fieldname) {
                var field = Ext.Array.findBy(fields, function (f) { return f.getName() === fieldname; });
                if (field)
                    return WebClient.common.layout.ColumnFactory.getInstance().createConfig(field);
                else
                    Ext.Error.raise('Field requested in autogrid not found: ' + fieldname);
            };

        this.enrichConfig(config, 'columns', 'dataIndex', Ext.Function.pass(controlConfigProvider, [], this));
        return config;

    },

    /**
     * Заполняет конфигурацию параметрами из переданного провайдера.
     *
     * @param {object} config - конфигурация, в которой нужно заполнить недостающие параметры контролов
     * @param {string} itemsPropertyName - название свойства, в котором нужно искать элементы с идентификатором, которые нужно "обогатить"
     * @param {string} itemUniquePropertyName - название идентификатора (уникального свойства). данное свойство будет передано в configProvider
     * @param {function} configProvider - функция, возвращающая конфигурацию по значению уникального свойства
     */
    enrichConfig: function (config, itemsPropertyName, itemUniquePropertyName, configProvider) {
        var globalParams = {
            itemsPropertyName: itemsPropertyName,
            itemUniquePropertyName: itemUniquePropertyName,
            configProvider: configProvider
        };

        this.traverse(config, Ext.Function.pass(this.readCallback, [], this), null, globalParams);
    },

    /** @private */
    enrichCallback: function (value, ctx, globalParams) {
        var uniqValue = value[globalParams.itemUniquePropertyName];
        if (uniqValue) {
            var defaultconfig = globalParams.configProvider(uniqValue);
            var oldconfig = value;
            Ext.Object.merge(defaultconfig, oldconfig);
            if (Ext.isDefined(ctx.property))
                ctx.parent[ctx.property] = defaultconfig;
            else if (Ext.isDefined(ctx.index))
                ctx.parent[ctx.index] = defaultconfig;
            else
                Ext.Error.raise('Neither property nor index found while enriching control config.');
        } else
            this.traverse(value, Ext.Function.pass(this.readCallback, [], this), ctx, globalParams);
    },

    /** @private */
    readCallback: function (value, ctx, globalParams) {
        var prop = undefined;
        if (Ext.isDefined(ctx.property))
            prop = ctx.property;
        else if (Ext.isDefined(ctx.parentCtx) && Ext.isDefined(ctx.parentCtx.property))
            prop = ctx.parentCtx.property;

        if (prop !== globalParams.itemsPropertyName)
            this.traverse(value, Ext.Function.pass(this.readCallback, [], this), ctx, globalParams);
        else
            this.traverse(value, Ext.Function.pass(this.enrichCallback, [], this), ctx, globalParams);
    },

    /** @private */
    traverse: function (obj, callback, ctx, globalParams) {
        if (typeof (obj) != 'object')
            return;
        if (Ext.getClass(obj))
            return;
        if (Ext.isArray(obj)) {
            for (var i = 0; i < obj.length; i++) {
                var value = obj[i];
                var newctx = {
                    parent: obj,
                    index: i,
                    parentCtx: ctx
                };
                callback(value, newctx, globalParams);
            }
        } else {
            for (var p in obj) {
                if (obj.hasOwnProperty(p)) {
                    var value = obj[p];
                    var newctx =
                        {
                            parent: obj,
                            property: p,
                            parentCtx: ctx
                        };

                    callback(value, newctx, globalParams);
                }
            }
        }
    }
});
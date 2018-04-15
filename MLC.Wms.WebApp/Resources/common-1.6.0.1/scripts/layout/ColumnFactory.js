/**
 *  Этот класс отвечает за создаение дефолтной конфигурации ячеек грида по метаданным.
 */
Ext.define('WebClient.common.layout.ColumnFactory', {
    requires: [
        'WebClient.common.layout.EditorFactory',
        'WebClient.common.layout.AutoFilterFactory',
        'WebClient.common.metadata.MetadataManager',
        'WebClient.common.metadata.DomainType',
        'WebClient.common.appController.EntityControllerProvider',
        'WebClient.common.util.doT'
    ],

    statics: {

        /**
         * Имя класса singleton фабрики конфигурации ячеек грида
         * @type String
         * @protected
         */
        className: 'WebClient.common.layout.ColumnFactory',

        /**
         * 
         * @type
         * @private 
         */
        instance: undefined,

        setColumnFactoryClassName: function(className) {
            Ext.require(className);
            this.className = className;
            delete this.instance;
        },

        getInstance: function() {
            if (!this.instance)
                this.instance = Ext.create(this.className);
            return this.instance;
        }
    },

    /**
     * @private
     * @type {Ext.util.MixedCollection}
     */
    columnCreatorMap: undefined,

    constructor: function() {
        var me = this;
        var DomainType = WebClient.common.metadata.DomainType;

        me.columnCreatorMap = new Ext.util.MixedCollection();
        me.columnCreatorMap.add(DomainType.string, me.createStringConfig);
        me.columnCreatorMap.add(DomainType.dateTime, me.createDateTimeConfig);
        me.columnCreatorMap.add(DomainType.numeric, me.createNumericConfig);
        me.columnCreatorMap.add(DomainType.boolean, me.createBooleanConfig);
        me.columnCreatorMap.add(DomainType.enumeration, me.createEnumConfig);
        me.columnCreatorMap.add(DomainType.entityId, me.createEntityIdConfig);
        me.columnCreatorMap.add(DomainType.entityRef, me.createEntityRefConfig);
        me.columnCreatorMap.add(DomainType.entityRefCollection, me.createEntityRefCollectionConfig);
    },

    /**
     * Создает массив конфигураций ячеек для авто грида, строящегося на основе переданного массива полей
     * @param {Array} fields
     * @return {Array} массив конфигураций
     */
    createConfigs: function(fields) {
        var me = this,
            controls = [];

        Ext.Array.each(fields, function(field) {
            if (!field.hidden)
                controls.push(me.createConfig(field));
        });

        return controls;
    },

    createConfig: function(field, overrideConfig) {
        if (!field.type)
            field.type = WebClient.common.metadata.MetadataManager.getDefaultFieldType();
        if (!field.domain || !field.domain.type)
            field.domain = WebClient.common.metadata.MetadataManager.getDefaultDomain(field);

        var creatorFn = this.columnCreatorMap.getByKey(field.domain.type) || this.createDefaultConfig;
        var config = creatorFn.apply(this, [field]);

        return Ext.merge(config, overrideConfig);
    },

    /**
     * @protected
     */
    createCommonConfig: function(field) {
        var commonConfig = {
            dataIndex: field.name,
            itemId: field.name,
            header: (field.columnInfo && field.columnInfo.header) || field.name,
            sortable: field.columnInfo && field.columnInfo.sortable,
            resizable: field.columnInfo && field.columnInfo.resizable,
            cellWrap: field.columnInfo && field.columnInfo.cellWrap
        };

        var width = field.columnInfo && field.columnInfo.width && parseInt(field.columnInfo.width, 10);
        if (width > 0)
            commonConfig.width = width;

        commonConfig.editor = WebClient.common.layout.EditorFactory.getInstance().createConfig(field, { hideLabel: true });
        commonConfig.filter = WebClient.common.layout.AutoFilterFactory.getInstance().createConfig(field);

        return commonConfig;
    },

    /**
     * @protected
     */
    createStringConfig: function(field) {
        return this.createCommonConfig(field);
    },

    /**
     * @protected
     */
    createDateTimeConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                renderer: field.domain.format !== undefined ? Ext.util.Format.dateRenderer(field.domain.format) : function(v) { return v; }
            }
        );
    },

    /**
     * @protected
     */
    createNumericConfig: function(field) {
        return this.createCommonConfig(field);
    },

    /**
     * @protected
     */
    createBooleanConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                renderer: function(value) { return value ? 'Да' : 'Нет'; }
            }
        );
    },

    /**
     * @protected
     */
    createEnumConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                renderer: function(value) {
                    var val = Ext.Array.findBy(field.domain.allowedValues, function(v) { return v.value === value; });
                    var name = val ? val.name : value;
                    return name;
                }
            }
        );
    },

    /**
     * @protected
     */
    createEntityIdConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                renderer: function(value) {
                    if (!value)
                        return '';

                    var entityId = WebClient.common.type.EntityId.decode(value);
                    return entityId.id.toString();
                }
            }
        );
    },

    /**
     * @protected
     */
    createEntityRefConfig: function(field) {


        var name = field.name,
            format = field.domain.entityRefDescriptor.format,
            entityType = field.domain.entityRefDescriptor.entityType,
            template = format ? WebClient.common.util.doT.template(format) : null,
            appController;

        WebClient.common.appController.EntityControllerProvider.take(entityType, function(instance) { appController = instance; });


        var renderer = function(value, metaData) {
            metaData.tdCls = '';

            if (!value) {
                metaData.tdCls = 'gr-entity-ref-empty';
                return '';
            }

            if (!template)
                return value.toString();

            return template(value.getValuesObject());
        };

        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'actioncolumn',
                tdCls: 'gr-entity-ref',
                renderer: renderer,
                items: [
                    {
                        iconCls: 'gr-trigger gr-trigger-external-link',
                        handler: function (view, rowIndex, colIndex, item, e, model, row) {
                            if (!appController)
                                return;
                            var entityRef = model.get(name);
                            if (!entityRef)
                                return;
                            appController.edit(null, entityRef, function () { view.getStore().load(); });
                        }
                    }
                ]
            }
        );
    },

    /**
     * @protected
     */
    createEntityRefCollectionConfig: function(field) {
        return this.createCommonConfig(field);
    },

    /**
     * @protected
     */
    createDefaultConfig: function (field) {
        return this.createCommonConfig(field);
    }
});
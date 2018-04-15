/**
 *  Этот класс отвечает за создаение дефолтной конфигурации фильтров по метаданным.
 */

Ext.define('WebClient.common.layout.AutoFilterFactory', {
    requires: [
        'WebClient.common.metadata.MetadataManager',
        'WebClient.common.metadata.DomainType',
        'WebClient.common.controls.fields.ComboBox',
        'WebClient.common.controls.fields.EntityRefEditor',
        'WebClient.common.layout.EnumModel',
        'WebClient.common.controls.fields.EntityId'
    ],

    statics: {

        /**
         * Имя класса singleton фабрики фильтров
         * @type String
         * @protected
         */
        className: 'WebClient.common.layout.AutoFilterFactory',

        /**
         * 
         * @type
         * @private 
         */
        instance: undefined,

        setFilterFactoryClassName: function(className) {
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
    filterCreatorMap: undefined,

    /**
     * Registers default mappings in constructor.
     */
    constructor: function() {
        var me = this;
        var DomainType = WebClient.common.metadata.DomainType;

        me.filterCreatorMap = new Ext.util.MixedCollection();
        me.filterCreatorMap.add(DomainType.string, this.createStringConfig);
        me.filterCreatorMap.add(DomainType.dateTime, this.createDateTimeConfig);
        me.filterCreatorMap.add(DomainType.numeric, this.createNumericConfig);
        me.filterCreatorMap.add(DomainType.boolean, this.createBooleanConfig);
        me.filterCreatorMap.add(DomainType.enumeration, this.createEnumConfig);
        me.filterCreatorMap.add(DomainType.entityId, this.createEntityIdConfig);
        me.filterCreatorMap.add(DomainType.entityRef, this.createEntityRefConfig);
    },

    /**
     * Создает массив конфигураций полей для авто формы, строящейся на основе переданного массива полей
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

    /**
     * Создает массив простых конфигураций полей для авто формы, строящейся на основе переданного массива полей, в дальнейшем требует обогащения (enrichment)
     * @param {Array} fields
     * @return {Array} массив конфигураций
     */
    createFieldPlaceholders: function(fields) {
        var controls = [];

        Ext.Array.each(fields, function(field) {
            if (!field.hidden)
                controls.push({ dataIndex: field.name });
        });

        return controls;
    },

    createConfig: function(field, overrideConfig) {
        if (!field.type)
            field.type = WebClient.common.metadata.MetadataManager.getDefaultFieldType();
        if (!field.domain || !field.domain.type)
            field.domain = WebClient.common.metadata.MetadataManager.getDefaultDomain(field);

        var creatorFn = this.filterCreatorMap.getByKey(field.domain.type) || this.createDefaultConfig;
        var config = creatorFn.apply(this, [field]);

        return Ext.merge(config, overrideConfig);
    },

    /**
     * @protected
     */
    createCommonConfig: function(field) {
        return {

        };
    },

    /**
    * @protected
    */
    createStringConfig: function(field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.LIKE;
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'textfield',
                dataIndex: field.name,
                itemId: field.name,
                __filterBinding: {
                    operator: operator,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createDateTimeConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'fieldcontainer',
                getInputId: function() {
                    return this.down('#' + field.name + 'From').getInputId();
                },
                listeners: {
                    beforerender: function() {
                        this.down('#LblTill').forId = this.down('#' + field.name + 'Till').getInputId();
                    }
                },
                layout: {
                    type: 'hbox',
                    align: 'stretch'
                },
                defaults: {
                    flex: 1
                },
                items: [
                    {
                        xtype: 'datefield',
                        dataIndex: field.name + 'From',
                        itemId: field.name + 'From',
                        format: field.domain.format || 'd.m.Y H:i',
                        __filterBinding: {
                            operator: WebClient.FilterOps.GTE,
                            dataIndex: field.name
                        }
                    },
                    {
                        xtype: 'label',
                        itemId: 'LblTill',
                        flex: 0,
                        text: '-',
                        margin: '0 5 0 5'
                    },
                    {
                        xtype: 'datefield',
                        dataIndex: field.name + 'Till',
                        itemId: field.name + 'Till',
                        format: field.domain.format || 'd.m.Y H:i',
                        __filterBinding: {
                            operator: WebClient.FilterOps.LTE,
                            dataIndex: field.name
                        }
                    }
                ]

            }
        );
    },

    /**
    * @protected
    */
    createNumericConfig: function(field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.EQ;
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'numberfield',
                dataIndex: field.name,
                itemId: field.name,
                allowDecimals: !!field.domain.decimalPrecision,
                decimalPrecision: field.domain.decimalPrecision,
                minValue: field.domain.minValue,
                maxValue: field.domain.maxValue,
                __filterBinding: {
                    operator: operator,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createBooleanConfig: function(field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.EQ;
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.ComboBox',
                dataIndex: field.name,
                itemId: field.name,
                store: {
                    model: 'WebClient.common.layout.EnumModel',
                    data: WebClient.common.layout.EnumModel.COMBOBOX_VALUES_FOR_BOOLEAN
                },
                displayField: 'name',
                valueField: 'value',
                queryMode: 'local',
                __filterBinding: {
                    operator: operator,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createEnumConfig: function(field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.EQ;
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.ComboBox',
                dataIndex: field.name,
                itemId: field.name,
                store: {
                    model: 'WebClient.common.layout.EnumModel',
                    data: field.domain.allowedValues
                },
                displayField: 'name',
                valueField: 'value',
                queryMode: 'local',
                __filterBinding: {
                    operator: operator,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createEntityIdConfig: function(field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.EQ;

        if (operator == WebClient.FilterOps.LIKE || operator == WebClient.FilterOps.LIKEW || operator == WebClient.FilterOps.NOTLIKE || operator == WebClient.FilterOps.NOTLIKEW) {
            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'textfield',
                    dataIndex: field.name,
                    itemId: field.name,
                    __filterBinding: {
                        operator: operator,
                        dataIndex: field.name
                    }
                }
            );
        } else {
            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'WebClient.common.controls.fields.EntityId',
                    dataIndex: field.name,
                    itemId: field.name,
                    entityType: field.domain.entityType,
                    __filterBinding: {
                        operator: operator,
                        dataIndex: field.name
                    }
                }
            );
        }
    },

    /**
     * @protected
     */
    createEntityRefConfig: function (field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.EQ;

        if (operator == WebClient.FilterOps.LIKE || operator == WebClient.FilterOps.LIKEW || operator == WebClient.FilterOps.NOTLIKE || operator == WebClient.FilterOps.NOTLIKEW) {
            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'textfield',
                    dataIndex: field.name,
                    itemId: field.name,
                    __filterBinding: {
                        operator: operator,
                        dataIndex: field.name
                    }
                }
            );
        } else {
            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'WebClient.common.controls.fields.EntityRefEditor',
                    dataIndex: field.name,
                    itemId: field.name,
                    field: (field.columnInfo && field.columnInfo.header) || field.name,
                    filterableFieldDescriptor: field.filterableFieldDescriptor,
                    entityRefDescriptor: field.domain.entityRefDescriptor,
                    __filterBinding: {
                        operator: WebClient.FilterOps.EQ,
                        dataIndex: field.name
                    }
                }
            );
        }
    },

    /**
    * @protected
    */
    createDefaultConfig: function (field) {
        var operator = (field.columnInfo && field.columnInfo.autoFilterDefaultOperator) || WebClient.FilterOps.LIKE;
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'textfield',
                dataIndex: field.name,
                itemId: field.name,
                __filterBinding: {
                    operator: operator,
                    dataIndex: field.name
                }
            }
        );
    }
});
/**
 *  Этот класс отвечает за создаение дефолтной конфигурации фильтров по метаданным.
 */

Ext.define('WebClient.common.layout.FilterFactory', {
    requires: [
        'WebClient.common.metadata.MetadataManager',
        'WebClient.common.metadata.DomainType',
        'WebClient.common.controls.fields.ComboBox',
        'WebClient.common.controls.fields.EntityRefEditor',
        'WebClient.common.layout.EnumModel',
        'WebClient.common.controls.fields.EntityId',
        'WebClient.common.controls.fields.EntityIdTag',
        'WebClient.common.controls.fields.EntityRefTag',
        'WebClient.common.controls.fields.EnumTag'
    ],

    statics: {

        /**
         * Имя класса singleton фабрики фильтров
         * @type String
         * @protected
         */
        className: 'WebClient.common.layout.FilterFactory',

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

        var suitableFilter = Ext.Array.indexOf([
            WebClient.FilterOps.IN,
            WebClient.FilterOps.NOTIN,
            WebClient.FilterOps.LIKELIST,
            WebClient.FilterOps.LIKELISTW
        ], field.columnInfo.autoFilterDefaultOperator);

        if (suitableFilter > -1) {
            var model = new Ext.data.Model();
            model.fields = ['value'];

            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'tagfield',
                    dataIndex: field.name,
                    store: {
                        model: model,
                        data: []
                    },
                    itemId: field.name,
                    hideTrigger: true,
                    queryMode: 'local',
                    createNewOnEnter: true,
                    fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                    __filterBinding: {
                        operator: field.columnInfo.autoFilterDefaultOperator,
                        dataIndex: field.name
                    }
                }
            );
        }

        suitableFilter = Ext.Array.indexOf([
            WebClient.FilterOps.EMPTY
        ], field.columnInfo.autoFilterDefaultOperator);

        if (suitableFilter > -1) {
            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'textfield',
                    dataIndex: field.name,
                    itemId: field.name,
                    fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                    __filterBinding: {
                        operator: WebClient.FilterOps.LIKE,
                        dataIndex: field.name
                    }
                }
            );
        }

        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'textfield',
                dataIndex: field.name,
                itemId: field.name,
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                __filterBinding: {
                    operator: WebClient.FilterOps.LIKE,
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
                fieldLabel: ((field.columnInfo && field.columnInfo.header) || field.name) + ', c',
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
                        text: ' по ',
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

        var suitableFilter = Ext.Array.indexOf([
            WebClient.FilterOps.IN,
            WebClient.FilterOps.NOTIN,
            WebClient.FilterOps.LIKELIST,
            WebClient.FilterOps.LIKELISTW
        ], field.columnInfo.autoFilterDefaultOperator);

        if (suitableFilter > -1) {
            var model = new Ext.data.Model();
            model.fields = ['value'];

            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'tagfield',
                    dataIndex: field.name,
                    store: {
                        model: model,
                        data: []
                    },
                    itemId: field.name,
                    hideTrigger: true,
                    queryMode: 'local',
                    createNewOnEnter: true,
                    enableKeyEvents: true,
                    maskRe: new RegExp('[' + '0123456789,\+\-' + ']'),
                    fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                    __filterBinding: {
                        operator: field.columnInfo.autoFilterDefaultOperator,
                        dataIndex: field.name
                    }
                }
            );
        }

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
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                __filterBinding: {
                    operator: field.columnInfo.autoFilterDefaultOperator || WebClient.FilterOps.EQ,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createBooleanConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.ComboBox',
                dataIndex: field.name,
                itemId: field.name,
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                store: {
                    model: 'WebClient.common.layout.EnumModel',
                    data: WebClient.common.layout.EnumModel.COMBOBOX_VALUES_FOR_BOOLEAN
                },
                displayField: 'name',
                valueField: 'value',
                queryMode: 'local',
                __filterBinding: {
                    operator: WebClient.FilterOps.EQ,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createEnumConfig: function(field) {

        var suitableFilter = Ext.Array.indexOf([
            WebClient.FilterOps.IN,
            WebClient.FilterOps.NOTIN,
            WebClient.FilterOps.LIKELIST,
            WebClient.FilterOps.LIKELISTW
        ], field.columnInfo.autoFilterDefaultOperator);

        if (suitableFilter > -1) {
            var model = new Ext.data.Model();
            model.fields = ['value'];

            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'fieldcontainer',
                    itemId: field.name + 'Cont',
                    fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                    layout: {
                        type: 'vbox',
                        align: 'stretch'
                    },
                    defaults: {
                        flex: 1
                    },
                    items: [
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
                            listeners: {
                                change: function(inField, val) {
                                    var cont = inField.up('#' + field.name + 'Cont'),
                                        dispField = cont.down('#' + field.name + 'TagField');

                                    dispField.setValue(val, null, this.getDisplayValue());
                                }
                            }
                        },
                        {
                            xtype: 'WebClient.common.controls.fields.EnumTag',
                            dataIndex: field.name,
                            store: {
                                model: model,
                                data: []
                            },
                            itemId: field.name + 'TagField',
                            hideTrigger: true,
                            queryMode: 'local',
                            createNewOnEnter: true,
                            enableKeyEvents: true,
                            __filterBinding: {
                                operator: field.columnInfo.autoFilterDefaultOperator,
                                dataIndex: field.name
                            }
                        }
                    ]
                }
            );
        }

        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.ComboBox',
                dataIndex: field.name,
                itemId: field.name,
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                store: {
                    model: 'WebClient.common.layout.EnumModel',
                    data: field.domain.allowedValues
                },
                displayField: 'name',
                valueField: 'value',
                queryMode: 'local'
            }
        );
    },

    /**
    * @protected
    */
    createEntityIdConfig: function(field) {

        var suitableFilter = Ext.Array.indexOf([
            WebClient.FilterOps.IN,
            WebClient.FilterOps.NOTIN,
            WebClient.FilterOps.LIKELIST,
            WebClient.FilterOps.LIKELISTW
        ], field.columnInfo.autoFilterDefaultOperator);

        if (suitableFilter > -1) {
            var model = new Ext.data.Model();
            model.fields = ['value'];

            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'WebClient.common.controls.fields.EntityIdTag',
                    dataIndex: field.name,
                    store: {
                        model: model,
                        data: []
                    },
                    itemId: field.name,
                    entityType: field.domain.entityType,
                    hideTrigger: true,
                    queryMode: 'local',
                    createNewOnEnter: true,
                    fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                    __filterBinding: {
                        operator: field.columnInfo.autoFilterDefaultOperator,
                        dataIndex: field.name
                    }
                }
            );
        }

        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.EntityId',
                dataIndex: field.name,
                itemId: field.name,
                entityType: field.domain.entityType,
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                __filterBinding: {
                    operator: WebClient.FilterOps.EQ,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
     * @protected
     */
    createEntityRefConfig: function(field) {

        var suitableFilter = Ext.Array.indexOf([
            WebClient.FilterOps.IN,
            WebClient.FilterOps.NOTIN,
            WebClient.FilterOps.LIKELIST,
            WebClient.FilterOps.LIKELISTW
        ], field.columnInfo.autoFilterDefaultOperator);

        if (suitableFilter > -1) {
            var model = new Ext.data.Model();
            model.fields = ['value'];

            return Ext.merge(
                this.createCommonConfig(field),
                {
                    xtype: 'fieldcontainer',
                    itemId: field.name + 'Cont',
                    fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                    layout: {
                        type: 'vbox',
                        align: 'stretch'
                    },
                    defaults: {
                        flex: 1
                    },
                    items: [
                        {
                            xtype: 'WebClient.common.controls.fields.EntityRefEditor',
                            dataIndex: field.name,
                            itemId: field.name,
                            filterableFieldDescriptor: field.filterableFieldDescriptor,
                            entityRefDescriptor: field.domain.entityRefDescriptor,
                            listeners: {
                                change: function(inField, val) {
                                    var cont = inField.up('#' + field.name + 'Cont'),
                                        dispField = cont.down('#' + field.name + 'TagField');

                                    dispField.setValue(val);
                                }
                            }
                        },
                        {
                            xtype: 'WebClient.common.controls.fields.EntityRefTag',
                            dataIndex: field.name,
                            store: {
                                model: model,
                                data: []
                            },
                            itemId: field.name + 'TagField',
                            hideTrigger: true,
                            queryMode: 'local',
                            createNewOnEnter: true,
                            enableKeyEvents: true,
                            __filterBinding: {
                                operator: field.columnInfo.autoFilterDefaultOperator,
                                dataIndex: field.name
                            }
                        }
                    ]
                }
            );
        }


        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.EntityRefEditor',
                dataIndex: field.name,

                itemId: field.name,
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                filterableFieldDescriptor: field.filterableFieldDescriptor,
                entityRefDescriptor: field.domain.entityRefDescriptor,
                __filterBinding: {
                    operator: WebClient.FilterOps.EQ,
                    dataIndex: field.name
                }
            }
        );
    },

    /**
    * @protected
    */
    createDefaultConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'textfield',
                dataIndex: field.name,
                itemId: field.name,
                fieldLabel: (field.columnInfo && field.columnInfo.header) || field.name,
                __filterBinding: {
                    operator: WebClient.FilterOps.LIKE,
                    dataIndex: field.name
                }
            }
        );
    }
});
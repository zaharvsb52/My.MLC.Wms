/**
 *  Этот класс отвечает за создаение дефолтной конфигурации редакторов полей по метаданным.
 */
Ext.define('WebClient.common.layout.EditorFactory', {
    requires: [
        'WebClient.common.controls.fields.CustomValidatorsPlugin',
        'WebClient.common.layout.ViewerFactory',
        'WebClient.common.metadata.MetadataManager',
        'WebClient.common.metadata.DomainType',
        'WebClient.common.controls.fields.ComboBox',
        'WebClient.common.layout.EnumModel',
        'WebClient.common.controls.fields.EntityRefEditor',
        'WebClient.common.controls.fields.EntityRefCollectionEditor',
        'WebClient.common.controls.fields.EntityId',
        'WebClient.common.controls.fields.MaskedDateTimeField'
    ],

    statics: {

        /**
         * Имя класса singleton фабрики элементов управления
         * @type String
         * @protected
         */
        className: 'WebClient.common.layout.EditorFactory',

        /**
         * @type
         * @private 
         */
        instance: undefined,

        setEditorFactoryClassName: function(className) {
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
        me.filterCreatorMap.add(DomainType.string, me.createStringConfig);
        me.filterCreatorMap.add(DomainType.dateTime, me.createDateTimeConfig);
        me.filterCreatorMap.add(DomainType.numeric, me.createNumericConfig);
        me.filterCreatorMap.add(DomainType.boolean, me.createBooleanConfig);
        me.filterCreatorMap.add(DomainType.enumeration, me.createEnumConfig);
        me.filterCreatorMap.add(DomainType.entityId, me.createEntityIdConfig);
        me.filterCreatorMap.add(DomainType.entityRef, me.createEntityRefConfig);
        me.filterCreatorMap.add(DomainType.entityRefCollection, me.createEntityRefCollectionConfig);
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

    createFieldPlaceholders: function(fields) {
        return WebClient.common.layout.ViewerFactory.getInstance().createFieldPlaceholders(fields);
    },

    createConfig: function(field, overrideConfig) {
        if (!field.type)
            field.type = WebClient.common.metadata.MetadataManager.getDefaultFieldType();
        if (!field.domain || !field.domain.type)
            field.domain = WebClient.common.metadata.MetadataManager.getDefaultDomain(field);

        if (field.persist === false || (overrideConfig && overrideConfig.persist === false))
            return WebClient.common.layout.ViewerFactory.getInstance().createConfig(field, overrideConfig);

        var creatorFn = this.filterCreatorMap.getByKey(field.domain.type) || this.createDefaultConfig;
        var config = creatorFn.apply(this, [field]);

        return Ext.merge(config, overrideConfig);
    },

    /**
     * @protected
     */
    createCommonConfig: function(field) {
        return {
            name: field.name,
            itemId: field.name,
            readOnly: field.editorInfo && field.editorInfo.readOnly,
            disabled: field.editorInfo && field.editorInfo.disabled,
            fieldLabel: (field.editorInfo && field.editorInfo.label) || field.name,
            hideLabel: field.editorInfo && field.editorInfo.hideLabel,
            labelAlign: (field.editorInfo && field.editorInfo.labelAlign) || 'left',
            labelWidth: 160,
            plugins: [{ ptype: 'customValidators', customValidators: field.customValidators }]
        };
    },

    /**
     * @protected
     */
    createStringConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'textfield',
                emptyText: field.editorInfo && field.editorInfo.emptyText,
                maxLength: field.domain.maxLength || Number.MAX_VALUE,
                enforceMaxLength: !!field.domain.maxLength
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
                xtype: 'WebClient.common.controls.fields.MaskedDateTimeField',
                format: field.domain.format || 'd.m.Y H:i'
            }
        );
    },

    /**
     * @protected
     */
    createNumericConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'numberfield',
                hideTrigger: true,
                keyNavEnabled: false,
                mouseWheelEnabled: false,
                allowDecimals: !!field.domain.decimalPrecision,
                decimalPrecision: field.domain.decimalPrecision,
                minValue: field.domain.minValue || Number.NEGATIVE_INFINITY,
                maxValue: field.domain.maxValue || Number.MAX_VALUE
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
                xtype: 'checkboxfield'
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
                xtype: 'WebClient.common.controls.fields.ComboBox',
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
    * @private
    */
    createEntityIdConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.EntityId',
                entityType: field.domain.entityType
            }
        );
    },

    /**
    * @protected
    */
    createEntityRefConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.EntityRefEditor',
                filterableFieldDescriptor: field.filterableFieldDescriptor,
                entityRefDescriptor: field.domain.entityRefDescriptor
            }
        );
    },

    /**
    * @protected
    */
    createEntityRefCollectionConfig: function(field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                xtype: 'WebClient.common.controls.fields.EntityRefCollectionEditor',
                editable: false,
                filterableFieldDescriptor: field.filterableFieldDescriptor,
                entityRefDescriptor: field.domain.entityRefDescriptor
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
                emptyText: field.editorInfo && field.editorInfo.emptyText,
                maxLength: field.domain.maxLength || Number.MAX_VALUE,
                enforceMaxLength: !!field.domain.maxLength
            }
        );
    }
});
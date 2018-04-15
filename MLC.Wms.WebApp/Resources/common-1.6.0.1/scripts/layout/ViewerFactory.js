/**
 *  Этот класс отвечает за создаение дефолтной конфигурации просмотрщиков полей по метаданным.
 */
Ext.define('WebClient.common.layout.ViewerFactory', {
    requires: [
        'WebClient.common.metadata.MetadataManager',
        'WebClient.common.metadata.DomainType',
        'WebClient.common.layout.EnumModel',
        'WebClient.common.util.doT'
    ],

    statics: {

        /**
         * Имя класса singleton фабрики фильтров
         * @type String
         * @private
         */
        className: 'WebClient.common.layout.ViewerFactory',

        /**
         * 
         * @type
         * @private 
         */
        instance: undefined,

        setViewerFactoryClassName: function(className) {
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
    viewerCreatorMap: undefined,

    /**
     * Registers default mappings in constructor.
     */
    constructor: function() {
        var me = this;
        var DomainType = WebClient.common.metadata.DomainType;

        me.viewerCreatorMap = new Ext.util.MixedCollection();
        me.viewerCreatorMap.add(DomainType.dateTime, this.createDateTimeConfig);
        me.viewerCreatorMap.add(DomainType.boolean, this.createBooleanConfig);
        me.viewerCreatorMap.add(DomainType.enumeration, this.createEnumConfig);
        me.viewerCreatorMap.add(DomainType.entityId, this.createEntityIdConfig);
        me.viewerCreatorMap.add(DomainType.entityRef, this.createEntityRefConfig);
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
        var placeholders = [];

        Ext.Array.each(fields, function(f) {
            if (!f.hidden)
                placeholders.push({ name: f.name });
        });

        return placeholders;
    },

    createConfig: function(field, overrideConfig) {
        if (!field.type)
            field.type = WebClient.common.metadata.MetadataManager.getDefaultFieldType();
        if (!field.domain || !field.domain.type)
            field.domain = WebClient.common.metadata.MetadataManager.getDefaultDomain(field);

        var creatorFn = this.viewerCreatorMap.getByKey(field.domain.type) || this.createDefaultConfig;
        var config = creatorFn.apply(this, [field]);

        return Ext.merge(config, overrideConfig);
    },

    /**
     * @protected
     */
    createCommonConfig: function(field) {
        return {
            xtype: 'displayfield',
            name: field.name,
            itemId: field.name,
            fieldLabel: (field.editorInfo && field.editorInfo.label) || field.name,
            hideLabel: field.editorInfo && field.editorInfo.hideLabel,
            labelAlign: (field.editorInfo && field.editorInfo.labelAlign) || 'left'
        };
    },

    /**
     * @protected
     */
    createDateTimeConfig: function (field) {
        return Ext.merge(
            this.createCommonConfig(field),
            {
                renderer: field.domain.format !== undefined ?
                    Ext.util.Format.dateRenderer(field.domain.format) :
                    this.defaultRenderer
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
                renderer: Ext.pass(this.enumRenderer, [WebClient.common.layout.EnumModel.COMBOBOX_VALUES_FOR_BOOLEAN])
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
                renderer: Ext.pass(this.enumRenderer, [field.domain.allowedValues])
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
                    if (Ext.isString(value))
                        value = WebClient.common.type.EntityId.decode(value);
                    return '' || Ext.valueFrom(value.id, '');
                }
            }
        );
    },

    /**
     * @protected
     */
    createEntityRefConfig: function(field) {
        var format = field.domain.entityRefDescriptor.format,
            template = format ? WebClient.common.util.doT.template(format) : null;

        return Ext.merge(
            this.createCommonConfig(field),
            {
                renderer: function(value) {
                    if (!value)
                        return '';

                    if (!template)
                        return value.toLocaleString();

                    return template(value.getValuesObject());
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
                renderer: this.defaultRenderer
            }
        );
    },

    /**
     * Преобразует значение перечислимого типа в строку
     * @protected
     */
    enumRenderer: function(allowedValues, v) {
        if (Ext.isEmpty(v))
            return '';

        var result = Ext.Array.filter(allowedValues, function(item) {
            return item.value === v;
        });

        return result.length > 0 ? result[0].name : v;
    },

    /**
     * Преобразует значение в строку
     * @protected
     */
    defaultRenderer: function(v) {
        return v ? v.toLocaleString() : '';
    }
});
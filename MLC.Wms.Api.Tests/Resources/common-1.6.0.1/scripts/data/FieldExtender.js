/**
 * Этот класс работает с дополнительной мета-информацией поля, засунутой в Ext.data.field.Field.prototype, такой как customValidators
 */
Ext.define('WebClient.common.data.FieldExtender', {
    requires: [
        'Ext.data.field.Field',
        'WebClient.common.metadata.MetadataManager',
        'WebClient.common.metadata.DomainType',
        'WebClient.common.validator.Validator',
        'WebClient.common.validator.Required',
        'WebClient.common.validator.Min',
        'WebClient.common.validator.Max',
        'WebClient.common.validator.Regexp'
    ],

    singleton: true,

    /**
     * @private
     */
    paramsConverterFactoryMap: undefined,

    constructor: function() {
        var me = this,
            DomainType = WebClient.common.metadata.DomainType;

        me.paramsConverterFactoryMap = new Ext.util.MixedCollection();
        me.paramsConverterFactoryMap.add(DomainType.dateTime, me.getDateConverter);
    },

    getDateConverter: function(field) {
        return function(v) {
            if (!v)
                return null;

            if (v instanceof Date)
                return v;

            var parsed = Ext.Date.parse(v, 'c');
            return parsed ? new Date(parsed) : null;
        };
    },

    /**
     * Этот метод используется для добавления дополнительной (к Ext.data.field.Field) мета информации в созданный класс
     * Анализирует json данные для customValidators и преобразует их в соответсвующие валидаторы
     * @inner
     * @param {Ext.Class} model класс созданного Ext.data.Model
     */
    postProcessStructure: function(model) {
        Ext.Array.each(model.fields, this.createCustomValidators);
    },

    /**
     * @private
     */
    createCustomValidators: function(field) {
        if (!field.customValidators || !field.customValidators.length)
            return;

        if (!field.type)
            field.type = WebClient.common.metadata.MetadataManager.getDefaultFieldType();
        if (!field.domain || !field.domain.type)
            field.domain = WebClient.common.metadata.MetadataManager.getDefaultDomain(field);

        var converterFactory = WebClient.common.data.FieldExtender.paramsConverterFactoryMap.getByKey(field.domain.type),
            converter = converterFactory != null ? converterFactory.apply(this, [field]) : Ext.identityFn;

        field.customValidators = Ext.Array.map(field.customValidators, function(vcfg) {
            vcfg = Ext.merge({ paramsConverter: converter }, vcfg);
            return WebClient.common.validator.Validator.create(vcfg);
        });
    }
});
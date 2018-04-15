/**
 * Проверяет, что значение в поле больше или равно параметру.
 */
Ext.define('WebClient.common.validator.Min', {
    extend: 'WebClient.common.validator.Validator',
    alias: 'webclientvalidator.min',

    config: {
        messageTemplate: 'Значение должно быть больше или равно {0}'
    },

    validate: function(value) {
        return (value === undefined || value === null || value === '') || value >= this.getConvertedParams();
    }
});
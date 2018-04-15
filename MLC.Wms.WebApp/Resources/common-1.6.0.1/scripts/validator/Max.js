/**
 * Проверяет, что значение в поле меньше или равно параметру.
 */
Ext.define('WebClient.common.validator.Max', {
    extend: 'WebClient.common.validator.Validator',
    alias: 'webclientvalidator.max',

    config: {
        messageTemplate: 'Значение должно быть меньше или равно {0}'
    },

    validate: function(value) {
        return (value === undefined || value === null || value === '') || value <= this.getConvertedParams();
    }
});
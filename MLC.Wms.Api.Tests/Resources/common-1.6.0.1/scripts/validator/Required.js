/**
 * Проверяет, что в поле есть значение.
 */
Ext.define('WebClient.common.validator.Required', {
    extend: 'WebClient.common.validator.Validator',
    alias: 'webclientvalidator.required',

    config: {
        messageTemplate: 'Поле обязательно для ввода'
    },

    validate: function(value) {
        return !(value === undefined || value === null || value === '');
    }
});
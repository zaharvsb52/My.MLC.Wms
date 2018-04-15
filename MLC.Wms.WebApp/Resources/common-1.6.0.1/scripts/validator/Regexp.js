/**
 * Проверяет, что строка соответсвует указанному формату.
 */
Ext.define('WebClient.common.validator.Regexp', {
    extend: 'WebClient.common.validator.Validator',
    alias: 'webclientvalidator.regexp',

    config: {
        messageTemplate: 'Строка имеет неверный формат'
    },

    validate: function (value) {
        if (value === undefined || value === null || value === '')
            return true;
        return new RegExp(this.getParams()).test(value);
    }
});
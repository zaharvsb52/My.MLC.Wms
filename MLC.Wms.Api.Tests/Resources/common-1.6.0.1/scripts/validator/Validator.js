/**
 * Базовый класс для всех валидаторов. 
 */
Ext.define('WebClient.common.validator.Validator', {
    mixins: [
        'Ext.mixin.Factoryable'
    ],

    alias: 'webclientvalidator.base', // Factoryable

    statics: {
        ERROR: 'error',

        WARNING: 'warning',

        INFORMATION: 'information'
    },

    config: {
        /**
         * @cfg {string} level Уровень валидатора. Допустимые значения: '**information**', '**warning**', '**error**'.
         * Только уровень '**error**' блокирует форму от сохранения.
         */
        level: 'error',

        /**
         * @cfg {Object/undefined} params Параметры для работы валидатора.
         * Например, минимальное значение для проверки.
         */
        params: undefined,

        /**
         * @cfg {string/undefined} messageTemplate Сообщение, отображаемое на форме при срабатывании валидатора.
         */
        messageTemplate: 'Неверное значение',

        /**
         * @cfg {Function} paramsConverter Функция, которя преобразует json представление параметров с сервера в удобные для валидации
         */
        paramsConverter: Ext.identityFn
    },

    getConvertedParams: function() {
        var converter = this.getParamsConverter();
        return converter ? converter.apply(this, [this.getParams()]) : this.getParams();
    },

    constructor: function(config) {
        this.initConfig(config);
    },

    /**
     * Проверяет переданное значение.
     * @param {Object} value Значение для проверки
     * @return {Boolean/String} `true` если значение корректно
     */
    validate: function() {
        return true;
    },

    /**
     * Сообщение для отображения на форме.
     * @returns {string} сообщение
     */
    getDisplayMessage: function() {
        return Ext.String.format(this.getMessageTemplate(), this.getConvertedParams());
    }
});
/**
 * Класс предназначен чтобы предоставить унифицированный интерфейс чтения\записи какого-либо интересного свойства виджета (контрола).
 * Также через него можно подписаться на событие "изменение" значения.
 */
Ext.define('WebClient.common.binding.HasValue', {
    mixins: {
        observable: 'Ext.util.Observable'
    },

    get: WebClient.notImplementedFn,

    /**
     * 
     * @param {object} newValue
     */
    set: WebClient.notImplementedFn,


    constructor: function(config) {
        Ext.apply(this, config);
        this.mixins.observable.constructor.apply(this, arguments);
    },

    /**
     * Удобный метод подписи на событие изменения HasValue, shortcut на метод on('change',...).
     * @param {Function} fn
     * @param {Object} scope
     */
    subscribe: function(fn, scope, options, others) {
        this.on('change', fn, scope, options, others);
    },

    fire: function(newValue) {
        this.fireEvent('change', newValue);
    },

    destroy: function() {
        this.clearListeners();
        this.set = Ext.emptyFn;
        this.get = Ext.emptyFn;
    }
});
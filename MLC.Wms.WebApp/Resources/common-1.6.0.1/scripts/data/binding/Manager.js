/**
 * Позволяет временно устанавливать текущий контекст data binding-а. 
 */
Ext.define('WebClient.common.data.binding.Manager', {
    requires: [
        'WebClient.common.data.binding.Context'
    ],

    singleton: true,

    /**
     * @private
     * @type WebClient.common.data.binding.Context 
     */
    currentContext: undefined,


    /**
     * Вызывает переданную функцию внутри которой переданный контекст data binding-а доступен как текущий (доступен через метод {@link #getCurrentContext})  
     * --------------
     * ЗАМЕЧАНИЕ: Пока не поддерживается иерархический вызов медода (стэк вызовов). Если понадобится, 
     * переменную "текущий контекст" можно заменить на стэк. 
     * @param {WebClient.common.data.binding.Context} bindingContext
     * @param {Function} fn
     * @param {Object} fnScope optional
     */
    plunge: function(bindingContext, fn, fnScope) {
        Assert.notEmpty(bindingContext, 'bindingContext');
        Assert.notEmpty(fn, 'fn');

        try {
            this.currentContext = bindingContext;
            fn.call(fnScope || window);
        } finally {
            this.currentContext = undefined;
        }
    },

    /**
     * @private 
     * @return {WebClient.common.data.binding.Context}
     */
    getCurrentContext: function() {
        if (!this.currentContext)
            Ext.Error.raise('Текущий контекст data binding-а не определен. Возможно, текущий код работает не внутри стэка метода plunge');
        return this.currentContext;
    },

    /**
     * Достает store по имени структуры в текущем контексте data binding-а.
     * @param {String} structureName
     * @return {Ext.data.Store}
     */
    takeStore: function(structureName) {
        return this.getCurrentContext().getDataContext().takeStore(structureName);
    },

    /**
     * Достает Ext.data.Model по имени структуры в текущем контексте data binding-а.
     * @param {String} structureName
     * @return {Ext.data.Store}
     */
    getStructure: function(structureName) {
        return this.getCurrentContext().getDataContextModel().getStructure(structureName);
    }

});
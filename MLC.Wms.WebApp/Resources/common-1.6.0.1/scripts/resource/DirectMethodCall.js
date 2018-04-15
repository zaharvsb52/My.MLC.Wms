/**
 * Этот ресурс позволяет вызвать Direct функцию и получить результат ее выполнения
 */
Ext.define('WebClient.common.resource.DirectMethodCall', {
    extend: 'WebClient.common.resource.Resource',

    extDirectFn: undefined,

    args: undefined,

    /**
     * 
     * @param {Function} extDirectFn Direct-функция для вызова
     * @param {Object} args Хеш-массив параметров вызова direct-функции
     */
    constructor: function(extDirectFn, args) {
        Assert.isTrue(Ext.isFunction(extDirectFn), 'Ext.isFunction(extDirectFn)');
        this.extDirectFn = extDirectFn;
        this.args = args;
    },

    require: function(resourceLoadingSession) {
        if (!Ext.isDefined(this.v))
            resourceLoadingSession.addResource(this);
    },

    load: function(callback, callbackScope) {
        var me = this;
        this.extDirectFn(this.args || {}, function(result, event, success) {
            me.v = result;
            Ext.callback(callback, callbackScope, [me]);
        });
    }
});
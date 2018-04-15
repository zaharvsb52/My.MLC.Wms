/**
 * Этот ресурс представляет результат отложенного вызова функции. Функция вызовется только один раз в момент получения значения ресурса.
 */
Ext.define('WebClient.common.resource.PostponedCall', {
    extend: 'WebClient.common.resource.Resource',

    fn: undefined,

    scope: undefined,

    args: undefined,

    constructor: function(fn, scope, args) {
        Assert.isTrue(Ext.isFunction(fn), 'Ext.isFunction(fn)');
        this.fn = fn;
        this.scope = scope;
        this.args = args;
    },

    value: function() {
        if (!Ext.isDefined(this.v))
            this.v = this.fn.apply(this.scope || window, this.args || []);
        return this.v;
    }
});
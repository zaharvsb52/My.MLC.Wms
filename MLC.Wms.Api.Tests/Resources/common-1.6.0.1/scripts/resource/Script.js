/**
 * Этот ресурс представляет js-сценарий, загружаемый по требованию.
 */
Ext.define('WebClient.common.resource.Script', {
    extend: 'WebClient.common.resource.Resource',

    url: undefined,

    constructor: function(url) {
        Assert.notEmpty(url);
        this.id = url;
        this.url = url;
    },

    require: function(resourceLoadingSession) {
        if (!Ext.isDefined(this.v))
            resourceLoadingSession.addResource(this);
    },

    load: function(callback, callbackScope) {
        var me = this;
        Ext.Loader.loadScript({
            url: me.url,
            onLoad: function() {
                me.v = true;
                Ext.callback(callback, callbackScope, [me]);
            }
        });
    }
});
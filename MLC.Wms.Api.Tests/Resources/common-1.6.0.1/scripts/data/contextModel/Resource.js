Ext.define('WebClient.common.data.contextModel.Resource', {
    extend: 'WebClient.common.resource.Resource',

    /**
     * @private
     * @type String
     */
    modelName: undefined,

    /**
     * @private
     * loader будет использоваться для загрузки модели с сервера
     * @type {WebClient.common.data.contextModel.Loader}
     */
    loader: undefined,

    /**
     * @private
     * @type WebClient.common.data.contextModel.Provider 
     */
    provider: undefined,

    require: function(resourceLoadingSession) {
        this.v = this.provider.tryGetCachedModel(this.modelName);
        if (!this.v)
            resourceLoadingSession.addResource(this);
    },

    load: function(callback, callbackScope) {
        var me = this;
        this.provider.getAsync(this.modelName, this.loader, function(model) {
            me.v = model;
            Ext.callback(callback, callbackScope, [me]);
        });
    }
});
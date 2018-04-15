/**
 * Провайдер дата-контекст моделей. Запрашивает их с сервера и кэширует, идентифицируя по имени.
 * Также, предоставляет метод создания "ресурса" (см. {@link WebClient.common.resource.Resource}),
 * который будет предоставлять модель через этот провайдер.
 */
Ext.define('WebClient.common.data.contextModel.Provider', {
    requires: [
        'WebClient.common.data.contextModel.Loader',
        'WebClient.common.data.contextModel.Resource'
    ],


    singleton: true,

    /**
     * Cahce of models, keyed by name
     * @private
     * @type Ext.util.MixedCollection
     */
    items: undefined,


    constructor: function(config) {
        Ext.apply(this, config);

        this.items = new Ext.util.MixedCollection(false, function(dcModel) { return dcModel.name; });
    },

    /**
     * Возвращает контект-модель из кэша, или активи 
     * @param {String} modelName
     * @param {WebClient.common.data.contextModel.Loader} loader
     * @param {Function} callback function(model) - вызывается, когда модель загружена
     */
    getAsync: function(modelName, loader, callback) {
        if (!this.tryGetCachedModel(modelName))
            loader.load(modelName, Ext.pass(this.onGetAsyncResult, [callback], this));
    },

    /**
     * @private
     */
    onGetAsyncResult: function(callback, model) {
        this.addOrReplaceModelToCache(model);
        callback(model);
    },

    /**
     * Возвращает {@link WebClient.common.data.contextModel.Resource ресурс} на требуемую модель {@link WebClient.common.data.contextModel.Model}. 
     * Если модель еще не загружена в память, то переданный loader будет использоваться для загрузки её с сервера
     * @param {String} modelName
     * @param {WebClient.common.data.contextModel.Loader} loader
     * @return {WebClient.common.data.contextModel.Resource}
     */
    getResource: function(modelName, loader) {
        return new WebClient.common.data.contextModel.Resource({
            id: 'DataContextModel:' + modelName,
            modelName: modelName,
            loader: loader,
            provider: this
        });
    },

    /**
     * @param {WebClient.common.data.contextModel} model
     */
    addModelToCache: function(model) {
        Assert.notEmpty(model);
        Assert.notEmpty(model.name);

        if (this.items.containsKey(model.name))
            Ext.Error.raise('DataContextModel с указанным именем уже добавлена в cache. Name:' + model.name);

        this.items.add(model);
    },

    /**
     * @param {WebClient.common.data.contextModel} model
     */
    addOrReplaceModelToCache: function(model) {
        this.items.add(model);
    },


    tryGetCachedModel: function(modelName) {
        return this.items.getByKey(modelName);
    },

    getCachedModel: function(modelName) {
        var ret = this.items.getByKey(modelName);
        if (!ret)
            Ext.Error.raise('DataContextModel с указанным именем не существует в cache. Name:' + modelName);

        return ret;
    }
});
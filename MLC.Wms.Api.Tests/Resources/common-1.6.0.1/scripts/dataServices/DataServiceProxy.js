/**
 * 
 */
Ext.define('WebClient.common.dataServices.DataServiceProxy', {
    requires: [
        'WebClient.common.data.contextModel.Provider',
        'WebClient.common.data.contextModel.Loader',
        'WebClient.common.data.DataContext',
        'WebClient.common.data.DataContextModelStoreFactory',
        'WebClient.common.dataServices.DataContextModelBuilder'
    ],

    statics: {
        DEFAULT_GET_MODEL_METHOD_NAME: 'getMetadata'
    },

    /**
     * Имя серверного метода, через которые будут читаться данные о контекстной модели. Опционально, по-умолчанию равно {@link #DEFAULT_GET_MODEL_METHOD_NAME}
     * {@link WebClient.common.data.contextModel.Model}   
     * @type String
     */
    getModelMethodName: undefined,

    /**
     * Объект, содержащий параметры к серверному методу указанному в {@link #getModelMethodName} 
     * @type {Object} 
     */
    getModelMethodParameters: undefined,

    /**
     * Имя Ext.direct Action - набора серверных методов доступа к данным и метаданным
     * @type {String} 
     */
    actionName: undefined,

    /**
     * Имя {@link WebClient.common.data.contextModel.Model#name} которое используется для кэширования. Опционально, по-умолчанию равно {@link #actionName}
     * модели
     * @type String 
     */
    modelName: undefined,

    /**
     * Переопределение конфигурация структур загружаемых с сервера. См. {@link WebClient.common.data.contextModel.Builder#structureConfigs}
     * @type {Object} 
     */
    structureConfigs: undefined,

    /**
     * Переопределение конфигурация {@link Ext.data.Store} store-ов создаваемых по структурам. См. {@link WebClient.common.data.DataContextModelStoreFactory#storeConfigs}
     * @type {Object} 
     */
    storeConfigs: undefined,

    /**
     * Ext.direct Action - набор серверных методов доступа к данным и метаданным
     * @private
     * @type {Object} 
     */
    serverMethods: undefined,

    constructor: function(config) {
        Ext.apply(this, config);
        Assert.notEmpty(this.actionName, 'ExtDirect Action name passed to DataServiceProxy');

        this.serverMethods = WebClient.getByPath(Server, this.actionName);
        if (!this.serverMethods)
            Ext.Error.raise('В DataServiceProxy было передано имя несуществующего серверного класса. actionName:' + this.actionName);

        if (!this.modelName)
            this.modelName = this.actionName;

        if (!this.getModelMethodName)
            this.getModelMethodName = this.self.DEFAULT_GET_MODEL_METHOD_NAME;

        if (!this.serverMethods[this.getModelMethodName])
            Ext.Error.raise('В DataServiceProxy было передано имя несуществующего метода серверного класса, либо имя по-умолчанию указывает на несуществующий метод. actionName:' + this.actionName + '. getModelMethodName:' + this.getModelMethodName);
    },

    /**
     * Возвращает ресурс на модель (DataContextModel), которая будет читаться с дата сервиса на сервере, или браться из кэша
     * @return {WebClient.common.data.contextModel.Resource}
     */
    createDataContextModelResource: function() {
        return WebClient.common.data.contextModel.Provider.getResource(
            //имя загружаемой модели, для кэширования 
            this.modelName,
            //instance loader-а, который будет загружать и создавать ресурс
            new WebClient.common.data.contextModel.Loader({
                // через какой серверный метод loader будет запрашивать json модели
                serverMethod: this.serverMethods[this.getModelMethodName],
                serverMethodParameters: this.getModelMethodParameters,
                builder: new WebClient.common.dataServices.DataContextModelBuilder(this.serverMethods),
                structureConfigs: this.structureConfigs
            })
        );
    },

    /**
     * Возвращает {@link WebClient.common.data.DataContext}, мета информация которая будет читаться с дата сервиса на сервере, или браться из кэша
     * @return {WebClient.common.data.DataContext}
     */
    createDataContext: function() {
        return new WebClient.common.data.DataContext({
            storeFactory: new WebClient.common.data.DataContextModelStoreFactory(
                this.createDataContextModelResource(),
                this.storeConfigs
            )
        });
    },

    /**
     * Возвращает серверный метод дата сервиса, который будет принимать изменения DataContext-а (в виде {@link WebClient.common.data.change.Set}).
     * Кидает ошибку, если мета информация еще не загружена с сервера, или если сервер не определил имя этого метода 
     * @return {Function}
     */
    getCommitMethod: function() {
        var m = this.getCachedDataContextModel();
        if (!m.commitMethod)
            Ext.Error.raise('Дата сервис не указал в DataContextModel имя commitMethod-а. Дата сервис:' + this.actionName);
        var ret = this.serverMethods[m.commitMethod];
        if (!ret)
            Ext.Error.raise('Дата сервис указал в DataContextModel имя commitMethod-а которое не существует в классе дата сервиса. Дата сервис:' + this.actionName);
        return ret;
    },

    /**
     * @private
     * @return {WebClient.common.data.contextModel.Model}
     */
    getCachedDataContextModel: function() {
        var ret = WebClient.common.data.contextModel.Provider.tryGetCachedModel(this.modelName);
        if (!ret)
            Ext.Error.raise('DataContext модель еще не была загружена с сервера. Имя модели: ' + this.modelName + '. Дата сервис:' + this.actionName);
        return ret;
    }
});
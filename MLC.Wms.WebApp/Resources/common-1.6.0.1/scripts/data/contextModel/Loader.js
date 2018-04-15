Ext.define('WebClient.common.data.contextModel.Loader', {
    requires: [
        'WebClient.common.data.contextModel.Builder',
        'WebClient.common.ExtDirectHelper'
    ],

    /**
     * ExtDirect метод возвращаемый данные для генерации data context model 
     * @type Function 
     */
    serverMethod: undefined,

    /**
     * Параметры к вызову серверного метода. Опционально.
     * @type Object 
     */
    serverMethodParameters: undefined,

    /**
     * Билдер, который обработает ответ с сервера и создаст инстанс модели.
     * Опционально. Если не передано, используется стандартный билдер.
     * @type WebClient.common.data.contextModel.Builder 
     */
    builder: undefined,

    /**
     * Переопределение конфигурация структур, передаваемое билдеру. См. {@link WebClient.common.data.contextModel.Builder#structureConfigs}
     * @type {Object} 
     */
    structureConfigs: undefined,

    /**
     * Перехватчик ошибок. Если не указан, то срабатывает стандартный handler
     * @type Function 
     */
    onError: undefined,


    constructor: function(config) {
        Ext.apply(this, config);

        if (!this.serverMethod)
            Ext.Error.raise('В loader DataContextModel-и передан пустой объект вместо серверного метода, используемого для чтения модели');

        if (!this.builder)
            this.builder = new WebClient.common.data.contextModel.Builder();
    },


    /**
     * Активирует загрузку модели с сервера
     * @param {Function} callback function(model)
     */
    load: function(modelName, callback) {
        this.serverMethod(this.serverMethodParameters, Ext.pass(this.onLoad, [modelName, callback], this));
    },


    onLoad: function(modelName, callback, result, event) {
        if (WebClient.common.ExtDirectHelper.responseOk(event, this)) //uses onError
        {
            var model = this.createModel(modelName, result);
            callback(model);
        }
    },

    createModel: function(modelName, result) {
        return this.builder.build(modelName, result, this.structureConfigs);
    }
});
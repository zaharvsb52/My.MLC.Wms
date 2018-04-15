/**
 * Класс, умеющий читать данные для DataContex-а с сервера, и писать изменения на сервер 
 */
Ext.define('WebClient.common.data.DataContextProxy', {
    mixins: {
        observable: 'Ext.util.Observable'
    },

    requires: [
        'WebClient.common.ExtDirectHelper'
    ],

    /**
     * Перехватчик ошибок. Если не указан, то срабатывает стандартный handler
     * @type {Function} function({Ext.direct.Event}, requestOptions)
     */
    onError: undefined,

    /**
     * Происходит ли сейчас запрос на сервер 
     * @type Boolean
     */
    loading: false,

    statics: {
        /**
         * Это константа - название свойства в json объекте (в чтении или сохранении) содержащее данные для store-ов.
         * Пример: <code>
            {
                tables: {
                    SalesOrder: { //название root-level store в data context-е
                        total: 10000,
                        data: [
                            { Id:102, Name:"Order102", Lines: [ //заказ с линиями
                                    { Id:1, ProductId:545, Quantity:0.0}
                                    { Id:2, ProductId:546, Quantity:1.0}
                                ]
                            },
                            { Id:103
                        ]
                    },
                    Comment: {
                        total: 100000,
                        data: []
                    }
                }
            }</code>     
         * @type String
         */
        tablesRoot: 'tables',

        /**
         * Название параметра серверного метода для commit-а, в который будет передаваться changeSet
         * @type String
         */
        changeSetParameterNameInCommitMethod: 'jsChangeSet'
    },

    //    /**
    //     * 
    //     * @type WebClient.common.data.Dataset 
    //     */
    //    : undefined,

    constructor: function(config) {
        Ext.apply(this, config);
        this.mixins.observable.constructor.apply(this, arguments);
    },

    /**
     * Происходит ли сейчас запрос на сервер
     * @return {Boolean}
     */
    isLoading: function() {
        return this.loading;
    },

    /**
     * @param {Object} params Дополнительные параметры к серверному методу
     */
    commit: function(changeSet, serverMethod, params, callback, scope) {
        var requestOptions = {
            data: params || {},
            callback: callback,
            scope: scope
        };

        requestOptions.data[this.self.changeSetParameterNameInCommitMethod] = changeSet;

        this.invoke(serverMethod, requestOptions, this.createCommitCallback(requestOptions));
    },

    load: function(dataContext, serverMethod, params, callback, scope) {
        var requestOptions = {
            dataContext: dataContext,
            data: params,
            callback: callback,
            scope: scope
        };

        this.invoke(serverMethod, requestOptions, this.createLoadCallback(requestOptions));
    },

    createFillDataContextWithCommitResultCallback: function(dataContext) {
        var me = this;
        return function(result, event, requestOptions) {
            me.fillDataContext(dataContext, result, requestOptions);
        };
    },

    getStructureNameByTableName: function(tableName) {
        return Ext.String.capitalize(tableName);
    },

    /**
     * Загружает полученные с сервера JSON данные (сырой объект) (result) в DataContext
     * @param dataContext {WebClient.common.data.DataContext}
     */
    fillDataContext: function(dataContext, result, requestOptions) {
        var tablesData = result ? result[WebClient.common.data.DataContextProxy.tablesRoot] : undefined;
        if (!tablesData) {
            Ext.Error.raise({
                msg: 'Метод сервера не вернул ожидаемых данных для data context-а. Ожидался объект {"' + WebClient.common.data.DataContextProxy.tablesRoot + '": {...}}',
                methodInfo: requestOptions.methodInfo
            });
        }

        for (var tableName in tablesData) {
            var store = dataContext.takeStore(this.getStructureNameByTableName(tableName));
            var tableData = tablesData[tableName];

            store.loadRawData(tableData);
        }
    },

    /**
     * @private
     */
    createCommitCallback: function(requestOptions) {
        var me = this;

        return function(result, event) {
            me.processCommitResponse(result, event, requestOptions);
        };
    },

    /**
     * @private
     */
    processCommitResponse: function(result, event, requestOptions) {
        if (WebClient.common.ExtDirectHelper.responseOk(event, this, requestOptions))
            this.onCommitSuccess(result, event, requestOptions);
        this.loading = false;
        this.fireEvent('response', result, event, requestOptions);
    },

    /**
     * @private
     */
    onCommitSuccess: function(result, event, requestOptions) {
        if (typeof requestOptions.callback == 'function')
            requestOptions.callback.call(requestOptions.scope || this, result, event, requestOptions);
    },

    /**
     * @private
     */
    createLoadCallback: function(requestOptions) {
        var me = this;

        return function(result, event) {
            me.processLoadResponse(result, event, requestOptions);
        };
    },

    /**
     * @private
     */
    processLoadResponse: function(result, event, requestOptions) {
        if (WebClient.common.ExtDirectHelper.responseOk(event, this, requestOptions)) //uses onError
            this.onLoadSuccess(result, event, requestOptions);
        this.loading = false;
        this.fireEvent('response', result, event, requestOptions);
    },

    /**
     * @private
     */
    onLoadSuccess: function(result, event, requestOptions) {
        this.fillDataContext(requestOptions.dataContext, result, requestOptions);

        if (typeof requestOptions.callback == 'function')
            requestOptions.callback.call(requestOptions.scope || window, result, event, requestOptions);
    },


    /**
     * @private
     */
    invoke: function(serverMethod, requestOptions, methodCallback) {
        if (this.fireEvent('request', this, requestOptions) !== false) {
            this.loading = true;
            requestOptions.methodInfo = serverMethod.directCfg; //информация взята из Ext.direct.RemotingProvider.createHandler
            serverMethod.call(window, requestOptions.data, methodCallback);
        }
    }
});
/**
 * Этот класс наследует {@link WebClient.common.data.contextModel.Builder}, дополнительно используя
 * информацию JsDataContextModel.dataProxies, возвращаемую с сервера.
 * Создаваемые Ext.data.Model привязываются к direct proxy, причем серверный метод или класс имеют 
 * параметр\свойство "structureName", то имя структуры будет передаваться  
 */
Ext.define('WebClient.common.dataServices.DataContextModelBuilder', {
    extend: 'WebClient.common.data.contextModel.Builder',

    requires: ['WebClient.common.dataServices.ServerMethodHelper'],

    /**
     * ExtDirect Action в котором методы доступа к данным. Эти методы будут засовываться в proxy составаемых структур
     * @private
     * @type Object 
     */
    serverAction: undefined,

    /**
     * @private
     * @type Ext.util.MixedCollection
     */
    dataProxies: undefined,

    constructor: function(serverAction) {
        Assert.notEmpty(serverAction);
        this.serverAction = serverAction;
    },

    /**
     * @override
     */
    beforeBuild: function() {
        if (this.data.dataProxies && this.data.dataProxies.length > 0) {
            this.dataProxies = new Ext.util.MixedCollection(false, function(proxy) { return proxy.name; });
            this.dataProxies.addAll(this.data.dataProxies);
        }
    },

    /**
     * @override
     */
    defineStructureProxy: function(sconfig) {
        if (this.dataProxies) {
            var p = this.dataProxies.get(sconfig.name);
            if (p && p.loadMethod) {
                var m = this.serverAction[p.loadMethod];
                if (!m)
                    Ext.Error.raise('DataProxy для структуры ' + sconfig.name + ' указывает на несуществующий метод на сервере ' + p.loadMethod);

                var defaultProxyConfig = WebClient.common.dataServices.ServerMethodHelper.buildReadTableProxyConfig(m);

                //Если серверный метод или класс имеют параметр "structureName", то имя структуры будет передаваться
                defaultProxyConfig.extraParams = {
                    structureName: sconfig.name
                };

                if (sconfig.entityType) //в JsStructure.entityType указана сущность. Будем передавать это имя при вызове методов чтения
                    defaultProxyConfig.extraParams.entityType = sconfig.entityType;

                //См. JsDataProxy.pagingUnsupported на сервере
                if (p.pagingUnsupported)
                    defaultProxyConfig.pagingUnsupported = true;

                sconfig.proxy = Ext.merge(defaultProxyConfig, sconfig.proxy);
            }
        }

        this.callParent(arguments);
    }
});
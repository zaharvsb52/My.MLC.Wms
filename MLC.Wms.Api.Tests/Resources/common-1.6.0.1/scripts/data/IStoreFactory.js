Ext.define('WebClient.common.data.IStoreFactory', {
    extend: 'WebClient.common.Interface',

    /**
     * @param {String} structureName имя структуры, по которой создается store
     * @param {Object} storeConfig optional переопределение конфигурации структуры 
     * @return {Ext.data.Store}
     */
    create: function(structureName, storeConfig) {}
});
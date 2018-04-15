/**
 * Этот класс содержит удобные builder-ы разных объектов, связанных с ExtDirect server methods 
 */
Ext.define('WebClient.common.dataServices.ServerMethodHelper', {
    singleton: true,

    /**
     * Возвращает конфигурацию для Ext.data.proxy.Direct настроенную только на чтение табличных данных через переданный серверный метод.
     * Серверный метод должен возвращать объект JsTable (на сервере), в котором строки обрамлены в свойство data. 
     * @param {Function} directFn
     * @return {Object}
     */
    buildReadTableProxyConfig: function(directFn) {
        Assert.notEmpty(directFn, 'directFn');

        return {
            type: 'direct',
            directFn: directFn,
            reader: {
                type: 'json',
                rootProperty: 'data'
            }
        };
    },

    /**
     * Возвращает конфигурацию для Ext.data.proxy.Direct настроенную только на чтение одного объекта через переданный серверный метод.
     * Серверный метод должен возвращать просто DTO объект, без обрамления (в отличие от {@link #buildReadTableProxyConfig})
     * @param {Function} directFn
     * @return {Object}
     */
    buildReadObjectProxyConfig: function(directFn) {
        Assert.notEmpty(directFn, 'directFn');

        return {
            type: 'direct',
            directFn: directFn,
            reader: {
                type: 'json',
                rootProperty: null
            }
        };
    },

    /**
     * Возвращает конфигурацию для Ext.data.proxy.Proxy настроенную только на чтение из JSON объектов уже полученных с сервера 
     * @return {Object}
     */
    buildInMemoryProxyConfig: function() {
        return {
            type: 'proxy',
            reader: {
                type: 'json',
                rootProperty: 'data'
            }
        };
    },

    /**
     * Этот метод возвращает object для конфигурации record structure (Ext.data.Model) для будущей Ext.data.TreeStore. 
     * В возвращаемом объекте конфигурация proxy настроена чтение данных из поля 'children' полученного с сервера json-а.
     * Серверный метод должен возвращать данные в поле 'children' (не 'data' как обычно), данные детей каждой строки 
     * - в поле 'children' каждой строки соответсвенно и т.д.
     * @return {Object}
     */
    prepareStructureConfigForTreeStore: function(cfgToOverride) {
        return Ext.merge({
            proxy: {
                reader: {
                    rootProperty: null
                    //defaultRootProperty: 'children' - это по умолчанию
                }
            }
        }, cfgToOverride);
    }
});
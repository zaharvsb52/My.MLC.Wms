/**
 * Представляет контекст data binding-а. См. {@link WebClient.common.data.binding.Manager}
 */
Ext.define('WebClient.common.data.binding.Context', {

    /**
     * @cfg {WebClient.common.data.DataContext} dataContext
     * DataContext доступный для связывания 
     */
    dataContext: undefined,

    /**
     * @cfg {WebClient.common.data.contextModel.Model} dataContextModel
     * DataContextModel доступная для связывания 
     */
    dataContextModel: undefined,

    constructor: function(cfg) {
        Ext.apply(this, cfg);
    },

    /**
     * @inner
     * @return {WebClient.common.data.DataContext }
     */
    getDataContext: function() {
        if (!this.dataContext)
            Ext.Error.raise('dataContext не был установлен в текущем binding context-е');
        return this.dataContext;
    },

    /**
     * @inner
     * @return {WebClient.common.data.contextModel.Model}
     */
    getDataContextModel: function() {
        if (!this.dataContextModel)
            Ext.Error.raise('dataContextModel не был установлен в текущем binding context-е');
        return this.dataContextModel;
    }

});
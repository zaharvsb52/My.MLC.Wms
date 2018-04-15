Ext.define('WebClient.common.error.DefaultHandlerProvider', {
    requires: [
        'WebClient.common.error.DefaultHandler'
    ],

    singleton: true,

    /**     
     * @type String
     * @private
     */
    appErrorHandlerClass: 'WebClient.common.error.DefaultHandler',

    /**
     * 
     * @private 
     */
    appErrorHandler: undefined,

    registerErrorHandler: function(className) {
        Ext.require(className);
        this.appErrorHandlerClass = className;
        delete this.appErrorHandler;
    },

    getErrorHandler: function() {
        var me = this;
        if (!me.appErrorHandler)
            me.appErrorHandler = Ext.create(me.appErrorHandlerClass);
        return me.appErrorHandler;
    },

    isError: function(event) {

    }
});
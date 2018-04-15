Ext.define('MLC.wms.workspace.ClosableWindowContainer', {
    extend: 'WebClient.common.workspace.WindowContainer',

    mixins: {
        //interfaces
        'MLC.wms.workspace.IClosable': 'MLC.wms.workspace.IClosable'
    },

    requires: [
        'WebClient.common.Site'
    ],

    closeCallback: undefined,

    /**
     * НАЧАЛО: Реализация интерфейса MLC.wms.workspace.IClosable
     * --------------------------------------------------
     */

    registerCloseCallback: function (callback, scope) {
        this.closeCallback.push(Ext.Function.bind(callback, scope));
    },

    /**
     * --------------------------------------------------
     * КОНЕЦ: Реализация интерфейса MLC.wms.workspace.IClosable
     */

    constructor: function (cfg) {
        this.callParent(arguments);
        this.closeCallback = [];
    },

    putView: function (view) {
        var me = this;
        me.callParent(arguments);

        var windowSite = WebClient.common.Site.asSite(me.window);
        var containerSite = WebClient.common.Site.asSite(me);
        windowSite.bindToSite(containerSite);

        me.window.on('beforeclose', me.onBeforeclose, me);
    },

    onBeforeclose: function (panel, eOpts) {
        for (var i = 0; i < this.closeCallback.length; i++) {
            var res = this.closeCallback[i]();
            if (!res) {
                return false;
            }
        }
        return true;
    }
});
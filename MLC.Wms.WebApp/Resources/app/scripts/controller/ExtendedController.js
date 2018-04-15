Ext.define('MLC.wms.controller.ExtendedController', {
    extend: 'WebClient.common.controller.Controller',

    beginWait: function (msg) {
        var me = this;
        if (me.view != null) {
            if (msg == null)
                msg = "Выполняется...";
            me.view.mask(msg, "x-mask-loading");
        }
    },

    endWait: function () {
        var me = this;
        if (me.view != null) {
            me.view.unmask();
        }
    }
})
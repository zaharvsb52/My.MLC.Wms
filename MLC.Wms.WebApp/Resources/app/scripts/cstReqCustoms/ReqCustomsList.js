Ext.define('MLC.wms.cstReqCustoms.ReqCustomsList', {
    extend: 'WebClient.common.controls.EntityGridWithFilter',

    /**
     * override
     */
    getTbarItems: function (config) {
        var me = this;
        var res = me.callParent();
        res = res.filter(function (item) { return item.itemId === 'destroyentity'; });
        return res;
    }
});
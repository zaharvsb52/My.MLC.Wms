Ext.define('MLC.wms.yInternalTraffic.Monitor.InternalTrafficList', {
    extend: 'WebClient.common.controls.EntityGridWithFilter',

    /**
     * override
     */
    getTbarItems: function (config) {
        var me = this;
        var res = me.callParent();
        // монитор только на просмотр => оставляем на панели только кнопку "Фильтр"
        res = res.filter(function (item) { return item.itemId === 'openfilter'; });
        return res;
    }
});

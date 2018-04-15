Ext.define('MLC.wms.wmsWorker.WorkerList', {
    extend: 'WebClient.common.controls.EntityGridWithFilter',

    /**
     * override
     */
    getTbarItems: function (config) {
        var me = this;
        var res = me.callParent();
        res.push(
            {
                xtype: 'button',
                itemId: 'btnPinCreate',
                glyph: 0xf0f6,
                text: 'Задать PIN'
            }
        );

        return res;
    }
});
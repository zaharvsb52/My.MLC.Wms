Ext.define('MLC.wms.wf.common.MessageBoxLargeText', {
    extend: 'MLC.wf.controls.Card',

    constructor: function (cfg) {
        var defaultCfg = {
            items: [
                {
                    name: 'Message',
                    xtype: 'displayfield',
                    fieldCls: 'big-field',
                    width: 490
                }
            ]
        };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
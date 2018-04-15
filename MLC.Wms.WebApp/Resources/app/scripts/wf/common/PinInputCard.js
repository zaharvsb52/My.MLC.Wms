Ext.define('MLC.wms.wf.common.PinInputCard', {
    extend: 'MLC.wf.controls.Card',

    constructor: function(cfg) {
        var defaultCfg = {
                items: [
                    {
                        name: 'PIN',
                        inputType: 'password',
                        labelCls: 'big-field',
                        fieldCls: 'big-field'
                    }
                ]
            };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
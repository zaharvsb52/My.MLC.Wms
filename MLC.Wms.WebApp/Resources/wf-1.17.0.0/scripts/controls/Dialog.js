Ext.define('MLC.wf.controls.Dialog', {

    extend: 'Ext.form.Panel',

    constructor: function (cfg) {
       
        var defaultCfg = {
            layout: 'fit',
            autoScroll: true,
            items: {
                xtype: 'textarea',
                readOnly: true,
                grow: true,
                name: 'Message'
            }
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);
    }

});
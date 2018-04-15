Ext.define('MLC.wf.controls.Print', {
    extend: 'Ext.form.Panel',

    url: undefined,

    constructor: function (config) {
        var c = 81 / 100; // minime ругается на decimal 0.81
        var defaultCfg = {
            layout: 'fit',
            autoScroll: true,
            height: Ext.getBody().getViewSize().height * c,
            title: 'Печать',
            items: [
                {
                    xtype: 'panel',
                    html: '<iframe src="' + config.url + '" width="100%" height="100%" frameborder="0"></iframe>'
                }
            ]
        };
        config = Ext.Object.merge(defaultCfg, config);
        this.callParent([config]);
    }
});
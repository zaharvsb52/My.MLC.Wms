Ext.define('MLC.wms.yExternalTraffic.wf.VehiclePassView', {
    extend: 'Ext.panel.Panel',

    constructor: function(config) {

        var defaultConfig =
        {
            bodyPadding: 5,
            height: 500,
            width: 1200,
            layout: {
                type: 'hbox',
                align: 'stretch'
            },
            items: [
                {
                    itemId: 'passList',
                    xtype: 'panel',
                    layout: 'fit',
                    flex: 1
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
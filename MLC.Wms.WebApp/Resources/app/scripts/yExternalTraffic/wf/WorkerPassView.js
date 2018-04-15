Ext.define('MLC.wms.yExternalTraffic.wf.WorkerPassView', {
    extend: 'Ext.panel.Panel',
    
    constructor: function(config) {

        var defaultConfig =
        {
            bodyPadding: 5,
            height: 500,
            width: 1300,
            layout: {
                type: 'hbox',
                align: 'stretch'
            },
            items: [
                {
                    itemId: 'passList',
                    xtype: 'panel',
                    layout: 'fit',
                    flex: 1.62
                },
                { xtype: 'splitter' },
                {
                    itemId: 'workerCard',
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
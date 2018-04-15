Ext.define('MLC.wms.yInternalTraffic.InternalTrafficCard', {
    extend: 'WebClient.common.controls.AutoCard',

    constructor: function (config) {

        var defaultConfig =
        {
            bodyPadding: 7,
            layout: 'anchor',
            defaults: {
                anchor: '100%'
            },
            width: 700,
            items: [
                {
                    xtype: 'panel',
                    region: 'north',
                    cls: 'graybg',
                    items: [
                        {
                            height: 50,
                            xtype: 'toolbar',
                            itemId: 'commandToolbar'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    region: 'center',
                    bodyPadding: 7,
                    layout: 'anchor',
                    defaults: {
                        anchor: '100%'
                    },
                    items: [
                        { name: 'InternalTrafficID' },
                        { name: 'ExternalTraffic' },
                        { itemId: 'status', name: 'Status' },
                        { name: 'Partner' },
                        { name: 'PurposeVisit' },
                        { itemId: 'warehouse', name: 'Warehouse' },
                        { itemId: 'gate', name: 'Gate' },
                        { name: 'InternalTrafficFactArrived' },
                        { name: 'InternalTrafficFactDeparted' },
                        { name: 'InternalTrafficOrder' }
                    ]
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
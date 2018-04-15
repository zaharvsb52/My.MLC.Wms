Ext.define('MLC.wms.wmsWorker.WorkerPinCard', {
    extend: 'MLC.wf.controls.Card',

    constructor: function (config) {

        var defaultConfig =
        {
            layout: 'border',
            scrollable: false,
            width: 300,
            height: 100,
            items: [
                {
                    xtype: 'form',
                    region: 'center',
                    bodyPadding: 7,
                    layout: 'anchor',
                    defaults: {
                        anchor: '100%'
                    },
                    items: [
                        {
                            itemId: 'pinCode',
                            name: 'PIN',
                            fieldCls: 'biggiesttext',
                            labelWidth: 30
                        }
                    ]
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
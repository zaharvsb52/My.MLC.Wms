Ext.define('MLC.wms.yExternalTraffic.create.NewCarDriverCard', {
    extend: 'MLC.wf.controls.Card',

    constructor: function(config) {

        var defaultConfig =
        {
            layout: 'border',
            height: 240,
            width: 600,
            title: 'Новый водитель',
            items: [
                {
                    xtype: 'form',
                    region: 'center',
                    layout: 'fit',
                    itemId: 'fieldsPanel',
                    items: [
                        {
                            xtype: 'panel',
                            layout:
                            {
                                type: 'hbox',
                                align: 'stretch'
                            },
                            defaults: {
                                padding: '3 3 0 10',
                                labelWidth: 70
                            },
                            items: [
                                {
                                    xtype: 'panel',
                                    layout:
                                    {
                                        type: 'vbox',
                                        align: 'stretch'
                                    },
                                    defaults: {
                                        padding: '3 3 0 10',
                                        labelWidth: 70
                                    },
                                    items: [
                                        {
                                            name: 'WorkerLastName'
                                        },
                                        {
                                            name: 'WorkerName'
                                        },
                                        {
                                            name: 'WorkerMiddleName'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'MLC.wms.controls.ImageField',
                                    name: 'WorkerPhoto',
                                    fieldLabel: ''
                                }
                            ]
                        }
                    ]
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
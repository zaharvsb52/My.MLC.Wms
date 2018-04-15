Ext.define('MLC.wms.yExternalTraffic.wf.WorkerCardView', {
    extend: 'WebClient.common.controls.AutoCard',

    requires: [
        'WebClient.common.ComponentConfigEnricher',
        'MLC.wms.controls.ImageField',
        'MLC.wms.controls.PhoneText'
    ],

    constructor: function (config) {
        var defaultConfig =
        {
            xtype: 'panel',
            layout: {
                type: 'vbox',
                align: 'stretch'
            },
            items: [
                {
                    xtype: 'panel',
                    scrollable: true,
                    flex: 1,
                    layout: {
                        type: 'hbox',
                        align: 'stretch'
                    },
                    defaults: {
                        padding: '10 0 0 10'
                    },
                    items: [
                        {
                            xtype: 'panel',
                            scrollable: true,
                            margin: '0 10 0 0',
                            flex: 3,
                            layout: {
                                type: 'vbox',
                                align: 'stretch'
                            },
                            defaults: {
                                labelWidth: 80
                            },
                            items: [
                                { labelAlign: 'top', name: 'WorkerLastName' },
                                { labelAlign: 'top', name: 'WorkerName' },
                                { labelAlign: 'top', name: 'WorkerMiddleName' },
                                { labelWidth: 80, name: 'WorkerEmployee' },
                                { labelAlign: 'top', name: 'WorkerPhoneWork', xtype: 'phonefield' },
                                { labelAlign: 'top', name: 'WorkerPhoneMobile', xtype: 'phonefield' },
                                //{ labelAlign: 'top', name: 'WorkerEmailWork' },
                                //{ labelAlign: 'top', name: 'WorkerEmailPersonal' },
                                { labelWidth: 80, name: 'WorkerBirthday' }
                            ]
                        },
                        {
                            xtype: 'panel',
                            scrollable: true,
                            layout: {
                                type: 'vbox',
                                align: 'stretch'
                            },
                            items: [
                                {
                                    xtype: 'MLC.wms.controls.ImageField',
                                    name: 'WorkerPhoto',
                                    padding: '10 10 0 5',
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
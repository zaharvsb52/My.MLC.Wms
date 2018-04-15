Ext.define('MLC.wms.wmsWorker.WorkerCard', {
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
                                labelWidth: 130
                            },
                            items: [
                                { name: 'VSecurityCheckPassed' },
                                { name: 'WorkerLastName' },
                                { name: 'WorkerName' },
                                { name: 'WorkerMiddleName' },
                                { name: 'WorkerEmployee' },
                                { name: 'WorkerPhoneWork', xtype: 'phonefield' },
                                { name: 'WorkerPhoneMobile', xtype: 'phonefield' },
                                { name: 'WorkerEmailWork' },
                                { name: 'WorkerEmailPersonal' },
                                { name: 'WorkerBirthday' },
                                { name: 'WorkerResidenceAddr' }
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
                }//,
                //{ xtype: 'splitter' },
                //{
                //    region: 'south',
                //    flex: 1,
                //    xtype: 'WebClient.common.controls.EntityGridWithFilter',
                //    title: 'Адреса',
                //    layout: 'fit',
                //    structureName: 'WmsAddressBookList',
                //    gridConfig: { 
                //        editOnDblClick: true, 
                //        tbar: { 
                //            items: WebClient.common.controls.CrudEntityGrid.getTbarItems(null).filter(function (item) { return item.itemId == 'editentity'; })
                //        } 
                //    }
                //}
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
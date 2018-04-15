Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateCardDocStep', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'MLC.wms.controls.PhoneText',
        'MLC.wms.controls.ImageField',
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(cfg) {
        var me = this,
            defaultCfg = {
                xtype: 'panel',
                title: 'Водитель',
                layout: 'hbox',
                padding: 5,
                items: [
                    {
                        xtype: 'panel',
                        flex: 1,
                        layout: 'auto',
                        margin: '5px 0 5px 0',
                        defaults: {
                            width: '100%'
                        },
                        items: [
                            //{
                            //    name: 'WorkerPass', fieldLabel: 'Документ', emptyText: 'Введите серию и номер документа', labelWidth: 120,
                            //    forceSelection: false,
                            //    itemId: 'trafficDriverLookUp'
                            //},
                            { name: 'WorkerPass_WorkerPassSeries__WorkerPassNumber', plugins: ['converttolat'], fieldLabel: 'Серия и номер', labelWidth: 120 },
                            { name: 'WorkerPass_WorkerPassType', fieldLabel: 'Тип док-та', labelWidth: 120 },
                            { name: 'WorkerPass_Worker_WorkerLastName__WorkerName__WorkerMiddleName', fieldLabel: 'ФИО', labelWidth: 120 },
                            { name: 'ExternalTrafficDriver_WorkerPhoneMobile', fieldLabel: 'Телефон', labelWidth: 120, xtype: 'phonefield' },
                            {
                                xtype: 'textarea',
                                fieldLabel: 'Адрес регистрации',
                                height: 135,
                                labelWidth: 120,
                                name: 'ExternalTrafficDriver_WorkerResidenceAddr',
                                enableKeyEvents: true,
                                listeners: {
                                    keypress: function(field, e, eOpts) {
                                        if (e.getKey() == e.ENTER) {
                                            e.stopEvent();
                                            me.fireEvent('enterToVehicleRn', me);
                                        }
                                    }
                                }
                            }
                        ]
                    },
                    {
                        layout: 'vbox',
                        xtype: 'panel',
                        items: [
                            {
                                width: 200,
                                height: 200,
                                xtype: 'MLC.wms.controls.ImageField',
                                name: 'ExternalTrafficDriver_WorkerPhoto',
                                hideLabel: true,
                                margin: '0 0 5 5'
                            },
                            { name: 'ExternalTrafficDriver_WorkerProcPersData', itemId: 'ProcData', labelAlign: 'top', fieldLabel: 'Согласие обработки данных', labelWidth: 60, margin: '0 0 5 5' }
                        ]
                    }
                ]
            };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
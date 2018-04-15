Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateCardVehStep', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(cfg) {
        var defaultCfg = {
                xtype: 'panel',
                title: 'ТС',
                layout: { type: 'hbox', align: 'stretch' },
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
                            { name: 'Vehicle_VehicleRN', plugins: ['converttolat'], fieldLabel: '№ ТС', labelWidth: 120 },
                            { name: 'ExternalTrafficTrailerRN', plugins: ['converttolat'], fieldLabel: '№ Прицепа', labelWidth: 120 },
                            { name: 'Vehicle_VehicleVIN', fieldLabel: 'VIN TC', labelWidth: 120 },
                            { name: 'Vehicle_CarType_CarTypeMark', fieldLabel: 'Марка', labelWidth: 120 },
                            { name: 'Vehicle_VehicleOwner', fieldLabel: 'Владелец', labelWidth: 120 },
                            { name: 'Vehicle_VehicleOwnerAddr', fieldLabel: 'Адрес владельца', labelWidth: 120 }
                        ]
                    }
                ]
            };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
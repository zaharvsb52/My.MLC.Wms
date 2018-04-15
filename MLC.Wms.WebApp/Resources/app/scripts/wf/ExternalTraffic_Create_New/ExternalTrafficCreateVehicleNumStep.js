Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateVehicleNumStep', {
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
                        { name: 'Vehicle', fieldLable: 'ТС', forceSelection: false, itemId: 'vehicleLookUp', emptyText: 'Введите номер ТС', labelWidth: 120 },
                        { name: 'CustomVehNum', itemId: 'customVehNum', hidden: true }
                    ]
                }
            ]
        };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
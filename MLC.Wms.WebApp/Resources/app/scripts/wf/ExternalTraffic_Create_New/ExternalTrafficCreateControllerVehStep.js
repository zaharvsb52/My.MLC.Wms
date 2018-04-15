Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateControllerVehStep', {
    extend: 'MLC.wf.controller.Card',

    vehicleLookupAction: 'VEHICLELOOKUP',

    refs: {
        vehicleLookUp: '#vehicleLookUp',
        customVehNum: '#customVehNum'
    },

    constructor: function(cfg) {
        this.callParent(arguments);
    },

    loadData: function() {
        var me = this;
        me.callParent(arguments);

        var vehicle = me.getVehicleLookUp(),
            customVehNum = me.getCustomVehNum();

        vehicle.on('change', function() {
                var action =
                {
                    code: me.vehicleLookupAction,
                    hidden: true,
                    ignoreValidation: true,
                    type: 'wfaction'
                }
                me.handleAction(action);
        });

        vehicle.on('collapse', function() {
            if (!vehicle.value)
                customVehNum.setValue(vehicle.getRawValue());
        });
    }
});
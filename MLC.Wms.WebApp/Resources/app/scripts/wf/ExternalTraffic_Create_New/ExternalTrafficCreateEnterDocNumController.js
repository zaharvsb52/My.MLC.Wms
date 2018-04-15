Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateEnterDocNumController', {
    extend: 'MLC.wf.controller.Card',

    driverLookupAction: 'DRIVERDOC',

    refs: {
        trafficDriverLookUp: '#trafficDriverLookUp',
        customDocNum: '#customDocNum'
    },

    constructor: function (cfg) {
        this.callParent(arguments);
    },

    loadData: function () {
        var me = this;
        me.callParent(arguments);

        var driver = me.getTrafficDriverLookUp(),
            custumDNum = me.getCustomDocNum();

        driver.on('change', function () {
                var action =
                {
                    code: me.driverLookupAction,
                    hidden: true,
                    ignoreValidation: true,
                    type: 'wfaction'
                }
                me.handleAction(action);
        });

        driver.on('collapse', function () {
            if (!driver.value)
                custumDNum.setValue(driver.getRawValue());
        });
    }
});
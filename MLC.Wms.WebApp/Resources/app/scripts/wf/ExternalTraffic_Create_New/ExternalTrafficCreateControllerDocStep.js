Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateControllerDocStep', {
    extend: 'MLC.wf.controller.Card',

    //driverLookupAction: 'DRIVERDOC',

    //refs: {
    //    trafficDriverLookUp: '#trafficDriverLookUp'
    //},
    refs: {
        procData: '#ProcData'
    },

    constructor: function(cfg) {
        this.callParent(arguments);
    },

    onViewCreated: function() {
        var me = this,
            procData = me.getProcData();

        me.callParent(arguments);

        procData.on('focus', me.focusProcDataHandler, me);
    },

    focusProcDataHandler: function(pl, ctx) {
        if (pl && !pl.value) {
            pl.setValue(new Date());
        }
        pl.selectText();
    }

    //loadData: function() {
    //    var me = this;
    //    me.callParent(arguments);

    //    var driver = me.getTrafficDriverLookUp();

    //    driver.on('change', function() {

    //        var action =
    //        {
    //            code: me.driverLookupAction,
    //            hidden: true,
    //            ignoreValidation: true,
    //            type: 'wfaction'
    //        }
    //        me.handleAction(action);
    //    });
    //}
});
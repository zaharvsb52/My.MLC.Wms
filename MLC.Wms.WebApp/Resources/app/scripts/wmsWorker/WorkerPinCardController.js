Ext.define('MLC.wms.wmsWorker.WorkerPinCardController', {
    extend: 'MLC.wf.controller.Card',

    refs: {
        pinCode: '#pinCode'
    },

    /**
     * @override
     */
    onViewDisplayed: function() {
        var me = this;
        me.callParent();
        var pinCode = me.getPinCode();
        //выставляем фокус
        pinCode.focus();
    }
});
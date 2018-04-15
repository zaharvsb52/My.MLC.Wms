Ext.define('MLC.wms.wmsWorker.WorkerCardController', {
    extend: 'MLC.wms.controller.EntityCardWithWFToolbar',

    wfIdentityPinCreate: { package: 'CLIENT', code: 'PIN_CREATE', version: '1.0.0.0' },

    wfIdentityApproveDriver: { package: 'CLIENT', code: 'APPROVE_DRIVER', version: '1.0.0.0' },

    /**
     * @override
     */
    getTBarItems: function () {
        return new Array(
            new WebClient.common.commands.Command({ handler: this.pinCreate, scope: this, text: 'Задать PIN', glyph: 0xf0f6 }),
            new WebClient.common.commands.Command({ handler: this.approveDriver, scope: this, text: 'Проверка в СБ', glyph: 0xf0f6 })
            );
    },

    pinCreate: function () {
        var me = this;
        me.onWfBtnClick(me.wfIdentityPinCreate, me.getWfPinCreateInArguments, null);
    },

    approveDriver: function () {
        var me = this;
        me.onWfBtnClick(me.wfIdentityApproveDriver, me.getWfInArguments, null);
    },

    /**
     * Сбор входных параметров wf PIN_CREATE
     */
    getWfInArguments: function (source) {
        var me = source,
            entityId = me.dataParams.id.id;
        return { EntityId: entityId };
    },

    loadData: function () {
        var me = this;

        me.callParent({
            params: me.dataParams,
            scope: me,
            callback: me.loadDataCallback
        });
    },

    loadDataCallback: function (records, operation, success) {
        var me = this;
        //    me.callParent(arguments);
        //    var itemStore = me.dataContext.takeStore('WmsAddressBookList'),
        //        filter = new Ext.util.Filter({
        //            itemId: 'AddressOwner',
        //            property: 'VWorkerID',
        //            operator: WebClient.FilterOps.IN
        //        });

        //    filter.setValue([me.dataParams.id.id]);
        //    itemStore.addFilter(filter);
        //    itemStore.load();
    },

    reload: function () {
        var me = this;
    }
});
Ext.define('MLC.wms.yInternalTraffic.InternalTrafficCardController', {
    extend: 'WebClient.common.controller.EntityCard',

    mixins: {
        ctrl: 'MLC.wms.controller.ExtendedController'
    },

    requires: [
        'WebClient.common.workspace.ContainerHelper',
        'WebClient.common.commands.Command',
        'MLC.wf.workspace.WfDialogWindowContainer',
        'MLC.wf.controller.Dispatcher'
    ],

    refs: {
        commandToolbar: '#commandToolbar',
        warehouse: '#warehouse',
        gate: '#gate',
        status: '#status'
    },

    wfIdentityVisitorArrived: { package: 'CLIENT', code: 'VISITOR_ARRIVED', version: '1.0.0.0' },

    wfIdentityVisitorDeparted: { package: 'CLIENT', code: 'VISITOR_DEPARTED', version: '1.0.0.0' },

    visitorDepartedCommand: undefined,
    visitorArrivedCommand: undefined,

    /**
     * override
     */
    loadData: function () {
        var me = this;
        me.callParent(arguments);
        var warehouse = me.getWarehouse(),
            gate = me.getGate().getFilterable();

        WebClient.common.filters.FilterBinder.bind(gate, [{ source: warehouse, operator: WebClient.FilterOps.EQ, dataIndex: 'Warehouse' }]);
    },

    setNullGate: function () {
        this.getGate().setValue(null);
    },

    /**
     * override
     */
    onViewCreated: function () {
        var me = this;
        this.callParent();

        me.visitorArrivedCommand = new WebClient.common.commands.Command({ handler: this.visitorArrived, scope: this, text: 'Прибыл на склад', glyph: 0xf0d1 });
        me.visitorDepartedCommand = new WebClient.common.commands.Command({ handler: this.visitorDeparted, scope: this, text: 'Убыл со склада', glyph: 0xf08b });

        var toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar([
            me.visitorArrivedCommand,
            me.visitorDepartedCommand
        ]);
        if (toolbarCfg) {
            var tab = me.getCommandToolbar();
            tab.add(toolbarCfg);
        }

        var warehouse = me.getWarehouse();
        warehouse.on('change', Ext.Function.bind(me.setNullGate, me));

        var status = me.getStatus();
        status.on('change', Ext.Function.bind(me.disabledBtn, me));
    },

    visitorDeparted: function () {
        var me = this;
        me.onWfBtnClick(me.wfIdentityVisitorDeparted, me.getWfVisitorDepartedInArguments, null);
    },

    visitorArrived: function () {
        var me = this;
        me.onWfBtnClick(me.wfIdentityVisitorArrived, me.getWfVisitorArrivedInArguments, null);
    },

    onWfBtnClick: function (wfIdentity, collectInArgumentsCallback, wfResponseCallback) {
        var me = this;
        var container = new MLC.wf.workspace.WfDialogWindowContainer();
        var dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: wfIdentity,
            inArguments: collectInArgumentsCallback(me),
            container: container,
            listeners: {
                reload: function () {
                    me.reload();
                    me.onSave();
                },
                beginwait: function () {
                    me.beginWait();
                },
                endwait: function () {
                    me.endWait();
                }
            }
        });
        // подписываемся на окончание wf (если есть что)
        if (wfResponseCallback)
            dispatcher.on('wfResponse', wfResponseCallback);
        // запускаем wf
        dispatcher.run();
    },

    /**
     * Сбор входных параметров wf VISITOR_ARRIVED
     */
    getWfVisitorArrivedInArguments: function (source) {
        var me = source,
            entityId = me.dataParams.id.id,
            viewKind = 'CARD';
        return { EntityId: entityId, ViewKind: viewKind };
    },

    /**
     * Сбор входных параметров wf VISITOR_DEPARTED
     */
    getWfVisitorDepartedInArguments: function (source) {
        var me = source,
            entityId = me.dataParams.id.id,
            viewKind = 'CARD';
        return { EntityId: entityId, ViewKind: viewKind };
    },

    /**
    * Доступность кнопок
    */
    disabledBtn: function () {
        var me = this;

        me.visitorDepartedCommand.setDisabled(true);
        me.visitorArrivedCommand.setDisabled(true);

        var status = this.getStatus().getValue();
        if (status == null)
            return;
        
        switch (status.id) {
            case "VISITOR_ARRIVED":
                me.visitorDepartedCommand.setDisabled(false);
                break;
            case "VISITOR_PLAN":
                var statusExt = me.dataContext.takeStore('YInternalTrafficCard').getAt(0).get('ExternalTraffic_Status_StatusCode');
                if (statusExt.startsWith("CAR_ARRIVED") || statusExt.startsWith("CAR_TRANSITTERRITORY")) {
                    me.visitorArrivedCommand.setDisabled(false);
                }
                break;
        }
    }

});
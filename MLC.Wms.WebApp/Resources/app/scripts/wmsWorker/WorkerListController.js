Ext.define('MLC.wms.wmsWorker.WorkerListController', {
    extend: 'WebClient.common.controller.EntityList',

    mixins: {
        ctrl: 'MLC.wms.controller.ExtendedController'
    },

    requires: [
        //'WebClient.common.workspace.ContainerHelper',
        //'WebClient.common.commands.Command',
        'MLC.wf.workspace.WfDialogWindowContainer',
        'MLC.wf.controller.Dispatcher'
    ],

    refs: {
        btnPinCreate: '#btnPinCreate'
    },

    onViewCreated: function() {
        var me = this;
        me.callParent(arguments);

        var btnPin = me.getBtnPinCreate();
        btnPin.on('click', function() {
            var id = me.view.grid.getSelectedId().get()[0];
            if (id != null) {
                var container = new MLC.wf.workspace.WfDialogWindowContainer(),
                    dispatcher = new MLC.wf.controller.Dispatcher({
                        workflowIdentity: {
                            package: 'CLIENT',
                            code: 'PIN_CREATE',
                            version: '1.0.0.0'
                        },
						inArguments: { EntityId: id.id },
                        listeners: {
                            reload: function() {
                                me.loadData();
                            },
                            beginwait: function () {
                                me.beginWait();
                            },
                            endwait: function () {
                                me.endWait();
                            }
                        },
                        container: container
                    });
                dispatcher.run();
            }
        });
    }
});
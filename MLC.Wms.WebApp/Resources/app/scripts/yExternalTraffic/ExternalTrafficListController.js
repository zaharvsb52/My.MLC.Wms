Ext.define('MLC.wms.yExternalTraffic.ExternalTrafficListController', {
    extend: 'WebClient.common.controller.EntityList',

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
        btnCarArrived: '#btnCarArrived',
        btnCarDeparted: '#btnCarDeparted',
        btnCancel: '#btnCancel',
        btnVerify: '#btnVerify',
        btnPrint: '#btnPrint',
        btnCreateTemp: '#btnCreateTemp'
    },
    
    onViewCreated: function () {
        var me = this;
        me.callParent(arguments);

        var btnCarArrived = me.getBtnCarArrived();
        btnCarArrived.on('click', function () {
            var id = me.view.grid.getSelectedId().get()[0];

            if (!id) {
                me.showError("Выберите рейс");
                return;
            }

            var container = new MLC.wf.workspace.WfDialogWindowContainer(),
                dispatcher = new MLC.wf.controller.Dispatcher({
                    workflowIdentity: {
                        package: 'CLIENT',
                        code: 'CAR_ARRIVED',
                        version: '1.0.0.0'
                    },
					inArguments: { EntityId: id.id },
                    listeners: {
                        reload: function () {
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
        });

        var btnPrint = me.getBtnPrint();
        btnPrint.on('click', function () {
            var id = me.view.grid.getSelectedId().get()[0];

            if (!id) {
                me.showError("Выберите рейс");
                return;
            }

            var dispatcher = new MLC.wf.controller.Dispatcher({
                    workflowIdentity: {
                        package: 'CLIENT',
                        code: 'PRINT_PERMIT',
                        version: '1.0.0.0'
                    },
					inArguments: { EntityId: id.id },
                listeners: {
                    beginwait: function () {
                        me.beginWait();
                    },
                    endwait: function () {
                        me.endWait();
                    }
                    },
                    container: new MLC.wf.workspace.WfDialogWindowContainer()
                });
            dispatcher.run();
        });

        var btnCarDeparted = me.getBtnCarDeparted();
        btnCarDeparted.on('click', function () {
            var id = me.view.grid.getSelectedId().get()[0];

            if (!id) {
                me.showError("Выберите рейс");
                return;
            }

            var container = new MLC.wf.workspace.WfDialogWindowContainer(),
                dispatcher = new MLC.wf.controller.Dispatcher({
                    workflowIdentity: {
                        package: 'CLIENT',
                        code: 'CAR_DEPARTED',
                        version: '1.0.0.0'
                    },
                    inArguments: { EntityId: id.id, WorkerId: Ext.util.Cookies.get('WorkerID') },
                    container: container,
                    listeners: {
                        reload: function () {
                            me.loadData();
                        },
                        beginwait: function () {
                            me.beginWait();
                        },
                        endwait: function () {
                            me.endWait();
                        }
                    }
                });
            dispatcher.run();
        });

        var btnCancel = me.getBtnCancel();
        btnCancel.on('click', function () {
            var id = me.view.grid.getSelectedId().get()[0];

            if (!id) {
                me.showError("Выберите рейс");
                return;
            }

            var container = new MLC.wf.workspace.WfDialogWindowContainer(),
                dispatcher = new MLC.wf.controller.Dispatcher({
                    workflowIdentity: {
                        package: 'CLIENT',
                        code: 'EXTERNALTRAFFIC_CANCEL',
                        version: '1.0.0.0'
                    },
					inArguments: { EntityId: id.id },
                    container: container,
                    listeners: {
                        reload: function () {
                            me.loadData();
                        },
                        beginwait: function () {
                            me.beginWait();
                        },
                        endwait: function () {
                            me.endWait();
                        }
                    }
                });
            dispatcher.run();
        });

        var btnVerify = me.getBtnVerify();
        btnVerify.on('click', function () {
            var id = me.view.grid.getSelectedId().get()[0];

            if (!id) {
                me.showError("Выберите рейс");
                return;
            }

            var container = new MLC.wf.workspace.WfDialogWindowContainer(),
                dispatcher = new MLC.wf.controller.Dispatcher({
                    workflowIdentity: {
                        package: 'CLIENT',
                        code: 'VISITOR_VERIFY',
                        version: '1.0.0.0'
                    },
					inArguments: { EntityId: id.id },
                    container: container,
                    listeners: {
                        reload: function () {
                            me.loadData();
                        },
                        beginwait: function () {
                            me.beginWait();
                        },
                        endwait: function () {
                            me.endWait();
                        }
                    }
                });
            dispatcher.run();
        });

        var btnCreateTemp = me.getBtnCreateTemp();
        btnCreateTemp.on('click', function () {
            var dispatcher = new MLC.wf.controller.Dispatcher({
                    workflowIdentity: {
                        package: 'CLIENT',
                        code: 'CREATE_FROM_TEMPLATE',
                        version: '1.0.0.0'
                    },
                    container: new MLC.wf.workspace.WfDialogWindowContainer(),
                    listeners: {
                        reload: function () {
                            me.loadData();
                        },
                        beginwait: function () {
                            me.beginWait();
                        },
                        endwait: function () {
                            me.endWait();
                        }
                    }
                });
            dispatcher.run();
        });

        me.disableBtn(null);
        
        me.view.grid.getSelectionModel().on({
            selectionchange: function (sm, selections) {
                if (selections.length) {
                    me.disableBtn(selections);
                }
            }
        });
    },

    disableBtn: function (selections) {
        var me = this;
            me.getBtnCarArrived().setDisabled(true);
            me.getBtnCarDeparted().setDisabled(true);
            me.getBtnVerify().setDisabled(true);

        if (selections !== null) {
            var status = selections[0].get('Status');
            switch (status.id) {
            case "CAR_ARRIVED":
                me.getBtnCarDeparted().setDisabled(false);
                me.getBtnVerify().setDisabled(false);
                break;
            case "CAR_TRANSITTERRITORY":
                me.getBtnCarDeparted().setDisabled(false);
                break;
            case "CAR_PLAN":
                me.getBtnCarArrived().setDisabled(false);
                break;

            }
        }
    },

    showError: function (errorText) {
        var messageBox = new Ext.window.MessageBox();
        messageBox.show({
            title: 'Ошибка',
            msg: errorText,
            buttons: Ext.Msg.OK
        });
    }
});
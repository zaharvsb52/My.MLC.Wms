Ext.define('MLC.wms.yExternalTraffic.ExternalTrafficCardController', {
    extend: 'WebClient.common.controller.EntityCard',

    requires: [
        'WebClient.common.dataServices.DataServiceProxy',
        'WebClient.common.workspace.RoomContainer',
        'WebClient.common.Site',
        'WebClient.common.appController.EntityControllerProvider',
        'WebClient.common.workspace.ContainerHelper',
        'MLC.wf.workspace.WfDialogWindowContainer',
        'MLC.wf.controller.Dispatcher',
        'WebClient.common.commands.Command'
    ],

    mixins: {
        standAlone: 'WebClient.common.controller.StandAloneControllerMixin',
        //interfaces
        'WebClient.common.controller.IList': 'WebClient.common.controller.IList',
        ctrl: 'MLC.wms.controller.ExtendedController'
    },

    refs: {
        wfpanel: '#wfpanel',
        commandToolbar: '#commandToolbar',
        driverpanel: '#driverpanel',
        driver: '#driver',
        vehicle: '#vehicle',
        wrkpass: '#wrkpass',
        status: '#status',
        internaltrafficgrid: '#internaltrafficgrid'
    },

    dispatcher: undefined,

    inithandlers: false,

    saveCommand: undefined,

    reloadCommand: undefined,

    carArrivedCommand: undefined,

    carDepartedCommand: undefined,

    cancelCommand: undefined,

    verifyCommand: undefined,

    printCommand: undefined,

    /**
    */
    getStates: function () {

    },

    notifyOnStatesChange: function (callback, scope) {

    },
    /**
    */

    constructor: function (cfg) {
        this.mixins.standAlone.constructor.call(this, cfg);
        var dataServiceProxy = new WebClient.common.dataServices.DataServiceProxy({
            actionName: 'WMS.DataServices.ExternalTraffic.DataService',
            modelName: 'externalTrafficCardModel'
        });

        var defaultConfig =
        {
            viewBox: WebClient.lazy('MLC.wms.yExternalTraffic.ExternalTrafficCard'),
            structureName: 'ExternalTrafficCard',
            dataServiceProxy: dataServiceProxy
        };

        cfg = Ext.merge(defaultConfig, cfg);

        this.callParent([cfg]);
    },

    /**
     * 
     * @param {Array} records массив записей
     */
    destroy: function (records) {

        var store = this.dataContext.takeStore('InternalTrafficList');
        store.remove(records);

        //собираем изменения
        var changeSet = WebClient.common.data.change.SetCollector.collect(this.getDataContext());
        new WebClient.common.data.DataContextProxy().commit(
            changeSet,
            this.dataServiceProxy.getCommitMethod(),
            {
                entityType: this.entityType
            },
            function () {
                this.loadData();
            },
            this
        );
    },

    loadData: function () {
        var me = this;
        me.callParent(arguments);
        var itemStore = me.dataContext.takeStore('InternalTrafficList'),
            internalTrafficFilter = new Ext.util.Filter({
                itemId: 'ExternalTraffic',
                property: 'ExternalTraffic',
                operator: WebClient.FilterOps.EQ
            });

        internalTrafficFilter.setValue([me.dataParams.id]);
        itemStore.addFilter(internalTrafficFilter);
        itemStore.load();
        var driver = me.getDriver(),
            vehicle = me.getVehicle(),
            filterblWorkerPass = me.getWrkpass().getFilterable();

        driver.on('change', function (driver) {
            Server.WMS.DataServices.ExternalTraffic.DataService.getWorkerExtendedInfo({ driverId: driver.getValue() ? driver.getValue().id : null }, Ext.Function.bind(me.onGetExternalTrafficInfoComplete, me));
        });

        vehicle.on('change', function (vehicle) {
            Server.WMS.DataServices.ExternalTraffic.DataService.getVehicleExtendedInfo({ vehicleId: vehicle.getValue() ? vehicle.getValue().id : null }, Ext.Function.bind(me.onGetExternalTrafficInfoComplete, me));
        });

        WebClient.common.filters.FilterBinder.bind(filterblWorkerPass, [{ source: driver, operator: WebClient.FilterOps.EQ, dataIndex: 'Worker' }]);
    },

    onGetExternalTrafficInfoComplete: function (obj) {
        var form = this.view.getForm();
        for (var name in obj) {
            if (obj.hasOwnProperty(name)) {

                if (form.findField(name)) {
                    if (form.findField(name).xtype === 'datefield') {
                        form.findField(name).setValue(Ext.Date.parse(obj[name], 'c'));
                    } else {
                        form.findField(name).setValue(obj[name]);
                    }
                }
            }
        }
    },

    loadDataCallback: function () {
        var me = this;
        me.callParent(arguments);
        var workerPass = me.getWrkpass();
        // передаём водителя из рейса в лукап (используется потом при создании новых документов, автозаполняется водитель, см. wmsWorkerPass.WorkerPassListController)
        workerPass.Worker = me.view.getRecord().data.ExternalTrafficDriver;
    },

    reload: function () {
        var me = this;

        if (!me.getDriverpanel().isDirty())
            me.loadData();
        else {
            Ext.MessageBox.show({
                title: 'Подтверждение',
                msg: 'Есть несохраненные изменения. Отменить их и обновить?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNO,
                fn: function (buttonId) {
                    if (buttonId === 'yes')
                        me.loadData();
                }
            });
        }
    },

    onViewCreated: function () {
        var me = this;
        this.callParent();

        me.saveCommand = new WebClient.common.commands.Save({ handler: this.save, scope: this });
        me.reloadCommand = new WebClient.common.commands.Reload({ handler: this.reload, scope: this });
        me.carArrivedCommand = new WebClient.common.commands.Command({ handler: this.carArrived, scope: this, text: 'Зарегистрировать', glyph: 0xf0f6 });
        me.carDepartedCommand = new WebClient.common.commands.Command({ handler: this.carDeparted, scope: this, text: 'Убытие', glyph: 0xf08b });
        me.printCommand = new WebClient.common.commands.Command({ handler: this.print, scope: this, text: 'Печать', glyph: 0xf02f });
        me.cancelCommand = new WebClient.common.commands.Command({ handler: this.cancel, scope: this, text: 'Аннулировать', glyph: 0xf05e });
        me.verifyCommand = new WebClient.common.commands.Command({ handler: this.verify, scope: this, text: 'Верифицировать', glyph: 0xf046 });

        var toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar([
            me.saveCommand,
            me.reloadCommand,
            me.pcarArrivedCommand,
            me.carDepartedCommand,
            me.printCommand,
            me.cancelCommand,
            me.verifyCommand
        ]);
        if (toolbarCfg) {
            var tab = me.getCommandToolbar();
            tab.add(toolbarCfg);
        }

        var interTrGrid = me.getInternaltrafficgrid(),
            tbar = Ext.Array.findBy(interTrGrid.grid.dockedItems.items, function (item) { return item.xtype === 'toolbar' });

        if (tbar) {
            var item2Remove = Ext.Array.findBy(tbar.items.items, function (tbarItem) { return tbarItem.itemId === 'openfilter'; });
            Ext.Array.remove(tbar.items.items, item2Remove);
        }
        
        var status = me.getStatus();
        status.on('change', Ext.Function.bind(me.disabledBtn, me));
        me.disabledBtn();
    },

    carArrived: function () {
        var me = this;
        var id = me.dataParams.id,
            container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'CAR_ARRIVED',
                    version: '1.0.0.0'
                },
				inArguments: { EntityId: id.id },
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
        //this.relayEvents(dispatcher, [/*'reload', */'beginrequest', 'endrequest']);
        dispatcher.run();
    },

    print: function () {
        var me = this;
        var id = me.dataParams.id,
            container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'PRINT_PERMIT',
                    version: '1.0.0.0'
                },
				inArguments: { EntityId: id.id },
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
        dispatcher.run();
    },

    carDeparted: function () {
        var me = this;
        me.dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: {
                package: 'CLIENT',
                code: 'CAR_DEPARTED',
                version: '1.0.0.0'
            },
            inArguments: { EntityId: me.dataParams.id.id, WorkerId: Ext.util.Cookies.get('WorkerID') },
            container: new MLC.wf.workspace.WfDialogWindowContainer(),
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
        me.dispatcher.run();
    },

    cancel: function () {
        var me = this;
        me.dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: {
                package: 'CLIENT',
                code: 'EXTERNALTRAFFIC_CANCEL',
                version: '1.0.0.0'
            },
			inArguments: { EntityId: me.dataParams.id.id },
            container: new MLC.wf.workspace.WfDialogWindowContainer(),
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
        me.dispatcher.run();
    },

    verify: function () {
        var me = this;
        me.dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: {
                package: 'CLIENT',
                code: 'VISITOR_VERIFY',
                version: '1.0.0.0'
            },
			inArguments: { EntityId: me.dataParams.id.id },
            container: new MLC.wf.workspace.WfDialogWindowContainer(),
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
        me.dispatcher.run();
    },

    getContainerCommandList: function () {
        return [];
    },

    disabledBtn: function () {
        var me = this;

        me.carDepartedCommand.setDisabled(true);
        me.carArrivedCommand.setDisabled(true);
        me.verifyCommand.setDisabled(true);

        var status = this.getStatus().getValue();
        if (status == null)
            return;
        switch (status.id) {
            case "CAR_ARRIVED":
                me.carDepartedCommand.setDisabled(false);
                me.verifyCommand.setDisabled(false);
                break;
            case "CAR_TRANSITTERRITORY":
                me.carDepartedCommand.setDisabled(false);
                break;
            case "CAR_PLAN":
                me.carArrivedCommand.setDisabled(false);
                break;
        }
    }
});
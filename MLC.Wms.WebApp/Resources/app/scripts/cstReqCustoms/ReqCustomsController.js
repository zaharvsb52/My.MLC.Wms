Ext.define('MLC.wms.cstReqCustoms.ReqCustomsController', {
    extend: 'WebClient.common.controller.EntityCard',

    mixins: {
        'WebClient.common.controller.IList': 'WebClient.common.controller.IList',
        standAlone: 'WebClient.common.controller.StandAloneControllerMixin',
        ctrl: 'MLC.wms.controller.ExtendedController'
    },

    requires: [
        'WebClient.common.dataServices.DataServiceProxy',
        'WebClient.common.type.EntityId',
        'MLC.wf.controller.Dispatcher',
        'MLC.wf.workspace.WfDialogWindowContainer'
    ],

    refs: {
        commandToolbar: '#commandToolbar',
        addBtn: '#addBtnId',
        accountsGrid: '#accountsGrid',
        cstDocTransportGrid: '#cstDocTransportGrid',
        transportContgrid: '#transportContgrid',
        accountsPanel: '#accountsPanel',
        customsPanel: '#customsPanel',
        commonPanel: '#commonPanel',
        addTrCont: '#addTrCont',
        addTrDoc: '#addTrDoc',
        openWaybillButton: '#openWaybill',
        deleteWayBillButton: '#deleteWayBill',
        fillTrFieldsBtn: '#fillTrFieldsBtn',
        vehInRef: '#vehInRef',
        vehInCode: '#vehInCode',
        vehInCountry: '#vehInCountry',
        vehOutRef: '#vehOutRef',
        vehOutCode: '#vehOutCode',
        vehOutCountry: '#vehOutCountry',
        wayBillGrid: '#reqCustoms2WBGrid',
        posList: '#posList',
        post: '#post',
        deliveryConditions: '#deliveryConditions',
        postDate: '#postDate',
        lastPostDate: '#lastPostDate'
    },

    constructor: function(cfg) {
        var me = this;

        var dataServiceProxy = new WebClient.common.dataServices.DataServiceProxy({
            actionName: 'WMS.DataServices.ReqCustoms.DataService',
            getModelMethodName: 'getMetadata',
            modelName: 'cstReqCustomsModel'
        });

        var dtCont = dataServiceProxy.createDataContext();

        var defaultConfig =
        {
            viewBox: WebClient.lazy('MLC.wms.cstReqCustoms.ReqCustomsView'),
            dataServiceProxy: dataServiceProxy,
            dataServiceMethods: dataServiceProxy.serverMethods,
            dataContext: dtCont,
            entityType: 'CstReqCustoms',
            structureName: 'CstReqCustomsCard',
            mode: WebClient.CardViewMode.CREATE
        };

        cfg = Ext.merge(defaultConfig, cfg);
        me.callParent([cfg]);
    },

    processRevive: function() {
        var me = this;
        Ext.merge(me.viewBox.config, {
            mode: WebClient.CardViewMode.CREATE
        });

        me.callParent(arguments);
    },

    onViewCreated: function() {
        var me = this;

        me.reloadCommand = new WebClient.common.commands.Command({ handler: me.reloadData, scope: me, text: 'Обновить', disabled: 'true' });
        me.clearCommand = new WebClient.common.commands.Command({ handler: me.closeCstReqCustoms, scope: me, text: 'Закрыть', disabled: 'true' });
        me.openCommand = new WebClient.common.commands.Command({ handler: me.openReqCustomsListHandler, scope: me, text: 'Открыть' });
        me.saveCommand = new WebClient.common.commands.Save({ handler: me.checkDataAndSave, scope: me, text: 'Сохранить', disabled: 'true' });
        me.deleteCommand = new WebClient.common.commands.Command({ handler: me.destroy, scope: me, text: 'Удалить', disabled: 'true' });
        me.printCommand = new WebClient.common.commands.Command({ handler: me.runWFPrintReqCustoms, scope: me, text: 'Печать', disabled: 'true' });
        me.createItems = new WebClient.common.commands.Command({ handler: me.runWFCreateReqCustomsPos, scope: me, text: 'Создать позиции', disabled: 'true' });
        me.sendRequest = new WebClient.common.commands.Command({ handler: me.runWFSendReqCustoms, scope: me, text: 'Отправить заявку', disabled: 'true' });
        me.getOpenWaybillButton().setHandler(me.openWayBill, me);
        me.getDeleteWayBillButton().setHandler(me.runWFCstReqCustoms2WbDelete, me);
        me.getAddBtn().setHandler(me.addWaybillReqCustomsHandle, me);
        me.getAddTrDoc().setHandler(me.addTrDocHandler, me);
        me.getAddTrCont().setHandler(me.addTrContHandler, me);
        me.getFillTrFieldsBtn().setHandler(me.fillTrFieldsHandler, me);

        var toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar([
            me.reloadCommand,
            me.clearCommand,
            me.openCommand,
            me.saveCommand,
            me.printCommand,
            me.deleteCommand,
            me.createItems,
            me.sendRequest
        ]);
        if (toolbarCfg) {
            var tab = me.getCommandToolbar();
            tab.add(toolbarCfg);
        }

        me.setDisableControls(true);

        me.connectToSignalRServer();
    },

    getContainerCommandList: function() {},

    setDisableControls: function(disable) {
        var me = this,
            accountsPanel = me.getAccountsPanel(),
            customsPanel = me.getCustomsPanel(),
            commonPanel = me.getCommonPanel(),
            commandsToEnable = me.getCommandToolbar().getRefItems(true);

        commandsToEnable.forEach(function(el) {
            if (['Закрыть', 'Создать позиции', 'Сохранить', 'Удалить', 'Обновить', 'Печать', 'Отправить заявку'].indexOf(el.text) >= 0)
                el.setDisabled(disable);
        });

        me.getAddTrDoc().setDisabled(disable);
        me.getAddTrCont().setDisabled(disable);

        [commonPanel, accountsPanel, customsPanel].forEach(function(el) {
            var childEls = el.getChildItemsToDisable();
            childEls.forEach(function(child) {
                    if (child.setReadOnly && !child.allwaysReadOnly)
                        child.setReadOnly(disable);
                }
            );
        });
    },

    connectToSignalRServer: function() {
        var me = this;
        var baseUrl = window.location.origin + window.location.pathname;
        var resUrl = [baseUrl.replace(/^\/|\/$/g, ""), '/signalr/hubs'.replace(/^\/|\/$/g, "")].join("/");
        var signalRhubConnection = $.hubConnection(resUrl);

        me.dclHubProxy = signalRhubConnection.createHubProxy('dclHub');
        me.dclHubProxy.on('writeConsole', function(message) {
            console.log(message);
        });

        signalRhubConnection.start()
            .done(function() {
            })
            .fail(function(error) {
                Ext.MessageBox.show({
                    title: 'Could not connect',
                    msg: error,
                    icon: Ext.MessageBox.ERROR,
                    buttons: Ext.MessageBox.YES
                });
            });
    },

    loadStores: function() {
        var me = this,
            customsStore = me.dataContext.takeStore('CstReqCustomsCard'),
            docStore = me.dataContext.takeStore('CstTransportDocumentList'),
            transportContractStore = me.dataContext.takeStore('CstTransportContractList'),
            reqCustoms2WBStore = me.dataContext.takeStore('CstReqCustoms2WBList'),
            customPosStore = me.dataContext.takeStore('CstReqCustomsPosList'),
            filterablePost = me.getPost().getFilterable();

        filterablePost.getFilters().add('', new Ext.util.Filter({ property: 'VIsCustomsPost', operator: WebClient.FilterOps.EQ, value: true }));

        me.mode = 'edit';

        var reqCustomsFilter = new Ext.util.Filter({
            itemId: 'ReqCustoms',
            property: 'ReqCustoms',
            operator: WebClient.FilterOps.EQ
        });

        reqCustomsFilter.setValue([me.dataParams.id]);

        WebClient.common.controls.FormPanelHelper.takeMaskForPanelAndBindToStore(me.view, customsStore);

        customsStore.load({
            params: me.dataParams,
            scope: me,
            callback: me.loadDataCallback
        });

        docStore.addFilter(reqCustomsFilter);
        customPosStore.addFilter(reqCustomsFilter);
        transportContractStore.addFilter(reqCustomsFilter);
        reqCustoms2WBStore.addFilter(reqCustomsFilter);
        docStore.load();
        customPosStore.load();
        transportContractStore.load();
        reqCustoms2WBStore.load();

        Server.WMS.DataServices.ReqCustoms.DataService.getAccountsList({ entityId: me.dataParams.id }, me.onGetAccountsList.bind(me));

        me.getPosList().enable();
    },

    onGetAccountsList: function() {
        var me = this,
            accountsLst = me.getAccountsGrid();

        var accListStore = accountsLst.getStore();
        if (accListStore.isEmptyStore) {
            accListStore = new Ext.data.Store({
                proxy: {
                    type: "memory"
                },
                fields: ['AccountNumber', 'AccountAmount', 'AccountCurrency'],
                data: arguments[0].data
            });
            accountsLst.setStore(accListStore);
        } else {
            accListStore.loadData(arguments[0].data);
        }

        accListStore.load();
    },

    loadDataCallback: function(records, operation, success) {
        var me = this;

        me.cardTitleFn = function(it) {
            if (it.Status != null && it.Status.id === 'REQCUSTOMS_ACTIVATED')
                me.sendRequest.setDisabled(true);

            var out = 'Заявка на декларирование ';
            if (it.ReqCustomsID) {
                out += '"' + WebClient.common.type.EntityId.decode(it.ReqCustomsID).id + '"';
            }
            return out;
        };
        if (me.cardTitleFn && success && records.length > 0)
            me.view.setTitle(me.cardTitleFn(records[0].getData()));
        WebClient.common.controls.FormPanelHelper.loadDataCallback(me.view, records, operation, success);
        me.view.getForm().isValid(); // для отображения невалидных полей
    },

    destroy: function() {
        var me = this,
            store = this.dataContext.takeStore(this.structureName);

        store.removeAll();

        //собираем изменения
        var changeSet = WebClient.common.data.change.SetCollector.collect(this.getDataContext());
        if (changeSet.isEmpty()) {
            return;
        }

        new WebClient.common.data.DataContextProxy().commit(
            changeSet,
            this.dataServiceProxy.getCommitMethod(),
            {
                entityType: this.entityType
            },
            null,
            this
        );

        me.cleanChildStores();
        me.setDisableControls(true);
    },

    isChange: function() {
        var me = this,
            form = me.view.getForm(),
            changeSet = WebClient.common.data.change.SetCollector.collect(me.getDataContext());

        return me.dataParams && (form.isDirty() || !changeSet.isEmpty());
    },

    checkData: function() {
        var me = this,
            docStore = me.getDataContext().takeStore('CstTransportDocumentList'),
            transportContractStore = me.getDataContext().takeStore('CstTransportContractList'),
            raise,
            deliveryConditions = me.getDeliveryConditions().getValue(),
            regex = new RegExp('^(?:\\w{3} {1})*\\w{3}$'),
            errorMessage = '';

        if (deliveryConditions && !regex.test(deliveryConditions))
            errorMessage += 'Неправильно заполнено поле "Условия поставки": соблюдайте формат "ХХХ ХХХ ХХХ"';

        if (me.getLastPostDate().getValue() > me.getPostDate().getValue())
            errorMessage += '"Дата предыдущей выгрузки" не может быть больше, чем "Дата въезда/выезда"';

        raise = docStore.findBy(function (item) { return !item.data.TransportDocumentType; });
        if (raise > -1)
            errorMessage += 'Не заполнено поле "Тип" у документа(ов) на перевозку';

        raise = docStore.findBy(function (item) { return !item.data.TransportDocumentNumber; });
        if (raise > -1)
            errorMessage += 'Не заполнено поле "Номер" у документа(ов) на перевозку';

        raise = transportContractStore.findBy(function (item) { return !item.data.TransportContractNumber; });
        if (raise > -1)
            errorMessage += 'Не заполнено поле "Номер" у транспортного договора(ов)';

        raise = transportContractStore.findBy(function (item) { return !item.data.TransportContractDate; });
        if (raise > -1)
            errorMessage += 'Не заполнено поле "Дата" у транспортного договора(ов)';

        if (errorMessage === '')
            return true;

        Ext.MessageBox.show({
            title: 'Данные некорректны',
            msg: errorMessage,
            icon: Ext.MessageBox.ERROR,
            buttons: Ext.MessageBox.YES
        });
        return false;
    },

    checkDataAndSave: function() {
        var me = this,
            checked = me.checkData();

        if (!checked) return;
        me.save(arguments);
    },

    save: function() {
        var me = this,
            deliveryConditions = me.getDeliveryConditions();

        deliveryConditions.setValue(deliveryConditions.getValue().toUpperCase());
        me.callParent(arguments);
        me.getDataContext().stores.items.forEach(function(store) { store.commitChanges(); });
    },

    cleanChildStores: function() {
        var me = this,
            stores = me.getDataContext().stores.items;

        stores.forEach(function(item) { item.removeAll() });
        me.getAccountsGrid().store.removeAll();

        //view в режим создания
        me.mode = WebClient.CardViewMode.CREATE;
        me.dataParams = null;
        me.loadData();
    },

    closeCstReqCustoms: function() {
        var me = this;

        if (me.isChange()) {
            Ext.MessageBox.show({
                title: 'Данные изменены',
                msg: 'Сохранить изменения?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNOCANCEL,
                fn: function(buttonId) {
                    if (buttonId === 'cancel') return;
                    if (buttonId === 'yes') {
                        var checked = me.checkData();
                        if (!checked) return;
                        me.save();
                    }
                    me.cleanChildStores();
                    me.setDisableControls(true);
                    me.getPosList().disable();
                }
            });
        } else {
            me.cleanChildStores();
            me.setDisableControls(true);
            me.getPosList().disable();
        }
    },

    reloadData: function() {
        var me = this;

        if (me.isChange()) {
            Ext.MessageBox.show({
                title: 'Данные изменены',
                msg: 'Сохранить изменения?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNOCANCEL,
                fn: function(buttonId) {
                    if (buttonId === 'cancel') return;
                    if (buttonId === 'yes') {
                        var checked = me.checkData();
                        if (!checked) return;
                        me.save();
                    }
                    me.loadData();
                    Server.WMS.DataServices.ReqCustoms.DataService.getAccountsList({ entityId: me.dataParams.id }, me.onGetAccountsList.bind(me));
                }
            });
        } else {
            me.loadData();
            Server.WMS.DataServices.ReqCustoms.DataService.getAccountsList({ entityId: me.dataParams.id }, me.onGetAccountsList.bind(me));
        }
    },

    openReqCustomsListHandler: function() {
        var me = this;

        if (me.isChange()) {
            Ext.MessageBox.show({
                title: 'Данные изменены',
                msg: 'Сохранить изменения?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNOCANCEL,
                fn: function(buttonId) {
                    if (buttonId === 'cancel') return;
                    if (buttonId === 'yes') {
                        var checked = me.checkData();
                        if (!checked) return;
                        me.save();
                    }
                    me.runWfReqCustomsList();
                }
            });
        } else {
            me.runWfReqCustomsList();
        }
    },

    addTrContHandler: function() {
        var me = this,
            transportContgrid = me.getTransportContgrid(),
            rec = new transportContgrid.grid.store.model();

        rec.data.TransportContractId = { EntityId: null, type: 'CstTransportContract' };
        rec.data.ReqCustoms = { id: me.dataParams.id.id, type: me.dataParams.id.type };

        transportContgrid.grid.store.add(rec);
        // выставляем редактирование
        transportContgrid.grid.plugins[0].startEditByPosition({
            row: transportContgrid.grid.store.getCount() - 1,
            column: 1
        });
    },

    addTrDocHandler: function() {
        var me = this,
            cstDocTransportGrid = me.getCstDocTransportGrid(),
            rec = new cstDocTransportGrid.grid.store.model();

        rec.data.TransportDocumentId = { EntityId: null, type: 'CstTransportDocument' };
        rec.data.ReqCustoms = { id: me.dataParams.id.id, type: me.dataParams.id.type };

        cstDocTransportGrid.grid.store.add(rec);
        // выставляем редактирование
        cstDocTransportGrid.grid.plugins[0].startEditByPosition({
            row: cstDocTransportGrid.grid.store.getCount() - 1,
            column: 1
        });
    },

    fillTrFieldsHandler: function() {
        var me = this,
            inRef = me.getVehInRef(),
            inCode = me.getVehInCode(),
            inCountry = me.getVehInCountry(),

            outRef = me.getVehOutRef(),
            outCode = me.getVehOutCode(),
            outCountry = me.getVehOutCountry();

        inRef.setValue(outRef.value);
        inCode.setValue(outCode.value);
        inCountry.setValue(outCountry.value);
    },

    runWfReqCustomsList: function() {
        var me = this;
        var container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'REQCUSTOMSLIST_OPEN',
                    version: '1.0.0.0'
                },
                workflowDataServiceName: 'WMS.DataServices.ReqCustoms.WF.DataService',
                container: container,
                listeners: {
                    reload: function() {
                        me.reload();
                        me.onSave();
                    },
                    beginwait: function() {
                        me.beginWait();
                    },
                    endwait: function() {
                        me.endWait();
                    },
                    wfResponse: function(r) {
                        // читаем результаты workflow при окончании работы
                        if (r.response && r.response.workflowInstanceIdentity.state === "Closed" && r.response.resultData) {
                            var wfresult = r.response.resultData.tables.results.data[0],
                                entId = WebClient.common.type.EntityId.decode(wfresult.entityId),
                                disableControls = wfresult.state !== 'REQCUSTOMS_CREATED';
                            me.dataParams = { id: { id: entId.id, type: entId.type } };
                            me.loadStores();
                            me.setDisableControls(disableControls);

                            var commandsToEnable = me.getCommandToolbar().getRefItems(true);
                            commandsToEnable.forEach(function (el) {
                                if ('Закрыть' === el.text)
                                    el.setDisabled(false);
                            });
                        }
                    }
                }
            });
        dispatcher.run();
    },

    runWFCreateReqCustomsPos: function() {
        var me = this;

        var id = me.dataParams.id,
            container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'REQCUSTOMSPOS_FILL',
                    version: '1.0.0.0'
                },
                inArguments: { EntityId: id.id },
                container: container,
                listeners: {
                    beginwait: function() {
                        me.beginWait();
                    },
                    endwait: function() {
                        me.endWait();
                    },
                    wfResponse: function(r) {
                        if (r.response && r.response.workflowInstanceIdentity.state === "Closed") {
                            var success = r.response.resultData.tables.results.data[0].isPositionsCreated,
                                customPosStore = me.getDataContext().takeStore('CstReqCustomsPosList');
                            me.sendRequest.setDisabled(!success);
                            if (success && success === true)
                                customPosStore.reload();
                        }
                    }
                }
            });
        dispatcher.run();
    },


    runWFPrintReqCustoms: function() {
        var me = this;

        var id = me.dataParams.id,
            container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'REQCUSTOMS_PRINT',
                    version: '1.0.0.0'
                },
                workflowDataServiceName: 'WMS.DataServices.ReqCustoms.WF.DataService',
                inArguments: { EntityId: id.id },
                container: container,
                listeners: {
                    reload: function() {
                        me.reload();
                        me.onSave();
                    },
                    beginwait: function() {
                        me.beginWait();
                    },
                    endwait: function() {
                        me.endWait();
                    }
                }
            });

        if (me.isChange()) {
            Ext.MessageBox.show({
                title: 'Данные изменены',
                msg: 'Сохранить изменения?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNOCANCEL,
                fn: function (buttonId) {
                    if (buttonId === 'cancel') return;
                    if (buttonId === 'yes') {
                        var checked = me.checkData();
                        if (!checked) return;
                        me.save();
                    }
                    dispatcher.run();
                }
            });
        } else {
            dispatcher.run();
        }
    },

    runWFSendReqCustoms: function() {
        var me = this;

        var id = me.dataParams.id,
            container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'REQCUSTOMS_SEND',
                    version: '1.0.0.0'
                },
                inArguments: { EntityId: id.id },
                container: container,
                listeners: {
                    reload: function() {
                        me.reload();
                        me.onSave();
                    },
                    beginwait: function() {
                        me.beginWait();
                    },
                    endwait: function() {
                        me.endWait();
                    },
                    wfResponse: function(r) {
                        // читаем результаты workflow при окончании работы
                        if (r.response && r.response.workflowInstanceIdentity.state === "Closed" && r.response.resultData) {
                            me.loadStores();
                            var result = r.response.resultData.tables.results.data[0];

                            if (result.state === 'REQCUSTOMS_ACTIVATED') {
                                me.setDisableControls(true);

                                var commandsToEnable = me.getCommandToolbar().getRefItems(true);
                                commandsToEnable.forEach(function (el) {
                                    if ('Закрыть' === el.text)
                                        el.setDisabled(false);
                                });
                            }
                            else if (!result.isPosExists)
                                me.sendRequest.setDisabled(true);
                        }
                    }
                }
            });

        if (me.isChange()) {
            Ext.MessageBox.show({
                title: 'Данные изменены',
                msg: 'Сохранить изменения?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNOCANCEL,
                fn: function (buttonId) {
                    if (buttonId === 'cancel') return;
                    if (buttonId === 'yes') {
                        var checked = me.checkData();
                        if (!checked) return;
                        me.save();
                    }
                    dispatcher.run();
                }
            });
        } else {
            dispatcher.run();
        }
    },

    runWFCstReqCustoms2WbDelete: function() {
        var me = this,
            selection = me.view.down('#reqCustoms2WBGrid').down('gridpanel').getSelection();

        if (selection.length === 0)
            return;

        var entIdArr = Ext.Array.map(selection, function(el) {
            return WebClient.common.type.EntityId.decode(el.id).id;
        });

        var id = me.dataParams.id,
            container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'REQCUSTOMS2WB_DELETE',
                    version: '1.0.0.0'
                },
                inArguments: { EntityId: id.id, Cst2WB: entIdArr.join(';') },
                container: container,
                listeners: {
                    reload: function() {
                        me.loadStores();
                    },
                    beginwait: function() {
                        me.beginWait();
                    },
                    endwait: function() {
                        me.endWait();
                    },
                    wfResponse: function(r) {
                        // читаем результаты workflow при окончании работы
                        if (r.response && r.response.workflowInstanceIdentity.state === "Closed") {
                            if (r.response.resultData.tables.results.data[0].isCreatePosNeed) {
                                me.runWFCreateReqCustomsPos();
                            }
                        }
                    }
                }
            });
        dispatcher.run();
    },

    addWaybillReqCustomsHandle: function() {
        var me = this;
        var id = (me.dataParams != null && me.dataParams.id != null) ? me.dataParams.id.id : null;

        var container = new MLC.wf.workspace.WfDialogWindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({
                workflowIdentity: {
                    package: 'CLIENT',
                    code: 'REQCUSTOMS_ADD',
                    version: '1.0.0.0'
                },
                workflowDataServiceName: 'WMS.DataServices.ReqCustoms.WF.WBGrid.DataService',
                inArguments: { EntityId: id },
                container: container,
                listeners: {
                    beginwait: function() {
                        me.beginWait();
                    },
                    endwait: function() {
                        me.endWait();
                    },
                    wfResponse: function(r) {
                        // читаем результаты workflow при окончании работы
                        if (r.response && r.response.workflowInstanceIdentity.state === "Closed" && r.response.resultData) {
                            me.dataParams = {};
                            var entId = WebClient.common.type.EntityId.decode(r.response.resultData.tables.results.data[0].entityId);
                            if (entId != null)
                                me.dataParams.id = { id: entId.id, type: entId.type };
                            me.loadStores();
                            me.setDisableControls(false);
                        }
                    }
                }
            });

        if (me.isChange()) {
            Ext.MessageBox.show({
                title: 'Данные изменены',
                msg: 'Сохранить изменения?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNOCANCEL,
                fn: function (buttonId) {
                    if (buttonId === 'cancel') return;
                    if (buttonId === 'yes') {
                        var checked = me.checkData();
                        if (!checked) return;
                        me.save();
                    }
                    dispatcher.run();
                }
            });
        } else {
            dispatcher.run();
        }
    },

    openWayBill: function() {
        var me = this,
            selection = me.view.down('#reqCustoms2WBGrid').down('gridpanel').getSelection(),
            wayBill,
            wayBillPkType = "System.Decimal";

        if (selection.length === 0)
            return;

        wayBill = selection[0].data;
        wayBill = wayBill.IWB ? wayBill.IWB : wayBill.OWB;

        me.dclHubProxy.invoke("showEntityCard", wayBill.type, wayBillPkType, wayBill.id)
            .fail(function(error) {
                Ext.MessageBox.show({
                    title: 'Не получилось открыть накладную',
                    msg: error,
                    icon: Ext.MessageBox.ERROR,
                    buttons: Ext.MessageBox.YES
                });
            });
    }
});
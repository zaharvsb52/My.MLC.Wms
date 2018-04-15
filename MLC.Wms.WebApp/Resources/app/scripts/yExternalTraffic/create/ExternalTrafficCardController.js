Ext.define('MLC.wms.yExternalTraffic.create.ExternalTrafficCardController', {
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
        'WebClient.common.controller.IList': 'WebClient.common.controller.IList'
    },

    dispatcher: undefined,

    inithandlers: false,

    saveCommand: undefined,

    reloadCommand: undefined,

    /**
     * WF добавления машины
     */
    wfIdentityAddVehicle: { package: 'CLIENT', code: 'ADDVEHICLE', version: '1.0.0.0' },

    /**
     * WF добавления водителя
     */
    wfIdentityAddCarDriver: { package: 'CLIENT', code: 'ADDCARDRIVER', version: '1.0.0.0' },

    refs: {
        btnAddDriver: '#btnAddDriver',
        btnAddVehicle: '#btnAddVehicle',
        trafficDriver: '#trafficDriver',
        trafficVehicle: '#trafficVehicle',
        driverHeader: '#driverHeader',
        txtPhoneMobile: '#txtPhoneMobile',
        dtpPlanArrived: '#dtpPlanArrived'
    },

    /**
    */
    getStates: function() {

    },

    notifyOnStatesChange: function(callback, scope) {

    },
    /**
    */

    constructor: function(cfg) {
        this.mixins.standAlone.constructor.call(this, cfg);
        var dataServiceProxy = new WebClient.common.dataServices.DataServiceProxy({
            actionName: 'WMS.DataServices.ExternalTrafficCreate.DataService',
            modelName: 'externalTrafficCardModel'
        });

        var defaultConfig =
        {
            viewBox: WebClient.lazy('MLC.wms.yExternalTraffic.create.ExternalTrafficCardCreate'),
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
    destroy: function() {

        var store = this.dataContext.takeStore('InternalTrafficCreateList');
        store.remove(records);

        //собираем изменения
        var changeSet = WebClient.common.data.change.SetCollector.collect(this.getDataContext());
        if (changeSet.isEmpty()) {
            WebClient.showError('Данные на форме не изменились');
            return;
        }

        new WebClient.common.data.DataContextProxy().commit(
            changeSet,
            this.dataServiceProxy.getCommitMethod(),
            {
                entityType: this.entityType
            },
            function() {
                this.loadData();
            },
            this
        );
    },

    loadData: function() {
        var me = this;
        me.callParent(arguments);
        var itemStore = me.dataContext.takeStore('InternalTrafficCreateList'),
            internalTrafficFilter = new Ext.util.Filter({
                itemId: 'ExternalTraffic',
                property: 'ExternalTraffic',
                operator: WebClient.FilterOps.EQ
            });
          
          

        internalTrafficFilter.setValue([me.dataParams.id]);
        itemStore.addFilter(internalTrafficFilter);
        itemStore.load();

        var driver = me.getTrafficDriver();
        var vehicle = me.getTrafficVehicle();
        
        driver.on('change', function (driver) {
            Server.WMS.DataServices.ExternalTraffic.DataService.getWorkerExtendedInfo({ driverId: driver.getValue() ? driver.getValue().id : null }, Ext.Function.bind(me.onGetExternalTrafficInfoComplete, me));

            if (!vehicle || !vehicle.getValue()) {
                Server.WMS.DataServices.ExternalTraffic.DataService.getLastVehicle({ driverId: driver.getValue() ? driver.getValue().id : null }, Ext.Function.bind(me.onGetVehicleInfoComplete, me));
            }
        });

        vehicle.on('change', function (vehicle) {
            if (!driver || !driver.getValue()) {
                Server.WMS.DataServices.ExternalTraffic.DataService.getLastWorker({ vehicleId: vehicle.getValue() ? vehicle.getValue().id : null }, Ext.Function.bind(me.onGetWorkerInfoComplete, me));
            }
        });

    },

    reload: function() {
        var me = this;
    },

    onViewCreated: function() {
        var me = this;
        this.callParent(arguments);

        var btnAddDriver = me.getBtnAddDriver();
        btnAddDriver.setGlyph(null);
        btnAddDriver.on('click', function() {
            me.onWfBtnClick(me.wfIdentityAddCarDriver, me.getWfAddCarDriverInArguments, Ext.Function.bind(me.onWfAddCarDriverResponse, me));
        });

        var btnAddVehicle = me.getBtnAddVehicle();
        btnAddDriver.setGlyph(null);
        btnAddVehicle.on('click', function() {
            me.onWfBtnClick(me.wfIdentityAddVehicle, me.getWfAddVehicleInArguments, Ext.Function.bind(me.onWfAddVehicleResponse, me));
        });
    },

    onWfBtnClick: function(wfIdentity, collectInArgumentsCallback, wfResponseCallback) {
        var container = new MLC.wf.workspace.WfDialogWindowContainer();
        var dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: wfIdentity,
            inArguments: collectInArgumentsCallback(this),
            container: container
        });
        // подписываемся на окончание wf (если есть что)
        if (wfResponseCallback)
            dispatcher.on('wfResponse', wfResponseCallback);
        // запускаем wf
        dispatcher.run();
    },

    onGetExternalTrafficInfoComplete: function(obj) {
        var form = this.view.getForm();
        this.changeImage(obj);
        for (var name in obj) {
            if (obj.hasOwnProperty(name)) {
                var field = form.findField(name);
                if (field) {
                    if (field.xtype === 'datefield') {
                        field.setValue(Ext.Date.parse(obj[name], 'c'));

                    } else {
                        field.setValue(obj[name]);

                    }
                }
            }
        }
        if (this.getTxtPhoneMobile().getValue())
            this.getDtpPlanArrived().focus();
        else
            this.getTxtPhoneMobile().focus();
    },

    onGetVehicleInfoComplete: function(vehicle) {
        var form = this.view.getForm();
        this.fillField(form.findField('Vehicle'), vehicle);
    },

    onGetWorkerInfoComplete: function (driver) {
        var form = this.view.getForm();
        this.fillField(form.findField('ExternalTrafficDriver'), driver);
    },

    fillField: function (field, obj) {
        if (field) {
            if (obj) {

                var entRef = new WebClient.common.type.EntityRef({
                    id: obj["id"],
                    type: obj["type"],
                    values: obj["values"]
                });

                field.setValue(entRef);

            } else {
                field.setValue(null);
            }
        }
    },

    /**
     * Сбор входных параметров wf добавления водителя
     */
    getWfAddCarDriverInArguments: function(arg) {
        return { InitString: arg.getTrafficDriver().getRawValue() }
    },

    /**
         * Сбор входных параметров wf добавления машины
         */
    getWfAddVehicleInArguments: function(arg) {
        return { InitString: arg.getTrafficVehicle().getRawValue() }
    },

    /**
         * Обработчик окончания wf добавления водителя
         */
    onWfAddCarDriverResponse: function(r) {
        if (r.response) {
            var wfInstanceIdentity = r.response.workflowInstanceIdentity;
            if (wfInstanceIdentity.state === 'Closed') {
                var form = this.view.getForm(),
                    entityRefField = form.findField('ExternalTrafficDriver'),
                    photoField = form.findField('ExternalTrafficDriver_WorkerPhoto');

                if (entityRefField && r.response.resultData) {

                    var resData = r.response.resultData["tables"]["DriverInfo"]["data"]["0"],
                        workerEntityRef = resData["WorkerEntityRef"],
                        photoWfValue = resData["WorkerPhoto"],
                        entRef = new WebClient.common.type.EntityRef({
                            id: workerEntityRef["id"],
                            type: workerEntityRef["type"],
                            values: workerEntityRef["values"]
                        });

                    entityRefField.setValue(entRef);

                    if (photoWfValue)
                        photoField.setValue(photoWfValue);
                }
            }
        }
    },

    /**
         * Обработчик окончания wf добавления машины
         */
    onWfAddVehicleResponse: function(r) {
        if (r.response) {
            var wfInstanceIdentity = r.response.workflowInstanceIdentity;
            if (wfInstanceIdentity.state === 'Closed') {
                var form = this.view.getForm(),
                    name = 'Vehicle',
                    field = form.findField(name);

                if (field && r.response.resultData) {
                    var ret = r.response.resultData.tables.VehicleInfo.data[0]["VehicleEntityRef"];
                    var entRef = new WebClient.common.type.EntityRef({
                        id: ret["id"],
                        type: ret["type"],
                        values: ret["values"]
                    });
                    field.setValue(entRef);
                }
            }
        }
    },

    getContainerCommandList: function() {

        var barItems = this.callParent(arguments);

        barItems = barItems.map(function (item) {
            if (item.text === 'ОК')
                item.initialConfig.text = 'Создать';
            return item;
        });

        barItems = barItems.filter(function (item) {
            return item.text !== 'Обновить';
        });

        return barItems;
    },

    changeImage: function(obj) {
        var me = this;
        var header = me.getDriverHeader();

        if (obj === null || !obj.hasOwnProperty("ExternalTrafficDriver_IsInBL")) {
            header.addCls('driver-not-select');
            header.removeCls('driver-not-black');
            header.removeCls('driver-black');
        } else {
            if (obj.hasOwnProperty("ExternalTrafficDriver_IsInBL") && obj["ExternalTrafficDriver_IsInBL"]) {
                header.addCls('driver-black');
                header.removeCls('driver-not-black');
                header.removeCls('driver-not-select');
            } else {
                header.addCls('driver-not-black');
                header.removeCls('driver-black');
                header.removeCls('driver-not-select');
            }
        }
    }
});
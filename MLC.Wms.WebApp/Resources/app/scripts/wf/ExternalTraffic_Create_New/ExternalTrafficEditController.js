﻿Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficEditController', {
    extend: 'MLC.wf.controller.Card',

    vehicleActionCode: 'VEHICLELOOKUP',

    workerPassActionCode: 'WORKERPASSLOOKUP',

    refs: {
        externalTrafficPassNumberField: '#ExternalTrafficPassNumber',
        externalTrafficDriverWorkerResidenceAddrField: '#ExternalTrafficDriver_WorkerResidenceAddr',
        vehicleEdit: '#VehicleEdit',
        workerPassEdit: '#WorkerPassEdit',
        addIntTraffBtn: '#AddIntTraff',
        delIntTraffBtn: '#DelIntTraff',
        intTraffGrid: '#IntTraffGrid',
        procData: '#ProcData',
        warehouse: '#Warehouse',
        warehouseOffice: '#WarehouseOffice',
        arrived: '#Arrived',
        departed: '#Departed'
    },

    constructor: function() {
        this.callParent(arguments);
    },

    onViewCreated: function() {
        var me = this,
            grid = me.getIntTraffGrid(),
            plugin = grid.getPlugin('cellplugin'),
            procData = me.getProcData();

        me.callParent(arguments);
        me.getExternalTrafficPassNumberField().setReadOnly(!!me.externalTrafficPassNumberReadOnly);
        //me.getExternalTrafficDriverWorkerResidenceAddrField().setReadOnly(!!me.externalTrafficDriverWorkerResidenceAddrReadOnly);

        procData.on('focus', me.focusProcDataHandler, me);
        me.getAddIntTraffBtn().setHandler(me.addIntTraff, me);
        me.getDelIntTraffBtn().setHandler(me.delSelIntTraff, me);
        me.view.on('deleteIntTraf', me.delIntTraff, me);
        me.view.on('enterToGrid', me.enterToGrid, me);
        me.view.on('enterToVehicleRn', me.enterToVehicleRn, me);
        plugin.on('beforeedit', me.beforeIntTraffEdit, me);
    },

    focusProcDataHandler: function(pl, ctx) {
        if (pl && !pl.value) {
            pl.setValue(new Date());
        }
        pl.selectText();
    },

    loadData: function() {
        var me = this,
            departed = me.getDeparted().getEditor(),
            arrived = me.getArrived().getEditor(),
            warehouseOffice = me.getWarehouseOffice(),
            warehouse = me.getWarehouse();

        me.callParent(arguments);

        var vehicle = me.getVehicleEdit(),
            workerPass = me.getWorkerPassEdit()

        vehicle.on('change', function() {

            var action =
            {
                code: me.vehicleActionCode,
                hidden: true,
                ignoreValidation: true,
                type: 'wfaction'
            }
            me.handleAction(action);
        });

        workerPass.on('change', function() {

            var action =
            {
                code: me.workerPassActionCode,
                hidden: true,
                ignoreValidation: true,
                type: 'wfaction'
            }
            me.handleAction(action);
        });

        me.container.window.setWidth(800);
        me.container.window.center();

        warehouse.getEditor().on('change', me.changeWarehouseHandler, me);
        warehouseOffice.getEditor().on('focus', me.setWarehouseFilter, me);
        warehouseOffice.getEditor().on('change', me.changeOfficeHandler, me);

        arrived.format = 'd.m H:i';
        departed.format = 'd.m H:i';
    },

    beforeIntTraffEdit: function(plugin, ctx) {
        if (ctx && ctx.field === 'PurposeVisit' && ctx.record && ctx.record.get('CanEditPurposeVisit') === false)
            return false;

        if (ctx && (ctx.field === 'InternalTrafficFactArrived' || ctx.field === 'InternalTrafficFactDeparted'))
            ctx.value = new Date();
    },

    addIntTraff: function() {
        var intTraffStore = this.getDataContext().takeStore('InternalTraffic'),
            intTraffModel = intTraffStore.model,
            newRec = new intTraffModel(),
            grid = this.getIntTraffGrid(),
            plugin = grid.getPlugin('cellplugin'),
            selModel = grid.getView().getSelectionModel();

        intTraffStore.insert(0, newRec);
        selModel.select(0);
        plugin.startEditByPosition({ row: 0, column: 1 });
    },

    delSelIntTraff: function() {
        var grid = this.getIntTraffGrid(),
            selection = grid.getView().getSelectionModel().getSelection(),
            intTraffStore = this.getDataContext().takeStore('InternalTraffic');

        intTraffStore.remove(selection);
    },

    delIntTraff: function (view, intTraff) {
        var intTraffStore = this.getDataContext().takeStore('InternalTraffic'),
            grid = this.getIntTraffGrid();

        grid.focus();
        intTraffStore.remove(intTraff);
    },

    enterToGrid: function() {
        var me = this,
            intTraffStore = me.getDataContext().takeStore('InternalTraffic'),
            grid = me.getIntTraffGrid(),
            plugin = grid.getPlugin('cellplugin'),
            selModel = grid.getView().getSelectionModel();

        if (intTraffStore.getCount() > 0) {
            selModel.select(0);
            plugin.startEditByPosition({ row: 0, column: 1 });
        } else {
            me.addIntTraff();
        }
    },

    enterToVehicleRn: function() {
        var me = this,
            vehicleEdit = me.getVehicleEdit();

        vehicleEdit.focus();
    },

    setWarehouseFilter: function() {
        var me = this,
            selModel = me.getIntTraffGrid().getView().getSelectionModel(),
            warehouseOffice = me.getWarehouseOffice().field,
            selectedWarehouse = selModel.getSelection()[0].get('Warehouse'),
            filters = warehouseOffice.getFilterable().getFilters(),
            idFilter = new Ext.util.Filter({
                itemId: 'Warehouse',
                property: 'Warehouse',
                operator: WebClient.FilterOps.EQ
            });

        //если склад не указан, сбрасываем все фильтры
        if (!selectedWarehouse) {
            //чистим фильтр store вручную т.к. при сбросе значения Warehouse=null, filters.clear() не чистит store.filters
            if (warehouseOffice.entityListController)
                warehouseOffice.entityListController.dataContext.getStore('WmsWarehouseOfficeList').filters.clear();

            filters.clear();
            return;
        }

        var savedValue = warehouseOffice.getValue();
        idFilter.setValue([selectedWarehouse]);

        filters.clear();
        filters.add(idFilter);
        //восстанавливаем значение поля, т.к. повторная фильтрация сбрасывает значение
        warehouseOffice.setValue(savedValue);
    },

    changeOfficeHandler: function (ctrl, newVal) {
        var me = this,
            warehouseOffice = me.getWarehouseOffice(),
            selectedRow = me.getIntTraffGrid().getSelection()[0];

        if (!newVal || !warehouseOffice.field.entityListController || selectedRow.get('Warehouse'))
            return;

        var officeObj = warehouseOffice.field.entityListController.getDataContext()
                                       .getStore('WmsWarehouseOfficeList').getById(newVal.getEntityId());

        if (!officeObj)
            return;

        selectedRow.set('Warehouse', officeObj.data.Warehouse);
    },

    changeWarehouseHandler: function() {
        var me = this,
            selectedRow = me.getIntTraffGrid().getSelection()[0];

        if (!selectedRow) return;

        selectedRow.set('WarehouseOffice', null);
    }
});
Ext.define('MLC.wms.wf.PassRequest_Create.PassRequestCardController', {
    extend: 'MLC.wf.controller.Card',

    refs: {
        grid: '#grid',
        addPurposeBtn: '#addPurpose',
        deleteSelectedPurposesBtn: '#deleteSelectedPurposes',
        warehouse: '#warehouse',
        warehouseOffice: '#warehouseOffice'
    },

    onViewCreated: function () {
        var me = this;

        me.callParent(arguments);

        me.getAddPurposeBtn().setHandler(me.addPurpose, me);
        me.getDeleteSelectedPurposesBtn().setHandler(me.deleteSelectedPurposes, me);
        me.view.on('deletePurpose', me.deletePurpose, me);
        me.view.on('enterToGrid', me.enterToGrid, me);
    },

    loadData: function () {
        var me = this,
            warehouseOffice = me.getWarehouseOffice(),
            warehouse = me.getWarehouse();

        me.callParent(arguments);

        warehouse.getEditor().on('change', me.changeWarehouseHandler, me);
        warehouseOffice.getEditor().on('focus', me.setWarehouseFilter, me);
        warehouseOffice.getEditor().on('change', me.changeOfficeHandler, me);
    },

    changeOfficeHandler: function (ctrl, newVal) {
        var me = this,
            warehouseOffice = me.getWarehouseOffice(),
            selectedRow = me.getGrid().getSelection()[0];

        if (!newVal || !warehouseOffice.field.entityListController || selectedRow.get('Warehouse'))
            return;

        var officeObj = warehouseOffice.field.entityListController.getDataContext()
                                       .getStore('WmsWarehouseOfficeList').getById(newVal.getEntityId());

        if (!officeObj)
            return;

        selectedRow.set('Warehouse', officeObj.data.Warehouse);
    },

    setWarehouseFilter: function () {
        var me = this,
            warehouseOffice = me.getWarehouseOffice().field,
            selectedWarehouse = me.getGrid().getSelection()[0].get('Warehouse'),
            filters = warehouseOffice.getFilterable().getFilters(),
            filter = new Ext.util.Filter({
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
        filter.setValue([selectedWarehouse]);
 
        filters.clear();
        filters.add(filter);
        //восстанавливаем значение поля, т.к. повторная фильтрация сбрасывает значение
        warehouseOffice.setValue(savedValue);
    },

    changeWarehouseHandler: function () {
        var me = this,
            selectedRow = me.getGrid().getSelection()[0];

        if (!selectedRow) return;

        selectedRow.set('WarehouseOffice', null);
    },

    addPurpose: function () {
        var gridStore = this.getDataContext().takeStore('YPassRequestList'),
            purposeModel = gridStore.model,
            newRec = new purposeModel(),
            grid = this.getGrid(),
            plugin = grid.getPlugin('cellplugin'),
            selModel = grid.getView().getSelectionModel();

        gridStore.insert(0, newRec);
        selModel.select(0);
        plugin.startEditByPosition({ row: 0, column: 1 });
    },

    deleteSelectedPurposes: function () {
        var grid = this.getGrid(),
            selection = grid.getView().getSelectionModel().getSelection(),
            gridStore = this.getDataContext().takeStore('YPassRequestList');

        gridStore.remove(selection);
    },

    deletePurpose: function (view, purpose) {
        var me = this,
            gridStore = me.getDataContext().takeStore('YPassRequestList');

        me.getGrid().focus();
        gridStore.remove(purpose);
    },

    enterToGrid: function () {
        var me = this,
            gridStore = me.getDataContext().takeStore('YPassRequestList'),
            grid = me.getGrid(),
            plugin = grid.getPlugin('cellplugin'),
            selModel = grid.getView().getSelectionModel();

        if (gridStore.getCount() > 0) {
            selModel.select(0);
            plugin.startEditByPosition({ row: 0, column: 1 });
        } else {
            me.addPurpose();
        }
    }
});
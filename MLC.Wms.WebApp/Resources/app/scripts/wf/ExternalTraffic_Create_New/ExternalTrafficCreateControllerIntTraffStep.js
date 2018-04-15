Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateControllerIntTraffStep', {
    extend: 'MLC.wf.controller.Card',

    refs: {
        addIntTraffBtn: '#AddIntTraff',
        delIntTraffBtn: '#DelIntTraff',
        intTraffGrid: '#IntTraffGrid',
        warehouse: '#Warehouse',
        warehouseOffice: '#WarehouseOffice',
        arrived: '#Arrived',
        departed: '#Departed'
    },

    constructor: function() {
        this.callParent(arguments);
    },

    loadData: function () {
        var me = this,
            departed = me.getDeparted().getEditor(),
            arrived = me.getArrived().getEditor(),
            warehouseOffice = me.getWarehouseOffice(),
            warehouse = me.getWarehouse();

        me.callParent(arguments);

        warehouse.getEditor().on('change', me.changeWarehouseHandler, me);
        warehouseOffice.getEditor().on('focus', me.setWarehouseFilter, me);
        warehouseOffice.getEditor().on('change', me.changeOfficeHandler, me);

        arrived.format = 'd.m H:i';
        departed.format = 'd.m H:i';
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

    onViewCreated: function() {
        var me = this,
            grid = me.getIntTraffGrid(),
            plugin = grid.getPlugin('cellplugin');
            gridStore = me.getDataContext().takeStore('InternalTraffic'),
            selModel = grid.getView().getSelectionModel();

        me.callParent(arguments);

        me.getAddIntTraffBtn().setHandler(me.addIntTraff, me);
        me.getDelIntTraffBtn().setHandler(me.delSelIntTraff, me);
        me.view.on('deleteIntTraf', me.delIntTraff, me);
        plugin.on('beforeedit', me.beforeIntTraffEdit, me);
        me.container.window.setWidth(800);

       if (gridStore.getCount() > 0) {
            selModel.select(0);
            plugin.startEditByPosition({ row: 0, column: 0 });
        }

    },

    onViewDisplayed: function() {
        var me = this;
        me.callParent(arguments);

        var keyMap = me.keyMap || [];

        keyMap.push(new Ext.util.KeyMap({
            eventName: 'keydown',
            target: me.view.getEl(),
            key: 45, // insert
            efaultEventAction: 'stopEvent',
            fn: me.addIntTraff,
            scope: me
        }));

        keyMap.push(new Ext.util.KeyMap({
            eventName: 'keydown',
            target: me.view.getEl(),
            key: 46, // delete
            efaultEventAction: 'stopEvent',
            fn: me.delSelIntTraff,
            scope: me
        }));

        me.keyMap = keyMap;
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
            plugin = grid.getPlugin('cellplugin'),
            selection = grid.getView().getSelectionModel().getSelection(),
            intTraffStore = this.getDataContext().takeStore('InternalTraffic');

        plugin.completeEdit();
        intTraffStore.remove(selection);

        if (grid.getStore().getCount()) {
            grid.getView().focusRow(0);
             grid.getView().getSelectionModel().select(0);
        }
        else
            grid.focus();
    },

    delIntTraff: function (view, intTraff) {
        var intTraffStore = this.getDataContext().takeStore('InternalTraffic'),
            grid = this.getIntTraffGrid();

        grid.focus();
        intTraffStore.remove(intTraff);
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

    changeWarehouseHandler: function () {
        var me = this,
            selectedRow = me.getIntTraffGrid().getSelection()[0];

        if (!selectedRow) return;

        selectedRow.set('WarehouseOffice', null);
    }
});
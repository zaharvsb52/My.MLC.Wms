Ext.define('MLC.wms.yExternalTraffic.wf.VehiclePassController', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'WebClient.common.workspace.RoomContainer',
        'WebClient.common.type.EntityId',
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    refs: {
        passList: '#passList'
    },

    passListController: undefined,

    newVehicleController: undefined,

    newPassController: undefined,

    editPassController: undefined,

    constructor: function(config) {
        var defaultConfig = {
            entityType: 'YVehiclePass'
        };
        config = Ext.merge(defaultConfig, config);
        this.callParent([config]);
    },

    adjustViewConfig: function () {
        var me = this;

        me.callParent(arguments);

        Ext.merge(me.viewBox.config, {
            dockedItems: [
                {
                    xtype: 'toolbar',
                    dock: 'bottom',
                    layout: {
                        type: 'hbox',
                        align: 'middle',
                        pack: 'end'
                    },
                    ui: 'footer',
                    items: Ext.Array.map(me.actions, function (a) {
                        var ac = MLC.wf.type.Action.create(a);
                        if (!ac.handler)
                            ac.setHandler(Ext.bind(me.handleAction, me, [a]));

                        return new Ext.button.Button(ac);
                    })
                }
            ]
        });
    },

    onViewCreated: function() {
        var me = this,
            listContainer = new WebClient.common.workspace.RoomContainer({ room: me.getPassList() });

        WebClient.common.controller.EntityControllerFactory.create(
            'YVehiclePass',
            WebClient.ViewKind.LIST,
            WebClient.ListViewMode.SELECT,//BROWSE,
            {},
            listContainer,
            function(instance) {
                //TODO: refactor, когда будут события в базовых контроллерах
                Ext.override(instance, {

                    getContainerCommandList: function() {
                        var tBarActions = [
                            new WebClient.common.commands.Command({ handler: me.addVehicle, scope: me, text: 'Добавить автомобиль', glyph: 0xf0d1 }),
                            new WebClient.common.commands.Command({ handler: me.addPass, scope: me, text: 'Добавить документ', glyph: 0xf0f6 }),
                            new WebClient.common.commands.Command({ handler: me.editPass, scope: me, text: 'Редактировать', glyph: 'xf2bf@ionicons' })
                        ];
                        return tBarActions;
                    },

                    // hide CRUD panel
                    adjustViewConfig: function() {
                        var defaultConfig = { gridConfig: { tbar: { items: null } } };
                        this.viewBox.config = Ext.merge(defaultConfig, this.viewBox.config);
                        this.callParent(arguments);
                    }

                });

                me.passListController = instance;
                instance.run();
            });
        
        me.callParent(arguments);
    },

    addVehicle: function () {
        var me = this,
            defaultValues = {};

        WebClient.common.controller.EntityControllerFactory.create(
            'YVehicle',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.CREATE,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                me.newVehicleController = instance;
                me.newVehicleController.onSave = function () { me.passListController.loadData(); };
            });

        var filters = me.getPassList().items.items[0].grid.getFilter().filterBinder.bindings.items;
        filters = filters.filter(function (item) { return item.filter; });
        filters = filters.filter(function (item) { return item.filter._property.indexOf("Vehicle_") > -1; });
        filters = filters.map(function (item) { return { fieldName: item.filter._property.substring(7), filterValue: item.filter._value[0] } });
        filters.forEach(function(filter) { defaultValues[filter.fieldName] = filter.filterValue; });

        me.newVehicleController.run({ defaultValues: defaultValues });
    },

    addPass: function () {
        var me = this,
            defaultValues = {};

        var filters = me.getPassList().items.items[0].grid.getFilter().filterBinder.bindings.items;
        filters = filters.filter(function (item) { return item.filter; });
        filters = filters.filter(function (item) { return item.filter._property.indexOf("Vehicle_") == -1; });
        filters = filters.map(function (item) { return { fieldName: item.filter._property, filterValue: item.filter._value[0] } });
        filters.forEach(function (filter) { defaultValues[filter.fieldName] = filter.filterValue; });
        var selectedPass = me.getPassList().items.items[0].grid.getSelected().get();
        if (selectedPass[0])
            defaultValues["Vehicle"] = selectedPass[0].data.Vehicle;

        WebClient.common.controller.EntityControllerFactory.create(
            'YVehiclePass',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.CREATE,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                me.newPassController = instance;
                me.newPassController.onSave = function () { me.passListController.loadData(); };
                me.newPassController.run({ defaultValues: defaultValues });
            });
    },

    editPass: function () {
        var me = this,
            selectedRow = me.getPassList().items.items[0].grid.selModel.lastSelected;

        WebClient.common.controller.EntityControllerFactory.create(
            'YVehiclePass',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.EDIT,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                me.editPassController = instance;
                me.editPassController.onSave = function () { me.passListController.loadData(); };
                if (selectedRow)
                    me.editPassController.run({ id: { id: selectedRow.raw.VehiclePassID.substring(0, selectedRow.raw.VehiclePassID.indexOf(":")), type: "YVehiclePass" } });
            });
    },

    getRequestParams: function (action) {
        var me = this,
            gr = me.getPassList(),
            innGr = gr.items.items[0].grid,
            ids = innGr.getSelectedId().get(),
            id = ids[0] ? ids[0].id : '';

        return { cancelAction: false, requestData: { selected: [id] } };
    }
});
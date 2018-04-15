Ext.define('MLC.wms.yExternalTraffic.wf.WorkerPassController', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'WebClient.common.workspace.RoomContainer',
        'WebClient.common.type.EntityId',
        'WebClient.common.commands.list.EditEntity',
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    refs: {
        passList: '#passList',
        workerCard: '#workerCard'
    },

    workerCardController: undefined,

    passListController: undefined,

    newWorkerController: undefined,

    newPassController: undefined,

    editPassController: undefined,

    constructor: function(config) {
        var defaultConfig = {
            entityType: 'WmsWorkerPass'
        };
        config = Ext.merge(defaultConfig, config);
        this.callParent([config]);
    },

    adjustViewConfig: function() {
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
                    items: Ext.Array.map(me.actions, function(a) {
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
            listContainer = new WebClient.common.workspace.RoomContainer({ room: me.getPassList() }),
            cardContainer = new WebClient.common.workspace.RoomContainer({ room: me.getWorkerCard() }),
            workerId = me.workerId;

        WebClient.common.controller.EntityControllerFactory.create(
            'WmsWorkerPass',
            WebClient.ViewKind.LIST,
            WebClient.ListViewMode.SELECT,
            {},
            listContainer,
            function(instance) {
                //TODO: refactor, когда будут события в базовых контроллерах
                Ext.override(instance, {
                    onViewCreated: function() {
                        this.callParent(arguments);
                        this.view.grid.on('select', function(grid, record, index, eOpts) {
                            var workerId = WebClient.common.type.EntityId.decode(record.get('Worker_WorkerID'));
                            me.workerCardController.container = cardContainer;
                            me.workerCardController.run({ id: workerId });
                        });
                    },

                    getContainerCommandList: function() {
                        var tBarActions = [
                            new WebClient.common.commands.Command({ handler: me.addDriver, scope: me, text: 'Добавить водителя', glyph: 'xf211@ionicons' }),
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

        WebClient.common.controller.EntityControllerFactory.create(
            'WmsWorker',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.EDIT,
            {},
            cardContainer,
            function(instance) {
                Ext.override(instance, {

                    // hide WF toolbar
                    adjustViewConfig: function() {
                        var defaultConfig = { dockedItems: null };
                        this.viewBox.config = Ext.merge(defaultConfig, this.viewBox.config);
                        this.viewBox.className = 'MLC.wms.yExternalTraffic.wf.WorkerCardView';
                        this.callParent(arguments);
                    }

                });

                me.workerCardController = instance;
                me.workerCardController.onSave = function() {
                    me.passListController.loadData();
                    me.workerCardController.loadData();
                };
                if (workerId)
                    me.workerCardController.run({ id: { id: workerId, type: "WmsWorker" } });
            });

        me.callParent(arguments);
    },

    addDriver: function() {
        var me = this,
            defaultValues = {};

        var filters = me.getPassList().items.items[0].grid.getFilter().filterBinder.bindings.items;
        filters = filters.filter(function (item) { return item.filter; });
        filters = filters.filter(function (item) { return item.filter._property.indexOf("Worker_") > -1; });
        filters = filters.map(function (item) { return { fieldName: item.filter._property.substring(7), filterValue: item.filter._value[0] } });
        filters.forEach(function (filter) { defaultValues[filter.fieldName] = filter.filterValue; });

        WebClient.common.controller.EntityControllerFactory.create(
            'WmsWorker',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.CREATE,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                me.newWorkerController = instance;
                me.newWorkerController.onSave = function () { me.passListController.loadData(); };
                me.newWorkerController.run({ defaultValues: defaultValues });
            });
    },

    addPass: function() {
        var me = this,
            defaultValues = {};

        var filters = me.getPassList().items.items[0].grid.getFilter().filterBinder.bindings.items;
        filters = filters.filter(function(item) { return item.filter; });
        filters = filters.filter(function(item) { return item.filter._property.indexOf("Worker_") == -1; });
        filters = filters.map(function(item) { return { fieldName: item.filter._property, filterValue: item.filter._value[0] } });
        filters.forEach(function(filter) { defaultValues[filter.fieldName] = filter.filterValue; });

        var worker = me.workerCardController.dataContext.takeStore('WmsWorkerCard').getAt(0);

        defaultValues["Worker"] = me.workerCardController.dataParams.id;
        defaultValues["Worker"].values = [
            { name: "WorkerLastName", value: worker.get('WorkerLastName') },
            { name: "WorkerName", value: worker.get('WorkerName') },
            { name: "WorkerMiddleName", value: worker.get('WorkerMiddleName') }
        ];

        defaultValues["Country"] = {
            id: 'RUS',
            type: 'IsoCountry',
            values: [ { name: "CountryCode", value: 'RUS' } ]
        };

        WebClient.common.controller.EntityControllerFactory.create(
            'WmsWorkerPass',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.CREATE,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                Ext.override(instance, {
                    onViewCreated: function () {
                        this.callParent(arguments);
                        this.view.items.items.forEach(function (item) {
                            if (item.itemId == "Worker") {
                                item.disabled = true;
                            }
                        });
                    }
                });

                me.newPassController = instance;
                me.newPassController.onSave = function () { me.passListController.loadData(); };
                me.newPassController.run({ defaultValues: defaultValues });
            });
    },

    editPass: function () {
        var me = this,
            selectedRow = me.getPassList().items.items[0].grid.selModel.lastSelected;

        WebClient.common.controller.EntityControllerFactory.create(
            'WmsWorkerPass',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.EDIT,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                me.editPassController = instance;
                me.editPassController.onSave = function () { me.passListController.loadData(); };
            });

        if (selectedRow)
            me.editPassController.run({ id: { id: selectedRow.raw.WorkerPassID.substring(0, selectedRow.raw.WorkerPassID.indexOf(":")), type: "WmsWorkerPass" } });
    },

    getRequestParams: function (action) {
        var me = this,
            gr = me.getPassList(),
            innGr = gr.items.items[0].grid,
            ids = innGr.getSelectedId().get(),
            id = ids[0] ? ids[0].id : '';

        return { cancelAction: false, requestData: { selected: [id] }};
    }
});
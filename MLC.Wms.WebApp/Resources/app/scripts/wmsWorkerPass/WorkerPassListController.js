Ext.define('MLC.wms.wmsWorkerPass.WorkerPassListController', {
    extend: 'WebClient.common.controller.EntityList',

    requires: [
        'WebClient.common.controls.CrudEntityGrid'
    ],

    worker: undefined,

    newPassController: undefined,

    constructor: function (config) {
        var me = this;
        this.callParent(arguments);
        if (config.container.windowConfig)
            if (config.container.windowConfig.ownerCmp)
                me.worker = config.container.windowConfig.ownerCmp.Worker;
    },

    adjustViewConfig: function (config) {
        this.callParent(arguments);

        var me = this,
            defaultBarItems = WebClient.common.controls.CrudEntityGrid.getTbarItems(config),
            newBarItems = defaultBarItems.filter(function (item) { return item.itemId != 'createentity'; }),
            createCommand = new WebClient.common.commands.Command({ handler: me.createWorkerPassWithKnownWorker, scope: me, text: 'Создать', glyph: 'xf12f@ionicons', itemId: 'createentity' }),
            filterCommand = { xtype: 'button', itemId: 'openfilter', enableToggle: true, glyph: 'xf4a5@ionicons', text: 'Фильтры', toggleHandler: function (btn, state) { me.view.filter.setCollapsed(!state); }};

        newBarItems.push(createCommand, filterCommand);
        var defaultConfig = { gridConfig: { tbar: { items: newBarItems } } };
        if (me.worker) // если Worker передан сверху - заменяем стандартную команду "Создать" на свою, с подстановкой Worker'a в создаваемый документ
            this.viewBox.config = Ext.merge(defaultConfig, this.viewBox.config);
    },

    createWorkerPassWithKnownWorker: function () {
        var me = this,
            defaultValues = {};

        WebClient.common.controller.EntityControllerFactory.create(
            'WmsWorkerPass',
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.CREATE,
            {},
            new WebClient.common.workspace.WindowContainer(),
            function (instance) {
                defaultValues["Worker"] = me.worker;
                me.newPassController = instance;
                me.newPassController.onSave = function () { me.loadData(); };
                me.newPassController.run({ defaultValues: defaultValues });
            });
    }
});
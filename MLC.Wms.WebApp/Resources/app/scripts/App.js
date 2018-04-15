Ext.require("WebClient.common.appController.EntityControllerProvider", function () {
    Ext.override(WebClient.common.appController.EntityControllerProvider, {
        createAutoClassEntry: function (entityType, classEntry) {
            classEntry.classConfig = Ext.merge(classEntry.classConfig || {}, { extend: "MLC.wms.appController.Entity" });
            this.callParent(arguments);
        }
    });
});

Ext.require("WebClient.common.controller.EntityControllerFactory", function () {
    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "YExternalTraffic",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: "MLC.wms.yExternalTraffic.ExternalTrafficListController",
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "YExternalTraffic",
        viewKind: WebClient.ViewKind.CARD,
        viewMode: WebClient.CardViewMode.CREATE, // только на создание
        className: "MLC.wms.yExternalTraffic.create.ExternalTrafficCardController",
        dataService: "WMS.DataServices.ExternalTrafficCreate.DataService"
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "YExternalTraffic",
        viewKind: WebClient.ViewKind.CARD,
        className: "MLC.wms.yExternalTraffic.ExternalTrafficCardController",
        dataService: "WMS.DataServices.ExternalTraffic.DataService"
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "YInternalTraffic",
        viewKind: WebClient.ViewKind.CARD,
        className: "MLC.wms.yInternalTraffic.InternalTrafficCardController",
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "WmsWorker",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: "MLC.wms.wmsWorker.WorkerListController",
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "WmsWorker",
        viewKind: WebClient.ViewKind.CARD,
        className: "MLC.wms.wmsWorker.WorkerCardController",
        //dataService: 'WMS.DataServices.Worker.DataService'
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });


    WebClient.common.controller.EntityControllerFactory.map({
        entityType: "WmsWorkerPass",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.SELECT,
        className: "MLC.wms.wmsWorkerPass.WorkerPassListController",
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: 'SchJob',
        viewKind: WebClient.ViewKind.CARD,
        className: 'MLC.wms.schJob.JobCardController',
        dataService: 'WMS.DataServices.Job.DataService'
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: 'SchJobParam',
        viewKind: WebClient.ViewKind.CARD,
        className: 'MLC.wms.schJob.JobParamCardController',
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: 'SchCronTrigger',
        viewKind: WebClient.ViewKind.CARD,
        className: 'MLC.wms.schJob.CronTriggerCardController',
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: 'SchSimpleTrigger',
        viewKind: WebClient.ViewKind.CARD,
        className: 'MLC.wms.schJob.SimpleTriggerCardController',
        dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });

    WebClient.common.controller.EntityControllerFactory.map({
        entityType: 'YInternalTrafficMonitor',
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: 'MLC.wms.yInternalTraffic.Monitor.InternalTrafficListController',
        dataService: 'WMS.DataServices.InternalTraffic.DataService'
        //dataService: WebClient.common.controller.EntityControllerFactory.AUTO_DATA_SERVICE
    });
});

Ext.require("WebClient.common.view.EntityViewRegistry", function () {
    WebClient.common.view.EntityViewRegistry.map({
        entityType: "YInternalTraffic",
        viewKind: WebClient.ViewKind.CARD,
        className: "MLC.wms.yInternalTraffic.InternalTrafficCard"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "YExternalTraffic",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: "MLC.wms.yExternalTraffic.ExternalTrafficList"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "WmsWorker",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: "MLC.wms.wmsWorker.WorkerList"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "WmsWorker",
        viewKind: WebClient.ViewKind.CARD,
        className: "MLC.wms.wmsWorker.WorkerCard"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "WmsPartner",
        viewKind: WebClient.ViewKind.CARD,
        className: "MLC.wms.wmsPartner.PartnerCard"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "WmsMandant",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.LOOKUP,
        className: "MLC.wms.wmsMandant.MandantLookupView"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "YInternalTrafficMonitor",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: "MLC.wms.yInternalTraffic.Monitor.InternalTrafficList"
    });

    WebClient.common.view.EntityViewRegistry.map({
        entityType: "CstReqCustoms",
        viewKind: WebClient.ViewKind.LIST,
        viewMode: WebClient.ListViewMode.BROWSE,
        className: "MLC.wms.cstReqCustoms.ReqCustomsList"
    });
    
});

Ext.define("MLC.wms.App", {
    extend: "Ext.ux.desktop.App",

    requires: [
        "MLC.wms.desktop.ShortcutModel",
        "WebClient.common.workspace.WindowContainer",
        "MLC.wms.desktop.menuCommands.BrowseEntities",
        "MLC.wms.desktop.menuCommands.RunController",
        "MLC.wms.desktop.menuCommands.RunControllerCstCustoms",
        "MLC.wms.desktop.menuCommands.OpenUrl",
        "MLC.wms.LoginForm",
        "MLC.wms.workspace.ClosableWindowContainer",
        "MLC.wms.desktop.menuCommands.ExecuteWorkFlow"
    ],

    workerCookieId: "WorkerID",

    rootpath: undefined,

    tenter: undefined,

    scriptspath: undefined,

    stylespath: undefined,

    imagespath: undefined,

    sessionTimeout: undefined,

    productVersion: undefined,

    reauthTimeoutId: undefined,

    authWindow: undefined,

    commandMap: undefined,

    init: function() {
        this.callParent();

        Ext.setGlyphFontFamily("FontAwesome");

        var me = this,
            desktop = me.getDesktop();

        desktop.mask("Загрузка...");

        this.initCommands();

        var menuStore = new Ext.data.TreeStore({
            proxy: {
                type: "direct",
                directFn: Server.WMS.DataServices.MainMenuService.DataService.loadMenu
            },
            autoLoad: true
        });

        Ext.define("WorkerModel",
        {
            extend: "Ext.data.Model",
            fields: [
                { name: "workerID", type: "int" },
                { name: "workerLastName", type: "string" },
                { name: "workerName", type: "string" },
                { name: "workerMiddleName", type: "string" }
            ]
        });

        var workerStore = new Ext.data.Store({
            proxy: {
                model: "WorkerModel",
                type: "direct",
                directFn: Server.WMS.DataServices.WorkerService.DataService.loadWorkers
            }
        });

        workerStore.on("load", this.buildWorkers, this);
        workerStore.load();

        menuStore.setRoot({ expanded: true });
        menuStore.on("load", this.buildMenu, this);

        me.resetAuthTimeout();
        Ext.Ajax.on("requestcomplete", me.resetAuthTimeout, me);
        me.authWindow = new MLC.wms.LoginForm({
            rootpath: me.rootpath,
            productVersion: me.productVersion,
            listeners: {
                loginsuccess: function() {
                    me.authWindow.hide();
                    me.authWindow.passwordField.setRawValue(null);
                }
            }
        });

        me.initShortcut();

        if (window.location.hash.length > 0) {
            var commandObj = Ext.Object.fromQueryString(window.location.hash.substring(1));
            me.executeCommand(commandObj);
        }

        Ext.tip.QuickTipManager.init();
    },

    initCommands: function() {
        var me = this,
            commandMap = new Ext.util.MixedCollection();
        commandMap.add("browseEntities", new MLC.wms.desktop.menuCommands.BrowseEntities());
        commandMap.add("runController", new MLC.wms.desktop.menuCommands.RunController());
        commandMap.add("runControllerCstCustoms", new MLC.wms.desktop.menuCommands.RunControllerCstCustoms());
        commandMap.add("executeWorkFlow", new MLC.wms.desktop.menuCommands.ExecuteWorkFlow());
        commandMap.add("openUrl", new MLC.wms.desktop.menuCommands.OpenUrl({
            rootpath: me.rootpath,
            listeners: {
                open: me.resetAuthTimeout,
                refresh: me.resetAuthTimeout,
                scope: me
            }
        }));
        me.commandMap = commandMap;
    },

    getDesktopConfig: function() {
        var me = this,
            ret = me.callParent();

        return Ext.apply(ret, {
            wallpaper: me.imagespath + "wallpaper.jpg",
            cls: "noselect",
            wallpaperStretch: true,

            shortcuts: Ext.create("Ext.data.Store", {
                model: "MLC.wms.desktop.ShortcutModel",
                data: [
                    { name: 'Заявка на пропуск', iconCls: 'passrequest-create-shortcut', command: 'command=executeWorkFlow&isModal=false&wfIdentity[package]=CLIENT&wfIdentity[code]=PASSREQUEST_CREATE&wfIdentity[version]=1.0.0.0' },
                    { name: 'Рейс', iconCls: 'externaltraffic-create-shortcut', command: 'command=executeWorkFlow&isModal=false&wfIdentity[package]=CLIENT&wfIdentity[code]=EXTERNALTRAFFIC_CREATE&wfIdentity[version]=1.0.0.0' },
                    { name: 'Рейс II', iconCls: 'externaltraffic-create-shortcut', command: 'command=executeWorkFlow&isModal=false&wfIdentity[package]=CLIENT&wfIdentity[code]=EXTERNALTRAFFIC_CREATE_NEW&wfIdentity[version]=1.0.0.0' },
                    { name: 'КПП - Прибытие', iconCls: 'checkpoint-arrival-shortcut', command: 'command=executeWorkFlow&isModal=false&wfIdentity[package]=CLIENT&wfIdentity[code]=PASSOFFICE_CHECKPOINT_ARRIVAL&wfIdentity[version]=1.0.0.0' },
                    { name: 'КПП - Убытие', iconCls: 'checkpoint-departure-shortcut', command: 'command=executeWorkFlow&isModal=false&wfIdentity[package]=CLIENT&wfIdentity[code]=PASSOFFICE_CHECKPOINT_DEPARTURE&wfIdentity[version]=1.0.0.0' },
                    { name: 'Авто на территории', iconCls: 'internaltraffic-monitor-shortcut', command: 'command=browseEntities&entityType=YInternalTrafficMonitor' }
                    //,{ name: 'Заявка на декларирование', iconCls: 'internaltraffic-monitor-shortcut', command: 'command=runControllerCstCustoms&controller=MLC.wms.cstReqCustoms.ReqCustomsController' }
                ]
            }),
            onShortcutItemClick: function(dataView, record) {
                me.executeMenuCommand.apply(me, [record.get("command")]);
            }
        });
    },

    getStartConfig: function() {
        var me = this,
            ret = me.callParent();

        return Ext.apply(ret, {
            title: me.productVersion,
            height: 300,
            toolConfig: {
                width: 100,
                items: [
                    {
                        text: "Выход",
                        glyph: 0xf08b,
                        handler: function() {
                            window.location = me.rootpath + "security/logout";
                        }
                    }
                ]
            }
        });
    },

    getTaskbarConfig: function() {
        var ret = this.callParent();

        return Ext.apply(ret, {
            trayItems: [
                { xtype: "trayclock", flex: 1 }
            ]
        });
    },

    createOrActivateWindowContainer: function(winId, winCfg) {
        var desktop = this.getDesktop(),
            dw = desktop.getWidth(),
            dh = desktop.getHeight(),
            th = desktop.taskbar.getHeight(),
            win = desktop.getWindow(winId);

        if (!win) {
            winCfg = Ext.merge({
                id: winId,
                title: "Загрузка...",
                glyph: 0xf1b3,
                layout: "fit",
                width: dw,
                height: dh - th,
                animCollapse: false,
                constrainHeader: true
            }, winCfg);
            win = desktop.createWindow(winCfg);
            win.on("titlechange", function(v, newTitle, oldTitle, eOpts) {
                v.taskButton.setText(Ext.util.Format.ellipsis(newTitle, 20));
            });
            win.wscontainer = new MLC.wms.workspace.ClosableWindowContainer({ window: win });
        }

        return win.wscontainer;
    },

    buildMenu: function(treeStore, records, successful, operation, node, eOpts) {
        var me = this,
            desktop = me.getDesktop(),
            menu = desktop.taskbar.startMenu;

        Ext.each(records, function(r) {
            var mi = me.buildSubMenuItem(r);
            menu.add(mi);
        });

        desktop.unmask();
    },

    buildSubMenuItem: function(node) {
        var me = this,
            menuItem = new Ext.menu.Item({ text: node.get("text"), handler: me.executeMenuCommand.bind(me, node.get("command")) }),
            menu;

        if (node.hasChildNodes()) {
            menu = new Ext.menu.Menu();
            node.eachChild(function(n) { menu.add(me.buildSubMenuItem(n)); });
            menuItem.setMenu(menu);
            menuItem.glyph = 0xf114;
        }

        return menuItem;
    },

    buildWorkers: function(store, records, successful, operation, node, eOpts) {
        var me = this,
            desktop = me.getDesktop(),
            workerMenu = desktop.taskbar.quickStart,
            expirationDate = new Date(),
            menuBtn = new Ext.menu.Menu();

        expirationDate.setFullYear(expirationDate.getFullYear() + 1);
        Ext.each(records, function(r) {
            if (records.length === 1) {
                Ext.util.Cookies.set(me.workerCookieId, r.get("workerID"), expirationDate);
            }


            var mi = new Ext.menu.Item({
                text: new Array(r.get("workerLastName"), r.get("workerName"), r.get("workerMiddleName")).join(" "),
                glyph: 0xf007,
                handler: function() {
                    Ext.util.Cookies.set(me.workerCookieId, r.get("workerID"), expirationDate);
                }
            });
            menuBtn.add(mi);
        });

        workerMenu.add(new Ext.button.Button({ glyph: 0xf007, menu: menuBtn }));
        desktop.unmask();
    },

    executeMenuCommand: function(command) {
        if (!command)
            return;

        var cmdObj = Ext.Object.fromQueryString(command, true);
        this.executeCommand(cmdObj);
    },

    executeCommand: function(commandObj) {
        var me = this,
            commandHandler = me.commandMap.getByKey(commandObj.command);
        if (!commandHandler)
            Ext.Error.raise("Неизвестная команда: " + commandObj.command);

        var windowId = commandHandler.getWindowId(commandObj),
            container = commandHandler.config.needContainer ? me.createOrActivateWindowContainer(windowId, commandHandler.windowConfig) : null;
        commandHandler.handler(commandObj, container, me);
    },

    reauthenticate: function() {
        var w = this.authWindow;
        w.center();
        w.show();
    },

    resetAuthTimeout: function() {
        var me = this;
        clearTimeout(me.reauthTimeoutId);
        me.reauthTimeoutId = setTimeout(me.reauthenticate.bind(me), me.sessionTimeout);
    },

    initShortcut: function() {
        var items = Ext.query(".ux-desktop-shortcut");
        if (items.length === 0)
            return;

        // max кол-во элементов в столбце
        var maxEl = 6;

        var maxW = Ext.Array.max(Ext.Array.map(items, function(x) { return x.clientWidth; }));
        var col = 0;
        var column = 0;
        var numberOfItems = 0;
        var padding = items[0].offsetLeft;


        for (var i = 0, len = items.length; i < len; i++) {
            numberOfItems += 1;

            if (column !== 0) {
                Ext.fly(items[i]).setXY([col, -items[i].offsetTop + items[i % maxEl].offsetTop]);
            }

            if (Math.floor(numberOfItems / maxEl) > column) {
                col = col + maxW + padding;
                column++;
            }

        }
    }
});
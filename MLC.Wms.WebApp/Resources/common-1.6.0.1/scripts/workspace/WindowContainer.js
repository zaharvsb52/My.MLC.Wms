Ext.define('WebClient.common.workspace.WindowContainer', {
    extend: 'WebClient.common.workspace.Container',

    requires: [
        'WebClient.common.workspace.ContainerHelper',
        'WebClient.common.controls.WindowHelper'
    ],

    /**
     * Инстанс окна, в которое нужно добавлять view. Если не передан, окно создается controller-ом. Обычно не используется
     * @type Ext.window.Window 
     */
    window: undefined,

    /**
     * Конфигурация для нового окна
     * @type Object 
     */
    windowConfig: undefined,

    /**
     * @override
     */
    applyContainerToViewConfig: function (viewConfig) {
        this.callParent(arguments);
        Ext.merge(viewConfig, { border: false, header: false });
    },

    /**
     * @override
     */
    putView: function (view) {
        this.callParent(arguments);

        var me = this,
            title = view.getTitle() || 'Новое окно';

        if (!me.window) {
            var wcfg = Ext.applyIf(me.windowConfig || {}, {
                constrain: true,
                width: 600,
                layout: 'fit',
                title: title,
                items: [view]
            });
            WebClient.common.controls.WindowHelper.adjustWindowSizeByContentSize(wcfg);
            me.window = new Ext.Window(wcfg);
        } else {
            me.window.setTitle(title);
            me.window.removeAll();
            me.window.add(view);
        }

        view.on('titlechange', function (v, newTitle, oldTitle, eOpts) {
            me.window.setTitle(newTitle);
        });
    },

    /**
     * @override
     */
    displayView: function (commandList) {
        var me = this,
            window = me.window;

        WebClient.common.workspace.ContainerHelper.removeCommandToolbar(window);
        if (commandList !== undefined && commandList.length > 0) {
            var supportedCommands = WebClient.common.workspace.ContainerHelper.getSupportedCommandList(me, commandList),
                toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar(supportedCommands, {
                    ui: 'footer',
                    dock: 'bottom',
                    layout: { pack: 'end' }
                });
            if (toolbarCfg)
                WebClient.common.workspace.ContainerHelper.addCommandToolbar(window, toolbarCfg);

            var closingCommands = Ext.Array.filter(supportedCommands, function (c) { return c.closeContainerOnSuccess; });
            Ext.each(closingCommands, function (c) { c.on('success', function () { window.close(); }); });
        }

        // рассчитываем максимальные размеры
        var body = Ext.getBody();
        window.setMaxHeight(body.getHeight());
        window.setMaxWidth(body.getWidth());

        window.show();

        me.onDisplay(me.view);
    }
});
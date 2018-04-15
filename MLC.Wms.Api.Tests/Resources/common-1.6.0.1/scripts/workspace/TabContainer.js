Ext.define('WebClient.common.workspace.TabContainer', {
    extend: 'WebClient.common.workspace.Container',

    requires: [
        'WebClient.common.workspace.ContainerHelper'
    ],

    /**
     * Инстанс закладки, в которое нужно добавлять view.
     * @type Ext.tab.Tab
     */
    tab: undefined,

    constructor: function (config) {
        this.callParent(arguments);

        if (!this.tab)
            Ext.Error.raise('tab должен быть передан в TabContainer');
    },

    /**
     * @override
     */
    applyContainerToViewConfig: function(viewConfig) {
        this.callParent(arguments);
        Ext.merge(viewConfig, { border: false, header: false });
    },

    /**
     * @override
     */
    putView: function(view) {
        this.callParent(arguments);

        var tab = this.tab,
            title = view.getTitle() || 'Новое окно';

        tab.setTitle(title);
        tab.removeAll();
        tab.add(view);

        view.on('titlechange', function (v, newTitle, oldTitle, eOpts) {
            tab.setTitle(newTitle);
        });
    },

    /**
     * @override
     */
    displayView: function(commandList) {
        var me = this,
            tab = me.tab;

        WebClient.common.workspace.ContainerHelper.removeCommandToolbar(tab);
        if (commandList !== undefined && commandList.length > 0) {
            var supportedCommands = WebClient.common.workspace.ContainerHelper.getSupportedCommandList(me, commandList),
                toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar(supportedCommands);
            if (toolbarCfg)
                WebClient.common.workspace.ContainerHelper.addCommandToolbar(tab, toolbarCfg);
        }

        var panel = tab.up('tabpanel');
        if (panel)
            panel.setActiveTab(tab);

        me.onDisplay(me.view);
    }
});
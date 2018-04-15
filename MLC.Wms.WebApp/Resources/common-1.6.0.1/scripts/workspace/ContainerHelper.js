Ext.define('WebClient.common.workspace.ContainerHelper', {

    singleton: true,

    toolbarItemId: 'commandList',

    getSupportedCommandList: function(container, allCommands) {
        return Ext.Array.filter(allCommands, function (command) {
            return !Ext.Array.some(command.unsupportedContainerTypes || [], function (cname) {
                var c = Ext.ClassManager.get(cname);
                return !!c && (container instanceof c);
            });
        });
    },

    /**
     * @param {Array} commandList
     */
    createCommandToolbar: function(commandList, config) {
        if (!commandList || commandList.length === 0)
            return;
       
        var defaultConfig = {
            xtype: 'toolbar',
            itemId: this.toolbarItemId,
            items: commandList,
            dock: 'top',
            layout: { pack: 'start' },
            defaults: function (config) {
                var defaults = {};
                if (!config.xtype || config.xtype === 'button' || (config.isComponent && config.isXType('button')))
                    defaults = Ext.apply({ minWidth: 75 }, defaults);
                return defaults;
            }
        };
        return Ext.merge(defaultConfig, config);
    },

    /**
     * 
     * @param {Ext.panel.AbstractPanel} panel
     */
    removeCommandToolbar: function (panel) {
        var oldtbar = panel.down('#' + this.toolbarItemId);
        if (oldtbar) {
            panel.removeDocked(oldtbar);
        }


    },

    /**
     * 
     * @param {Ext.panel.AbstractPanel} panel
     */
    addCommandToolbar: function(panel, tbar) {
        panel.addDocked(tbar);
    }

});
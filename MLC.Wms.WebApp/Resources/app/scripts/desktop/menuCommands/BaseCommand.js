Ext.define("MLC.wms.desktop.menuCommands.BaseCommand", {
    config: {
        needContainer: true
    },

    getWindowId: function (params) {
        if (params.windowId)
            return params.windowId;
        return null;
    },

    constructor: function(config) {
        this.initConfig(config);
        return this;
    }
});
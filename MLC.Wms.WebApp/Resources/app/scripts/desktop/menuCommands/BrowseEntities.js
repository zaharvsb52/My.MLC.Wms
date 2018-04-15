Ext.define('MLC.wms.desktop.menuCommands.BrowseEntities', {
    extend: "MLC.wms.desktop.menuCommands.BaseCommand",

    uses: [
        'WebClient.common.appController.EntityControllerProvider'
    ],

    getWindowId: function (params) {
        if (params.windowId)
            return params.windowId;

        return 'browse_' + params.entityType;
    },

    handler: function (params, container) {
        WebClient.common.appController.EntityControllerProvider.take(
            params.entityType,
            function (instance) {
                instance.browse(container, params.filters, params.sorters, params.page);
            },
            this);
    }
});
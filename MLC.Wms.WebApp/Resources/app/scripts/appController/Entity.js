Ext.define('MLC.wms.appController.Entity', {

    extend: 'WebClient.common.appController.Entity',

    getWindowConfig: function (mode, kind) {
        if (mode === WebClient.ViewKind.LIST)
            return {};

        if (this.entityType === 'SchJob')
            return {};

        if (this.entityType === 'YExternalTraffic') {
            return kind === WebClient.CardViewMode.EDIT ? {} : { width: 840, height: 450 }
        }

        if (this.entityType === 'WmsWorker') { return { width: 600, height: 450 } }
        return { width: 600 };
    },

    getDefaultBrowseContainer: function () {
        return MLC.wms.application.createOrActivateWindowContainer(
            'browse_' + this.entityType,
            this.getWindowConfig(WebClient.ViewKind.LIST, WebClient.ListViewMode.BROWSE));
    },

    getDefaultSelectContainer: function () {
        return MLC.wms.application.createOrActivateWindowContainer(
            'select_' + this.entityType + new Date().getTime(),
            this.getWindowConfig(WebClient.ViewKind.LIST, WebClient.ListViewMode.SELECT));
    },

    getDefaultViewContainer: function (entityId) {
        return MLC.wms.application.createOrActivateWindowContainer(
            'view_' + entityId.type + '_' + entityId.id,
            this.getWindowConfig(WebClient.ViewKind.CARD, WebClient.ListViewMode.VIEW));
    },

    getDefaultEditContainer: function (entityId) {
        return MLC.wms.application.createOrActivateWindowContainer(
            'edit_' + entityId.type + '_' + entityId.id,
            this.getWindowConfig(WebClient.ViewKind.CARD, WebClient.CardViewMode.EDIT));
    },

    getDefaultCreateContainer: function () {
        return MLC.wms.application.createOrActivateWindowContainer(
            'create_' + this.entityType + new Date().getTime(),
            this.getWindowConfig(WebClient.ViewKind.CARD, WebClient.CardViewMode.CREATE));
    }
});
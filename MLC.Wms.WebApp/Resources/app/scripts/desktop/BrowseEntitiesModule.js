Ext.define('MLC.wms.desktop.BrowseEntitiesModule', {
    extend: 'Ext.ux.desktop.Module',

    uses: [
        'WebClient.common.appController.EntityControllerProvider',
        'WebClient.common.workspace.WindowContainer'
    ],

    text: undefined,

    entityType: undefined,

    init: function () {
        this.launcher = {
            text: this.text,
            glyph: 0xf1b3,
            handler: this.browseEntities,
            scope: this,
            entityType: this.entityType
        }
    },

    browseEntities: function (src) {
        var win = this.createWindow(src),
            container = new WebClient.common.workspace.WindowContainer({ window: win });

        WebClient.common.appController.EntityControllerProvider.take(
            this.entityType,
            function (instance) {
                instance.browse(container);
            },
            this);

        return win;
    },

    createWindow: function (src) {
        var desktop = this.app.getDesktop();
        var win = desktop.getWindow('browseEntity_' + src.entityType);
        if (!win) {
            win = desktop.createWindow({
                id: 'browseEntity_' + src.entityType,
                title: src.text,
                glyph: src.glyph,
                layout: 'fit',
                width: 640,
                height: 480,
                animCollapse: false,
                constrainHeader: true
            });
        }
        win.show();
        return win;
    }
});
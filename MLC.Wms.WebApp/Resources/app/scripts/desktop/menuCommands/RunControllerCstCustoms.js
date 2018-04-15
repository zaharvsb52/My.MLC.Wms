Ext.define('MLC.wms.desktop.menuCommands.RunControllerCstCustoms', {
    extend: "MLC.wms.desktop.menuCommands.BaseCommand",

    getWindowId: function(params) {
        return 'run_' + params.controller.replace(/\./gi, '_');
    },

    config: {
        needContainer: false
    },

    handler: function(params, container, parentWin) {
        Server.WMS.DataServices.ReqCustoms.DataService.getAvailableMandants(null, this.onGetAvailableMandants.bind(this, params,parentWin));
    },

    onGetAvailableMandants: function (params, parentWin, mndCount) {

        if (mndCount === 0) {
            WebClient.showError('У вас нет доступа к таможенным мандантам');
            return;
        }

        var container = parentWin.createOrActivateWindowContainer(this.getWindowId(params));

        var controllerBox = WebClient.lazy(params.controller, Ext.apply(params, { container: container }));
        WebClient.require(controllerBox, function() {
            var controller = WebClient.unbox(controllerBox);
            controller.run(params.params);
        });
    }
});
Ext.define('MLC.wms.desktop.menuCommands.RunController', {
    extend: "MLC.wms.desktop.menuCommands.BaseCommand",

    //constructor: function (config) {
    //    Ext.apply(this, config);
    //    this.mixins.observable.constructor.call(this, config);

    //    this.callParent([config]);
    //},

    getWindowId: function (params) {
        return 'run_' + params.controller.replace(/\./gi, '_');
    },

    handler: function (params, container) {
        var controllerBox = WebClient.lazy(params.controller, Ext.apply(params, { container: container }));
        WebClient.require(controllerBox, function () {
            var controller = WebClient.unbox(controllerBox);
            controller.run(params.params);
        });
    }
});
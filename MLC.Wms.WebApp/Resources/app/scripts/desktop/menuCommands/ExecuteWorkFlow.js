Ext.define("MLC.wms.desktop.menuCommands.ExecuteWorkFlow", {
    extend: "MLC.wms.desktop.menuCommands.BaseCommand",

    requires: [
        "MLC.wf.workspace.WfDialogWindowContainer",
        "MLC.wf.controller.Dispatcher"
    ],

    config: {
        needContainer: false
    },

    handler: function(params) {
        var defaultModal = typeof params.isModal === "undefined",
            container = new MLC.wf.workspace.WfDialogWindowContainer({
                windowConfig: {
                    modal: defaultModal || params.isModal === 'true'
                }
            });
        var dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: params.wfIdentity,
            container: container
        });
        dispatcher.run();
    }
});
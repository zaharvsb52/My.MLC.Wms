Ext.define('MLC.wf.commands.RunWorkflowForEntity', {
    extend: 'WebClient.common.commands.Command',

    requires: [
        'WebClient.common.view.ICardView',
        'WebClient.common.workspace.WindowContainer',
        'MLC.wf.controller.Dispatcher'
    ],

    /**
     * Id workflow для запуска
     * @type MLC.wf.type.WorkflowIdentity
     */
    workflowIdentity: undefined,

    /**
     * Достает view как сервис из текущего Site-а 
     * @return {WebClient.common.view.ICardView}
     */
    getCardView: function() {
        if (!this.cardView)
            this.cardView = this.getSite().getService('WebClient.common.view.ICardView');
        return this.cardView;
    },

    handler: function() {
        var view = this.getCardView(),
            record = view.getRecord(),
            id = Ext.isFunction(record.getEntityId) ? record.getEntityId() : record.getId(),
            container = new WebClient.common.workspace.WindowContainer(),
            dispatcher = new MLC.wf.controller.Dispatcher({ workflowIdentity: this.workflowIdentity, inArguments: { EntityId: id.id }, container: container});
        this.relayEvents(dispatcher, ['reload', 'beginrequest', 'endrequest']);
        dispatcher.run();
    }
});
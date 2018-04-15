Ext.define('WebClient.common.commands.CallEntityController', {
    extend: 'WebClient.common.commands.Command',

    uses: [
        'WebClient.common.appController.EntityControllerProvider'
    ],

    entityType: undefined,

    /**
     * Instance of the controller. Optional, in this case instance will be taken from {@link WebClient.common.appController.EntityControllerProvider}
     * @type {WebClient.common.appController.Entity} 
     */
    controller: null,

    handler: function() {
        if (this.controller == null) {
            WebClient.common.appController.EntityControllerProvider.take(
                this.getEntityType(),
                function(instance) {
                    this.controller = instance;
                    this.callController();
                },
                this);
        } else
            this.callController();
    },

    getEntityType: function() {
        if (!this.entityType)
            Ext.Error.raise('entityType is not defined, or the logic of its taking is not overriden in the command');
        return this.entityType;
    },

    /**
     * To be overriden
     * @protected
     */
    callController: function() {
    }
});
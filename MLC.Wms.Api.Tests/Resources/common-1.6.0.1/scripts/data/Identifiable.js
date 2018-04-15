Ext.define('WebClient.common.data.Identifiable', {

    requires: ['WebClient.common.type.EntityId'],

    /**
     * @type String
     */
    entityType: undefined,

    getEntityId: function() {
        var id = this.getId();
        return id ? WebClient.common.type.EntityId.decode(id) : null;
    }

});
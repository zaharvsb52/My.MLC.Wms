Ext.define('WebClient.common.data.field.EntityId', {
    extend: 'Ext.data.field.Field',

    alias: 'data.field.entityId',

    requires: ['WebClient.common.type.EntityId'],

    getType: function() {
        return 'EntityId';
    }
});
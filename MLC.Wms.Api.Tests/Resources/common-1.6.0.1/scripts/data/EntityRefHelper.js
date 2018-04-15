Ext.define('WebClient.common.data.EntityRefHelper', {
    requires: ['WebClient.common.type.EntityRef'],

    singleton: true,

    /**
     * Этот метод создает WebClient.common.type.EntityRef по переданным Ext.data.Model и EntityRefDescriptor
     * @param {Ext.data.Model} record
     * @param {EntityRefDescriptor} entityRefDescriptor
     * @return {WebClient.common.type.EntityRef}
     */
    createEntityRef: function(record, entityRefDescriptor) {
        Assert.notEmpty(record, 'record');
        Assert.notEmpty(entityRefDescriptor, 'entityRefDescriptor');

        var entityId = record.getEntityId();

        var values = null;

        if (entityRefDescriptor.fields)
            values = Ext.Array.map(entityRefDescriptor.fields, function(f) { return { name: f.name, value: record.get(f.name) }; });

        return new WebClient.common.type.EntityRef({
            type: entityId.type,
            id: entityId.id,
            values: values
        });
    }
});
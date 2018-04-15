Ext.define('WebClient.common.metadata.MetadataManager', {
    singleton: true,

    getDefaultFieldType: function() {
        return 'string';
    },

    getDefaultDomain: function(field) {
        var DomainType = WebClient.common.metadata.DomainType;

        switch (field.type) {
        case 'string':
            return { type: DomainType.string, maxLength: 200 };

        case 'float':
        case 'number':
        case 'int':
        case 'integer':
            return { type: DomainType.numeric };

        case 'boolean':
        case 'bool':
            return { type: DomainType.boolean };

        case 'date':
            return { type: DomainType.dateTime };

        default:
            return { type: DomainType.unknown };
        }
    }
});
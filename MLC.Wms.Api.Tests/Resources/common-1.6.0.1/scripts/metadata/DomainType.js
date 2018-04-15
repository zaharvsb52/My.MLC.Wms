Ext.define('WebClient.common.metadata.DomainType', {
    alias: ['WebClient.DomainType'],

    statics: {
        string: 'String',
        dateTime: 'DateTime',
        numeric: 'Numeric',
        boolean: 'Boolean',
        enumeration: 'Enum',
        entityId: 'EntityId',
        entityRef: 'EntityRef',
        entityRefCollection: 'EntityRefCollection',
        unknown: 'Unknown'
    }

});
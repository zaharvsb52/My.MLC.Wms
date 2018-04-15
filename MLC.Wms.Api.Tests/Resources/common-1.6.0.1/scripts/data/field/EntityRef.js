Ext.define('WebClient.common.data.field.EntityRef', {
    extend: 'Ext.data.field.Field',

    alias: 'data.field.entityRef',

    requires: ['WebClient.common.type.EntityRef'],

    sortType: function(value) {
        return value ? value.id : undefined; // When sorting, order by id
    },

    isEqual: function(lhs, rhs) {
        if (lhs && Ext.isFunction(lhs.equals))
            return lhs.equals(rhs);
        if (rhs && Ext.isFunction(rhs.equals))
            return rhs.equals(lhs);

        return this.callParent(arguments);
    },

    convert: function(value) {
        if (!value)
            return null;

        return Ext.getClassName(value) === 'WebClient.common.type.EntityRef' ? value : new WebClient.common.type.EntityRef(value);
    },

    serialize: function(value) {
        if (!value)
            return null;

        return { id: value.id, type: value.type };
    },

    getType: function() {
        return 'EntityRef';
    }
});
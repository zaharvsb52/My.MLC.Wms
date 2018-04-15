Ext.define('WebClient.common.data.field.EntityRefCollection', {
    extend: 'Ext.data.field.Field',

    alias: 'data.field.entityRefCollection',

    requires: ['WebClient.common.type.EntityRefCollection'],

    sortType: function(value) {
        return value ? value.items.length : undefined; // Сортируем пока по количеству :)
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

        return Ext.getClassName(value) === 'WebClient.common.type.EntityRefCollection' ? value : new WebClient.common.type.EntityRefCollection(value);
    },

    serialize: function(value) {
        if (!value)
            return null;

        return { type: value.type, items: value.items };
    },

    getType: function() {
        return 'EntityRefCollection';
    }
});
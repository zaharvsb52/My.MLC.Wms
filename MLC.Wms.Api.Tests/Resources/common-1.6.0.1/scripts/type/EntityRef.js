Ext.define('WebClient.common.type.EntityRef',
    {
        requires: ['WebClient.common.type.EntityId'],

        mixins: {
            jsonSerializable: 'WebClient.common.JsonSerializable'
        },

        id: undefined,
        type: undefined,
        values: undefined,

        constructor: function(config) {
            if (!Ext.isDefined(config) || !Ext.isDefined(config.id) || !Ext.isDefined(config.type) || !Ext.isDefined(config.values))
                Ext.Error.raise('Invalid configuration format');
            Ext.apply(this, config);
        },

        getEntityId: function() {
            return new WebClient.common.type.EntityId({ id: this.id, type: this.type });
        },

        getValuesObject: function() {
            var v = {};
            Ext.Array.each(this.values, function (item) { v[item.name] = item.value; });
            return v;
        },

        equals: function(obj) {
            var me = this;
            if (!obj)
                return false;

            return me.id === obj.id && me.type === obj.type;
        },

        toString: function() {
            var me = this;
            if (Ext.isEmpty(me.values))
                return me.id + ':' + me.type;

            return me.values.reduce(function(m, n) { return n ? (m ? m + ', ' + n.name + ': ' + n.value : n.name + ': ' + n.value) : m; }, '');
        },

        //values are ignored - no need for them on server
        toJSON: function() {
            if (!this.id || !this.type)
                return Ext.JSON.encode(null);
            return Ext.JSON.encode({ id: this.id, type: this.type });
        }
    });
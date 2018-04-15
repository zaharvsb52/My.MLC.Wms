Ext.define('WebClient.common.type.EntityId',
    {
        mixins: {
            jsonSerializable: 'WebClient.common.JsonSerializable'
        },

        id: undefined,
        type: undefined,

        statics: {
            decode: function(str) {
                if (!Ext.isString(str))
                    return null;

                var values = str.split(':');
                if (values.length < 2)
                    Ext.Error.raise('Invalid entity key format');

                var id = values[0];
                var type = values[1];

                if (!id || !type)
                    Ext.Error.raise('Invalid entity key format');

                return Ext.create('WebClient.common.type.EntityId', { id: id, type: type });
            }
        },

        constructor: function(config) {
            if (!Ext.isDefined(config) || !Ext.isDefined(config.id) || !Ext.isDefined(config.type))
                Ext.Error.raise('Invalid configuration format');

            Ext.apply(this, config);
        },

        equals: function(obj) {
            var me = this;
            if (!obj)
                return false;

            return me.id == obj.id && this.typesEqual(me.type, obj.type);
        },

        /** Сравнивает два имени типа с учетом существования полного и краткого форматов.
     * @private
     */
        typesEqual: function(type1, type2) {
            if (type1 === type2)
                return true;

            if (type1 && type2) {
                // возможно, один из типов полный, а другой - короткий
                var index1 = type1.lastIndexOf('.');
                if (index1 > 0 && type1.substr(index1 + 1) === type2)
                    return true;

                var index2 = type2.lastIndexOf('.');
                if (index2 > 0 && type2.substr(index2 + 1) === type1)
                    return true;
            }

            return false;
        },

        toString: function() {
            return this.id + ':' + this.type;
        },

        toJSON: function() {
            return Ext.JSON.encode({ id: this.id, type: this.type });
        }
    });
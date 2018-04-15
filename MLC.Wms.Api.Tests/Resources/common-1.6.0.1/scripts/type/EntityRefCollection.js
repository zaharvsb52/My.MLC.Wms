Ext.define('WebClient.common.type.EntityRefCollection', {
    requires: [
        'WebClient.common.type.EntityRef'
    ],

    mixins: {
        jsonSerializable: 'WebClient.common.JsonSerializable'
    },

    /**
     * @type String 
     */
    type: undefined,

    /**
     * @type {[WebClient.common.type.EntityRef]} 
     */
    items: undefined,

    constructor: function(config) {
        if (!Ext.isDefined(config) || !Ext.isDefined(config.type) || !Ext.isDefined(config.items))
            Ext.Error.raise('Invalid configuration format');

        this.type = config.type;
        this.items = Ext.Array.map(config.items, function(itemConfig) {
            return itemConfig instanceof WebClient.common.type.EntityRef
                ? itemConfig
                : new WebClient.common.type.EntityRef(itemConfig);
        });
    },

    toString: function() {
        if (Ext.isEmpty(this.items))
            return '';

        return this.items.join(', ');
    },

    //values are ignored - no need for them on server
    toJSON: function() {
        return Ext.JSON.encode({
            type: this.type,
            items: this.items
        });
    },

    equals: function(obj) {
        var me = this;
        if (!obj)
            return false;

        return me.type === obj.type && me.itemsDifference(me.items, obj.items).length === 0 && me.itemsDifference(obj.items, me.items).length === 0;
    },


    /**
     * @private
     */
    itemsDifference: function(itemsA, itemsB) {
        var clone = Ext.Array.slice(itemsA),
            ln = clone.length,
            i,
            j,
            lnB;

        for (i = 0, lnB = itemsB.length; i < lnB; i++) {
            for (j = 0; j < ln; j++) {
                if (clone[j].equals(itemsB[i])) {
                    Ext.Array.erase(clone, j, 1);
                    j--;
                    ln--;
                }
            }
        }

        return clone;
    },

    statics: {
        /**
         * Создает пустую коллекцию для заданной сущности.
         * @param string entityType Имя сущности.
         */
        createEmpty: function(entityType) {
            return new WebClient.common.type.EntityRefCollection({
                type: entityType,
                items: []
            });
        }
    }
});
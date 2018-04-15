Ext.define('WebClient.common.data.change.ObjectNode', {
    requires: ['WebClient.common.data.change.ListNode'],

    __iid: undefined,

    constructor: function(iid, objectData) {
        Ext.apply(this, objectData);
        this.__iid = iid;
    },

    getIID: function() {
        return this.__iid;
    },

    createListChangeNode: function(listPropertyName) {
        var childListNode = new WebClient.common.data.change.ListNode();
        this[listPropertyName] = childListNode;
        return childListNode;
    }
});
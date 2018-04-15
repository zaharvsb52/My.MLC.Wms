Ext.define('WebClient.common.data.change.RootListNode', {

    //по сути наследует WebClient.common.data.change.ListNode
    statics:
        {
            IS_ROOT: '__rt',
            OBJECT_CHANGE_STATUS: '__c',
            OBJECT_CHANGE_STATUS_ADDED: 'a',
            OBJECT_CHANGE_STATUS_REMOVED: 'r'
        },

    registerModification: function(objNode, isNew) {
        if (isNew)
            objNode[WebClient.common.data.change.RootListNode.OBJECT_CHANGE_STATUS] = WebClient.common.data.change.RootListNode.OBJECT_CHANGE_STATUS_ADDED;
        objNode[WebClient.common.data.change.RootListNode.IS_ROOT] = 1;
    },

    registerRemoval: function(objNode) {
        objNode[WebClient.common.data.change.RootListNode.OBJECT_CHANGE_STATUS] = WebClient.common.data.change.RootListNode.OBJECT_CHANGE_STATUS_REMOVED;
        objNode[WebClient.common.data.change.RootListNode.IS_ROOT] = 1;
    }
});
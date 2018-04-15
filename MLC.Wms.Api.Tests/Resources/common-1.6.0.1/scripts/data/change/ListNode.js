Ext.define('WebClient.common.data.change.ListNode', {

    /**
     * Modified
     */
    m: undefined,

    /**
     * Added
     */
    a: undefined,

    /**
     * Removed
     */
    r: undefined,

    registerModification: function(objNode, isNew) {
        var list;
        if (isNew) {
            if (!this.a)
                this.a = [];
            list = this.a;
        } else {
            if (!this.m)
                this.m = [];
            list = this.m;
        }

        list.push(objNode.getIID());
    },

    registerRemoval: function(objNode) {
        if (!this.r)
            this.r = [];

        this.r.push(objNode.getIID());
    }

});
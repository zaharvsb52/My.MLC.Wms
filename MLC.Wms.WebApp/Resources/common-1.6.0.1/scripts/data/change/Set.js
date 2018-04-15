/**
 * Сериализованный вид примерно такой:
 * <code>
{
    "nodes" : {
        "Order" : [{
                    "Number" : "100_100",
                    "Id" : "1",
                    "__iid" : 1,
                    "__rt" : 1,
                    "Lines" : {
                        "m" : [2, 3, 4, 5, 6, 7, 8, 9, 10],
                        "a" : [11],
                        "d" : [12]
                    }
                }],
        "SalesOrderLine" : [{
                    "Quantity" : 502,
                    "Id" : "97",
                    "__iid" : 2
                }, {
                    "Quantity" : 503,
                    "Id" : "98",
                    "__iid" : 3
                }, {
                    "Quantity" : 502,
                    "Id" : "99",
                    "__iid" : 4
                }, {
                    "Quantity" : 503,
                    "Id" : "100",
                    "__iid" : 5
                }, {
                    "Quantity" : 504,
                    "Id" : "101",
                    "__iid" : 6
                }, {
                    "Quantity" : 502,
                    "Id" : "102",
                    "__iid" : 7
                }, {
                    "Quantity" : 501,
                    "Id" : "103",
                    "__iid" : 8
                }, {
                    "Quantity" : 503,
                    "Id" : "104",
                    "__iid" : 9
                }, {
                    "Quantity" : 506,
                    "Id" : "105",
                    "__iid" : 10
                }, {
                    "Id" : "",
                    "Product_Code" : "newcode",
                    "Product_Name" : "new name",
                    "Quantity" : 503,
                    "__iid" : 11
                }, {
                    "Id" : "96",
                    "__iid" : 12
                }]
            }
}</code>
 * 
 * ------------
 * ПРИМЕЧАНИЕ: Сейчас объекты безусловно добавляются. В будущем, для предотвращения цикличных ссылок, можно анализировать, есть ли уже 
 * node представляющий этот объект
 * ------------
 */
Ext.define('WebClient.common.data.change.Set', {
    requires: [
        'WebClient.common.data.change.RootListNode',
        'WebClient.common.data.change.ListNode',
        'WebClient.common.data.change.ObjectNode'
    ],

    mixins: {
        jsonSerializable: 'WebClient.common.JsonSerializable'
    },

    /**
     * Объект, каждый член которого представляет массив нодов одного typeName-а
     * @type Object
     */
    nodes: undefined,

    /**
     * Генератор внутренних iid
     * @type 
     */
    iidCounter: undefined,

    constructor: function() {
        this.nodes = {};
        this.iidCounter = 0;
    },

    getNextIID: function() {
        return ++this.iidCounter;
    },

    /**
     * Добавляет node представляющий объект в пачку. На него можно потом сослаться указав его iid.  
     * @param {Object} obj - сейчас игнорируется
     * @param {Object} objectData
     * @param {String} typeName
     * @return {WebClient.common.data.change.ObjectNode}
     */
    addObjectNode: function(obj, objectData, typeName) {
        if (!this.nodes[typeName])
            this.nodes[typeName] = [];

        var ret = new WebClient.common.data.change.ObjectNode(this.getNextIID(), objectData);
        this.nodes[typeName].push(ret);
        return ret;
    },

    /**
     * 
     * @param {WebClient.common.data.change.ListNode} listChangeNode
     * @param {Object} obj
     * @param {Object} objectData
     * @param {Boolean} isNew
     * @param {String} typeName
     * @return {WebClient.common.data.change.ObjectNode}
     */
    registerObjectModification: function(listChangeNode, obj, objectData, isNew, typeName) {
        var objNode = this.addObjectNode(obj, objectData, typeName);
        listChangeNode.registerModification(objNode, isNew);
        return objNode;
    },


    registerObjectDeletion: function(listChangeNode, obj, objectData, typeName) {
        var objNode = this.addObjectNode(obj, objectData, typeName);
        listChangeNode.registerRemoval(objNode);
        return objNode;
    },

    createRootListNode: function(typeName) {
        return new WebClient.common.data.change.RootListNode();
    },


    isEmpty: function() {
        return !WebClient.hasProperties(this.nodes);
    },

    /**
     * Переопределенная сериализация в json
     */
    toJSON: function() {
        return Ext.JSON.encode({ nodes: this.nodes });
    }

});
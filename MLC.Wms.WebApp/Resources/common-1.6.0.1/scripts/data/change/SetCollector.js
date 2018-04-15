/**
 * Собиральщик изменений в DataContext-е в виде {@link WebClient.common.data.change.Set ChangeSet-а}
 */
Ext.define('WebClient.common.data.change.SetCollector', {
    requires: [
        'Ext.data.Store',
        'Ext.data.writer.Writer',
        'WebClient.common.data.change.Set',
        'WebClient.common.data.DataContext',
        'WebClient.common.type.EntityId'
    ],

    /**
     * @cfg {Boolean} writeAllFields
     * См. {@link Ext.data.writer.Writer#writeAllFields}
     */
    writeAllFields: false,

    /**
     * @private
     * @type Ext.data.writer.Writer 
     */
    writer: undefined,

    /**
     * Набор изменений собираесый текущим объектом
     * @type WebClient.common.data.change.Set 
     */
    changeSet: undefined,

    ENTITYID_ID_FOR_NEW_ENTITY: null,

    statics:
        {
            /**
         * Возвращает изменения произошедшие в DataContext-е в виде WebClient.common.data.change.Set (может быть без наполнения, если изменений не обнаружено).
         * @param dataContext {WebClient.common.data.DataContext}
         * @param storeNamesToCollectOnly {Array/String} optional список имен store-ов, только по которым нужно собирать изменения. Если не передан,
         * все загруженные store просматриваются на изменения
         * @return {WebClient.common.data.change.Set}
         */
            collect: function(dataContext, storeNamesToCollectOnly) {
                Assert.notEmpty(dataContext);
                if (storeNamesToCollectOnly && !Ext.isArray(storeNamesToCollectOnly))
                    storeNamesToCollectOnly = [storeNamesToCollectOnly];

                var c = new WebClient.common.data.change.SetCollector();

                dataContext.stores.each(function(store) {

                    if ((!storeNamesToCollectOnly || Ext.Array.contains(storeNamesToCollectOnly, store.name)) && !c.shouldSkipStore(store))
                        c.collectRootStoreDeep(store);
                });

                return c.changeSet;
            }

        },

    /**
     * @private
     */
    constructor: function() {
        this.changeSet = new WebClient.common.data.change.Set();

        this.writer = new Ext.data.writer.Writer({
            writeAllFields: this.writeAllFields
        });
    },

    shouldSkipStore: function(store) {
        if (!(store instanceof Ext.data.Store))
            return true;
        if (!store.model.idField) {
            Ext.log({ msg: 'Store не содержит primary key и поэтому измениея в нем будут проигнорированы. StructureName: ' + WebClient.common.data.DataContext.getStructureName(store), level: 'warn' });
            return true;
        }
        return false;
    },

    /**
     * Собирает информацию об изменениях в переданном store в свой changeSet
     */
    collectRootStoreDeep: function(store) {
        var me = this,
            listNode = undefined;

        function listNodeAccessor() {
            if (!listNode)
                listNode = me.changeSet.createRootListNode(me.getTypeName(store));
            return listNode;
        }

        this.collectStoreDeep(store, listNodeAccessor);
    },

    /**
     * @private
     */
    collectStoreDeep: function(store, listNodeAccessor) {
        var me = this,
            typeName = me.getTypeName(store);

        store.each(function(rec) {
            me.collectRecordChangeDeep(rec, store, listNodeAccessor);
        });

        var removedRecs = store.getRemovedRecords();

        if (!Ext.isEmpty(removedRecs)) {
            var listNode = listNodeAccessor();

            Ext.Array.each(removedRecs, function(remrec) {

                var objData = {};
                objData[remrec.getIdProperty()] = remrec.getId();

                me.changeSet.registerObjectDeletion(listNode, remrec, objData, typeName);
            });
        }
    },

    /**
     * @private
     * @param {Ext.data.Model} rec
     * @param {Ext.data.Store} store
     * @param {Function} listNodeAccessor
     */
    collectRecordChangeDeep: function(rec, store, listNodeAccessor) {
        var me = this,
            recordNode = undefined,
            listNode = undefined,
            associations = rec.associations,
            role,
            roleName,
            childStore;

        function recordNodeAccessor() {
            if (!recordNode) {
                listNode = listNodeAccessor();

                var recordData = me.collectRecordFieldsChange(rec, store);
                recordNode = me.changeSet.registerObjectModification(listNode, rec, recordData, rec.phantom, me.getTypeName(store));
            }
            return recordNode;
        };

        if (store.filterNew(rec) || store.filterUpdated(rec))
            recordNodeAccessor(); //насильно добавляем нод с измененными данными

        for (roleName in associations) {
            if (!associations.hasOwnProperty(roleName))
                continue;

            role = associations[roleName];
            if (!role.isMany)
                continue; //only HasManyAssociation is supported

            childStore = role.getAssociatedItem(rec);
            if (!childStore || !childStore.isStore)
                continue;

            this.collectChildStoreDeep(childStore, role, recordNodeAccessor);
        }
    },

    /**
     * @private
     */
    collectChildStoreDeep: function(childStore, role, parentObjectNodeAccessor) {
        var childListNode = undefined;

        function childListNodeAccessor() {
            if (!childListNode) {
                var parentObjectNode = parentObjectNodeAccessor();
                childListNode = parentObjectNode.createListChangeNode(role.getterName);
            }
            return childListNode;
        };

        this.collectStoreDeep(childStore, childListNodeAccessor);
    },

    /**
     * @protected
     * @param {Ext.data.Model} rec
     */
    collectRecordFieldsChange: function(rec, store) {
        var data = this.writer.getRecordData(rec);

        //Если запись новая, это сущность и id явно не установлен - то создаем EntityId с указанием имени сущности
        if (store.filterNew(rec)) {
            var entityType = rec.entityType;
            if (entityType && !rec.getId())
                data[rec.getIdProperty()] = new WebClient.common.type.EntityId({ id: this.ENTITYID_ID_FOR_NEW_ENTITY, type: entityType });
        }
        return data;
    },

    /**
     * Возвращает null если связанный store (через HasMany association) не был даже создан 
     * @private 
     * @param ownerRec {Ext.data.Model}
     * @param association {Ext.data.HasManyAssociation}
     */
    getAssociatedStoreIfCreated: function(ownerRec, association) {
        return ownerRec[association.storeName];
    },

    /**
     * @private
     */
    getTypeName: function(store) {
        return WebClient.common.data.DataContext.getStructureName(store);
    }
});
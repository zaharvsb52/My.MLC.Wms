Ext.define('WebClient.common.appController.Entity', {

    requires: [
        'WebClient.common.controller.EntityControllerFactory',
        'WebClient.common.workspace.MainRoomContainer',
        'WebClient.common.workspace.WindowContainer'
    ],

    entityType: undefined,

    constructor: function(config) {
        Ext.apply(this, config);

        Assert.notEmpty(this.entityType, 'this.entityType');
    },

    browse: function(container, filters, sorters, page) {
        if (!container)
            container = this.getDefaultBrowseContainer();

        WebClient.common.controller.EntityControllerFactory.create(
            this.entityType,
            WebClient.ViewKind.LIST,
            WebClient.ListViewMode.BROWSE,
            { editOnDblClick: true },
            container,
            Ext.pass(this.onBrowseCreated, [{ filters: filters, sorters: sorters, page: page }], this),
            this);
    },

    getDefaultBrowseContainer: function() {
        return WebClient.common.workspace.MainRoomContainer.instance;
    },

    /**
     * @protected
     * @param {WebClient.common.controller.EntityList} controller
     */
    onBrowseCreated: function(dataParams, controller) {
        controller.run(dataParams);
    },

    select: function (container, filters, sorters, page) {
        if (!container)
            container = this.getDefaultSelectContainer();

        WebClient.common.controller.EntityControllerFactory.create(
            this.entityType,
            WebClient.ViewKind.LIST,
            WebClient.ListViewMode.SELECT,
            {},
            container,
            Ext.pass(this.onSelectCreated, [{ filters: filters, sorters: sorters, page: page }], this),
            this);
    },

    getDefaultSelectContainer: function() {
        return new WebClient.common.workspace.WindowContainer();
    },

    /**
     * @protected
     * @param {WebClient.common.controller.EntityList} controller
     */
    onSelectCreated: function (dataParams, controller) {
        controller.run(dataParams);
    },

    view: function (container, entityId) {
        Assert.notEmpty(entityId, 'entityId');
        Assert.notEmpty(entityId.type, 'entityId.type');

        if (!container)
            container = this.getDefaultViewContainer(entityId);

        WebClient.common.controller.EntityControllerFactory.create(
            entityId.type,
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.VIEW,
            {},
            container,
            Ext.pass(this.onViewCreated, [{ id: entityId }], this),
            this
        );
    },

    getDefaultViewContainer: function(entityId) {
        return new WebClient.common.workspace.WindowContainer();
    },

    /**
     * 
     * @param {Object} dataParams
     * @param {WebClient.common.controller.EntityCard} controller
     */
    onViewCreated: function(dataParams, controller) {
        controller.run(dataParams);
    },

    edit: function (container, entityId, callback) {
        Assert.notEmpty(entityId, 'entityId');
        Assert.notEmpty(entityId.type, 'entityId.type');

        if (!container)
            container = this.getDefaultEditContainer(entityId);

        WebClient.common.controller.EntityControllerFactory.create(
            entityId.type,
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.EDIT,
            {},
            container,
            Ext.pass(this.onEditCreated, [{ id: entityId }, callback], this),
            this);
    },

    getDefaultEditContainer: function(entityId) {
        return new WebClient.common.workspace.WindowContainer();
    },

    /**
     * 
     * @param {Object} dataParams
     * @param {WebClient.common.controller.EntityCard} controller
     */
    onEditCreated: function(dataParams, callback, controller) {
        controller.onSave = callback;
        controller.run(dataParams);
    },

    create: function (container, parentRecord, callback) {
        if (!container)
            container = this.getDefaultCreateContainer();

        WebClient.common.controller.EntityControllerFactory.create(
            this.entityType,
            WebClient.ViewKind.CARD,
            WebClient.CardViewMode.CREATE,
            {},
            container,
            Ext.pass(this.onCreateCreated, [{ parentRecord: parentRecord }, callback], this),
            this);
    },

    getDefaultCreateContainer: function() {
        return new WebClient.common.workspace.WindowContainer();
    },

    onCreateCreated: function(dataParams, callback, controller) {
        controller.onSave = callback;
        controller.run(dataParams);
    }
});
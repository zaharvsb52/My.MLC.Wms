Ext.define('WebClient.common.commands.CreateEntity', {
    extend: 'WebClient.common.commands.CallEntityController',

    uses: [
        'WebClient.common.view.IEntityView'
    ],

    mixins: {
        entitylistviewaware: 'WebClient.common.commands.list.EntityListViewAwareMixin'
    },

    text: 'Создать',

    glyph: 'xf12f@ionicons',

    minWidth: 75,

    /** @override */
    getEntityType: function() {
        return this.entityType || this.getSite().getService('WebClient.common.view.IEntityView').entityType;
    },

    /**
     * @protected
     */
    callController: function() {
        var listView = this.getEntityListView(),
            parentCardView = this.getSite().tryGetService('WebClient.common.view.IEntityCardView');
        this.controller.create(null, parentCardView != null ? parentCardView.getRecord() : null, function() { listView.getFilterable().load(); });
    }
});
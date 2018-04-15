Ext.define('WebClient.common.commands.list.ViewEntity', {
    extend: 'WebClient.common.commands.CallEntityController',

    mixins: {
        entitylistviewaware: 'WebClient.common.commands.list.EntityListViewAwareMixin'
    },

    text: 'Просмотреть',

    glyph: 'xf12e@ionicons',

    minWidth: 75,

    /**
     * @protected
     */
    callController: function() {
        var view = this.getEntityListView();
        var ids = view.getSelectedId().get();

        if (ids.length === 1)
            this.controller.view(null, ids[0]);
    },

    /** @override */
    getEntityType: function() {
        if (!this.entityType)
            return this.getEntityListView().entityType;
    }

});
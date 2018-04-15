Ext.define('WebClient.common.commands.list.EditEntity', {
    extend: 'WebClient.common.commands.CallEntityController',

    mixins: {
        entitylistviewaware: 'WebClient.common.commands.list.EntityListViewAwareMixin'
    },

    text: 'Редактировать',

    glyph: 'xf2bf@ionicons',

    minWidth: 75,

    /**
     * @protected
     */
    callController: function() {
        var view = this.getEntityListView();
        var ids = view.getSelectedId().get();

        if (ids.length === 1)
            this.controller.edit(null, ids[0], function() { view.getFilterable().load(); });
    },

    /** @override */
    getEntityType: function() {
        if (!this.entityType)
            return this.getEntityListView().entityType;
    }
});
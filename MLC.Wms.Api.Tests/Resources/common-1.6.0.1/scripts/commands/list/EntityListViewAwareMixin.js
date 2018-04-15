Ext.define('WebClient.common.commands.list.EntityListViewAwareMixin', {

    /** 
     * @private 
     * @type WebClient.common.view.IEntityListView
     * */
    entityListView: undefined,

    uses: [
        'WebClient.common.view.IEntityListView'
    ],

    /**
     * Достает view как сервис из текущего Site-а 
     * @return {WebClient.common.view.IEntityListView}
     */
    getEntityListView: function() {
        if (!this.entityListView)
            this.entityListView = this.getSite().getService('WebClient.common.view.IEntityListView');
        return this.entityListView;
    }
});
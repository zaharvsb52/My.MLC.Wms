Ext.define('WebClient.common.commands.list.ListViewAwareMixin', {

    /** 
     * @private 
     * @type WebClient.common.view.IEntityListView
     * */
    view: undefined,

    uses: [
        'WebClient.common.view.IListView'
    ],

    /**
     * Достает view как сервис из текущего Site-а 
     * @return {WebClient.common.view.IEntityListView}
     */
    getView: function() {
        if (!this.view)
            this.view = this.getSite().getService('WebClient.common.view.IListView');
        return this.view;
    },

    setView: function(view) {
        this.view = view;
    }
});
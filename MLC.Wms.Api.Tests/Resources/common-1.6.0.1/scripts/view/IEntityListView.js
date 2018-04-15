Ext.define('WebClient.common.view.IEntityListView', {
    extend: 'WebClient.common.Interface',

    mixins: {
        'WebClient.common.view.IListView': 'WebClient.common.view.IListView',
        'WebClient.common.view.IEntityView': 'WebClient.common.view.IEntityView'
    }
});
Ext.define('WebClient.common.view.IEntityCardView', {
    extend: 'WebClient.common.Interface',

    mixins: {
        'WebClient.common.view.ICardView': 'WebClient.common.view.ICardView',
        'WebClient.common.view.IEntityView': 'WebClient.common.view.IEntityView'
    }
});
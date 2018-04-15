Ext.define('WebClient.common.commands.BrowseEntities', {
    extend: 'WebClient.common.commands.CallEntityController',

    text: 'Список',

    glyph: 'xf3c9@ionicons',

    minWidth: 75,

    /**
     * @protected
     */
    callController: function() {
        this.controller.browse();
    }
});
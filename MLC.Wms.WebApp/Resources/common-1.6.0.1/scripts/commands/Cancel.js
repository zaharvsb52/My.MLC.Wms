Ext.define('WebClient.common.commands.Cancel', {
    extend: 'WebClient.common.commands.Command',

    closeContainerOnSuccess: true,

    /**
     * @override
     * @type 
     */
    unsupportedContainerTypes: [
        'WebClient.common.workspace.RoomContainer',
        'WebClient.common.workspace.MainRoomContainer',
        'WebClient.common.workspace.TabContainer'
    ],

    text: 'Отмена',

    glyph: 'xf405@ionicons',

    minWidth: 75
});
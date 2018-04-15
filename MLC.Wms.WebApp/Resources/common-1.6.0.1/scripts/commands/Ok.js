Ext.define('WebClient.common.commands.Ok', {
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
    
    text: 'ОК',

    glyph: 'xf3fe@ionicons',
    
    minWidth: 75
});
Ext.define('WebClient.common.workspace.MainRoomContainer', {
    extend: 'WebClient.common.workspace.Container',

    requires: [
        'WebClient.common.workspace.ContainerHelper'
    ],

    statics: {

        /**
         * @static
         * @type  WebClient.common.workspace.MainRoomContainer
         * */
        instance: undefined
    },

    /**
     * 
     * @type {Ext.panel.Panel} 
     */
    room: undefined,

    /**
     * 
     * @param {Ext.panel.Panel} room
     */
    setRoom: function(room) {
        WebClient.common.workspace.MainRoomContainer.instance.room = room;
    },

    getRoom: function() {
        if (!WebClient.common.workspace.MainRoomContainer.instance.room)
            Ext.Error.raise('Не установлен MainRoomContainer. Для установки вызовите WebClient.common.workspace.MainRoomContainer.instance.setRoom(extPanel) при запуске приложения.');
        return WebClient.common.workspace.MainRoomContainer.instance.room;
    },

    /**
     * @override
     */
    displayView: function(commandList) {
        var room = this.getRoom();
        room.removeAll(); //TODO: Ask user to confirm changes
        WebClient.common.workspace.ContainerHelper.removeCommandToolbar(room);

        room.add(this.view);

        if (commandList.length > 0) {
            var supportedCommands = WebClient.common.workspace.ContainerHelper.getSupportedCommandList(this, commandList),
                toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar(supportedCommands);
            if (toolbarCfg)
                WebClient.common.workspace.ContainerHelper.addCommandToolbar(room, toolbarCfg);
        }

        this.onDisplay(this.view);
    }

}, function(cls) {
    cls.instance = new WebClient.common.workspace.MainRoomContainer();
});
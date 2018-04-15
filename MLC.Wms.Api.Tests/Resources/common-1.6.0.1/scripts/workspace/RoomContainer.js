Ext.define('WebClient.common.workspace.RoomContainer', {
    extend: 'WebClient.common.workspace.Container',

    requires: [
        'WebClient.common.workspace.ContainerHelper'
    ],

    /**
     * Контейнерный компонент, в котором должен располагаться вид.
     * @type Ext.panel.Panel 
     */
    room: undefined,

    /**
     * @override
     */
    displayView: function(commandList) {
        var room = WebClient.unbox(this.room);

        room.removeAll(); //TODO: Ask user to confirm changes
        room.add(this.view);
        WebClient.common.workspace.ContainerHelper.removeCommandToolbar(room);

        if (commandList !== undefined && commandList.length > 0) {
            var supportedCommands = WebClient.common.workspace.ContainerHelper.getSupportedCommandList(this, commandList),
                toolbarCfg = WebClient.common.workspace.ContainerHelper.createCommandToolbar(supportedCommands);
            if (toolbarCfg)
                WebClient.common.workspace.ContainerHelper.addCommandToolbar(room, toolbarCfg);
        }

        this.onDisplay(this.view);
    }
});
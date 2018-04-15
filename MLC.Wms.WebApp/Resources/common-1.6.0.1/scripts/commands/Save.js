Ext.define('WebClient.common.commands.Save', {
    extend: 'WebClient.common.commands.Command',

    closeContainerOnSuccess: true,

    /**
     * @override
     * @type 
     */
    unsupportedContainerTypes: [
        'WebClient.common.workspace.WindowContainer'
    ],

    text: 'Сохранить',

    glyph: 'xf41f@ionicons',

    minWidth: 75
});
Ext.define('MLC.wf.workspace.WfDialogWindowContainer', {
    extend: 'WebClient.common.workspace.WindowContainer',

    constructor: function (config) {
        var defaultConfig = {
            windowConfig: {
                closable: false, // не даем пользователю закрыть окно без возврата управления в WF
                modal: true      // только модальный режим
            }
        };
        config = Ext.merge(defaultConfig, config);
        this.callParent([config]);
    }
});
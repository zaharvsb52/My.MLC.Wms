Ext.define('MLC.wms.controller.EntityCardWithWFToolbar', {
    extend: 'WebClient.common.controller.EntityCard',

    mixins: {
        ctrl: 'MLC.wms.controller.ExtendedController'
    },

    requires: [
        'WebClient.common.workspace.ContainerHelper',
        'WebClient.common.commands.Command',
        'MLC.wf.workspace.WfDialogWindowContainer',
        'MLC.wf.controller.Dispatcher'
    ],

    /**
     * @override
     */
    adjustViewConfig: function () {
        var me = this,
            config = me.viewBox.config;
        me.callParent();

        var defaultConfig = {
            dockedItems: [
                {
                    xtype: 'panel',
                    cls: 'graybg',
                    items: [
                        {
                            height: 50,
                            xtype: 'toolbar',
                            itemId: 'commandToolbar',
                            dock: 'top',
                            items: me.getTBarItems()
                        }
                    ]
                }
            ]
        };

        config = Ext.Object.merge(defaultConfig, config);
        me.viewBox.config = config;
    },

    onWfBtnClick: function (wfIdentity, collectInArgumentsCallback, wfResponseCallback) {
        var me = this;
        var container = new MLC.wf.workspace.WfDialogWindowContainer();
        var dispatcher = new MLC.wf.controller.Dispatcher({
            workflowIdentity: wfIdentity,
            container: container,
			inArguments: { EntityId: me.dataParams.id.id },
            listeners: {
                reload: function () {
                    me.reload();
                },
                beginwait: function () {
                    me.beginWait();
                },
                endwait: function () {
                    me.endWait();
                }
            }
        });
        // подписываемся на окончание wf (если есть что)
        if (wfResponseCallback)
            dispatcher.on('wfResponse', wfResponseCallback);
        // запускаем wf
        dispatcher.run();
    },

    getTBarItems: function () {
        return new Array();
    }
});
Ext.define('MLC.wms.wf.Passoffice_CheckPoint_Arrival.ConfirmPassRequestController', {
    extend: 'MLC.wf.controller.Card',

    requires: [
    'MLC.wf.type.Action',
    'MLC.wf.type.WfAction',
    'MLC.wf.type.UrlAction'
    ],

    adjustViewConfig: function () {
        var me = this;

        Ext.merge(me.viewBox.config, {
            structureName: this.structureName,
            mode: this.mode,
            dockedItems: [
                {
                    xtype: 'toolbar',
                    dock: 'bottom',
                    layout: {
                        type: 'hbox',
                        align: 'middle',
                        pack: 'end'
                    },
                    ui: 'footer',
                    items: Ext.Array.map(me.actions, function (a) {
                        var ac = MLC.wf.type.Action.create(a);
                        if (!ac.handler)
                            ac.setHandler(Ext.bind(me.handleAction, me, [a]));

                        return new Ext.button.Button(ac);
                    })
                }
            ]
        });

        me.callParent(arguments);
    }
});
Ext.define('MLC.wf.controller.Menu', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    adjustViewConfig: function () {
        var me = this;

        me.callParent(arguments);

        Ext.merge(me.viewBox.config, {
            layout: {
                type: 'hbox',
                pack: 'center',
                align: 'middle'
            },
            items: [
                {
                    xtype: 'panel',
                    layout: {
                        type: 'vbox',
                        pack: 'center',
                        align: 'stretchmax'
                    },
                    defaults: {
                        margin: 10
                    },
                    items: Ext.Array.map(me.actions, function (a) {
                        var ac = MLC.wf.type.Action.create(a);
                        if (!ac.handler)
                            ac.setHandler(Ext.bind(me.handleAction, me, [a]));

                        return new Ext.button.Button(ac);
                    })
                }
            ]
        });
    }

});
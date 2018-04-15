Ext.define('MLC.wf.controller.Dialog', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    /**
     * Сообщение, отображаемое в диалоге
     * @type {String}
     * 
     */
    message: undefined,

    adjustViewConfig: function () {
        var me = this;

        me.callParent(arguments);

        Ext.merge(me.viewBox.config, {
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
    },

    onViewCreated: function () {
        this.callParent(arguments);

        var textarea = this.view.down('textarea');
        textarea.setValue(this.message);
    }
});
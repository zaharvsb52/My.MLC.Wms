Ext.define('WebClient.common.view.OkCancelWindow', {

    requires: [
        'WebClient.common.controls.WindowHelper'
    ],

    extend: 'Ext.Window',

    /**
     * @cfg {Object} ok Конфигурация для кнопки ok 
     */

    /**
     * @cfg {Object} cancel Конфигурация для кнопки cancel 
     */

    constructor: function(cfg) {
        var defaultCfg = {
            width: 400,
            border: true,
            bodyPadding: 5,
            bbar: {
                height: 32,
                items: [
                    '->',
                    Ext.apply({ xtype: 'button', text: 'OK', itemId: 'ok' }, cfg.ok),
                    Ext.apply({ xtype: 'button', text: 'Отмена', itemId: 'cancel' }, cfg.cancel)
                ]
            }
        };

        cfg = Ext.merge(defaultCfg, cfg);
        WebClient.common.controls.WindowHelper.adjustWindowSizeByContentSize(cfg);

        this.callParent([cfg]);

        var cancelBtn = this.down('#cancel');
        cancelBtn.setHandler(this.onCancel, this);
    },

    bindOkToCommand: function(command) {
        var me = this,
            button = me.down('#ok');

        command.bindToButton(button);

        command.onSuccess = this.okCommand_onSuccess;
        command.onSuccessScope = this;
    },

    okCommand_onSuccess: function() {
        this.close();
    },

    onCancel: function() {
        this.close();
    }
});
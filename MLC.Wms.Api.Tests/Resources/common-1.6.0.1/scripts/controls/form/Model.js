Ext.define('WebClient.common.controls.form.Model', {
    extend: 'Ext.form.Basic',
    alias: ['widget.WebClient.common.controls.form.Model'],

    requires: [
        'WebClient.common.controls.formActions.Load',
        'WebClient.common.controls.formActions.Save'
    ],

    waitMsgTarget: true,

    savingWaitMsg: 'Сохранение...',

    loadingWaitMsg: 'Загрузка...',


    constructor: function(owner, config) {
        this.callParent(arguments);
    },

    /** @override */
    submit: function(options) {
        options = options || {};
        if (!options.waitMsg)
            options.waitMsg = this.savingWaitMsg;

        return this.doAction('modelsave', options);
    },

    /** @override */
    load: function(options) {
        options = options || {};
        if (!options.waitMsg)
            options.waitMsg = this.loadingWaitMsg;

        return this.doAction('modelload', options);
    },

    onBeforeSave: function(action) {
        return this.fireEvent('beforesave', this, action);
    }
});
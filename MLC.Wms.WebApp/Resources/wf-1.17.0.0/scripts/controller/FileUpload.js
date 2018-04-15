Ext.define('MLC.wf.controller.FileUpload', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    isSuccess: undefined,
    fileName: undefined,

    onViewCreated: function () {
        this.callParent(arguments);
        var me = this;
        me.view.on('success', Ext.Function.bind(me.onSuccess, me));
        me.view.on('failure', Ext.Function.bind(me.onFailure, me));
    },

    onSuccess: function (fileName) {
        var me = this;
        me.isSuccess = true;
        me.fileName = fileName;
        me.handleAction({ code: 'Save' });
    },

    onFailure: function (error) {
        var me = this;
        this.isSuccess = false;
        this.fileName = error;
        me.handleAction({ code: 'Cancel' });
    },

    getRequestParams: function (action) {
        var me = this;
        return { cancelAction: false, requestData: { selected: [me.fileName] } };
    }
});
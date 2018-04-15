Ext.define('MLC.wf.controller.Card', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'WebClient.common.data.contextModel.Builder',
        'WebClient.common.data.DataContext',
        'WebClient.common.data.DataContextProxy',
        'WebClient.common.data.change.SetCollector',
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    /**
     * WebClient.CardViewMode
     * @type {WebClient.CardViewMode}
     */
    mode: undefined,

    /**
     * Имя record structure в data context-е с которым работает controller.
     * @type {String}
     */
    structureName: undefined,

    dataContextModel: undefined,

    dataContextData: undefined,

    run: function(actionCallBack) {
        var me = this;

        var builder = new WebClient.common.data.contextModel.Builder(),
            model = builder.build(undefined, me.dataContextModel),
            dataContextProxy = new WebClient.common.data.DataContextProxy();

        me.dataContext = new WebClient.common.data.DataContext({
            storeFactory: new WebClient.common.data.DataContextModelStoreFactory(model)
        });

        dataContextProxy.fillDataContext(me.dataContext, me.dataContextData);

        me.callParent(arguments);
    },

    adjustViewConfig: function() {
        var me = this;

        me.callParent(arguments);

        Ext.merge(me.viewBox.config, {
            structureName: me.structureName,
            mode: me.mode,
            dockedItems: me.getToolBars()
        });
    },

    loadData: function() {
        var me = this,
            store = me.getDataContext().takeStore(me.structureName);

        if (!store.getCount())
            Ext.Error.raise('Сервер не вернул ожидаемых данных');
        else if (store.getCount() > 1)
            Ext.Error.raise('Сервер вернул больше данных, чем ожидалось');
        else {
            me.view.getForm().loadRecord(store.getAt(0));
            me.view.getForm().isValid();
        }

    },

    loadDataCallback: function(records, operation, success) {
        WebClient.common.controls.FormPanelHelper.loadDataCallback(this.view, records, operation, success);
        this.view.getForm().isValid(); // для отображения невалидных полей
    },

    getRequestParams: function(action) {
        var me = this,
            cancelAction = !me.view.getForm().isValid() && !action.ignoreValidation,
            form = me.view.getForm(),
            rec = form.getRecord();

        form.updateRecord(rec);

        var changeSet = WebClient.common.data.change.SetCollector.collect(this.getDataContext());
        var requestData = !changeSet.isEmpty() ? changeSet : null;

        return { cancelAction: cancelAction, requestData: requestData };
    }
});
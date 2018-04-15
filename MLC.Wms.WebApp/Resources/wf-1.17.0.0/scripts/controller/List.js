Ext.define('MLC.wf.controller.List', {
    extend: 'MLC.wf.controller.Controller',

    requires: [
        'WebClient.common.dataServices.DataContextModelBuilder',
        'WebClient.common.data.DataContext',
        'WebClient.common.data.DataContextProxy',
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    /**
     * Имя record structure в data context-е с которым работает controller. Производная от entityType 
     * @type String 
     */
    structureName: undefined,

    serverMethods: undefined,

    dataContextModel: undefined,

    dataContextData: undefined,

    filters: undefined,

    /**
     * Код, который будет возвращен в WF при dbl click
     */
    dblClickActionCode: undefined,

    run: function(actionCallBack) {
        var me = this;

        var builder = new WebClient.common.dataServices.DataContextModelBuilder(me.serverMethods),
            model = builder.build('ModelName', me.dataContextModel),
            dataContextProxy = new WebClient.common.data.DataContextProxy();

        me.dataContext = new WebClient.common.data.DataContext({
            storeFactory: new WebClient.common.data.DataContextModelStoreFactory(model)
        });

        var store = me.dataContext.takeStore(me.structureName);
        store.on('beforeload', Ext.bind(me.beforeLoad, me));

        if (me.filters)
            store.addFilter(me.filters);

        if (me.dataContextData && Ext.Object.getKeys(me.dataContextData[WebClient.common.data.DataContextProxy.tablesRoot]).length > 0)
            dataContextProxy.fillDataContext(me.dataContext, me.dataContextData);
        else
            store.loadPage(1);

        me.callParent(arguments);
    },

    beforeLoad: function (store, operation, eOpts) {
        var proxy = store.getProxy();
        proxy.setExtraParam('workflowIdentity', this.workflowIdentity);
        proxy.setExtraParam('workflowInstanceIdentity', this.workflowInstanceIdentity);
    },

    adjustViewConfig: function () {
        var me = this;

        me.callParent(arguments);

        Ext.merge(me.viewBox.config, {
            structureName: this.structureName,
            gridConfig: {
                listeners: {
                    itemdblclick: function(grid, record, item, index, e, eOpts) {
                        var action = Ext.Array.findBy(me.actions, function(a) {
                            return a.code === me.dblClickActionCode;
                        });

                        if (action)
                            me.handleAction(action);
                    }
                }
            },
            dockedItems: me.getToolBars()
        });
    },

    getRequestParams: function (action) {
        var me = this,
            ids = me.view.getSelectedId().get();

        return { cancelAction: false, requestData: { selected: ids } };
    }
});
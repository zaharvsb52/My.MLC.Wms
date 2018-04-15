Ext.define('MLC.wms.cstReqCustoms.ReqCustomsListController', {
    extend: 'MLC.wf.controller.List',

    requires: [
        'WebClient.common.workspace.RoomContainer',
        'WebClient.common.type.EntityId',
        'MLC.wf.type.Action',
        'MLC.wf.type.WfAction',
        'MLC.wf.type.UrlAction'
    ],

    selectedMND: undefined,

    constructor: function(config) {
        var me = this,
            defaultConfig = {
                entityType: 'CstReqCustoms'
            };
        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);

        me.selectedMND = new WebClient.common.type.EntityRef({
            id: config.selectedMND,
            type: 'WmsPartner',
            values: []
        });
    },

    adjustViewConfig: function() {
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
                    items: Ext.Array.map(me.actions, function(a) {
                        var ac = MLC.wf.type.Action.create(a);
                        if (!ac.handler)
                            ac.setHandler(Ext.bind(me.handleAction, me, [a]));

                        return new Ext.button.Button(ac);
                    })
                }
            ]
        });
    },

    onViewCreated: function() {
        var me = this;
        var actionPlaceholders = Ext.ComponentQuery.query('*[__actionCode]', me.view);

        Ext.Array.each(actionPlaceholders, function(p) {
            var action = Ext.Array.findBy(me.actions, function(a) { return a.code === p.__actionCode; });

            if (!action) {
                p.hide();
            } else {
                var cloneAction = Ext.clone(action);
                delete cloneAction.ignoreValidation;

                var conf = Ext.merge({}, cloneAction);
                delete conf.code;
                delete conf.type;
                delete conf.url;
                conf.handler = Ext.bind(me.handleAction, me, [{ code: cloneAction.code, ignoreValidation: action.ignoreValidation }]);
                p.setConfig(conf);
            }
        });

        this.callParent();
    },

    loadData: function() {
        var me = this;
        var store = me.dataContext.takeStore(me.structureName);

        var mndFilter = new Ext.util.Filter({
            itemId: 'Partner',
            property: 'Partner',
            operator: WebClient.FilterOps.EQ
        });
        mndFilter.setValue([me.selectedMND]);
        store.addFilter(mndFilter);

        store.load();
    }
});
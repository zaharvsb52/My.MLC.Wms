Ext.define('WebClient.common.controls.AutoTree', {
    extend: 'Ext.tree.Panel',
    alias: ['widget.WebClient.common.controls.AutoTree'],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin',

        //interfaces
        'WebClient.common.view.IListView': 'WebClient.common.view.IListView'
    },

    requires: [
        'WebClient.common.data.StructureExtender',
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.binding.Binder',
        'WebClient.common.Site',
        'WebClient.common.layout.ColumnFactory',
        'WebClient.common.data.binding.Manager'
    ],

    /**
     * Метод IListView интерфейса
     */
    getFilterable: function() {
        return this.getStore();
    },

    getSelectedId: function() {
        return WebClient.common.binding.Binder.getHasValue(this, 'selectedId');
    },

    getSelected: function() {
        return WebClient.common.binding.Binder.getHasValue(this, 'selected');
    },

    constructor: function(cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var defaultCfg = {
            store: WebClient.common.data.binding.Manager.takeStore(this.structureName)
        };

        if (defaultCfg.store.pageSize > 0) {
            defaultCfg.dockedItems = [
                {
                    xtype: 'pagingtoolbar',
                    store: WebClient.common.data.binding.Manager.takeStore(this.structureName),
                    dock: 'bottom',
                    displayInfo: true
                }
            ];
        }

        if (cfg.columns)
            WebClient.common.ComponentConfigEnricher.populateColumns(cfg, this.structure);
        else {
            cfg.columns = WebClient.common.layout.ColumnFactory.getInstance().createConfigs(WebClient.common.data.StructureExtender.getFields(this.structure));
            if (cfg.columns.length > 0)
                cfg.columns[0].xtype = 'treecolumn';
        }

        if (Ext.isFunction(cfg.controlConfigProvider))
            cfg.controlConfigProvider = Ext.pass(cfg.controlConfigProvider, [], this);

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);

        WebClient.common.Site.asSite(this);
    }
});
Ext.define('MLC.wf.controls.List', {
    extend: 'Ext.panel.Panel',

    requires: [
        'WebClient.common.controls.grid.plugin.MultiSort',
        'WebClient.common.controls.grid.plugin.MultiSearch',
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.binding.Binder',
        'WebClient.common.Site',
        'WebClient.common.layout.ColumnFactory',
        'WebClient.common.data.binding.Manager'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin',

        //interfaces
        'WebClient.common.view.IListView': 'WebClient.common.view.IListView'
    },

    /**
     * НАЧАЛО: Реализация интерфейса WebClient.common.view.IListView
     * --------------------------------------------------
     */
    /**
     * Метод IListView интерфейса
     */
    getFilterable: function() {
        return this.grid.getStore();
    },

    getSelectedId: function() {
        return WebClient.common.binding.Binder.getHasValue(this.grid, 'selectedId');
    },

    getSelected: function() {
        return WebClient.common.binding.Binder.getHasValue(this.grid, 'selected');
    },

    /**
     * --------------------------------------------------
     * КОНЕЦ: Реализация интерфейса WebClient.common.view.IListView
     */

    /**
     * @private 
     */
    grid: undefined,

    constructor: function(cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);
        var store = WebClient.common.data.binding.Manager.takeStore(this.structureName),
            gridConfig = Ext.merge({
                xtype: 'grid',
                itemId: 'grid',
                title: this.structure.prototype.localizedName,
                store: store,
                features: [{ ftype: 'gmsrt', displaySortOrder: true }],
                plugins: [{ ptype: 'gms' }],
                dockedItems: store.pageSize > 0 ? [
                    {
                        xtype: 'pagingtoolbar',
                        store: store,
                        dock: 'bottom',
                        displayInfo: true
                    }
                ] : []
            }, cfg.gridConfig);


        if (gridConfig.columns)
            WebClient.common.ComponentConfigEnricher.populateColumns(gridConfig, this.structure);
        else
            gridConfig.columns = WebClient.common.layout.ColumnFactory.getInstance().createConfigs(this.structure.prototype.fields);

        if (Ext.isFunction(gridConfig.controlConfigProvider))
            gridConfig.controlConfigProvider = Ext.pass(gridConfig.controlConfigProvider, [], this);

        this.callParent([
            Ext.merge({
                layout: 'fit',
                items: [gridConfig]
            }, cfg)
        ]);

        this.grid = this.down('#grid');
    }
});
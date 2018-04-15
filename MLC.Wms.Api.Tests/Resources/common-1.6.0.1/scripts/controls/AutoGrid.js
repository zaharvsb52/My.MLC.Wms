Ext.define('WebClient.common.controls.AutoGrid', {
    extend: 'Ext.grid.Panel',
    alias: ['widget.WebClient.common.controls.AutoGrid'],

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
        'WebClient.common.data.binding.Manager',
        'WebClient.common.util.ClipboardHelper'
    ],

    /**
     * НАЧАЛО: Реализация интерфейса WebClient.common.view.IListView
     * --------------------------------------------------
     */
    /**
     * Метод IListView интерфейса
     */
    getFilterable: function () {
        return this.getStore();
    },

    getSelectedId: function () {
        return WebClient.common.binding.Binder.getHasValue(this, 'selectedId');
    },

    getSelected: function () {
        return WebClient.common.binding.Binder.getHasValue(this, 'selected');
    },
    /**
     * --------------------------------------------------
     * КОНЕЦ: Реализация интерфейса WebClient.common.view.IListView
     */

    constructor: function (cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var defaultCfg = {
            title: this.structure.prototype.title,
            store: WebClient.common.data.binding.Manager.takeStore(this.structureName),
            viewConfig: {
                listeners:
                    {
                        cellfocus: function (record, cell, position) {
                            if (cell)
                                WebClient.common.util.ClipboardHelper.set(cell.dom.textContent || cell.dom.innerText || '');
                        }
                    }
            }
        };

        if (defaultCfg.store.pageSize > 0) {
            defaultCfg.dockedItems = [
                {
                    itemId: 'pager',
                    xtype: 'pagingtoolbar',
                    store: WebClient.common.data.binding.Manager.takeStore(this.structureName),
                    dock: 'bottom',
                    displayInfo: true
                }
            ];
        }

        var strtype = this.structure.prototype.entityType ? this.structure.prototype.entityType : this.structure.prototype.name;


        if (cfg.columns)
            WebClient.common.ComponentConfigEnricher.populateColumns(cfg, this.structure);
        else
            cfg.columns = WebClient.common.layout.ColumnFactory.getInstance().createConfigs(WebClient.common.data.StructureExtender.getFields(this.structure));

        cfg.columns = cfg.columns.map(function (item) {
            var propName = item.editor ? item.editor.name : "DefProperty";
            item.tooltip = propName + ' [' + strtype + ']';
            return item;
        });


        if (Ext.isFunction(cfg.controlConfigProvider))
            cfg.controlConfigProvider = Ext.pass(cfg.controlConfigProvider, [], this);

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);

        WebClient.common.Site.asSite(this);
    },

    /**
     * @override
     */
    reconfigure: function (store, columns) {
        var me = this,
            oldStore = me.store;

        if (arguments.length === 1 && Ext.isArray(store)) {
            columns = store;
            store = null;
        }

        if (store && (store = Ext.StoreManager.lookup(store)) !== oldStore) {
            me.getDockedComponent('pager').bindStore(store);
        }

        this.callParent(arguments);
    }
});
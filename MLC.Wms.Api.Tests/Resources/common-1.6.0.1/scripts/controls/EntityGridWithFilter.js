Ext.define('WebClient.common.controls.EntityGridWithFilter', {
    extend: 'Ext.panel.Panel',
    alias: ['widget.WebClient.common.controls.EntityGridWithFilter'],

    requires: [
        'WebClient.common.controls.CrudEntityGrid',
        'WebClient.common.controls.grid.plugin.MultiSort',
        'WebClient.common.controls.grid.plugin.MultiSearch',
        'WebClient.common.controls.filters.ColumnsAutoPanel'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin'
    },

    getTbarItems: function(config) {

        var tbarItems = WebClient.common.controls.CrudEntityGrid.getTbarItems(config),
            me = this;

        tbarItems.push({
            xtype: 'button',
            itemId: 'openfilter',
            enableToggle: true,
            glyph: 'xf4a5@ionicons',
            text: 'Фильтры',
            toggleHandler: function (btn, state) { me.filter.setCollapsed(!state); }
        });

        return tbarItems;
    },

    /**
     * @cfg {Object} gridConfig Конфигурация, которая будет передана во вложенный grid контрол. См. {@link WebClient.common.controls.EntityGrid} 
     */

    /**
     * @cfg {Object} filterConfig Конфигурация, которая будет передана во вложенную панель авто фильтров. См. {@link WebClient.common.controls.filters.ColumnsAutoPanel}
     */

    /**
     * Если установлен в true то после рендеринга компонента произойдет загрузка данных из store-а
     * @type Boolean 
     */

    constructor: function(config) {
        config = config || {};
        this.mixins.recordstructureaware.constructor.call(this, config);

        config.itemId = config.itemId || 'grid';
        var filterConfig = Ext.merge(
            {
                region: 'north',
                collapseMode: 'placeholder',
                placeholder: { xtype: 'component', hidden: true },
                collapsible: true,
                collapsed: true,
                header: false,
                itemId: config.itemId + 'Filter',
                xtype: 'WebClient.common.controls.filters.ColumnsAutoPanel',
                structureName: this.structureName,
                border: false
            }, config.filterConfig);

        var gridConfig =
            {
                region: 'center',
                readOnly: config.readOnly,
                itemId: config.itemId + 'Grid',
                xtype: 'WebClient.common.controls.CrudEntityGrid',
                title: undefined,
                structureName: this.structureName,
                border: false,
                editOnDblClick: config.editOnDblClick || false,
                features: [{ ftype: 'gmsrt', displaySortOrder: true }],
                plugins: [{ ptype: 'gms' }],
                tbar: { items: this.getTbarItems(config.gridConfig) }
            };

        gridConfig = Ext.merge(gridConfig, config.gridConfig);

        var defaultConfig = {
            layout: 'border',
            title: this.structure.prototype.title,
            items: [
                filterConfig,
                gridConfig
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);

        this.grid = this.down('#' + config.itemId + 'Grid');
        this.filter = this.down('#' + config.itemId + 'Filter');

        this.filter.setFilterable(this.grid.store);
    },

    grid: undefined,

    filter: undefined
});
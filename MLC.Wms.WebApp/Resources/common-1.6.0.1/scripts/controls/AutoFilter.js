Ext.define('WebClient.common.controls.AutoFilter', {
    extend: 'WebClient.common.controls.form.ModelPanel',
    alias: ['widget.WebClient.common.controls.AutoFilter'],

    requires: [
        'WebClient.common.data.StructureExtender',
        'WebClient.common.filters.FilterBinder',
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.layout.FilterFactory'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin'
    },

    mode: WebClient.CardViewMode.UNDEFINED,

    filterSources: [],

    constructor: function(cfg) {
        var me = this;

        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var defaultCfg = {
            title: 'Фильтр',
            collapsible: true,
            //            layout: 'form',
            //            xtype: 'fieldset',
            //            autoHeight: true,

            //            defaults: {
            //                anchor: '100%'
            //            },
            autoScroll: true,
            //            bodyPadding: 5,
            items: (cfg.items) ? [] : WebClient.common.layout.FilterFactory.getInstance().createConfigs(WebClient.common.data.StructureExtender.getFields(this.structure)) //нет нужды - будет вызван enrichConfig ниже
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.enrichConfig(cfg);

        this.callParent([cfg]);

        //this.on('afterrender', function() {me.doLayout();});

        Ext.Array.each(cfg.items, function(item) {
            if (item.filterSource != undefined) {
                me.filterSources.push({
                    source: me.down('#' + item.filterSource),
                    operator: item.filterOperator,
                    dataIndex: item.filterDataIndex,
                    itemId: item.filterItemId
                });
            }
        });
    },

    addFilterable: function(filterable) {
        var filterBinder = WebClient.common.filters.FilterBinder.bind(filterable);

        if (this.filterSources.length > 0) {
            Ext.Array.each(this.filterSources, function(source) {
                filterBinder.addBinding({
                    source: source.source,
                    operator: source.operator,
                    dataIndex: source.dataIndex,
                    itemId: source.itemId
                });
            });
        }
    },

    enrichConfig: function(cfg) {
        if (!cfg)
            return;

        if (Ext.isFunction(cfg.controlConfigProvider))
            cfg.controlConfigProvider = Ext.pass(cfg.controlConfigProvider, [], this);

        WebClient.common.ComponentConfigEnricher.populateAutoFilters(cfg, this.structure);
    }

});
/**
 *  Создание дефолтного фильтра, т.к. элементы фильтра располагаются в несколько колонок и заранее неизвестно в какую колонку попадет поле, поля задаются единым списком в items.
 */
Ext.define('WebClient.common.controls.filters.AutoPanel', {
    extend: 'Ext.panel.Panel',
    alias: ['widget.WebClient.common.controls.filters.AutoPanel'],

    requires: [
        'WebClient.common.filters.FilterBinder',
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.layout.FilterFactory'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin'
    },

    constructor: function(config) {
        this.mixins.recordstructureaware.constructor.call(this, config);

        this.enrichConfig(config);

        this.callParent([config]);
    },

    enrichConfig: function(config) {
        if (!config)
            return;

        if (Ext.isFunction(config.controlConfigProvider))
            config.controlConfigProvider = Ext.pass(config.controlConfigProvider, [], this);

        WebClient.common.ComponentConfigEnricher.populateAutoFilters(config, this.structure);
    },

    setFilterable: function(filterable) {
        WebClient.common.filters.FilterBinder.bind(
            filterable,
            WebClient.common.filters.FilterBinder.getFilterBindings(this)
        );
    }
});
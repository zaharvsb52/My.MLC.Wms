/**
 *  Создание дефолтного фильтра, т.к. элементы фильтра располагаются в несколько колонок и заранее неизвестно в какую колонку попадет поле, поля задаются единым списком в filters.
 */
Ext.define('WebClient.common.controls.filters.ColumnsAutoPanel', {
    extend: 'WebClient.common.controls.filters.AutoPanel',
    alias: ['widget.WebClient.common.controls.filters.ColumnsAutoPanel'],

    requires: ['WebClient.common.data.StructureExtender'],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin'
    },

    panel: undefined,

    constructor: function(config) {
        this.mixins.recordstructureaware.constructor.call(this, config);

        var defaultconfig = {
            layout: 'fit',
            autoScroll: true,
            items: [
                {
                    layout: 'column',
                    items: [],
                    bodyPadding: 5,
                    border: false
                }
            ]
        };

        var filterItems = config.filters || WebClient.common.layout.FilterFactory.getInstance().createFieldPlaceholders(
            WebClient.common.data.StructureExtender.getFilterFields(this.structure)
        );

        var maxColumnsCount = config.columnCount || 3;
        var columnsCount = Math.min(maxColumnsCount, filterItems.length);
        var fieldsInColumn = Math.ceil(filterItems.length / columnsCount);

        for (var i = 0; i < columnsCount; i++) {
            var columnItems = [];
            for (var j = 0; j < fieldsInColumn; j++) {
                if (i * fieldsInColumn + j >= filterItems.length)
                    break;
                columnItems.push(filterItems[i * fieldsInColumn + j]);
            }

            var margin = i == 0 ? '0 20 0 0' : (i == columnsCount - 1 ? '0 0 0 20' : '0 20 0 20');

            defaultconfig.items[0].items.push({
                columnWidth: 1 / columnsCount,
                layout: 'anchor',
                defaults: {
                    anchor: '100%'
                },
                border: false,
                margin: margin,
                items: columnItems
            });
        }

        config = Ext.Object.merge(defaultconfig, config);

        this.callParent([config]);

        this.panel = this.items.items[0];
    }
});
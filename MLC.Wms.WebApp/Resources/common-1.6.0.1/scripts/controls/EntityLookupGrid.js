Ext.define('WebClient.common.controls.EntityLookupGrid', {
    alias: ['widget.WebClient.common.controls.EntityLookupGrid'],

    extend: 'WebClient.common.controls.AutoGrid',

    mixins: {
        //interfaces
        'WebClient.common.view.IEntityListView': 'WebClient.common.view.IEntityListView'
    },

    requires: [
        'WebClient.common.controls.grid.plugin.MultiSort',
        'WebClient.common.controls.grid.plugin.MultiSearch'
    ],

    constructor: function(cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var defaultCfg = {
            entityType: this.structure.prototype.entityType,
            selModel: 'rowmodel',
            features: [{ ftype: 'gmsrt', displaySortOrder: true }],
            plugins: [{ ptype: 'gms' }]
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);

        if (!this.entityType)
            Ext.Error.raise('Метаданные для формы-лукапа сущностей не содержат имя сущности (entityType)');
    }
});
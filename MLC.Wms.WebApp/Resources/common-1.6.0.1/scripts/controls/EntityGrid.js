Ext.define('WebClient.common.controls.EntityGrid', {
    extend: 'WebClient.common.controls.AutoGrid',
    alias: ['widget.WebClient.common.controls.EntityGrid'],

    mixins: {
        //interfaces
        'WebClient.common.view.IEntityListView': 'WebClient.common.view.IEntityListView'
    },

    constructor: function(cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var defaultCfg = {
            entityType: this.structure.prototype.entityType
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);

        if (!this.entityType)
            Ext.Error.raise('Метаданные для формы-списка сущностей не содержат имя сущности (entityType)');
    }
});
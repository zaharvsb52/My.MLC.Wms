Ext.define('WebClient.common.controls.EntityCard', {
    extend: 'WebClient.common.controls.AutoCard',
    alias: ['widget.WebClient.common.controls.EntityCard'],

    mixins: {
        //interfaces
        'WebClient.common.view.IEntityCardView': 'WebClient.common.view.IEntityCardView'
    },

    constructor: function(cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var defaultCfg = {
            entityType: this.structure.prototype.entityType
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);

        if (!this.entityType)
            Ext.Error.raise('Метаданные для формы-карточки сущности не содержат имя сущности (entityType)');
    }
});
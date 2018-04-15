Ext.define('WebClient.common.controls.AutoCard', {
    extend: 'WebClient.common.controls.form.ModelPanel',
    alias: ['widget.WebClient.common.controls.AutoCard'],

    requires: [
        'WebClient.common.data.StructureExtender',
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.layout.EditorFactory',
        'WebClient.common.layout.ViewerFactory',
        'WebClient.common.data.binding.Manager'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin',

        //interfaces
        'WebClient.common.view.ICardView': 'WebClient.common.view.ICardView'
    },

    mode: WebClient.CardViewMode.UNDEFINED,

    /**
     * НАЧАЛО: Реализация интерфейса WebClient.common.view.ICardView
     * --------------------------------------------------
     */
    /**
     * Метод ICardView интерфейса
     */
    load: function(options) {
        return this.callParent(arguments);
    },

    submit: function(options) {
        return this.callParent(arguments);
    },

    loadRecord: function(record) {
        return this.callParent(arguments);
    },

    getRecord: function() {
        return this.callParent(arguments);
    },

    updateRecord: function(record) {
        return this.callParent(arguments);
    },

    getHasValue: function(sourceName, sourceValueName) {
        var scomp = this.down('#' + sourceName);
        if (scomp)
            return WebClient.common.binding.Binder.getHasValue(scomp, sourceValueName);

        var record = this.getRecord();
        if (!record)
            return null;

        var field = Ext.Array.findBy(record.getFields(), function(f) { return f.getName() === sourceName; });
        if (!field)
            return null;

        return WebClient.common.binding.Binder.createVariableHasValue(record.get(sourceName));
    },

    /**
     * --------------------------------------------------
     * КОНЕЦ: Реализация интерфейса WebClient.common.view.ICardView
     */

    constructor: function(cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var isEditable = !(cfg.mode == WebClient.CardViewMode.VIEW);
        var createPlaceholdersFn = isEditable
            ? WebClient.common.layout.EditorFactory.getInstance().createFieldPlaceholders
            : WebClient.common.layout.ViewerFactory.getInstance().createFieldPlaceholders;

        var defaultCfg = {
            layout: 'anchor',
            defaults: {
                anchor: '100%'
            },
            bodyPadding: 5,
            autoScroll: true,
            trackResetOnLoad: true,
            items: (cfg.items) ? [] : createPlaceholdersFn(WebClient.common.data.StructureExtender.getFields(this.structure))
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.enrichConfig(cfg);
        var strtype = this.structure.prototype.entityType ? this.structure.prototype.entityType : this.structure.prototype.name;

        cfg.items = cfg.items.map(function (item) {
            item.listeners = [
                {
                    afterrender: function(c) {
                        Ext.QuickTips.register({
                            target: c.labelEl,
                            text: item.name + ' [' + strtype + ']'
                        });
                    }
                }
            ];
            return item;
        });

        this.callParent([cfg]);
    },

    enrichConfig: function(cfg) {
        if (!cfg)
            return;

        if (Ext.isFunction(cfg.controlConfigProvider))
            cfg.controlConfigProvider = Ext.pass(cfg.controlConfigProvider, [], this);

        var isEditable = !(cfg.mode == WebClient.CardViewMode.VIEW);
        if (isEditable)
            WebClient.common.ComponentConfigEnricher.populateEditors(cfg, this.structure);
        else
            WebClient.common.ComponentConfigEnricher.populateViewers(cfg, this.structure);
    }

});
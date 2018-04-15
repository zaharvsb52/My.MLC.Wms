Ext.define('MLC.wf.controls.Card', {

    extend: 'WebClient.common.controls.form.ModelPanel',

    requires: [
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
    load: function (options) {
        return this.callParent(arguments);
    },

    submit: function (options) {
        return this.callParent(arguments);
    },

    loadRecord: function (record) {
        return this.callParent(arguments);
    },

    getRecord: function () {
        return this.callParent(arguments);
    },

    updateRecord: function (record) {
        return this.callParent(arguments);
    },

    getHasValue: function (sourceName, sourceValueName) {
        var scomp = this.down('#' + sourceName);
        if (scomp)
            return WebClient.common.binding.Binder.getHasValue(scomp, sourceValueName);

        var record = this.getRecord();
        if (!record)
            return null;

        var field = Ext.Array.findBy(record.getFields(), function (f) { return f.getName() === sourceName; });
        if (!field)
            return null;

        return WebClient.common.binding.Binder.createVariableHasValue(record.get(sourceName));
    },

    /**
     * --------------------------------------------------
     * КОНЕЦ: Реализация интерфейса WebClient.common.view.ICardView
     */

    constructor: function (cfg) {
        this.mixins.recordstructureaware.constructor.call(this, cfg);

        var isEditable = !(cfg.mode == WebClient.CardViewMode.VIEW);
        var createPlaceholdersFn = isEditable
            ? WebClient.common.layout.EditorFactory.getInstance().createFieldPlaceholders
            : WebClient.common.layout.ViewerFactory.getInstance().createFieldPlaceholders;

        var defaultCfg = {
            layout: 'form',
            autoScroll: true,
            title: this.structure.prototype.localizedName,
            items: (cfg.items) ? [] : createPlaceholdersFn(this.structure.prototype.fields)
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.enrichConfig(cfg);

        this.callParent([cfg]);
    },

    enrichConfig: function (cfg) {
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
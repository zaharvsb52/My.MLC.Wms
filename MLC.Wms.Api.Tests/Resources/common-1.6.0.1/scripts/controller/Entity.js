Ext.define('WebClient.common.controller.Entity', {
    extend: 'WebClient.common.controller.Controller',

    mixins: {
        //interfaces
        'WebClient.common.controller.IEntity': 'WebClient.common.controller.IEntity'
    },

    uses: [
        'WebClient.common.view.EntityViewRegistry'
    ],

    /** 
     * @type WebClient.ViewKind
     */
    viewKind: undefined,

    /**
     * WebClient.ListViewMode или WebClient.CardViewMode
     * @type {WebClient.ListViewMode/WebClient.CardViewMode}
     */
    mode: undefined,

    /**
     * Имя record structure в data context-е с которым работает controller. Производная от entityType 
     * @type String 
     */
    structureName: undefined,

    constructor: function(cfg) {
        this.callParent(arguments);
        Assert.notEmpty(this.entityType, 'this.entityType');

        if (!this.viewClassName && !this.viewBox) {
            var entry = WebClient.common.view.EntityViewRegistry.getEntry(this.entityType, this.viewKind, this.mode);
            this.viewBox = WebClient.lazy(entry.className, entry.config);
        }

        if (!this.structureName)
            this.structureName = this.deriveStructureName();
    },

    /**
     * Вычисляет имя структуры для формы, управляемой этим контроллером 
     * @return {}
     */
    deriveStructureName: function() {
        WebClient.notImplementedFn();
    },

    /**
     * @override
     */
    adjustViewConfig: function() {
        this.callParent(arguments);
        Ext.merge(this.viewBox.config, {
            structureName: this.structureName,
            mode: this.mode
        });
    }
});
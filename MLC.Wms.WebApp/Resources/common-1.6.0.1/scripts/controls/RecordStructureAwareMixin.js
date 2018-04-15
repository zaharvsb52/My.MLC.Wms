Ext.define('WebClient.common.controls.RecordStructureAwareMixin', {
    requires: ['WebClient.common.data.binding.Manager'],
    /**
    * Имя record structure в data context-е, с которым работает форма. 
    * @type String 
    */
    structureName: undefined,

    /**
     * Record structure на основе информации из которой собирается форма. Модель (прототип)
     * @type Ext.data.Model 
     */
    structure: undefined,

    constructor: function(cfg) {
        if (!this.structureName)
            this.structureName = cfg ? cfg.structureName : undefined;

        if (!this.structureName)
            Ext.Error.raise('Имя record structure, с метаданными которого работает данный компонент, не передан');

        if (!this.structure)
            this.structure = WebClient.common.data.binding.Manager.getStructure(this.structureName);
    }
});
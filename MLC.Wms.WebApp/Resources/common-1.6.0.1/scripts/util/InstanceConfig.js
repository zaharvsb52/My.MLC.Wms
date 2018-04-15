Ext.define('WebClient.common.util.InstanceConfig', {
    className: undefined,

    /**
     * Кофигурация, передаваемая в конструктор instance-а
     * @type 
     */
    config: undefined,

    constructor: function(cfg) {
        Ext.apply(this, cfg);
    }

});
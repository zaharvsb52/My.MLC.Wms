Ext.define('WebClient.common.commands.Command', {
    extend: 'Ext.Action',

    uses: [
        'WebClient.common.Site'
    ],

    mixins: {
        observable: 'Ext.util.Observable'
    },

    /**
     * Если истина - то после успешного выполнения команды контейнер будет закрыт
     * @type Boolean
     */
    closeContainerOnSuccess: false,

    /**
     * Имена типов контейнеров, в которые эта команда НЕ будет добавлена. Например, если
     * команда не имеет смысла для данного типа контейнера.
     * @type Array 
     */
    unsupportedContainerTypes: [],

    //requiresConfirmation 

    /**
     * Config of Ext.util.KeyMap, nullable. Function to execute will be set to
     * handler of the action
     * @type {Ext.util.KeyMap}
     */
    keyMap: null,

    constructor: function(config) {

        config = config || {};

        if (config.xtype)
            delete config.xtype;

        Ext.applyIf(config, {
            text: this.text,
            glyph: this.glyph,
            iconCls: this.iconCls
        });

        Ext.apply(this, config);

        this.scope = this.scope || this;
        this.handler = Ext.pass(this.handler, [this.onSuccess, this], this.scope);

        if (this.handler) { //this is necessary that the handler is passed to MenuItems/ToolbarItems through initialConfig
            config = config || {};
            config.handler = this.handler;
            config.scope = this.scope;

            //Ext.Function.bind(this.handler, this);
        };

        this.callParent([config]);

        this.mixins.observable.constructor.apply(this, [config]);

        var keyMapConfig = this.keyMap;
        if (keyMapConfig && typeof keyMapConfig === 'object') {
            keyMapConfig.fn = this.handler;
            keyMapConfig.scope = this.scope;
            this.keyMap = new Ext.util.KeyMap(Ext.getBody(), keyMapConfig);
        }
    },

    /**
     * @return {WebClient.common.Site}
     */
    getSite: function() {
        if (!this.items.length)
            Ext.Error.raise({ msg: 'Cannot get command\'s site because it is not associated with any components', owner: this });

        return WebClient.common.Site.getSite(this.items[this.items.length - 1]);
    },

    bindToButton: function(button) {
        button.setHandler(this.handler, this.scope);
        this.addComponent(button);
    },

    handler: function(successCallback, successScope) {
        Ext.callback(successCallback, successScope);
    },

    /**
     * Вызывает событие success
     */
    onSuccess: function() {
        this.fireEvent('success', this);
    }
});
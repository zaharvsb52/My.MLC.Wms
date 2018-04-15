Ext.define('WebClient.common.workspace.Container', {
    mixins: {
        observable: 'Ext.util.Observable'
    },

    constructor: function(config) {
        Ext.apply(this, config);
        this.mixins.observable.constructor.apply(this, arguments);
    },

    onDisplay: function(view) {
        this.fireEvent('display', this, view);
    },

    /**
     * Представление, отображаемое контейнером
     * @type Ext.Component
     */
    view: undefined,

    /**
     * Для изменения конфигурации представления под определенный контейнер
     * @param {Object} viewConfig
     */
    applyContainerToViewConfig: function(viewConfig) {
    },

    /**
     * Установить представление для контейнера. 
     * @param {Ext.Component} view
     */
    putView: function(view) {
        this.view = view;
    },

    /**
     * Отобразить представление в контейнере
     * @param {Ext.Component} view
     */
    displayView: function(commandList) {
        WebClient.notImplementedFn();
    }
});
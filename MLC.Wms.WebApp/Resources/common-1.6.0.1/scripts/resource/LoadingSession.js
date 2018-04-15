/**
 * Сессия загрузки пачки ресурсов
 */
Ext.define('WebClient.common.resource.LoadingSession', {

    /**
     * Callback function который вызывается, когда все ресурсы загружены
     * @type Function 
     */
    onReady: undefined,

    onReadyScope: undefined,

    /**
     * @private
     * @type WebClient.common.resource.Resource[] 
     */
    resources: undefined,

    constructor: function(config) {
        this.resources = [];
        Ext.apply(this, config);
    },

    addResource: function(resource) {
        //TODO: Возможно, надо использовать Id ресурса при поиске
        if (Ext.Array.indexOf(this.resources, resource) === -1)
            this.resources.push(resource);
    },

    /**
     * Вызывает загрузку всех добавленных ресурсов
     */
    load: function() {
        var i = 0,
            resources = Ext.Array.clone(this.resources),
            ln = resources.length;

        if (ln == 0)
            this.invokeReady();
        else {
            for (; i < ln; i++)
                this.loadResource(resources[i]);
        }
    },

    loadResource: function(resource) {
        resource.load(this.onResourceLoaded, this);
    },

    /**
     * @private
     * @param {WebClient.common.resource.Resource} resource
     */
    onResourceLoaded: function(resource) {
        Ext.Array.remove(this.resources, resource);

        if (this.resources.length == 0)
            this.invokeReady();
    },

    invokeReady: function() {
        Ext.callback(this.onReady, this.onReadyScope || window);
    }
});
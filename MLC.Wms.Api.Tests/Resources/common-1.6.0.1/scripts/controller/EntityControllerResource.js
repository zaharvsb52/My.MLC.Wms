/**
 * Этот ресурс представляет контроллер {@link WebClient.common.controller.Entity} создаваемый через метод
 * {@link WebClient.common.controller.EntityControllerFactory#create}
 */
Ext.define('WebClient.common.controller.EntityControllerResource', {
    extend: 'WebClient.common.resource.Resource',

    /**
     * @private
     */
    entityType: undefined,
    /**
     * @private
     */
    viewKind: undefined,
    /**
     * @private
     */
    mode: undefined,
    /**
     * @private
     */
    container: undefined,

    /**
     * @private
     * factory будет использоваться для загрузки класса контроллера с сервера
     * @type {WebClient.common.controller.EntityControllerFactory}
     */
    factory: undefined,

    require: function(resourceLoadingSession) {
        if (!this.v)
            resourceLoadingSession.addResource(this);
    },

    load: function(callback, callbackScope) {
        var me = this;
        me.factory.create(me.entityType, me.viewKind, me.mode, me.container, function(controller) {
            me.v = controller;
            Ext.callback(callback, callbackScope, [me]);
        });
    }
});
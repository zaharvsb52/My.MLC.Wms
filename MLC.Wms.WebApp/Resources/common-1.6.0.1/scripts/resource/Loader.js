/**
 * Загрузчик пачки ресурсов
 */
Ext.define('WebClient.common.resource.Loader', {
    requires: ['WebClient.common.resource.LoadingSession'],

    singleton: true,

    /**
     * Вызывает загрузку переданных ресурсов, или ресурсов внутри свойств переданных объектов (иерархически).
     * Когда все ресурсы загружены, управление отдается в callback.
     * @param {Object/Array/WebClient.common.resource.Resource} objectsOrResources
     * @param {Function} callback
     * @param {Object} callbackScope optional
	 */
    require: function(objectsOrResources, callback, callbackScope) {
        Assert.notEmpty(objectsOrResources, 'objectsOrResources');

        var scope = callbackScope || objectsOrResources;

        if (!Ext.isArray(objectsOrResources))
            objectsOrResources = [objectsOrResources];

        var session = new WebClient.common.resource.LoadingSession({
            onReady: callback,
            onReadyScope: scope
        });

        for (var i = 0, ln = objectsOrResources.length; i < ln; i++)
            this.requireDeep(objectsOrResources[i], session);

        session.load();
    },

    /**
     * @private
     * @param {Number} maxRecursionLevel Максимальный глубина, на которую спускаться при поиске ресурсов. Если не задана, то 6 по-умолчанию.
	 */
    requireDeep: function(obj, session, maxRecursionLevel) {
        if (maxRecursionLevel <= 0)
            return;

        maxRecursionLevel = maxRecursionLevel || 6;

        if (!obj)
            return;

        if (obj.isResource) {
            obj.require(session);
            if (obj.isBox && obj.config)
                this.requireDeep(obj.config, session, maxRecursionLevel - 1);
        } else if (Ext.isElement(obj))
            return;
        else if (Ext.isObject(obj)) {
            var clsName = Ext.getClassName(obj);

            if (clsName && clsName.substring(0, 4) == 'Ext.') { // skip processing ExtJS objects
                return;
            }

            for (p in obj) {
                if (obj.hasOwnProperty(p))
                    this.requireDeep(obj[p], session, maxRecursionLevel - 1);
            }
        } else if (Ext.isArray(obj)) {
            var len = obj.length, i;
            for (i = 0; i < len; i += 1)
                this.requireDeep(obj[i], session, maxRecursionLevel - 1);
        }
    }
});
/**
 * Ресурс - информация об объекте, доступность которого не гарантируется немедленно. Для того, чтобы
 * воспользоваться объектом ресурса, необходимо сначала активировать загрузку ресурса, и подождать ответа.
 * Пример ресурсов: объект класса X и созданный с использованием конфигурации C (для того, чтобы получить такой объект, 
 * сначала нужно загрузить код класса), класс-наследник Ext.data.Model, структура которого запрашивается на 
 * сервере (функционал авто форм).    
 */
Ext.define('WebClient.common.resource.Resource', {

    /**
     * Уникальный идентификатор ресурса. Два ресурса с одним и тем же id не должны грузиться одновременно 
     * @type String 
     */
    id: undefined,

    /**
     * Результат получения ресурса
     * @protected
     */
    v: undefined,

    /**
     * Служебная
     * @inner
     */
    isResource: true,

    statics: {

        /**
         * Возвращает загруженный объект ресурса, или сам переданный параметр (если это не ресурс). Используется для удобства 
         * классами, в которые могут передать живой объект, или ресурс на него. 
         * @param {WebClient.common.resource.Resource/Object} objectOrResource
         * @return {Object}
         */
        unbox: function(objectOrResource) {
            if (objectOrResource)
                return objectOrResource.isResource ? objectOrResource.value() : objectOrResource;
            else
                return objectOrResource;
        }
    },

    /**
     * Возвращает объект, который этот ресурс представляет.
     * @return {Object}
     */
    value: function() {
        if (!Ext.isDefined(this.v)) {
            Ext.Error.raise('Требуемый ресурс "' + Ext.getClassName(this) +
                '" на был запрошен методом require, или значение запрашивается без ожидания загрузки (он пока еще не получен).' +
                'id:' + this.id);
        }
        return this.v;
    },

    /**
     * Проверяет, возможно ли немедленно получить требуемый объект (представленный этим ресурсом), 
     * и если нет, добавляет себя в сессию загрузки ресурсов, чтобы потом был вызван метод load. 
     * @inner
     * @param {WebClient.common.resource.LoadingSession} resourceLoadingSession
     */
    require: function(resourceLoadingSession) {},

    /**
     * Запускает загрузку чего-либо, необходимого для получения объека (представленного этим ресурсом).  
     * @param {Function} callback function(resource) - вызывается когда ресурс стал доступен
     */
    load: function(callback, callbackScope) {},

    constructor: function(config) {
        Ext.apply(this, config);
    }
});
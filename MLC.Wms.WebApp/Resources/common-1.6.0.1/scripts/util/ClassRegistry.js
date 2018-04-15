/**
 * Реестр классов. 
 * @private
 */
Ext.define('WebClient.common.util.ClassRegistry', {
    requires: ['Ext.util.HashMap'],

    /**     
     * @type {Ext.util.HashMap} 
     * 
     *  @private
     */
    classMap: undefined,

    constructor: function() {
        this.classMap = new Ext.util.HashMap();
    },

    /**
     * Зарегистрировать класс с заданным ключом по заданному пути. 
     * Путь представляет собой список строк, разделенных точкой, например:
     * 'list.select'.
     * Можно перерегистрировать повторно
     * @param {string} key
     * @param {string} path
     * @param {string} className
     * @param {object} classConfig
     */
    registerClass: function(key, path, className, classConfig) {
        if (!key)
            Ext.Error.raise('"key" argument should be defined');

        if (className || classConfig) {
            var fullKey = this.getFullKey(key, path);
            if (this.classMap.get(fullKey))
                Ext.Error.raise('Маппинг для указанных параметров уже задан. key:' + key + '. path:' + path + '. className:' + className);
            this.classMap.add(fullKey, { className: className, classConfig: classConfig });
        } else
            Ext.Error.raise('className or classConfig parameter must be specified, otherwise the registration has no sense');
    },

    /**
     * Поиск класса по заданному ключу и пути.
     * Путь представляет собой список строк, раделенных точкой, например:
     * 'list.select'
     * 
     * Возвращает объект типа {WebClient.common.util.ClassRegistryEntry} наиболее точно соответствующий запросу.
     * Если совпадений нет - возвращается undefined.
     * 
     * @param {string} key
     * @param {string} path
     */
    getClassEntry: function(key, path) {
        if (!key)
            Ext.Error.raise('"key" argument should be defined');

        if (!path)
            return this.internalGetClass(key);

        var parts = path.split('.');
        var length = parts.length;

        for (var i = 0; i < length; i++) {
            var p = parts.join('.');
            var entry = this.internalGetClass(key, p);

            if (entry)
                return entry;

            parts.pop();
        }

        return undefined;
    },

    /**
     * Поиск класса по заданному ключу и пути.
     * Поиск выполняется по точному совпадению ключа и пути.     
     * 
     * Возвращает объект типа {WebClient.common.util.ClassRegistryEntry} или undefined, если искомый класс не найден.
     * Если совпадений нет - возвращается undefined.
     * 
     * @param {string} key
     * @param {string} path
     * 
     * @private
     */
    internalGetClass: function(key, path) {
        if (!key)
            Ext.Error.raise('"key" argument should be defined');

        var fullKey = this.getFullKey(key, path);
        return this.classMap.get(fullKey);
    },

    /**
     * 
     * @param {string} key
     * @param {string} path
     * 
     * @private
     */
    getFullKey: function(key, path) {
        return !path ? key : key + '.' + path;
    }
});
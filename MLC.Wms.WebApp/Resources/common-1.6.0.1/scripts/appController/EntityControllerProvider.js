Ext.define('WebClient.common.appController.EntityControllerProvider', {
    requires: [
        'WebClient.common.util.ClassRegistry',
        'WebClient.common.appController.Entity'
    ],

    singleton: true,

    /**
    * 
    * @type {WebClient.common.util.ClassRegistry}
    * @private 
    */
    classRegistry: undefined,

    constructor: function() {
        this.classRegistry = new WebClient.common.util.ClassRegistry();
    },

    map: function(entityType, className, instanceConfig) {
        this.classRegistry.registerClass(entityType, null, className, instanceConfig);
    },

    /**
     * Создает (если нужно) класс контроллера, его инстанс и передает инстанс в callback
     * @param {String} entityType
     * @param {Function(controller)} callback
     * @param {Object} scope
     */
    take: function(entityType, callback, scope) {
        var entry = this.getActivatedEntry(entityType);
        entry.config = Ext.clone(entry.config);
        entry.config.entityType = entityType;

        Ext.onReady(function() {
            var o = Ext.create(entry.className, entry.config);
            if (callback != null)
                callback.call(scope || Ext.global, o);
        });
    },

    /**
     * 
     * @param {} entityType
     * @param {} viewKind
     * @param {} mode
     * @return {WebClient.common.util.InstanceConfig} configuration of future instance
     */
    getActivatedEntry: function(entityType) {
        var classEntry = this.classRegistry.getClassEntry(entityType, null) || {};
        this.activateEntry(classEntry, entityType);
        return { className: classEntry.className, config: classEntry.classConfig || {} };
    },

    activateEntry: function(classEntry, entityType) {
        if (!classEntry.className) {
            this.createAutoClassEntryAndDefineClass(entityType, classEntry);
            this.classRegistry.registerClass(entityType, null, classEntry.className, classEntry.classConfig);
        } else
            Ext.require(classEntry.className);
    },

    /**
     * @private
     * @param {string} entityType
     * @param {WebClient.common.util.ClassRegistryEntry} classEntry Entry в которую записывается имя класса и его конфигурацию 
     */
    createAutoClassEntryAndDefineClass: function(entityType, classEntry) {
        this.createAutoClassEntry(entityType, classEntry);
        Ext.define(classEntry.className, classEntry.classConfig);
    },

    /**
     * @protected
     * @param {string} entityType
     * @param {WebClient.common.util.ClassRegistryEntry} classEntry Entry в которую дополняется имя класса и расширяется его конфигурация.
     */
    createAutoClassEntry: function(entityType, classEntry) {
        classEntry.className = this.getAutoClassName(entityType);
        var defaultConfig =
            {
                extend: 'WebClient.common.appController.Entity',
                entityType: entityType
            };

        classEntry.classConfig = Ext.merge(defaultConfig, classEntry.classConfig);
    },

    /**
     * @protected
     * @param {string} entityType
     * @return {string}
     */
    getAutoClassName: function(entityType) {
        return 'WebClient.$runtime.appController.entity.' + entityType;
    }

});
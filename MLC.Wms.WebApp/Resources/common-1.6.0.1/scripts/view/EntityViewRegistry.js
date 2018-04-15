Ext.define('WebClient.common.view.EntityViewRegistry', {
    requires:
        [
            'WebClient.common.util.ClassRegistry',
            'WebClient.common.controls.CrudEntityGrid',
            'WebClient.common.controls.EntityCard',
            'WebClient.common.controls.EntityGridWithFilter'
        ],

    singleton: true,

    /**
     * 
     * @type {WebClient.common.util.ClassRegistry}
     * @private 
     */
    classRegistry: undefined,

    defaultCardClass: 'WebClient.common.controls.EntityCard',

    defaultListClass: 'WebClient.common.controls.EntityGridWithFilter',

    defaultLookupClass: 'WebClient.common.controls.EntityLookupGrid',

    constructor: function() {
        this.classRegistry = new WebClient.common.util.ClassRegistry();
    },

    /**
     * Регистрирует какую view с какой конфигурацией использовать для указанного типа сущностей, для указанного вида (список\карточка) и режима 
     * @param {string} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode Optional WebClient.ListViewMode или WebClient.CardViewMode. Если для конкретного режима регистрация не заводилась, то при запросе 
     * на view в конкретном режиме будет использоваться регистрация без указания режима 
     * @param {String} className Optional Имя определенного класса view. Если пропущено, то будет создана авто-форма
     * @param {Object} instanceConfig Optional Конфигурация, которая передается в конструктор view.  
     */
    map: function (entityType, viewKind, mode, className, instanceConfig) {
        if (Ext.isObject(entityType)) {
            var o = entityType;
            entityType = o.entityType;
            viewKind = o.viewKind;
            mode = o.viewMode;
            className = o.className;
            instanceConfig = o.instanceConfig;
        }

        instanceConfig = instanceConfig || {};

        this.classRegistry.registerClass(entityType, this.getPath(viewKind, mode), className, instanceConfig);
    },

    /**
     * Возвращает иформацию о классе view и её конфигурации для указанного имени entity descriptor-а. Если для указанной сущности не был зарегистрирован 
     * класс-view, то он создастся автоматически (применится конфигурация, зарегистрированная для сущности)  
     * @param {string} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode WebClient.ListViewMode или WebClient.CardViewMode
     * @return {WebClient.common.util.InstanceConfig}
     */
    getEntry: function(entityType, viewKind, mode) {
        var path = this.getPath(viewKind, mode);
        var entry = this.classRegistry.getClassEntry(entityType, path) || {};

        if (!entry.className) {
            this.constructClass(entityType, viewKind, mode, entry);
            this.classRegistry.registerClass(entityType, path, entry.className, entry.classConfig);
        }

        return { className: entry.className, config: Ext.clone(entry.classConfig) };
    },


    /**
     * @private
     * @param {string} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode WebClient.ListViewMode или WebClient.CardViewMode
     * @param {WebClient.common.util.ClassRegistryEntry} entry Entry в которую записывается имя класса и его конфигурацию 
     */
    constructClass: function(entityType, viewKind, mode, entry) {
        this.constructClassEntry(entityType, viewKind, mode, entry);
        Ext.define(entry.className, entry.classConfig);
    },

    /**
     * @protected
     * @param {string} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode WebClient.ListViewMode или WebClient.CardViewMode
     * @param {WebClient.common.util.ClassRegistryEntry} entry Entry в которую записывается имя класса и его конфигурацию 
     */
    constructClassEntry: function(entityType, viewKind, mode, entry) {
        entry.className = this.getAutoClassName(entityType, viewKind, mode);
        var defaultConfig =
            {
                extend: (viewKind === WebClient.ViewKind.CARD)
                    ? this.defaultCardClass
                    : (mode === WebClient.ListViewMode.LOOKUP ? this.defaultLookupClass : this.defaultListClass)
            };

        entry.classConfig = Ext.merge(defaultConfig, entry.classConfig);
    },


    /**
     * @protected
     * @param {string} entityType
     * @return {string}
     */
    getAutoClassName: function(entityType, viewKind, mode) {
        return 'WebClient.$runtime.view.entity.' + entityType + '.' + Ext.String.capitalize(mode || viewKind);
    },

    /** @private */
    getPath: function(viewKind, mode) {
        return WebClient.concat(viewKind, mode, '.');
    }
});
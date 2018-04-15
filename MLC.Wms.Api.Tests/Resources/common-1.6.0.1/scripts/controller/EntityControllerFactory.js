Ext.define('WebClient.common.controller.EntityControllerFactory', {
    requires: [
        'WebClient.common.util.ClassRegistry',
        'WebClient.common.controller.EntityList',
        'WebClient.common.controller.EntityCard',
        'WebClient.common.dataServices.DataServiceProxy',
        'WebClient.common.controller.EntityControllerResource'
    ],

    /**
     * Используйте эту константу при маппинге между сущностью и MVC контроллером, если хотите чтобы был использован дата сервис по-умолчанию.
     * Обычно применимо к авто-контроллерам 
     * @type String
     */
    AUTO_DATA_SERVICE: '_$auto',

    singleton: true,

    /**
     * Имя ExtDirect action-а дата сервиса используемого по умолчанию, поддерживающего базовую функциональность авто форм
     */
    defaultAutoDataServiceName: 'Common.DataServices.AutoForms.EntityAutoDataService',

    /**
     * Имя метода дата сервиса по умолчанию, возвращаемого мета информацию data context model
     */
    defaultGetModelMethodName: 'getMetadata',

    /**
    * 
    * @type {WebClient.common.util.ClassRegistry}
    * @private 
    */
    classRegistry: undefined,

    defaultCardClass: 'WebClient.common.controller.EntityCard',

    defaultListClass: 'WebClient.common.controller.EntityList',

    defaultLookupClass: 'WebClient.common.controller.EntityLookup',

    constructor: function() {
        this.classRegistry = new WebClient.common.util.ClassRegistry();
    },

    /**
     * Регистрирует какой controller с какой конфигурацией использовать для указанного типа сущностей, для указанного вида (список\карточка) и режима 
     * @param {string/Object} entityType имя сущности или объект-конфигурация, каждое поле которого это соответсвующий параметр
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode Optional WebClient.ListViewMode или WebClient.CardViewMode. Если для конкретного режима регистрация не заводилась, то при запросе 
     * на controller в конкретном режиме будет использоваться регистрация без указанного режима 
     * @param {String} className Optional Имя определенного класса controller. Если пропущено, то будет создана авто-форма
     * @param {Object} instanceConfig Optional Конфигурация, которая передается в конструктор controller.
     * @param {WebClient.common.dataServices.DataServiceProxy|String} dataServiceProxy Optional dataServiceProxy или имя ExtDirect action дата сервиса,
     * с которым работает автоконтроллер для загрузки данных и метаданных. 
     * Используйте константу AUTO_DATA_SERVICE, если хотите подключить авто дата сервис (для авто форм)
     */
    map: function(entityType, viewKind, mode, className, instanceConfig, dataService) {
        if (Ext.isObject(entityType)) {
            var o = entityType;
            entityType = o.entityType;
            viewKind = o.viewKind;
            mode = o.viewMode;
            className = o.className;
            instanceConfig = o.instanceConfig;
            dataService = o.dataService;
        }

        instanceConfig = instanceConfig || {};

        if (dataService) {
            if (Ext.isString(dataService))
                instanceConfig.dataServiceProxy = this.getAutoDataServiceProxy(entityType, dataService === this.AUTO_DATA_SERVICE ? undefined : dataService);
            else
                instanceConfig.dataServiceProxy = dataService;
        }

        this.classRegistry.registerClass(entityType, this.getPath(viewKind, mode), className, instanceConfig);
    },

    /**
     * Асинхронно создает контроллер, соответсвующий указанным параметрам. См. {@link #map}
     * @param {String} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode WebClient.ListViewMode или WebClient.CardViewMode
     * @param {WebClient.common.workspace.Container} container
     * @param {Function(controller)} callback
     * @param {Object} scope
     */
    create: function(entityType, viewKind, mode, config, container, callback, scope) {
        var entry = this.getActivatedEntry(entityType, viewKind, mode);
        entry.config = Ext.clone(entry.config);
        entry.config.container = container;
        entry.config.entityType = entityType;
        entry.config.viewKind = viewKind;
        entry.config.mode = mode;
        entry.config = Ext.merge(entry.config, config);

        Ext.onReady(function() {
            var o = Ext.create(entry.className, entry.config);
            if (callback != null)
                callback.call(scope || Ext.global, o);
        });
    },

    /**
     * Возвращает {@link WebClient.common.data.contextModel.Resource ресурс} на требуемый контроллер {@link WebClient.common.controller.Entity}. 
     * Те же параметры, что и в методе {@link #create}
     */
    getResource: function(entityType, viewKind, mode, container) {
        return new WebClient.common.controller.EntityControllerResource({
            entityType: entityType,
            viewKind: viewKind,
            mode: mode,
            container: container,
            factory: this
        });
    },

    /**
     * Компанует автоматический {@link WebClient.common.dataServices.DataServiceProxy} дата сервиса, поддерживающего базовую функциональность авто форм
     * @return {WebClient.common.dataServices.DataServiceProxy}
     */
    getAutoDataServiceProxy: function(entityType, actionName) {
        var modelCacheName = actionName || (this.defaultAutoDataServiceName + entityType);

        actionName = actionName || this.defaultAutoDataServiceName;
        if (!WebClient.getByPath(Server, actionName))
            Ext.Error.raise('При конфигурации маппинга между сущностью и MVC контроллером был указан несуществующий ExtDirect action (дата сервис), либо дата сервис по-умолчанию на сервере не существует. Имя сущности: ' + entityType + '. Имя дата сервиса:' + actionName);

        return new WebClient.common.dataServices.DataServiceProxy({
            actionName: actionName,
            getModelMethodName: this.defaultGetModelMethodName,
            modelName: modelCacheName, //получаемая с сервера модель будет закэширована с этим именем
            getModelMethodParameters: {
                entityType: entityType
            }
        });
    },


    /**
     * 
     * @param {} entityType
     * @param {} viewKind
     * @param {} mode
     * @return {WebClient.common.util.InstanceConfig} configuration of future instance
     */
    getActivatedEntry: function(entityType, viewKind, mode) {
        var path = this.getPath(viewKind, mode);
        var classEntry = this.classRegistry.getClassEntry(entityType, path);

        if (!classEntry) //NOTHING is registered
        {
            classEntry = {
                classConfig: {
                    dataServiceProxy: this.getAutoDataServiceProxy(entityType)
                }
            };
        }

        this.activateEntry(classEntry, entityType, viewKind, mode, path);

        return { className: classEntry.className, config: Ext.clone(classEntry.classConfig) || {} };
    },


    activateEntry: function(classEntry, entityType, viewKind, mode, path) {
        if (!classEntry.className) {
            this.createAutoClassEntryAndDefineClass(entityType, viewKind, mode, classEntry);
            this.classRegistry.registerClass(entityType, path, classEntry.className, classEntry.classConfig);
        } else
            Ext.require(classEntry.className);
    },


    /**
     * @private
     * @param {string} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode WebClient.ListViewMode или WebClient.CardViewMode
     * @param {WebClient.common.util.ClassRegistryEntry} classEntry Entry в которую записывается имя класса и его конфигурацию 
     */
    createAutoClassEntryAndDefineClass: function(entityType, viewKind, mode, classEntry) {
        this.createAutoClassEntry(entityType, viewKind, mode, classEntry);
        Ext.define(classEntry.className, classEntry.classConfig);
    },

    /**
     * @protected
     * @param {string} entityType
     * @param {WebClient.ViewKind} viewKind
     * @param {} mode WebClient.ListViewMode или WebClient.CardViewMode
     * @param {WebClient.common.util.ClassRegistryEntry} classEntry Entry в которую дополняется имя класса и расширяется его конфигурация.
     */
    createAutoClassEntry: function(entityType, viewKind, mode, classEntry) {
        classEntry.className = this.getAutoClassName(entityType, viewKind, mode);
        var defaultConfig =
            {
                extend: (viewKind === WebClient.ViewKind.CARD)
                    ? this.defaultCardClass
                    : (mode === WebClient.ListViewMode.LOOKUP ? this.defaultLookupClass : this.defaultListClass),
                entityType: entityType
            };

        classEntry.classConfig = Ext.merge(defaultConfig, classEntry.classConfig);
    },

    /**
     * @protected
     * @param {string} entityType
     * @return {string}
     */
    getAutoClassName: function(entityType, viewKind, mode) {
        return 'WebClient.$runtime.controller.entity.' + entityType + '.' + Ext.String.capitalize(mode || viewKind);
    },


    /** @private */
    getPath: function(viewKind, mode) {
        return WebClient.concat(viewKind, mode, '.');
    }

});
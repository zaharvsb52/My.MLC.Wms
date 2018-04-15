/**
 * Коллекция {@link Ext.data.Store store-ов). Элементы идентифицируемы именем структуры, как её понимает сервер.
 * DataContext это место, куда могут загружаться разнотипные данные с сервера, сразу несколько или по одному. 
 * DataContext это "Model" в паттерне MVC, контроллер создает один DataContext для своей работы с разнотипными данными. 
 * View могут обращаться к данным в DataContext-е через механизм {@link WebClient.common.data.binding.Manager data binding-а}.
 */
Ext.define('WebClient.common.data.DataContext', {
    requires: [
        'WebClient.common.data.contextModel.Model'
    ],

    statics: {

        /**
         * Создает Store по Ext.data/Model, опционально ассоциированный с указанным именем структуры
         * @param {Ect.data.Model} model
         * @param {String} name Optional
         * @param {Object} storeConfig Optional конфигурация store, в её свойствах можно указать свойство <b>type</b> (String)- полное имя класса создаваемого store-а
         * @return {Ext.data.Store}
         */
        createStore: function(model, structureName, storeConfig) {
            Assert.notEmpty(model, 'model');

            if (!structureName)
                structureName = WebClient.common.data.contextModel.Model.getStructureName(model);

            storeConfig = storeConfig || {};

            var isRemote = (model.getProxy() instanceof Ext.data.proxy.Server);

            if (isRemote) {
                Ext.applyIf(storeConfig, {
                    remoteSort: true, // to enable sorting at server-side
                    remoteFilter: true,
                    autoFilter: false // WebClient.common.filters.FilterBinder автоматически делает перезагрузку. см. reload
                });
            }

            //См. JsDataProxy.pagingUnsupported на сервере
            if (model.getProxy().pagingUnsupported) {
                Ext.applyIf(storeConfig, {
                    pageSize: 0
                });
            }

            Ext.apply(storeConfig, {
                name: structureName, // новое поле у Store
                model: model
            });

            var type = storeConfig.type || 'Ext.data.Store';

            return Ext.create(type, storeConfig);
        },

        getStructureName: function(store) {
            var ret = store.name || WebClient.common.data.contextModel.Model.getStructureName(store.model);
            if (!ret)
                Ext.Error.raise('store или его model "' + Ext.getClassName(store.model) + '" должно содержать name - имя структуры на сервере, которую store представляет');

            return ret;
        }
    },


    /**
     * Map of Stores, keyed by store.name
     * @private
     * @type Ext.util.MixedCollection
     */
    stores: undefined,

    /**
     * Фабрика store-ов, которая срабатывает если запрашивают не существующий store в методе {@link #takeStore}
     * Optional
     * @type WebClient.common.data.IStoreFactory 
     */
    storeFactory: undefined,


    constructor: function(config) {
        Ext.apply(this, config);

        this.stores = new Ext.util.MixedCollection(false, function(store) { return WebClient.common.data.DataContext.getStructureName(store); });
    },

    addStore: function(store) {
        var key = this.stores.getKey(store);
        if (this.stores.getByKey(key))
            Ext.Error.raise('store "' + key + '" уже добавлен');

        this.stores.add(store);
    },

    /**
     * Возвращает (по имени структуры) Store уже существующий ранее. Если не найден - ошибка
     * @param {String} name
     * @return {Ext.data.Store}
     */
    getStore: function(structureName) {
        var ret = this.stores.get(structureName);
        if (!ret)
            Ext.Error.raise('Store "' + structureName + '" is not registered in the data context');
        return ret;
    },

    /**
     * Возвращает существующий store по имени структуры, и, если нет, создает его, используя назначеную storeFactory
     * @param {String} structureName имя создаваемой\доставаемой стуктуры
     * @return {Ext.data.Store}
     */
    takeStore: function(structureName) {
        Assert.notEmpty(structureName, 'structureName');

        var ret = this.stores.get(structureName);
        if (!ret) {
            Assert.notEmpty(this.storeFactory);
            ret = this.storeFactory.create(structureName);
            this.stores.add(ret);
        }

        return ret;
    },

    /**
     * Helper функция, которая возвращает {@link WebClient.common.data.contextModel.Model}, "привязанный" к этому
     * дата контексту. Применимо в случаях, если store-ы в дата контексте создаются по указанной модели через
     * {@link WebClient.common.data.DataContextModelStoreFactory}, иначе ошибка.  
     * @return {WebClient.common.data.contextModel.Model} 
     */
    getModel: function() {
        var ret = this.tryGetModel();
        if (!ret)
            Ext.Error.raise('DataContext не привязан к data context model-и через WebClient.common.data.DataContextModelStoreFactory');
        return ret;
    },

    /**
     * Helper функция, которая возвращает {@link WebClient.common.data.contextModel.Model}, "привязанный" к этому
     * дата контексту. Применимо в случаях, если store-ы в дата контексте создаются по указанной модели через
     * {@link WebClient.common.data.DataContextModelStoreFactory}, иначе возвращается пустой.  
     * @return {WebClient.common.data.contextModel.Model} 
     */
    tryGetModel: function() {
        if (this.storeFactory instanceof WebClient.common.data.DataContextModelStoreFactory)
            return this.storeFactory.getModel();
    }
});
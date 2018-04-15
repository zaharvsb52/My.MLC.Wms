/**
 * Фабрика {@link Ext.data.Store store-ов} создаваемых по структурам, определенным в {@link WebClient.common.data.contextModel.Model}
 */
Ext.define('WebClient.common.data.DataContextModelStoreFactory', {
    mixins: {
        'WebClient.common.data.IStoreFactory': 'WebClient.common.data.IStoreFactory'
    },

    /**
     * Используя это свойство, вы можете явно переопределить конфигурацию каждой из {@link Ext.data.Store},
     * создаваемой этой фабрикой. Часто используется установка свойства <b>autoDataLoad</b> или <b>type</b> (задает тип 
     * создаваемого объекта, такие как {@link Ext.data.Store} или {@link Ext.data.TreeStore}.
     * Это объект, каждый мембер которого есть задание конфигурации store-а; имя мембера - имя структуры в {@link #model}.
     * @type Object
     */
    storeConfigs: undefined,

    /**
     * Data context model, информация о структурах которого используется, чтобы создать нужный store.
     * Может быть передан ресурс
     * @resource
     * @type WebClient.common.data.contextModel.Model 
     */
    model: undefined,

    /**
     * @private
     * @type Boolean
     */
    storeConfigsChecked: false,

    /**
     * @param {WebClient.common.data.contextModel.Model} model может быть передан как ресурс
     */
    constructor: function(model, storeConfigs) {
        Assert.notEmpty(model);
        this.model = model;
        this.storeConfigs = storeConfigs;
    },

    getModel: function() {
        return WebClient.unbox(this.model);
    },

    /**
     * @param {String} structureName имя структуры, по которой создается store
     * @param {Object} storeConfig optional переопределение конфигурации структуры 
     * @return {Ext.data.Store}
     */
    create: function(structureName, storeConfig) {
        var dcmodel = WebClient.unbox(this.model);

        var structureModel = dcmodel.getStructure(structureName);

        storeConfig = storeConfig || {};
        if (this.storeConfigs) {
            if (!this.storeConfigsChecked) {
                //проверка, что ничего лишнего не задекларировано в storeConfigs, что не опечатались
                for (var i in this.storeConfigs) {
                    if (!dcmodel.hasStructure(i))
                        Ext.Error.raise('В DataContextModelStoreFactory было передано переопределение store для не существующей структуры. Имя: ' + i);
                }
                this.storeConfigsChecked = true;
            }

            storeConfig = Ext.merge(storeConfig, this.storeConfigs[structureName]);
        }

        return WebClient.common.data.DataContext.createStore(structureModel, structureName, storeConfig);
    }
});
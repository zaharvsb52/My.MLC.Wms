/**
 * Коллекция мета-информации о структурах данных, известных серверу. Каждая структура представлена объектом {@link Ext.data.Model}
 * с большим, чем в ExtJS количеством информции в полях. 
 * Каждая структура ассоциирована с именем, и это имя отличается от названия класса-наследника Ext.data.Model. Это необходимо,
 * чтобы была возможность перегрузить информацию о конкретной структуре с сервера без перечитывания страницы браузера. 
 */
Ext.define('WebClient.common.data.contextModel.Model', {
    statics: {
        /**
         * Возвращает имя структуры ассоциированной с указанной Ext.data.Model 
         * @param {Ext.data.Store} model
         * @return {String}
         */
        getStructureName: function(model) {
            var ret = model.prototype.name;
            if (!ret)
                Ext.Error.raise('Имя структуры для Ext.data.Model "' + Ext.getClassName(model) + '" не было определено');
            return ret;
        },

        /**
         * Создает класс Ext.data.Model с автогенерящимся именем класса. 
         * Этим методом стоит пользоваться, если структура этой Ext.data.Model может меняться в течение жизни страницы, например, когда
         * пользователь выбрал другой набор колонок для показа
         * @param {Object} dataModelConfig
         * @return {Ext.data.Model}
         */
        createStructure: function(dataModelConfig) {
            var clsName = 'WebClient.$runtime.data.AutoStructure-' + Ext.id(undefined, '_');
            Ext.define(clsName, dataModelConfig);
            return Ext.getClass(clsName);
        }
    },

    /**
     * @type String 
     */
    name: undefined,

    /**
     * @type String 
     */
    commitMethod: undefined,

    /** 
     * Map of structures, keyed by model.name
     * @private
     * @type Ext.util.MixedCollection
     */
    structures: undefined,

    constructor: function(config) {
        Ext.apply(this, config);

        this.structures = new Ext.util.MixedCollection(true, function(model) { return WebClient.common.data.contextModel.Model.getStructureName(model); });
    },

    hasStructure: function(name) {
        return !!this.structures.get(name);
    },

    /**
     * Возвращает Model зарегистрированный ранее в этом объекте-е ассоциированный с указанным именем структуры
     * @param {String} name
     * @return {Ext.data.Model}
     */
    getStructure: function(name) {
        var ret = this.structures.get(name);
        if (!ret)
            Ext.Error.raise('Record structure "' + name + '" is not registered in the data context model');
        return ret;
    },

    /**
     * Добавляет Ext.data.Model ассоциированный с указанным именем структуры
     * @param {Ect.data.Model} model
     * @param {String} name Optional
     */
    addStructure: function(model, name) {
        Assert.notEmpty(model, 'model');
        if (name)
            model.prototype.name = name;
        else
            name = model.prototype.name;

        Assert.notEmpty(name, 'name or model.prototype.name');

        Assert.isFalse(this.structures.containsKey(name), 'this.structures.containsKey(name)');

        this.structures.add(model);
    }

});
/**
 * Создает объект WebClient.common.data.contextModel.Model на основе данных, как указано в серверном объекте JsDataContextModel.
 * Создаваемые классы структур (от Ext.data.Model) имеют автогенеренные имена для того, чтобы они могли изменяться в течение
 * жизни страницы, например, когда пользователь выбрал другой набор колонок для показа и нужно (пере)создать контекстную модель 
 * для конкретной формы.
 */
Ext.define('WebClient.common.data.contextModel.Builder', {
    requires: [
        'WebClient.common.data.Identifiable',
        'WebClient.common.data.contextModel.Model',
        'WebClient.common.data.StructureExtender',
        'WebClient.common.data.FieldExtender',
        'WebClient.common.dataServices.ServerMethodHelper',
        'WebClient.common.data.field.EntityId',
        'WebClient.common.data.field.EntityRef',
        'WebClient.common.data.field.EntityRefCollection'
    ],

    /**
     * Используя это свойство, вы можете явно переопределить конфигурации каждой из структур (Ext.data.Model),
     * возвращаемой с сервера. Часто используется для задания определенных proxy для Ext.data.Model.
     * Это объект, каждый мембер которого есть переопределение конфигурации структуры (с именем свойства) над данными, 
     * вернувшимися с сервера.
     * @type Object
     */
    structureConfigs: undefined,

    /**
     * @private
     * Результат сборки модели
     * @type {WebClient.common.data.contextModel.Model}
     */
    model: undefined,

    /** 
     * @private
     * Каждый элемент - данные для соответсвующей ассоциации
     * @type {Array}
     */
    associations: undefined,

    /** 
     * @private
     * Каждое свойство - данные для соответсвующей структуры
     * @type {Object}
     */
    structures: undefined,

    build: function(modelName, data, structureConfigs) {
        Assert.notEmpty(data, 'data');
        Assert.notEmpty(data.structures, 'data.structures');

        this.model = new WebClient.common.data.contextModel.Model({
            name: modelName,
            commitMethod: data.commitMethod
        });
        this.data = data;
        this.structureConfigs = structureConfigs || {};
        this.associations = [];
        this.structures = {};

        this.beforeBuild();

        Ext.each(data.structures, this.prepareStructure, this);
        Ext.each(data.associations, this.prepareAssociation, this);

        for (var s in this.structures)
            this.createStructureAndAddToModel(this.structures[s]);

        Ext.each(this.associations, this.addAssociation, this);

        //проверка, что ничего лишнего не задекларировано в structureConfigs, что не опечатались
        for (var i in this.structureConfigs) {
            if (!this.structures[i])
                Ext.Error.raise('В построитель DataContextModel было передано переопределение для не существующей структуры. Возможно, было задано ошибочное имя. Имя: ' + i);
        }

        return this.model;
    },

    beforeBuild: function() {
    },

    prepareStructure: function(sdata) {
        Assert.notEmpty(sdata.name, 'sdata.name');
        sdata = Ext.merge(sdata, this.structureConfigs[sdata.name]);

        if (!sdata.className)
            sdata.className = this.newStructureId();

        if (sdata.schema) {
            Ext.log({ msg: 'Переопределение схемы не поддерживается. Для работы ассоциаций все структуры должны быть в схеме по-умолчанию. Имя структуры: ' + sdata.name, level: 'warn' });
            delete sdata.schema;
        }

        this.defineStructureBaseClassAndMixins(sdata);

        this.structures[sdata.name] = sdata;
    },

    prepareAssociation: function(adata) {
        Assert.notEmpty(adata.leftStructureName, 'adata.leftStructureName');
        Assert.notEmpty(adata.leftRole, 'adata.leftRole');
        Assert.notEmpty(adata.rightStructureName, 'adata.rightStructureName');
        Assert.notEmpty(adata.rightRole, 'adata.rightRole');
        Assert.notEmpty(adata.type, 'adata.type');

        if (adata.type !== 'manyToOne') {
            Ext.log({ msg: 'Тип ассоциации не поддерживается. Ассоциация: ' + WebClient.toDebugString(adata), level: 'warn' });
            return;
        }

        var leftStruct = this.structures[adata.leftStructureName];
        if (!leftStruct)
            Ext.Error.raise('Ассоциация ссылается на незаданную структуру. Неверное имя структуры: ' + adata.leftStructureName + '. Ассоциация: ' + WebClient.toDebugString(adata));

        var rightStruct = this.structures[adata.rightStructureName];
        if (!rightStruct)
            Ext.Error.raise('Ассоциация ссылается на незаданную структуру. Неверное имя структуры: ' + adata.rightStructureName + '. Ассоциация:' + WebClient.toDebugString(adata));

        this.associations.push({
            leftStruct: leftStruct,
            leftRole: adata.leftRole,
            rightStruct: rightStruct,
            rightRole: adata.rightRole,
            type: adata.type,
            referenceFieldName: adata.referenceFieldName
        });
    },

    createStructureAndAddToModel: function(sconfig) {
        var s = this.createStructure(sconfig);
        this.model.addStructure(s);
    },

    createStructure: function(sconfig) {
        this.defineStructureProxy(sconfig);
        var clsName = sconfig.className;
        delete sconfig.className;
        Ext.define(clsName, sconfig);
        var cls = Ext.ClassManager.get(clsName);
        WebClient.common.data.StructureExtender.postProcessStructure(cls.prototype);
        WebClient.common.data.FieldExtender.postProcessStructure(cls.prototype);
        return cls;
    },

    defineStructureProxy: function(sconfig) {
        if (!sconfig.proxy)
            sconfig.proxy = WebClient.common.dataServices.ServerMethodHelper.buildInMemoryProxyConfig();
    },

    addAssociation: function(aconfig) {
        // default schema
        var schema = Ext.data.schema.Schema.get('default'),
            leftFields = WebClient.common.data.StructureExtender.getFields(this.model.getStructure(aconfig.leftStruct.name)),
            refField = Ext.Array.findBy(leftFields, function(f) { return f.getName() == aconfig.referenceFieldName; });

        schema.addReference(
            this.model.getStructure(aconfig.leftStruct.name), // entityType
            refField, // referenceField
            {
                // descr
                type: this.model.getStructure(aconfig.rightStruct.name).entityName,
                role: aconfig.rightRole,
                inverse: {
                    role: aconfig.leftRole
                }
            },
            false); // unique
    },

    /**
     * @protected
     */
    newStructureId: function() {
        return 'WebClient.$runtime.data.AutoStructure' + Ext.id(undefined, '_');
    },

    /**
     * @protected
     */
    defineStructureBaseClassAndMixins: function(sdata) {
        if (!sdata.extend)
            sdata.extend = 'Ext.data.Model';

        if (sdata.entityType)
            sdata.mixins = Ext.apply({ identifiable: 'WebClient.common.data.Identifiable' }, sdata.mixins);
    }

});
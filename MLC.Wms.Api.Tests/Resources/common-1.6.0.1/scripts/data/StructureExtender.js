/**
 * Этот класс работает с дополнительной мета-информацией структуры, засунутой в Ext.data.Model.prototype (представитель
 * структуры в ExtJS), такой как filterFields, sortFields
 */
Ext.define('WebClient.common.data.StructureExtender', {
    requires: [
        'Ext.data.field.Field'
    ],

    singleton: true,

    getFields: function(extDataModelOrPrototype) {
        Assert.notEmpty(extDataModelOrPrototype);
        return extDataModelOrPrototype.fields || extDataModelOrPrototype.prototype.fields;
    },

    getFilterFields: function(extDataModelOrPrototype) {
        Assert.notEmpty(extDataModelOrPrototype);
        var ret = extDataModelOrPrototype.filterFields || extDataModelOrPrototype.prototype.filterFields;
        return ret || [];
    },

    getSortFields: function(extDataModelOrPrototype) {
        Assert.notEmpty(extDataModelOrPrototype);
        var ret = extDataModelOrPrototype.sortFields || extDataModelOrPrototype.prototype.sortFields;
        return ret || [];
    },

    /**
     * Этот метод используется для добавления дополнительной (к Ext.data.Model) мета информации в созданный класс
     * Анализирует json данные для filterFields и sortFields и преобразует их в соответсвующие коллекции - поля класса
     * @inner
     * @param {Ext.Class} extDataModelPrototype класс созданного Ext.data.Model
     */
    postProcessStructure: function(extDataModelPrototype) {
        this.createFields(extDataModelPrototype, 'filterFields');
        this.createFields(extDataModelPrototype, 'sortFields');
    },

    /**
     * @private
     */
    createFields: function(extDataModelPrototype, pn) {
        var fields = extDataModelPrototype[pn];

        if (fields && fields.$processed) //already processed
            return;

        var fieldsArray = [];
        fieldsArray.$processed = true;

        if (fields) {
            for (var i = 0, ln = fields.length; i < ln; ++i)
                fieldsArray.push(Ext.data.field.Field.create(fields[i]));
        }

        extDataModelPrototype[pn] = fieldsArray;
    }
});
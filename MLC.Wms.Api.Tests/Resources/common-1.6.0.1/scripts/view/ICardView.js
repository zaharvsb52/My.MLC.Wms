Ext.define('WebClient.common.view.ICardView', {
    extend: 'WebClient.common.Interface',

    /**
     * See {@link Ext.form.Basic#load}
     * @param {Object} options
     */
    load: function(options) {},

    /**
     * See {@link Ext.form.Basic#submit}
     * @param {Object} options
     */
    submit: function(options) {},

    /**
     * See {@link Ext.form.Basic#loadRecord}
     * @param {Ext.data.Model} record
     */
    loadRecord: function(record) {},

    /**
     * See {@link Ext.form.Basic#getRecord}
     * @return {Ext.data.Model}
     */
    getRecord: function() {},

    /**
     * See {@link Ext.form.Basic#updateRecord}
     * @param {Ext.data.Model} record
     */
    updateRecord: function(record) {},

    /**
     * Возвращает HasValue для элемента формы или поля загруженной записи, если элемент не найден
     * @param {String} sourceName
     * @param {String} sourceValueName
     * @returns {WebClient.common.binding.HasValue}
     */
    getHasValue: function(sourceName, sourceValueName) {}
});
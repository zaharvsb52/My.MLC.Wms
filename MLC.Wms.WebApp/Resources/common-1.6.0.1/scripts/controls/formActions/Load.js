/**
 * Этот класс загружает форму с полями данными через обращение к методу load объекта {@link Ext.data.model model} установленного на форме
 */
Ext.define('WebClient.common.controls.formActions.Load', {
    extend: 'Ext.form.action.Load',
    requires: ['Ext.direct.Manager'],
    alias: 'formaction.modelload',

    run: function() {
        var params = this.getParams();
        var config = this.createCallback();
        config.params = params;

        var model = this.form.owner.model;
        Assert.notEmpty(model, 'this.form.owner.model');

        model.load(params.id, config);
    },

    /**
     * @private
     */
    onSuccess: function(record) {
        var form = this.form;
        form.clearInvalid();
        form.loadRecord(record);
        form.afterAction(this, true);
    }
});
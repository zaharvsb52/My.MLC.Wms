/**
 * Этот класс сохраняет форму с полями данных через обращение к методу save объекта {@link Ext.data.model model}, установленного на форме.
 */
Ext.define('WebClient.common.controls.formActions.Save', {
    extend: 'Ext.form.action.Action',
    requires: ['Ext.direct.Manager'],
    alias: 'formaction.modelsave',

    run: function() {
        var form = this.form;
        var record = form.getRecord();
        form.updateRecord(record);

        if (this.form.onBeforeSave(this) !== false) {
            var params = this.getParams();
            var options = this.createCallback();
            options.params = params;
            record.save(options);
        }
    },

    /**
     * @private
     */
    onSuccess: function(record) {
        var form = this.form;
        form.afterAction(this, true);
        record.commit();
        form.loadRecord(record);
    }
});
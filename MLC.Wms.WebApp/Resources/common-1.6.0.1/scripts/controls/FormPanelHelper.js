Ext.define('WebClient.common.controls.FormPanelHelper', {
    singleton: true,

    /**
     * @param {Ext.form.Panel} formPanel
     * @return {Ext.LoadMask}
     */
    getOrCreateLoadMask: function(formPanel) {
        if (!formPanel.loadMask)
            formPanel.loadMask = new Ext.LoadMask({ target: formPanel });
        return formPanel.loadMask;
    },

    /**
     * @param {Ext.form.Panel} formPanel
     * @return {Ext.LoadMask/Null}
     */
    tryGetLoadMask: function(formPanel) {
        return formPanel.loadMask;
    },

    /**
     * Создает (или получает созданную) {@link Ext.LoadMask} ассоциированную с formPanel и при-binded к store
     * @param {} formPanel
     * @param {} store
     */
    takeMaskForPanelAndBindToStore: function(formPanel, store) {
        Assert.notEmpty(formPanel, 'formPanel');
        Assert.notEmpty(store, 'store');

        var mask = this.getOrCreateLoadMask(formPanel);
        mask.bindStore(null);
        mask.bindStore(store);
        return mask;
    },

    /**
     * Загружает данные в {@link Ext.form.Panel} путем вызова {@link Ext.data.Store#load}, ожидая, что сервер вернет одну и только одну запись
     * @param {Ext.form.Panel} formPanel
     * @param {Ext.data.Store} store
     * @param {Object} dataParams optional
     */
    loadData: function(formPanel, store, dataParams) {
        this.takeMaskForPanelAndBindToStore(formPanel, store);

        store.load({
            params: dataParams,
            callback: Ext.Function.pass(this.loadDataCallback, [formPanel]),
            scope: this
        });
    },

    /**
     * Загружает данные, пришедшие в callback результат работы {@link Ext.data.Store#load}, в {@link Ext.form.Panel}
     * @param {Ext.form.Panel} formPanel
     * @param {} records параметр callback-а в store.load
     * @param {} operation параметр callback-а в store.load
     * @param {} success параметр callback-а в store.load
     */
    loadDataCallback: function(formPanel, records, operation, success) {
        if (success) //otherwise error is handled globally
        {
            if (!records.length)
                WebClient.showInternalError('Сервер не вернул ожидаемых данных');
            else if (records.length > 1)
                WebClient.showInternalError('Сервер вернул больше данных, чем ожидалось');
            else {
                var record = records[0];
                formPanel.getForm().loadRecord(record);
                var fieldsToDisable = record.get('__disable');
                if (fieldsToDisable && fieldsToDisable.length) {
                    Ext.each(fieldsToDisable, function(name) {
                        var field = formPanel.getForm().findField(name);
                        if (field)
                            field.setReadOnly(true);
                    });
                }
            }
        }
    }
});
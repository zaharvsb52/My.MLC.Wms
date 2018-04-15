Ext.define('MLC.wms.schJob.JobParamCardController', {
    extend: 'MLC.wms.schJob.EntityCardWithJob',

    loadData: function () {
        var me = this,
            parent = me.dataParams.parentRecord,
            form = me.view.getForm(),
            nameField = form.findField('Name'),
            jobTypeParamField = form.findField('JobTypeParam');

        me.callParent(arguments);

        if (me.mode === WebClient.CardViewMode.CREATE) {
            // добавляем фильтр на параметры по типу задания
            jobTypeParamField.getFilterable().getFilters()
                .add('', new Ext.util.Filter({ property: 'JobType', operator: WebClient.FilterOps.EQ, value: parent.get('JobType') }));
            // подписываемся на изменение
            jobTypeParamField.on('change', Ext.Function.bind(function () {
                var fieldValue = jobTypeParamField.getValue();
                if (!fieldValue) {
                    nameField.setValue(null);
                    nameField.focus();
                } else {
                    nameField.setValue(fieldValue.getValuesObject().Code);
                    form.findField('Value').focus();
                }
            }, me));
        } else {
            // при редактировнии - блокируем возможность выбора параметра (пусть удаляют и снова делают)
            jobTypeParamField.readOnly = true;
            var fieldValue = jobTypeParamField.getValue();
            if (fieldValue)
                nameField.readOnly = true;
        }
    }

});
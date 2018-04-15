Ext.define('MLC.wms.schJob.EntityCardWithJob', {
    extend: 'WebClient.common.controller.EntityCard',

    loadData: function () {
        var me = this,
            form = me.view.getForm(),
            jobField = form.findField('Job');

        me.callParent(arguments);

        if (jobField) {
            // прячем само поле Job-а
            jobField.hide();

            // если создаем новое - заполняем поле Job-а
            if (me.mode === WebClient.CardViewMode.CREATE) {
                var parent = me.dataParams.parentRecord;
                if (parent != null) {
                    var entityId = parent.getEntityId();

                    var entRef = new WebClient.common.type.EntityRef({
                        id: entityId.id,
                        type: entityId.type,
                        values: [{ name: 'ID', value: entityId.id }, { name: 'Code', value: parent.get('Code') }]
                    });

                    jobField.setValue(entRef);
                }
            }
        }
    }

});
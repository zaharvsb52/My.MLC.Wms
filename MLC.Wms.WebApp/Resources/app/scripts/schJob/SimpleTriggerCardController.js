Ext.define('MLC.wms.schJob.SimpleTriggerCardController', {
    extend: 'MLC.wms.schJob.EntityCardWithJob',

    loadData: function () {
        var me = this;
        me.callParent(arguments);

        if (me.mode === WebClient.CardViewMode.CREATE) {
            var parent = me.dataParams.parentRecord,
                form = me.view.getForm(),
                schedulerField = form.findField('Scheduler'),
                codeField = form.findField('Code'),
                triggerGroupField = form.findField('TriggerGroup'),
                priorityField = form.findField('Priority'),
                startTimeUtc = form.findField('StartTimeUtc'),
                disabledField = form.findField('Disabled');

            // выставляем default_ы
            if (parent) {
                schedulerField.setValue(parent.get('Scheduler'));
                codeField.setValue('TR_' + parent.get('Code'));
                triggerGroupField.setValue(parent.get('JobGroup'));
            }
            priorityField.setValue(100);
            var now = new Date();
            var now_utc = new Date(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDate(), now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds());
            startTimeUtc.setValue(now_utc);
            disabledField.setValue(true);
        }
    }
});
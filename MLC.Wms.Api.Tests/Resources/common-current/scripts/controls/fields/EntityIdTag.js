/* Наследник стандартного Tag для отображения и редактирования EntityId
 */
Ext.define('WebClient.common.controls.fields.EntityIdTag', {
    extend: 'Ext.form.field.Tag',

    alias: ['widget.WebClient.common.controls.fields.EntityIdTag'],

    requires: ['WebClient.common.type.EntityId'],

    /**
     * @type String
     */
    entityType: undefined,

    displayField: 'display',

    valueField: 'text',

    setValue: function (value, add) {
        var me = this,
            valueStore = me.valueStore,
            valueField = me.valueField,
            unknownValues = [],
            record, len, i, valueRecord, cls;

        if (Ext.isEmpty(value)) {
            value = null;
        }
        if (Ext.isString(value) && me.multiSelect) {
            value = value.split(me.delimiter);
        }
        value = Ext.Array.from(value, true);
        value = value.map(function(val) {
            if (!val)
                return null;

            if (val.data && val.data.hasOwnProperty(me.displayField) && val.data.hasOwnProperty(me.valueField))
                return val;

            return new WebClient.common.type.EntityId({
                id: val,
                type: me.entityType
            });
        });

        for (i = 0, len = value.length; i < len; i++) {
            record = value[i];
            if (!record || !record.isModel) {
                valueRecord = valueStore.findExact(valueField, record);
                if (valueRecord > -1) {
                    value[i] = valueStore.getAt(valueRecord);
                } else {
                    valueRecord = me.findRecord(valueField, record);
                    if (!valueRecord) {
                        if (me.forceSelection) {
                            unknownValues.push(record);
                        } else {
                            valueRecord = {};
                            valueRecord[me.valueField] = record;
                            valueRecord[me.displayField] = record.id;

                            cls = me.valueStore.getModel();
                            valueRecord = new cls(valueRecord);
                        }
                    }
                    if (valueRecord) {
                        value[i] = valueRecord;
                    }
                }
            }
        }

        return me.callParent([value, add]);
    }
});
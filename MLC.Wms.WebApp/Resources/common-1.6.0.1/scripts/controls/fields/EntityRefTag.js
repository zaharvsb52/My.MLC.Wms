Ext.define('WebClient.common.controls.fields.EntityRefTag', {
    extend: 'Ext.form.field.Tag',

    alias: ['widget.WebClient.common.controls.fields.EntityRefTag'],

    requires: ['WebClient.common.type.EntityRef'],

    /**
     * @type String
     */
    entityType: undefined,

    displayField: 'display',

    valueField: 'text',

    setValue: function(value, add) {
        var me = this,
            valueStore = me.valueStore,
            valueField = me.valueField,
            unknownValues = [],
            record,
            len,
            i,
            valueRecord,
            cls;

        if (Ext.isEmpty(value)) {
            value = null;
            return me.callParent([value, add]);
        }
        if (Ext.isString(value) && me.multiSelect)
            value = value.split(me.delimiter);

        value = Ext.Array.from(value, true);

        if (!Ext.Array.some(this.value, function(item) {
            return item.id === value[0].id && item.type === value[0].type;
        }))
            value = Ext.Array.union(value, this.value);
        else {
            value = this.value;
            return me.callParent([value, add]);
        }

        value = value.map(function(val) {
            if (!val)
                return null;

            if (val && val.hasOwnProperty('values'))
                return val;

            var entityId = val.getEntityId();

            return new WebClient.common.type.EntityRef({
                type: entityId.type,
                id: entityId.id,
                values: value[0].values
            });
        });

        for (i = 0, len = value.length; i < len; i++) {
            record = value[i];
            if (!record || !record.isModel) {
                valueRecord = valueStore.findExact(valueField, record);
                if (valueRecord > -1)
                    value[i] = valueStore.getAt(valueRecord);
                else {
                    valueRecord = me.findRecord(valueField, record);
                    if (!valueRecord) {
                        if (me.forceSelection)
                            unknownValues.push(record);
                        else {
                            valueRecord = {};
                            valueRecord[me.valueField] = record;
                            valueRecord[me.displayField] = value[i].values[0].value;

                            cls = me.valueStore.getModel();
                            valueRecord = new cls(valueRecord);
                        }
                    }
                    if (valueRecord)
                        value[i] = valueRecord;
                }
            }
        }

        return me.callParent([value, add]);
    }
});
/* Наследник стандартного Text для отображения и редактирования EntityId
 */
Ext.define('WebClient.common.controls.fields.EntityId', {
    extend: 'Ext.form.field.Text',

    alias: ['widget.WebClient.common.controls.fields.EntityId'],

    requires: ['WebClient.common.type.EntityId'],

    /**
     * @type String
     */
    entityType: undefined,

    valueToRaw: function (value) {
        if (!value)
            return '';

        if (Ext.isString(value))
            value = WebClient.common.type.EntityId.decode(value);

        return '' || Ext.valueFrom(value.id, '');
    },

    rawToValue: function (rawValue) {
        if (!rawValue)
            return null;

        return new WebClient.common.type.EntityId({
            id: rawValue,
            type: this.entityType
        });
    }
});
Ext.define('WebClient.common.layout.EnumModel', {
    extend: 'Ext.data.Model',

    statics: {
        COMBOBOX_VALUES_FOR_BOOLEAN: [
            { name: 'Да', value: true },
            { name: 'Нет', value: false }
        ]
    },

    fields: ['name', 'value']
});
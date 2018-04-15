Ext.define('WebClient.common.binding.FormFieldHasValueCreator', {
    extend: 'WebClient.common.binding.HasValueCreator',
    requires: [
        'WebClient.common.binding.ComponentHasValueCreator'
    ],

    nestedCreators: [
        'WebClient.common.binding.ComponentHasValueCreator'
    ],

    knownValueNames: { value: '$hasValue' },

    createHasValue: function(vo, control, valueName, mappedField) {
        if (valueName == 'value') {
            vo.get = Ext.bind(control.getValue, control);
            vo.set = Ext.bind(control.setValue, control);
            control.on('change', function(c, newValue, oldValue) {
                vo.fire(newValue);
            });
            return true;
        }
        return this.callParent(arguments);
    },

    supports: function(control) {
        return control.isFormField;
    }
});
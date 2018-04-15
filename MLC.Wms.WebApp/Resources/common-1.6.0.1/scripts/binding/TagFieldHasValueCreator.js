Ext.define('WebClient.common.binding.TagFieldHasValueCreator', {
    extend: 'WebClient.common.binding.HasValueCreator',
    requires: [
        'WebClient.common.binding.FormFieldHasValueCreator'
    ],

    supportedTypes: ['Ext.form.field.Tag'],

    nestedCreators: [
        'WebClient.common.binding.FormFieldHasValueCreator'
    ],

    knownValueNames: {
        /**
        * код выбранного элемента списка. Переопределяет такой-же из FormFieldHasValueCreator (подписывается к другому событию).
        * Если control.multiSelect = true - вовращает массив значений
        */
        value: '$hasValue'
    },

    createHasValue: function (vo, control, valueName, mappedField) {
        switch (valueName) {

            case 'value':

                vo.get = Ext.bind(control.getValue, control);
                vo.set = Ext.bind(control.setValue, control);

                control.on('change', function (cmb, record) {
                    var v = undefined;
                    if (record) {
                        if (control.multiSelect) {
                            v = [];
                            var i = 0;
                            for (var len = record.length; i < len; i++)
                                v.push(record[i]);
                        } else
                            v = control.valueField;
                    }
                    vo.fire(v);
                });

                return true;
        }
        return this.callParent(arguments);
    }
});
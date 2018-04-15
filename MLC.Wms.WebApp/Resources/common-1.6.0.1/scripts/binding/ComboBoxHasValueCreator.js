Ext.define('WebClient.common.binding.ComboBoxHasValueCreator', {
    extend: 'WebClient.common.binding.HasValueCreator',
    requires: [
        'WebClient.common.binding.FormFieldHasValueCreator'
    ],

    supportedTypes: ['Ext.form.field.ComboBox'],

    nestedCreators: [
        'WebClient.common.binding.FormFieldHasValueCreator'
    ],

    knownValueNames: {
        /**
        * код выбранного элемента списка. Переопределяет такой-же из FormFieldHasValueCreator (подписывается к другому событию).
        * Если control.multiSelect = true - вовращает массив значений
        */
        value: '$hasValue',

        /**
        * Выбранный элемента списка - запись соответсвующего store.
        * Если control.multiSelect = true - вовращает массив записей
        */
        selectedRecord: '$selectedRecordHasValue'
    },

    createHasValue: function(vo, control, valueName, mappedField) {
        switch (valueName) {

        case 'value':

            vo.get = Ext.bind(control.getValue, control);
            vo.set = Ext.bind(control.setValue, control);

            control.on('select', function(cmb, record) {
                var v = undefined;
                if (record) {
                    if (control.multiSelect) {
                        v = [];
                        var i = 0;
                        for (var len = record.length; i < len; i++)
                            v.push(record[i].get(control.valueField));
                    } else
                        v = record.get(control.valueField);
                }
                vo.fire(v);
            });

            return true;


        case 'selectedRecord':

            vo.get = function() {
                var ret = [];
                ExtArray.forEach(control.valueModels || [], function(record) {
                    if (record && record.isModel && control.store.indexOf(record) >= 0)
                        ret.push(record);
                });

                return control.multiSelect ? ret : (ret.length ? ret[0] : undefined);
            };

            vo.set = Ext.bind(control.setValue, control);

            control.on('select', function(cmb, record) {
                vo.fire(record);
            });

            return true;
        }
        return this.callParent(arguments);
    }
});
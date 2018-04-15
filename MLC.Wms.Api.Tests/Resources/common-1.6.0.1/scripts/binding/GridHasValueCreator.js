Ext.define('WebClient.common.binding.GridHasValueCreator', {
    extend: 'WebClient.common.binding.HasValueCreator',
    requires: [
        'WebClient.common.binding.ComponentHasValueCreator'
    ],

    nestedCreators: [
        'WebClient.common.binding.ComponentHasValueCreator'
    ],

    supportedTypes: ['Ext.grid.Panel', 'Ext.tree.Panel'],

    defaultValueName: 'selectedId',

    knownValueNames: {

        /**
         * Массив id-иков выбранных записей
         */
        selectedId: '$selectedIdHasValue',

        selectedIdFrozen: '$selectedIdFrozenHasValue',

        /**
         * {@link Ext.util.MixedCollection} выбранных записей
         */
        selected: '$selectedHasValue',

        selectedFrozen: '$selectedFrozenHasValue'
    },

    createHasValue: function (vo, control, valueName, mappedField) {
        var me = this;

        if (valueName == 'selectedIdFrozen' || valueName == 'selectedFrozen') {
            //Необходимо чтобы при сортировке (как пример) при скидывании selection selectedValue не сообщал о изменениях
            control.getStore().on({
                beforeload: function () { vo.selectedValueFrozen = true; },
                load: function () { vo.selectedValueFrozen = false; }
            });
        }

        switch (valueName) {
            case 'selectedId':

                vo.get = function () { return me.collectIds(control.getSelectionModel().getSelection()); };
                //vo.set is not supported

                //event binding
                if (Ext.getClassName(control.getSelectionModel()) === 'Ext.grid.selection.SpreadsheetModel') {
                    // fires GRID event
                    control.on('selectionchange', function (model, records) {
                        if (!vo.selectedValueFrozen)
                            vo.fire(me.collectIds(records.getRecords()));
                    });
                } else {
                    // fires SelectionModel event
                    control.getSelectionModel().on('selectionchange', function (model, records) {
                        if (!vo.selectedValueFrozen)
                            vo.fire(me.collectIds(records));
                    });
                }
                return true;

            case 'selected':

                vo.get = function () { return control.getSelectionModel().getSelection(); };
                //vo.set is not supported

                //event binding
                if (Ext.getClassName(control.getSelectionModel()) === 'Ext.grid.selection.SpreadsheetModel') {
                    // fires GRID event
                    control.on('selectionchange', function (model, records) {
                        if (!vo.selectedValueFrozen)
                            vo.fire(records.getRecords());
                    });
                } else {
                    // fires SelectionModel event
                    control.getSelectionModel().on('selectionchange', function (model, records) {
                        if (!vo.selectedValueFrozen)
                            vo.fire(records);
                    });
                }
                return true;
        }

        return this.callParent(arguments);
    },

    /**
     * @private
     */
    collectIds: function (selectedRows) {
        var ret = [];
        var fget = function (r) {
            return Ext.isFunction(r.getEntityId) ? r.getEntityId() : r.getId();
        };
        Ext.Array.forEach(selectedRows, function (r) { return ret.push(fget(r)); });
        return ret;
    }
});
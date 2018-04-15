/* Наследник стандартного ComboBox. В дополнении к базовому, поддерживает {@link Ext.form.field.ComboBox#allowBlank} при 
 * 'local' {@link Ext.form.field.ComboBox#queryMode} - в этом случае добавляет пустой элемент в store (если нет), и дает
 * нормальную возможность с клавиатуры очистить значение (при editable = true) 
 */
Ext.define('WebClient.common.controls.fields.ComboBox', {
    extend: 'Ext.form.field.ComboBox',

    alias: ['widget.WebClient.common.controls.fields.ComboBox'],

    constructor: function(cfg) {
        var defaultCfg = {
            forceSelection: true,
            selectOnFocus: true,
            emptyText: '(нет значения)',
            valueNotFoundText: '(не найдено)',
            triggerAction: 'all',
            listConfig: {
                getInnerTpl: function(displayField) { return '{' + displayField + ':defaultValue("&nbsp;")}'; }
            }
        };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    },

    bindStore: function(store, initial) {
        this.callParent(arguments);
        if (store != null) { //bindStore(null) is called in onDestroy in parent class
            this.ensureEmptyItemAddedIfRequired();
        }
    },

    onLoad: function() {
        this.ensureEmptyItemAddedIfRequired();
        this.callParent(arguments);
    },

    // removes 'dummy' empty record from selections
    onListSelectionChange: function(list, selectedRecords) {
        var me = this,
            valueField = me.valueField;

        if (me.multiSelect && me.allowBlank && me.queryMode === 'local') {
            for (var i = selectedRecords.length - 1; i >= 0; i--) {
                if (selectedRecords[i].get(valueField) === '') {
                    selectedRecords = Ext.Array.clone(selectedRecords); //this event parameter may be consumed by event handlers
                    selectedRecords.splice(i, 1); //removes
                    break;
                }
            }
        }

        me.callParent([list, selectedRecords]);
    },

    ensureEmptyItemAddedIfRequired: function() {
        var me = this;
        if (me.allowBlank && me.queryMode === 'local' && me.store.find('', me.valueField) < 0) {
            var rec = {};
            rec[me.valueField] = '';
            rec[me.displayField] = '';
            me.store.insert(0, rec);
        }
    },

    //Переопределен, чтобы при выделении текста и нажатии DEL (или BACKSPACE), drop-down список не оставался на предыдущем значении, а попадал на пустое или первое
    doAutoSelect: function() {
        var me = this,
            picker = me.picker;

        if (picker && me.autoSelect && me.store.getCount() > 0 && !this.getRawValue()) { //if empty text 
            picker.getSelectionModel().doDeselect(this.store.data.items, true);
        }

        this.callParent(arguments);
    }
});
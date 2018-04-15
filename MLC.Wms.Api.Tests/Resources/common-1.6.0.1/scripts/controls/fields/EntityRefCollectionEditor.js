Ext.define('WebClient.common.controls.fields.EntityRefCollectionEditor', {
    alias: ['widget.WebClient.common.controls.fields.EntityRefCollectionEditor'],

    extend: 'Ext.form.field.Picker',

    mixins: {
        filterable: 'WebClient.common.controls.fields.FilterableFieldMixin'
    },

    requires: [
        'WebClient.common.util.doT',
        'WebClient.common.data.EntityRefHelper',
        'WebClient.common.type.EntityRefCollection',
        'WebClient.common.workspace.RoomContainer'
    ],

    triggers: {
        picker: {
            cls: 'ef-trigger ef-trigger-search',
            handler: 'onTriggerClick',
            scope: 'this'
        },
        clear: {
            cls: 'ef-trigger ef-trigger-clear',
            handler: function () {
                this.clearValue();
            }
        }
    },

    /**
    * Предопределённые фильтры для грида, массив объект {@link Ext.util.Filter}
    * @public
    * @type Array
    */
    filters: undefined,

    /**
     * @private
     * @type WebClient.common.appController.Entity 
     */
    appController: undefined,

    /**
     * Container связанный с picker-окном, в котором будет показываться view
     * @type WebClient.common.workspace.Container 
     */
    container: undefined,

    entityRefDescriptor: undefined,

    template: undefined,

    constructor: function (cfg) {
        var format = cfg.entityRefDescriptor.format,
            template = format ? WebClient.common.util.doT.template(format) : null;

        var defaultCfg = {
            editable: false,
            matchFieldWidth: false,
            pickerAlign: 'tl-bl?',
            emptyText: '(нет значения)',
            template: template
        };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    },

    valueToRaw: function (value) {
        if (!value)
            return '';

        if (!this.template)
            return value.toString();

        var t = this.template;
        return Ext.Array.map(value.items, function (i) { return t(i.getValuesObject()); }).join(', ');
    },

    setValue: function (v) {
        v = v || WebClient.common.type.EntityRefCollection.createEmpty(this.entityRefDescriptor.entityType);
        this.callParent([v]);
    },

    getValue: function () {
        var v = this.value;
        return v;
    },

    createPicker: function () {
        var me = this,
            picker = Ext.create('Ext.panel.Panel', {
                height: 600,
                width: 800,
                scrollable: true,
                floating: true,
                layout: 'fit',
                dockedItems: [
                    {
                        xtype: 'toolbar',
                        dock: 'bottom',
                        layout: { pack: 'end' },
                        defaults: {
                            minWidth: 75
                        },
                        items: [
                            { text: 'OK', itemId: 'ok', handler: me.select, scope: me },
                            { text: 'Отмена', itemId: 'cancel', handler: me.collapse, scope: me }
                        ]
                    }
                ]
            });

        this.container = new WebClient.common.workspace.RoomContainer({ room: picker });
        this.container.on('display', this.onViewDisplayed, this);
        return picker;
    },

    onFocusLeave: function (e) {
        var me = this;
        if (!me.picker || !me.picker.owns(e.target))
            me.callParent(arguments);
    },

    onExpand: function () {
        var me = this;

        if (!this.appController) {
            me.initFilterBinder();

            var entityType = this.entityRefDescriptor.entityType;
            WebClient.common.appController.EntityControllerProvider.take(
                entityType,
                function (instance) {
                    me.appController = instance;
                    me.loadSelectForm();
                },
                me);
        } else
            this.loadSelectForm();

        me.picker.down('#ok').focus();
    },

    loadSelectForm: function () {
        var me = this;
        Assert.notEmpty(me.appController, 'this.appController');
        me.appController.select(this.container);
    },

    onViewDisplayed: function (container, view) {
        var me = this;

        var grid = me.picker.down('gridpanel');
        Assert.notEmpty(grid, 'view.down("gridpanel")');

        var selModel = grid.getSelectionModel();
        selModel.setSelectionMode('MULTI');

        var store = grid.getStore();
        me.applyFilterable(store, function (propName) {
            return me.picker.down('#' + propName);
        });

        // Устанавливаем текущие выбранные значения
        var value = me.getValue();
        store.on('load', function () {
            var selection = Ext.Array.map(value.items, function (item) {
                var itemEntityId = item.getEntityId();
                var index = store.findBy(function (record) {
                    return itemEntityId.equals(record.getEntityId());
                });
                return index >= 0 ? store.getAt(index) : null;
            });
            selModel.select(selection, false, true);
        });
    },

    select: function () {
        var me = this,
            grid = me.picker.down('gridpanel'),
            selected = grid.getSelectionModel().getSelection();

        var items = Ext.Array.map(selected, function (record) {
            return WebClient.common.data.EntityRefHelper.createEntityRef(record, me.entityRefDescriptor);
        });

        var value = new WebClient.common.type.EntityRefCollection({
            type: me.entityRefDescriptor.entityType,
            items: items
        });

        me.setValue(value);
        me.collapse();
    },

    clearValue: function () {
        this.setValue(null);
    }
});
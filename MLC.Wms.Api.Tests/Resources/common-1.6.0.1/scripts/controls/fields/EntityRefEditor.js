Ext.define('WebClient.common.controls.fields.EntityRefEditor', {
    alias: ['widget.WebClient.common.controls.fields.EntityRefEditor'],

    extend: 'Ext.form.field.Picker',

    mixins: {
        filterable: 'WebClient.common.controls.fields.FilterableFieldMixin'
    },

    requires: [
        'WebClient.common.controller.EntityControllerFactory',
        'WebClient.common.util.doT',
        'WebClient.common.type.EntityRef',
        'WebClient.common.workspace.RoomContainer'
    ],

    triggers: {
        picker: {
            cls: 'ef-trigger ef-trigger-search',
            handler: 'openEntityList',
            scope: 'this'
        },
        open: {
            cls: 'ef-trigger ef-trigger-external-link',
            handler: 'openEntityCard',
            scope: 'this'
        },
        clear: {
            cls: 'ef-trigger ef-trigger-clear',
            handler: 'clearValue',
            scope: 'this'
        }
    },

    matchFieldWidth: false,

    forceSelection: true,

    /**
     * Если ИСТИНА - то на сервере в автоматическом режиме значение будет в процентах.
     * @type {boolean}
     */
    encloseValueInPercent: true,

    /**
     * @private
     */
    fieldTextValue: undefined,

    /**
     * Дескриптор ссылки на сущность, описывает формат отображения сущности и используемые в отображении поля
     * @private
     * @type {object}
     */
    entityRefDescriptor: undefined,

    /**
     * @private
     * @type {function}
     */
    displayTemplateFn: undefined,

    /**
     * @private
     * @type {WebClient.common.controller.EntityLookup}
     */
    entityLookupController: undefined,

    /**
     * @private
     * @type {WebClient.common.workspace.RoomContainer}
     */
    entityLookupContainer: undefined,

    /**
     * @private
     * @type {WebClient.common.controller.EntityList}
     */
    entityListController: undefined,

    /**
     * @private
     * @type {WebClient.common.workspace.Container}
     */
    entityListContainer: undefined,

    /**
     * @private
     * @type {WebClient.common.controller.EntityCard}
     */
    entityCardController: undefined,

    /**
     * @private
     * @type {WebClient.common.workspace.Container}
     */
    entityCardContainer: undefined,

    /**
     * @private
     */
    filterLookupDebouncedFn: undefined,

    /**
     * @type {Ext.util.KeyNav}
     */
    lookupKeyNav: undefined,

    constructor: function(cfg) {
        var me = this,
            format = cfg.entityRefDescriptor.format,
            displayTemplateFn = format ? WebClient.common.util.doT.template(format) : null;

        var defaultCfg = {
            displayTemplateFn: displayTemplateFn
        };
        cfg = Ext.merge(defaultCfg, cfg);
        me.callParent([cfg]);

        me.filterLookupDebouncedFn = WebClient.debounce(
            function(queryText) {
                this.initEntityLookupController(function() {
                    this.expand();
                    this.entityLookupController.run({ queryText: queryText, encloseValueInPercent: me.encloseValueInPercent });
                }, this);
            },
            me,
            600);
    },

    initEntityLookupController: function(callback, scope) {
        var me = this;
        if (!me.entityLookupController) {
            me.entityLookupContainer = new WebClient.common.workspace.RoomContainer({ room: me.getPicker() });
            WebClient.common.controller.EntityControllerFactory.create(
                me.entityRefDescriptor.entityType,
                WebClient.ViewKind.LIST,
                WebClient.ListViewMode.LOOKUP,
                {},
                me.entityLookupContainer,
                function(instance) {
                    instance.on({
                        itemselected: function(sender, item) {
                            var value = new WebClient.common.type.EntityRef(item.get('__self'));
                            me.setValue(value);
                            delete me.lastMutatedValue;
                            me.collapse();
                            me.toQueryMode();
                        },
                        beforeload: function(sender, store) {
                            me.applyFilterable(store);
                        },
                        load: function(sender, store) {
                            var value = me.getValue();
                            if (value) {
                                var itemEntityId = value.getEntityId(),
                                    index = store.findBy(function(record) {
                                        return itemEntityId.equals(record.getEntityId());
                                    });
                                if (index >= 0)
                                    sender.selectItem(store.getAt(index));
                                else
                                    sender.selectFirstItem();
                            } else
                                sender.selectFirstItem();
                        }
                    });
                    me.entityLookupController = instance;
                    Ext.callback(callback, scope);
                });
        } else
            Ext.callback(callback, scope);
    },

    initEntityListController: function(callback, scope) {
        var me = this;
        if (!me.entityListController) {
            me.entityListContainer = new WebClient.common.workspace.WindowContainer({
                windowConfig: {
                    closeAction: 'hide',
                    modal: true,
                    ownerCmp: me,
                    //floatParent: me,
                    constrain: false,
                    //constrainHeader: false,
                    listeners: {
                        beforeshow: me.onBeforeListShow,
                        show: me.onListShow,
                        scope: me
                    }
                }
            });
            WebClient.common.controller.EntityControllerFactory.create(
                me.entityRefDescriptor.entityType,
                WebClient.ViewKind.LIST,
                WebClient.ListViewMode.SELECT,
                {},
                me.entityListContainer,
                function(instance) {
                    Ext.override(instance, {
                        adjustViewConfig: function() {
                            Ext.merge(this.viewBox.config, {
                                gridConfig: {
                                    selModel: {
                                        type: 'rowmodel',
                                        mode: 'SINGLE'
                                    },
                                    listeners: {
                                        itemdblclick: function(panel, record, item, index, e, eOpts) {
                                            var value = new WebClient.common.type.EntityRef(record.get('__self'));
                                            me.setValue(value);
                                            delete me.lastMutatedValue;
                                            me.entityListContainer.window.close();
                                        }
                                    }

                                }
                            });
                            this.callParent(arguments);
                        },
                        loadData: function() {
                            var store = this.dataContext.takeStore(this.structureName),
                                selModel = this.view.grid.getSelectionModel();
                            me.applyFilterable(store);

                            var value = me.getValue();
                            if (value) {
                                store.on('load', function() {
                                    var itemEntityId = value.getEntityId(),
                                        index = store.findBy(function(record) {
                                            return itemEntityId.equals(record.getEntityId());
                                        });
                                    if (index >= 0)
                                        selModel.select([store.getAt(index)], false, true);
                                });
                            }

                            this.callParent(arguments);
                        }
                    });

                    me.entityListController = instance;
                    Ext.callback(callback, scope);
                });
        } else
            Ext.callback(callback, scope);
    },

    initEntityCardController: function(callback, scope) {
        var me = this;
        if (!me.entityCardController) {
            me.entityCardContainer = new WebClient.common.workspace.WindowContainer({ windowConfig: { closeAction: 'hide' } });
            WebClient.common.controller.EntityControllerFactory.create(
                me.entityRefDescriptor.entityType,
                WebClient.ViewKind.CARD,
                WebClient.CardViewMode.EDIT,
                {},
                me.entityCardContainer,
                function(instance) {
                    me.entityCardController = instance;
                    Ext.callback(callback, scope);
                });
        } else
            Ext.callback(callback, scope);
    },

    onBeforeListShow: function(list) {
        var me = this,
            heightAbove = me.getPosition()[1] - Ext.getBody().getScroll().top,
            heightBelow = Ext.Element.getViewportHeight() - heightAbove - me.getHeight();

        list.setHeight(600);
        list.setMaxHeight(Math.max(heightAbove, heightBelow) - 5);
        list.setWidth(800);
        list.setMaxWidth(Ext.Element.getViewportWidth() - 5);
    },

    onListShow: function(list) {
        list.alignTo(this.triggerWrap, 'tl-bl?');
    },

    createPicker: function() {
        var me = this,
            picker = Ext.create('Ext.panel.Panel', {
                scrollable: true,
                floating: true,
                layout: 'fit',
                shadow: 'sides',
                listeners: {
                    beforeshow: me.onBeforePickerShow,
                    scope: me
                }
            });

        return picker;
    },

    onBeforePickerShow: function(picker) {
        var me = this,
            heightAbove = me.getPosition()[1] - Ext.getBody().getScroll().top,
            heightBelow = Ext.Element.getViewportHeight() - heightAbove - me.getHeight();

        picker.setHeight(600);
        picker.setMaxHeight(Math.max(heightAbove, heightBelow) - 5);
        picker.setWidth(800);
        picker.setMaxWidth(Ext.Element.getViewportWidth() - 5);
    },

    beforeFocus: function() {
        this.toQueryMode();
        this.callParent(arguments);
    },

    onFocusLeave: function(e) {
        var me = this;
        if (me.owns(e.relatedTarget))
            return;

        this.toFieldMode();
        delete me.lastMutatedValue;
        me.callParent(arguments);
    },

    onRender: function() {
        var me = this;
        me.callParent(arguments);
        me.initLookupKeyNav();
    },

    initLookupKeyNav: function() {
        var me = this;
        me.lookupKeyNav = new Ext.util.KeyNav({
            disabled: true,
            target: me.inputEl,
            forceKeyDown: true,
            defaultEventAction: 'preventDefault',
            up: function() {
                me.entityLookupController.selectPrevItem();
                return false;
            },
            down: function() {
                me.entityLookupController.selectNextItem();
                return false;
            },
            right: function() {
                me.entityLookupController.selectNextItem();
                return false;
            },
            left: function() {
                me.entityLookupController.selectPrevItem();
                return false;
            },
            pageDown: function() {
                me.entityLookupController.loadNextPage();
                return false;
            },
            pageUp: function() {
                me.entityLookupController.loadPrevPage();
                return false;
            },
            home: function() {
                me.entityLookupController.selectFirstItem();
                return false;
            },
            end: function() {
                me.entityLookupController.selectLastItem();
                return false;
            },
            enter: function() {
                var record = me.entityLookupController.getSelectedItem(),
                    value = null;
                if (record)
                    value = new WebClient.common.type.EntityRef(record.get('__self'));
                me.setValue(value);
                delete me.lastMutatedValue;
                me.collapse();
                me.toQueryMode();
                return false;
            },
            scope: me
        });
    },

    onExpand: function() {
        var keyNav = this.lookupKeyNav;
        if (keyNav)
            keyNav.enable();
    },

    onCollapse: function() {
        var keyNav = this.lookupKeyNav;
        if (keyNav)
            keyNav.disable();
    },

    toQueryMode: function() {
        var me = this;
        me.bindChangeEvents(false);
        if (Ext.supports.Placeholder) {
            if (me.forceSelection)
                me.inputEl.dom.placeholder = me.valueToRaw(me.getValue());
            else {
                me.fieldTextValue = me.getRawValue();
                me.inputEl.dom.placeholder = me.getRawValue();
            }
        }
        me.setRawValue('');
        me.inputEl.dom.value = '';
        me.bindChangeEvents(true);
    },

    toFieldMode: function() {
        var me = this;
        me.bindChangeEvents(false);
        if (Ext.supports.Placeholder)
            me.inputEl.dom.placeholder = '';
        if (me.forceSelection)
            me.inputEl.dom.value = me.valueToRaw(me.getValue());
        else
            me.inputEl.dom.value = me.lastMutatedValue || me.fieldTextValue || me.valueToRaw(me.getValue());
        me.bindChangeEvents(true);
    },

    onTriggerClick: function(e) {
        var me = this;
        if (!me.readOnly && !me.disabled) {
            if (me.isExpanded)
                me.collapse();
            else
                me.filterLookupDebouncedFn(this.inputEl.dom.value);
        }
    },

    onFieldMutation: function(e) {
        var me = this,
            key = e.getKey(),
            isDelete = key === e.BACKSPACE || key === e.DELETE,
            rawValue = me.inputEl.dom.value,
            len = rawValue.length;

        // Do not process two events for the same mutation.
        // For example an input event followed by the keyup that caused it.
        // We must process delete keyups.
        // Also, do not process TAB event which fires on arrival.
        if (!me.readOnly && (rawValue !== me.lastMutatedValue || isDelete) && key !== e.TAB) {
            me.lastMutatedValue = rawValue;
            if (len && (e.type !== 'keyup' || (!e.isSpecialKey() || isDelete)))
                me.filterLookupDebouncedFn(rawValue);
            else {
                // We have *erased* back to empty if key is a delete, or it is a non-key event (cut/copy)
                if (!len && (!key || isDelete)) {
                    me.clearValue();
                    me.collapse();
                }
                me.callParent([e]);
            }
        }
    },

    valueToRaw: function(value) {
        if (!value)
            return '';

        if (!this.displayTemplateFn)
            return value.toString();

        return this.displayTemplateFn(value.getValuesObject());
    },

    getValue: function() {
        return this.value;
    },

    isEqual: function(value1, value2) {
        if (!value1 && !value2)
            return true;
        if (!value1 || !value2)
            return false;

        return value1.id === value2.id;
    },

    clearValue: function() {
        this.setValue(null);
        this.collapse();
        if (Ext.supports.Placeholder) {
            this.inputEl.dom.placeholder = '';
            this.fieldTextValue = '';
        }
    },

    openEntityList: function() {
        var me = this;
        me.collapse();
        me.initEntityListController(function() {
            if (me.entityListContainer.window && me.entityListContainer.window.isHidden())
                me.entityListContainer.window.show();
            me.entityListController.run();
        });
    },

    openEntityCard: function() {
        var me = this,
            entityRef = me.getValue();

        me.collapse();

        if (!entityRef)
            return;

        me.initEntityCardController(function() {
            if (me.entityCardContainer.window && me.entityCardContainer.window.isHidden())
                me.entityCardContainer.window.show();
            me.entityCardController.run({ id: entityRef });
        });
    },

    onDestroy: function() {
        var me = this;
        me.callParent();
        Ext.destroy(me.lookupKeyNav);
        me.displayTemplateFn = null;
        me.entityLookupController = me.entityCardController = me.entityListController = null;
        me.entityLookupContainer = me.entityCardContainer = me.entityListContainer = null;
    }
});
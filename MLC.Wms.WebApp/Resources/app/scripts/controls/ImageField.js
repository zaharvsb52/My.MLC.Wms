Ext.define('MLC.wms.controls.ImageField', {
    extend: 'Ext.form.field.Base',

    alias: ['widget.MLC.wms.controls.ImageField'],

    requires: [
        'Ext.toolbar.Toolbar',
        'MLC.wms.controls.CropWindow',
        'MLC.wms.controls.PhotoWindow'
    ],

    initComponent: function() {
        this.callParent(arguments);
        if (!this.readOnly)
        this.imageToolBar = this.createToolBar();
    },

    getValue: function() {
        var me = this,
            val = me.rawToValue(me.processRawValue(this.value));
        me.value = val;
        return val;
    },

    childEls: [
        'imageEl'
    ],

    fieldSubTpl: [
        '<div class="thumb-wrap" style="text-align:center;min-width:200px;min-height:100px;max-width:200px;max-height:150px;">',
        '<img id="{id}" data-ref="imageEl" style="max-width:200px;max-height:150px;" src="{[Ext.util.Format.htmlEncode(values.value)]}" />',
        '</div>',
         '<div style="min-width:150px;min-height:20px;">',
        '{%',
        'var imageToolBar=Ext.getCmp(values.cmpId).imageToolBar; ',
        'if (imageToolBar) {',
        'Ext.DomHelper.generateMarkup(imageToolBar.getRenderTree(), out);',
        '}',
        '%}',
        '</div>'
    ],

    createToolBar: function() {
        var me = this;

        return Ext.widget('toolbar', {
            id: this.id + '-image-toolbar',
            ownerLayout: this.getComponentLayout(),
            height: 30,
            padding: '0 0 0 40',
            items: [
                {
                    xtype: 'filebutton',
                    listeners: {
                        afterrender: function(cmp) {
                            cmp.fileInputEl.set({
                                accept: 'image/*'
                            });
                        },
                        change: Ext.Function.bind(me.imageReader, me)
                    },
                    glyph: 0xf093
                },
                {
                    handler: function() {
                        var cw = new MLC.wms.controls.PhotoWindow(
                        {
                            listeners: {
                                photoReady: function(sender, imgBase64) {
                                    me.setValue(imgBase64);
                                }
                            }
                        });
                        cw.show();
                    },
                    glyph: 0xf030
                },
                {
                    glyph: 0xf125,
                    handler: function() {
                        //getting the image URL from whereever you want
                        var imageURL = me.value,
                            cw = new MLC.wms.controls.CropWindow({
                                imageUrl: imageURL,
                                listeners: {
                                    imageCroped: function(sender, imgBase64) {
                                        me.setValue(imgBase64);
                                    }
                                }
                            });
                        cw.show();
                    }
                },
                {
                    glyph: 0xf00d,
                    listeners: {
                        click:function() {
                            me.setValue(null);
                            var comp = me.getEl().down('input');

                            if (comp) {
                                comp.dom.value = null;
                           }
                        }
                    }
                }
            ]
        });
    },

    imageReader: function() {
        var lEvent = arguments[1];

        if (lEvent.target.files && lEvent.target.files[0]) {
            var fr = new FileReader();
            fr.onload = Ext.Function.bind(
                function(e) {
                    this.setValue(e.target.result);
                }, this);
            fr.readAsDataURL(lEvent.target.files[0]);
        }
    },

    privates: {
        finishRenderChildren: function() {
            var toolbar = this.imageToolBar;

            this.callParent(arguments);

            if (toolbar) {
                toolbar.finishRender();
            }
        }
    },

    getInputId: function() {
        return this.inputId || (this.inputId = this.id + '-imageEl');
    },

    setRawValue: function(value) {
        var me = this,
            rawValue = me.rawValue;

        if (!me.transformRawValue.$nullFn) {
            value = me.transformRawValue(value);
        }

        value = Ext.valueFrom(value, '');

        if (rawValue === undefined || rawValue !== value) {
            me.rawValue = value;

            // Some Field subclasses may not render an imageEl
            if (me.imageEl) {
                me.bindChangeEvents(false);
                me.imageEl.dom.src = value;
                me.bindChangeEvents(true);
            }

            if (me.rendered && me.reference) {
                me.publishState('rawValue', value);
            }
        }
        return value;
    },

    onDisable: function() {
        var me = this,
            imageEl = me.imageEl;

        me.callParent();
        if (imageEl) {
            imageEl.dom.disabled = true;
            if (me.hasActiveError()) {
                // clear invalid state since the field is now disabled
                me.clearInvalid();
                me.needsValidateOnEnable = true;
            }
        }
    },

    onEnable: function() {
        var me = this,
            imageEl = me.imageEl;

        me.callParent();
        if (imageEl) {
            imageEl.dom.disabled = false;
            if (me.needsValidateOnEnable) {
                delete me.needsValidateOnEnable;
                // will trigger errors to be shown
                me.forceValidation = true;
                me.isValid();
                delete me.forceValidation;
            }
        }
    },

    setReadOnly: function(readOnly) {
        var me = this,
            imageEl = me.imageEl;
        readOnly = !!readOnly;
        me[readOnly ? 'addCls' : 'removeCls'](me.readOnlyCls);
        me.readOnly = readOnly;
        if (imageEl) {
            imageEl.dom.readOnly = readOnly;
        } else if (me.rendering) {
            me.setReadOnlyOnBoxReady = true;
        }
        me.fireEvent('writeablechange', me, readOnly);
    },

    setFieldStyle: function(style) {
        var me = this,
            imageEl = me.imageEl;
        if (imageEl) {
            imageEl.applyStyles(style);
        }
        me.fieldStyle = style;
    },

    getRawValue: function() {
        var me = this,
            v = (me.imageEl ? me.imageEl.getValue() : Ext.valueFrom(me.rawValue, ''));
        me.rawValue = v;
        return v;
    }
});
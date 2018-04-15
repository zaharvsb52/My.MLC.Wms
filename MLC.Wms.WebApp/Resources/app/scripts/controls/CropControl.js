/**
 * Licence:
 * @author Thomas Lauria
 * http://www.thomas-lauria.de
 */
Ext.define('MLC.wms.controls.CropControl', {
    requires: ['Ext.Img'],
    extend: 'Ext.Component',
    minWidth: 50,
    minHeight: 50,
    quadratic: false,
    preserveRatio: true,
    autoEl: {
        tag: 'div',
        children: [
            {
                tag: 'div',
                cls: 'image-crop-wrapper',
                style: {
                    background: '#ffffff',
                    opacity: 0.5,
                    position: 'absolute'
                }
            }
        ]
    },
    initComponent: function() {
        this.preserveRatio = this.quadratic || this.preserveRatio;
        this.callParent(arguments);
    },
    getResultPosition: function() {
        var me = this,
            parent = me.getBox(),
            img = me.image.getBox(),
            res = {
                x: (img.x - parent.x),
                y: (img.y - parent.y),
                width: img.width,
                height: img.height
            };
        me.image.getEl().setStyle({
            'background-position': (-res.x) + 'px ' + (-res.y) + 'px'
        });
        return res;
    },
    /**
     * @return Object
     */
    getCropData: function() {
        return this.getResultPosition();
    },
    onRender: function(ct, position) {
        var me = this;
        me.height = me.height > me.maxHeight ? me.maxHeight : me.height;
        me.width = me.width > me.maxWidth ? me.maxWidth : me.width;

        var height = me.height,
            width = me.width,
            wrap = me.el.down('.image-crop-wrapper'),
            dragConf = {
                constrain: true,
                constrainTo: me.el,
                listeners: {
                    dragstart: function() {
                        this.image.getEl().setStyle({
                            'background': 'transparent'
                        });
                    },
                    dragend: function() {
                        var me = this,
                            res = me.getResultPosition();
                        me.image.getEl().setStyle({
                            'background-image': 'url(' + me.src + ')',
                            'background-repeat': 'no-repeat',
                            'background-size': me.width + 'px ' + me.height + 'px'
                        });
                        me.fireEvent('changeCrop', me, res);
                        me.fireEvent('moveCrop', me, res);
                    },
                    scope: me
                }
            };
        wrap.setSize(me.width, me.height);

        me.el.setStyle({
            background: 'url(' + me.src + ') no-repeat left top',
            'background-size': me.width + 'px ' + me.height + 'px'
        });
        if (me.quadratic) {
            if (height > width) {
                height = width;
            } else {
                width = height;
            }
        }
        me.image = Ext.create('Ext.Img', {
            opacity: 1.0,
            renderTo: me.el,
            resizable: {
                pinned: true,
                preserveRatio: false
            },
            draggable: dragConf,
            constrainTo: me.el,
            src: Ext.BLANK_IMAGE_URL,
            height: height,
            width: width,
            style: {
                cursor: 'move',
                position: 'absolute',
                background: 'url(' + me.src + ') no-repeat left top',
                'background-size': me.width + 'px ' + me.height + 'px'
            },
            listeners: {
                resize: function() {
                    res = me.getResultPosition();
                    me.fireEvent('changeCrop', me, res);
                    me.fireEvent('resizeCrop', me, res);
                }
            }
        });
    }
});
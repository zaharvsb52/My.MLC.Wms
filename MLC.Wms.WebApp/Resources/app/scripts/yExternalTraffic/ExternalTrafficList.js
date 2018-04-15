Ext.define('MLC.wms.yExternalTraffic.ExternalTrafficList', {
    extend: 'WebClient.common.controls.EntityGridWithFilter',

    constructor: function (config) {
        var defaultConfig = {
            gridConfig: {
                tbar: {
                    items: this.getTbarItems(config)
                }
            }
        };
        config = Ext.merge(defaultConfig, config);
        this.callParent([config]);
    },

    /**
     * override
     */
    getTbarItems: function (config) {
        var me = this;
        var res = me.callParent();
        res.push(
            {
                xtype: 'button',
                itemId: 'btnCarArrived',
                glyph: 0xf0f6,
                text: 'Зарегистрировать'
            }, 
            {
                xtype: 'button',
                itemId: 'btnCarDeparted',
                glyph: 0xf08b,
                text: 'Убытие'
            },
            {
                xtype: 'button',
                itemId: 'btnPrint',
                glyph: 0xf02f,
                text: 'Печать'
            },
            {
                xtype: 'button',
                itemId: 'btnCancel',
                glyph: 0xf05e,
                text: 'Аннулировать'
            },
            {
                xtype: 'button',
                itemId: 'btnVerify',
                glyph: 0xf046,
                text: 'Верифицировать'
            },
            {
                xtype: 'button',
                itemId: 'btnCreateTemp',
                glyph: 0xf0c5,
                text: 'Создать по шаблону'
            }
        );

        return res;
    }
});
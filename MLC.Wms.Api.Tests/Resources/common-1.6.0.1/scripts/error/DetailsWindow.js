Ext.define('WebClient.common.error.DetailsWindow', {
    extend: 'Ext.window.Window',
    /**
     * @cfg {String} text Текст для показа
     */

    title: 'Технические детали',
    modal: true,
    bodyBorder: false,
    defaultFocus: 'text',
    autoscroll: true,
    height: 500,
    width: 600,
    layout: 'fit',
    items: [
        {
            itemId: 'text',
            xtype: 'textarea',
            readOnly: true,
            selectOnFocus: true,
            border: false,
            cls: 'c-field-noborder'
        }
    ],
    bbar: {
        height: 32,
        items: [
            '->',
            { xtype: 'button', text: 'Закрыть', itemId: 'close' }
        ]
    },

    /**
     * @cfg {String} text Текст, показываемый в textarea.
     * 
     * @cfg {String} caption Текст, показываемый в выше textarea. Если не передан, то это область скрывается
     */
    constructor: function(cfg) {
        var me = this;

        me.callParent(arguments);

        me.down('#close').on('click', function() { me.close(); });
        me.down('#text').setValue(WebClient.toDebugString(cfg.text));
    }
});
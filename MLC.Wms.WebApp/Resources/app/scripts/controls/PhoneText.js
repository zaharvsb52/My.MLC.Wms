Ext.define('MLC.wms.controls.PhoneText', {
    extend: 'Ext.form.field.Text',
    alias: 'widget.phonefield',
    requires: [
        'MLC.wms.controls.PhoneTextPlugin'
    ],

    constructor: function (config) {
        var defaultConfig =
        {
            placeHolder: '_',
            mask: '+7(###)###-##-##',
            template: '+7(___)___-__-__',
            maskRe: /\d/,
            maxLength: 16,
            enableKeyEvents: true,
            plugins: ['phonetextplugin']
        }
        config = WebClient.mergeEx(defaultConfig, config);
        this.callParent([config]);
    }
});
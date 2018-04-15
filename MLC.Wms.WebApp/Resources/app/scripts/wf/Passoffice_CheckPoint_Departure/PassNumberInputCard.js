Ext.define('MLC.wms.wf.Passoffice_CheckPoint_Departure.PassNumberInputCard', {
    extend: 'MLC.wf.controls.Card',

    constructor: function (config) {
        var defaultConfig =
        {
            items: [
                {
                    name: 'PassNumber',
                    labelCls: 'big-field',
                    fieldCls: 'big-field'
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);
        this.callParent([config]);
    }
});
Ext.define('MLC.wms.wf.Passoffice_CheckPoint_Arrival.VehicleNumberInputCard', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(config) {
        var defaultConfig =
        {
            items: [
                {
                    name: 'VehicleNumber',
                    labelCls: 'big-field',
                    fieldCls: 'big-field',
                    plugins: ['converttolat']
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);
        this.callParent([config]);
    }
});
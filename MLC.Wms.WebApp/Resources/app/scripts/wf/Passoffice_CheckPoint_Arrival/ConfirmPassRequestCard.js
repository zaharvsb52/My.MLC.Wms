Ext.define('MLC.wms.wf.Passoffice_CheckPoint_Arrival.ConfirmPassRequestCard', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'WebClient.common.type.EntityId',
        'MLC.wms.controls.ImageField',
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(config) {

        var defaultConfig =
        {
            layout: 'hbox',
            height: 220,
            width: 450,
            items: [
                 {
                     xtype: 'container',
                     layout: 'form',
                     flex: 2,
                     padding: 5,
                     defaults: {
                         labelWidth: 50
                     },
                     items: [
                         {
                             xtype: 'displayfield',
                             name: 'VehicleNumber'
                         },
                         {
                             name: 'VehicleTrailerNumber',
                             plugins: ['converttolat']
                         },
                         {
                             xtype: 'displayfield',
                             name: 'DriverFIO'
                         },
                         {
                             xtype: 'displayfield',
                             name: 'Question',
                             hideEmptyLabel: true,
                             labelWidth: 0
                         },
                         {
                             name: 'WorkerPassNumber',
                             plugins: ['converttolat']
                         }
                     ]
                 },
                {
                    flex: 1,
                    xtype: 'MLC.wms.controls.ImageField',
                    name: 'DriverPhoto',
                    fieldLabel: ''
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
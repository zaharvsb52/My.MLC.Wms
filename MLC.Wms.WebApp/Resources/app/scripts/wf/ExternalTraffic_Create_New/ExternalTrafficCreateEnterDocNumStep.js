Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateEnterDocNumStep', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(cfg) {
        var me = this,
            defaultCfg = {
                xtype: 'panel',
                title: '№ документа',
                layout: 'hbox',
                padding: 5,
                items: [
                    {
                        xtype: 'panel',
                        flex: 1,
                        layout: 'auto',
                        margin: '5px 0 5px 0',
                        defaults: {
                            width: '100%'
                        },
                        items: [
                            {
                                name: 'WorkerPass',
                                fieldLabel: 'Документ',
                                emptyText: 'Введите серию и номер документа',
                                labelWidth: 120,
                                forceSelection: false,
                                itemId: 'trafficDriverLookUp'
                            },
                            {
                                name: 'CustomDocNum',
                                itemId: 'customDocNum',
                                hidden: true
                            }
                        ]
                    }
                ]
            };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
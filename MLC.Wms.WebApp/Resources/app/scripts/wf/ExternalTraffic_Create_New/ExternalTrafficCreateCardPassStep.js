Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateCardPassStep', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function (cfg) {
        var defaultCfg = {
            xtype: 'panel',
            title: 'Пропуск',
            layout: { type: 'hbox', align: 'stretch' },
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
                        { name: 'ExternalTrafficPassNumber', fieldLable: '№ пропуска', emptyText: 'Введите номер пропуска или оставьте поле пустым', labelWidth: 120 },
                    ]
                }
            ]
        };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
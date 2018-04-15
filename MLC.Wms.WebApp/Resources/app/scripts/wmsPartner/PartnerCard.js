Ext.define('MLC.wms.wmsPartner.PartnerCard', {
    extend: 'WebClient.common.controls.AutoCard',

    requires: [
        'MLC.wms.controls.PhoneText'
    ],

    constructor: function (config) {
        var defaultConfig =
        {
            xtype: 'panel',
            layout: {
                type: 'vbox',
                align: 'stretch'
            },
            items: [
                {
                    xtype: 'panel',
                    scrollable: true,
                    flex: 1,
                    layout: {
                        type: 'hbox',
                        align: 'stretch'
                    },
                    defaults: {
                        padding: '10 0 0 10'
                    },
                    items: [
                        {
                            xtype: 'panel',
                            scrollable: true,
                            margin: '0 10 0 0',
                            flex: 3,
                            layout: {
                                type: 'vbox',
                                align: 'stretch'
                            },
                            defaults: {
                                labelWidth: 130
                            },
                            items: [
                                { name: 'PartnerID' },
                                { name: 'PartnerCode' },
                                { name: 'PartnerName' },
                                { name: 'PartnerFullName' },
                                { name: 'PartnerLink2Mandant' },
                                { name: 'PartnerParent' },
                                { name: 'PartnerKind' },
                                { name: 'PartnerLocked' },
                                { name: 'PartnerContract' },
                                { name: 'PartnerDateContract' },
                                { name: 'PartnerPhone', xtype: 'phonefield' },
                                { name: 'PartnerFax', xtype: 'phonefield' },
                                { name: 'PartnerEmail' },
                                { name: 'PartnerINN' },
                                { name: 'PartnerKPP' },
                                { name: 'PartnerOGRN' },
                                { name: 'PartnerOKPO' },
                                { name: 'PartnerOKVED' },
                                { name: 'PartnerSettlementAccount' },
                                { name: 'PartnerCorrespondentAccount' },
                                { name: 'PartnerBIK' },
                                { name: 'PartnerCommercTime' },
                                { name: 'PartnerCommercTimeMeasure' },
                                { name: 'PartnerHostRef' }
                            ]
                        }
                    ]
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
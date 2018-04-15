Ext.define('MLC.wms.wmsMandant.MandantLookupView', {
    extend: 'WebClient.common.controls.EntityLookupGrid',
    
    constructor: function(config) {
        var me = this,
            defaultConfig = {
                columns: [
                    { dataIndex: 'PartnerCode', hidden: true },
                    { dataIndex: 'PartnerName' }
                ]
            };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
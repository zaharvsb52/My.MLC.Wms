Ext.define('MLC.wms.wf.ReqCustoms_Add.GridMultiSelect', {
    extend: 'MLC.wf.controls.List',

    constructor: function(config) {
        var me = this;
        var defaultConfig = {
            gridConfig: {
                selModel: {
                    type: 'checkboxmodel',
                    mode: 'MULTI',
                    checkboxSelect: true
                },
                editOnDblClick: false
            }
        };

        config = Ext.merge(defaultConfig, config);
        me.callParent([config]);
    }
});
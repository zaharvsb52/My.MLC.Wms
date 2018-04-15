Ext.define('MLC.wms.wf.PassRequest_Create.PassRequestCard', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'WebClient.common.controls.AutoGrid',
        'MLC.wms.controls.PhoneText',
	    'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(config) {
        var me = this,
            today = new Date(),
            defaultConfig =
            {
                title: 'Заявка на пропуск',
                itemId: 'fieldsPanel',
                xtype: 'panel',
                padding: '5',
                width: 650,
                layout: {
                    type: 'vbox',
                    align: 'stretch'
                },
                items: [
                    { labelWidth: 120, name: 'WorkerPassNumber', plugins: ['converttolat'] },
                    { labelWidth: 120, name: 'WorkerFio' },
                    { labelWidth: 120, name: 'VehicleNumber', plugins: ['converttolat'] },
                    { labelWidth: 120, name: 'VehicleTrailerNumber', plugins: ['converttolat'] },
                    { labelWidth: 120, name: 'PhoneNumber', xtype: 'phonefield' },
                    {
                        labelWidth: 120, name: 'ArrivalDatePlan',
                        xtype: 'WebClient.common.controls.fields.MaskedDateTimeField',
                        format: 'd.m.Y H:i',
                        enableKeyEvents: true,
                        maskRe: /[0-9\/]/,
                        listeners: {
                            keypress: function (field, e, eOpts) {
                                if (e.getKey() == e.ENTER) {
                                    e.stopEvent();
                                    me.fireEvent('enterToGrid', me);
                                }
                            },
                            focus: function (field, e, eOpts) {
                                if (!field.value) {
                                    field.setValue(new Date(today.getFullYear(), today.getMonth(), today.getDate()));
                                }
                            }
                        }
                    },
                    {
                        xtype: 'textarea',
                        fieldLabel: 'Примечание',
                        labelWidth: 120,
                        name: 'PassRequestComment'
                    },
                    {
                        region: 'center',
                        flex: 1,
                        height: 200,
                        xtype: 'WebClient.common.controls.AutoGrid',
                        title: 'Цели прибытия',
                        selModel: { type: 'checkboxmodel', mode: 'MULTI', checkboxSelect: true },
                        structureName: 'YPassRequestList',
                        entityType: 'YPassRequest',
                        itemId: 'grid',
                        editOnDblClick: false,
                        sortableColumns: false,
                        plugins: { ptype: 'cellediting', clicksToEdit: 1, pluginId: 'cellplugin' },
                        dockedItems: [
                            {
                                xtype: 'toolbar',
                                dock: 'top',
                                ui: 'footer',
                                items: [
                                    { text: 'Добавить', glyph: 0xf067, itemId: 'addPurpose' },
                                    { xtype: 'tbspacer' },
                                    { text: 'Удалить', glyph: 0xf068, itemId: 'deleteSelectedPurposes' }
                                ]
                            }
                        ],
                        columns: [
                            { dataIndex: 'Mandant', flex: 1 },
                            { dataIndex: 'PurposeVisit', flex: 1 },
                            { dataIndex: 'Warehouse', flex: 1, itemId: 'warehouse' },
                            { dataIndex: 'WarehouseOffice', flex: 1, itemId: 'warehouseOffice' },
                            {
                                xtype: 'actioncolumn',
                                width: 20,
                                iconCls:'',
                                items: [
                                    {
                                        icon: MLC.wms.application.imagespath + 'delete.png',
                                        tooltip: 'Удалить',
                                        handler: function (grid, rowIndex) {
                                            var rec = grid.getStore().getAt(rowIndex);
                                            me.fireEvent('deletePurpose', me, rec);
                                        }
                                    }
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
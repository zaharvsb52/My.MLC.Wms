Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficCreateCardIntTraffStep', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'WebClient.common.controls.AutoGrid'
    ],

    constructor: function(cfg) {
        var me = this,
            defaultCfg = {
                layout: { type: 'vbox', align: 'stretch' },
                title: 'Внутренние рейсы',
                items: [
                    {
                        xtype: 'WebClient.common.controls.AutoGrid',
                        flex: 1,
                        height: 200,
                        itemId: 'IntTraffGrid',
                        structureName: 'InternalTraffic',
                        selModel: { type: 'checkboxmodel', mode: 'MULTI', checkboxSelect: true },
                        dockedItems: [
                            {
                                xtype: 'toolbar',
                                dock: 'top',
                                ui: 'footer',
                                items: [
                                    { text: 'Добавить', itemId: 'AddIntTraff' },
                                    { text: 'Удалить', itemId: 'DelIntTraff' }
                                ]
                            }
                        ],
                        columns: [
                            { dataIndex: 'Partner', flex: 1, header: 'Проект' },
                            { dataIndex: 'PurposeVisit', flex: 1, header: 'Цель' },
                             { dataIndex: 'Warehouse', flex: 1, header: 'Склад', itemId: 'Warehouse' },
                            { dataIndex: 'WarehouseOffice', flex: 1, header: 'Офис', itemId: 'WarehouseOffice' },
                            { dataIndex: 'InternalTrafficFactArrived', flex: 1, header: 'Прибытие', itemId: 'Arrived', formatter: 'date("d.m H:i")' },
                            { dataIndex: 'InternalTrafficFactDeparted', flex: 1, header: 'Убытие', itemId: 'Departed', formatter: 'date("d.m H:i")' },
                            {
                                xtype: 'actioncolumn',
                                width: 20,
                                items: [
                                    {
                                        icon: MLC.wms.application.imagespath + 'delete.png',
                                        tooltip: 'Удалить',
                                        handler: function(grid, rowIndex) {
                                            var rec = grid.getStore().getAt(rowIndex);
                                            me.fireEvent('deleteIntTraf', me, rec);
                                        }
                                    }
                                ]
                            }
                        ],
                        plugins: {
                            ptype: 'cellediting',
                            clicksToEdit: 1,
                            pluginId: 'cellplugin'
                        }
                    },
                    {
                        xtype: 'panel',
                        title: ' ',
                        layout: { type: 'hbox', align: 'stretch' },
                        items: [
                            {
                                xtype: 'textarea',
                                margin: '5 5 5 5',
                                width: '100%',
                                name: 'ExternalTrafficComment',
                                labelAlign: 'top',
                                fieldLabel: 'Примечание'
                            }
                        ]
                    }
                ]
            };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
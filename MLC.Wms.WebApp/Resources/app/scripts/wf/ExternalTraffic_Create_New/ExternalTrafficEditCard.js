Ext.define('MLC.wms.wf.ExternalTraffic_Create_New.ExternalTrafficEditCard', {
    extend: 'MLC.wf.controls.Card',

    requires: [
        'MLC.wms.controls.PhoneText',
        'MLC.wms.controls.ImageField',
        'WebClient.common.controls.AutoGrid',
        'MLC.wms.plugins.ConvertToLatPlugin'
    ],

    constructor: function(cfg) {
        var me = this,
            defaultCfg = {
                layout: { type: 'vbox', align: 'stretch' },
                items: [
                    {
                        xtype: 'panel',
                        title: 'Водитель',
                        layout: 'hbox',
                        items: [
                            {
                                xtype: 'panel',
                                flex: 1,
                                layout: 'auto',
                                padding: 5,
                                defaults: {
                                    width: '100%'
                                },
                                items: [
                                    { name: 'ExternalTrafficPassNumber', fieldLabel: '№ пропуска', emptyText: 'Введите номер пропуска', labelWidth: 120 },
                                    { name: 'WorkerPass', plugins: ['converttolat'], itemId: 'WorkerPassEdit', fieldLabel: 'Документ', emptyText: 'Введите номер документа', labelWidth: 120 },
                                    { name: 'WorkerPass_WorkerPassType', fieldLabel: 'Тип док-та', labelWidth: 120 },
                                    { name: 'ExternalTrafficDriver_WorkerLastName__WorkerName__WorkerMiddleName', fieldLabel: 'ФИО', labelWidth: 120 },
                                    { name: 'ExternalTrafficDriver_WorkerPhoneMobile', fieldLabel: 'Телефон', labelWidth: 120, xtype: 'phonefield' },
                                    {
                                        xtype: 'textarea',
                                        fieldLabel: 'Адрес регистрации',
                                        labelWidth: 120,
                                        name: 'ExternalTrafficDriver_WorkerResidenceAddr',
                                        height: 102,
                                        enableKeyEvents: true,
                                        listeners: {
                                            keypress: function(field, e, eOpts) {
                                                if (e.getKey() == e.ENTER) {
                                                    e.stopEvent();
                                                    me.fireEvent('enterToVehicleRn', me);
                                                }
                                            }
                                        }
                                    }
                                ]
                            },
                            {
                                layout: 'vbox',
                                xtype: 'panel',
                                items: [
                                    {
                                        width: 200,
                                        height: 200,
                                        xtype: 'MLC.wms.controls.ImageField',
                                        name: 'ExternalTrafficDriver_WorkerPhoto',
                                        hideLabel: true,
                                        margin: '0 5 0 0'
                                    },
                                    { name: 'ExternalTrafficDriver_WorkerProcPersData', itemId: 'ProcData', labelAlign: 'top', fieldLabel: 'Согласие обработки данных', labelWidth: 60, margin: '0 5 5 0' }
                                ]

                            }
                        ]
                    },
                    {
                        xtype: 'panel',
                        title: 'ТС',
                        layout: { type: 'hbox', align: 'stretch' },
                        items: [
                            {
                                xtype: 'panel',
                                flex: 1,
                                layout: 'auto',
                                padding: 5,
                                defaults: {
                                    width: '100%'
                                },
                                items: [
                                    { name: 'Vehicle', plugins: ['converttolat'], itemId: 'VehicleEdit', fieldLabel: '№ ТС', emptyText: 'Введите номер ТС', labelWidth: 120 },
                                    { name: 'ExternalTrafficTrailerRN', plugins: ['converttolat'], fieldLabel: '№ Прицепа', labelWidth: 120 },
                                    { name: 'Vehicle_VehicleVIN', fieldLabel: 'VIN TC', labelWidth: 120 },
                                    { name: 'Vehicle_CarType_CarTypeMark', fieldLabel: 'Марка', labelWidth: 120 },
                                    { name: 'Vehicle_VehicleOwner', fieldLabel: 'Владелец', labelWidth: 120 },
                                    {
                                        name: 'Vehicle_VehicleOwnerAddr',
                                        fieldLabel: 'Адрес владельца',
                                        labelWidth: 120,
                                        enableKeyEvents: true,
                                        listeners: {
                                            keypress: function(field, e, eOpts) {
                                                if (e.getKey() == e.ENTER) {
                                                    e.stopEvent();
                                                    me.fireEvent('enterToGrid', me);
                                                }
                                            }
                                        }
                                    }
                                ]
                            },
                            {
                                xtype: 'textarea',
                                width: 200,
                                name: 'ExternalTrafficComment',
                                labelAlign: 'top',
                                fieldLabel: 'Примечание',
                                margin: '8 5 10 0'
                            }
                        ]
                    },
                    {
                        xtype: 'WebClient.common.controls.AutoGrid',
                        height: 200,
                        title: 'Внутренние рейсы',
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
                            { dataIndex: 'Partner', header: 'Проект', flex:1},
                            { dataIndex: 'PurposeVisit', header: 'Цель', flex: 1 },
                            { dataIndex: 'Warehouse', header: 'Склад', flex: 1, itemId: 'Warehouse' },
                            { dataIndex: 'WarehouseOffice', header: 'Офис', flex: 1, itemId: 'WarehouseOffice' },
                            {
                                dataIndex: 'InternalTrafficFactArrived', header: 'Прибытие', flex: 1, itemId: 'Arrived', formatter: 'date("d.m H:i")'
                            },
                            {
                                dataIndex: 'InternalTrafficFactDeparted', header: 'Убытие', flex: 1, itemId: 'Departed',formatter : 'date("d.m H:i")'
                            },
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
                    }
                ]
            };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    }
});
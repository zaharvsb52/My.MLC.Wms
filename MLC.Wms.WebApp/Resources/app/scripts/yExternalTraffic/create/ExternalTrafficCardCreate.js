Ext.define('MLC.wms.yExternalTraffic.create.ExternalTrafficCardCreate', {
    extend: 'WebClient.common.controls.AutoCard',

    requires: [
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.controls.EntityGrid',
        'MLC.wms.yExternalTraffic.create.ExternalTrafficCreateGrid',
        'WebClient.common.type.EntityId',
        'MLC.wms.controls.ImageField',
        'MLC.wms.controls.PhoneText'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin'
    },

    constructor: function(config) {
        var me = this,
            grid,
            defaultConfig =
            {
                layout: 'border',
                scrollable: false,
                items: [
                    {
                        xtype: 'form',
                        region: 'north',
                        itemId: 'fieldsPanel',
                        items: [
                            {
                                xtype: 'panel',
                                width: '70%',
                                layout:
                                {
                                    type: 'hbox'
                                },
                                defaults: {
                                    padding: '3 3 0 10'
                                },
                                items: [
                                    {
                                        xtype: 'panel',
                                        width: '70%',
                                        layout:
                                        {
                                            type: 'vbox'
                                        },
                                        defaults: {
                                            padding: '3 3 0 10'
                                        },
                                        items: [
                                            {
                                                xtype: 'fieldcontainer',
                                                itemId: 'driverHeader',
                                                componentCls: 'driver-not-select',
                                                width: '100%',
                                                layout: {
                                                    type: 'hbox',
                                                    align: 'stretch'
                                                },
                                                items: [
                                                    {
                                                        padding: '5 0 0 0',
                                                        name: 'ExternalTrafficDriver',
                                                        forceSelection: false,
                                                        itemId: 'trafficDriver',
                                                        width: '83%'
                                                    },
                                                    {
                                                        margin: '5 0 0 3',
                                                        xtype: 'button',
                                                        itemId: 'btnAddDriver',
                                                        width: '12%',
                                                        text: 'Создать'
                                                    }
                                                ]
                                            },
                                            {
                                                name: 'ExternalTrafficDriver_WorkerPhoneMobile',
                                                width: '83%',
                                                itemId: 'txtPhoneMobile',
                                                xtype: 'phonefield'
                                            },
                                            {
                                                name: 'ExternalTrafficPlanArrived',
                                                width: '83%',
                                                itemId: 'dtpPlanArrived'
                                            },
                                            {
                                                xtype: 'fieldcontainer',
                                                width: '100%',
                                                layout: {
                                                    type: 'hbox',
                                                    align: 'stretch'
                                                },
                                                items: [
                                                    {
                                                        name: 'Vehicle',
                                                        itemId: 'trafficVehicle',
                                                        forceSelection: false,
                                                        width: '83%'
                                                    },
                                                    {
                                                        margin: '0 0 0 3',
                                                        xtype: 'button',
                                                        itemId: 'btnAddVehicle',
                                                        width: '12%',
                                                        text: 'Создать'
                                                    }
                                                ]
                                            },
                                            {
                                                name: 'ExternalTrafficForvarder',
                                                width: '83%'
                                            },
                                            {
                                                name: 'ExternalTrafficCarrier',
                                                width: '83%'
                                            }
                                        ]
                                    },
                                    {
                                        xtype: 'MLC.wms.controls.ImageField',
                                        name: 'ExternalTrafficDriver_WorkerPhoto',
                                        fieldLabel: '',
                                        readOnly: true
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        region: 'center',
                        flex: 1,
                        xtype: 'MLC.wms.yExternalTraffic.create.ExternalTrafficCreateGrid',
                        title: 'Внутренние рейсы',
                        layout: 'fit',
                        structureName: 'InternalTrafficCreateList',
                        itemId: 'internaltrafficgrid',
                        editOnDblClick: false,
                        gridConfig: {
                            sortableColumns: false,
                            plugins: [
                                Ext.create('Ext.grid.plugin.CellEditing', {
                                    clicksToEdit: 1
                                })
                            ],
                            dockedItems: [
                                {
                                    xtype: 'toolbar',
                                    items: [
                                        {
                                            text: 'Добавить',
                                            handler: function() {
                                                var rec = new grid.store.model();
                                                // увеличиваем очередь
                                                var id = (grid.store.max('InternalTrafficOrder') || 0) + 1;
                                                rec.setId(new WebClient.common.type.EntityId({ id: id, type: 'YInternalTraffic' }));
                                                rec.set('InternalTrafficOrder', id);
                                                // если уже есть элементы - забираем данные с последней записи
                                                if (grid.store.getCount() > 0) {
                                                    var lastItem = grid.store.last();
                                                    rec.set('Partner', lastItem.get('Partner'));
                                                    //rec.set('Warehouse', lastItem.get('Warehouse'));
                                                }
                                                grid.getStore().add(rec);
                                                // выставляем редактирование
                                                grid.plugins[0].startEditByPosition({
                                                    row: grid.store.getCount() - 1,
                                                    column: (grid.store.getCount() === 1 ? 1 : 2)
                                                });
                                            }
                                        }, '-', {
                                            itemId: 'delete',
                                            text: 'Удалить',
                                            disabled: true,
                                            handler: function() {
                                                var selection = grid.getView().getSelectionModel().getSelection()[0];
                                                if (selection)
                                                    grid.store.remove(selection);
                                            }
                                        }
                                    ]
                                }
                            ]
                        }
                    }
                ]
            };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
        grid = this.down('gridpanel');
        grid.getSelectionModel().on('selectionchange', function(selModel, selections) {
            grid.down('#delete').setDisabled(selections.length === 0);
        });
    }
});
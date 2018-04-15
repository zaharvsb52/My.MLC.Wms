Ext.define('MLC.wms.cstReqCustoms.ReqCustomsView', {
    extend: 'WebClient.common.controls.AutoCard',

    requires: [
        'MLC.wms.yExternalTraffic.create.ExternalTrafficCreateGrid'
    ],

    constructor: function (config) {
        var me = this,
            cstDocTransportGrid,
            cstTransportContractGrid,
            reqCustoms2WBGrid;

        var defaultConfig =
        {
            title: 'Заявка на декларирование',
            items: [
                {
                    xtype: 'panel',
                    region: 'north',
                    padding: '0 0 5 0',
                    cls: 'graybg',
                    items: [
                        {
                            xtype: 'toolbar',
                            padding: '0 0 5 0',
                            itemId: 'commandToolbar'
                        }
                    ]
                },
                {
                    xtype: 'tabpanel',
                    itemId: 'orderTabs',
                    activeTab: 0,
                    items: [
                        {
                            xtype: 'panel',
                            title: 'Заявка',
                            cls: 'slim',
                            layout: {
                                type: 'hbox',
                                pack: 'start',
                                align: 'stretch'
                            },
                            scrollable: true,
                            items: [
                                {
                                    xtype: 'panel',
                                    flex: 1,
                                    layout: { type: 'vbox', align: 'stretch' },
                                    items: [
                                        {
                                            layout: { type: 'hbox', align: 'stretch' },
                                            itemId: 'commonPanel',
                                            items: [
                                                {
                                                    xtype: 'fieldset',
                                                    title: 'Общее',
                                                    width: 307,
                                                    margin: '0 5 0 5',
                                                    defaults: {
                                                        labelSeparator: ''
                                                    },
                                                    items: [
                                                        {
                                                            name: 'ReqCustomsID',
                                                            allwaysReadOnly: true,
                                                            labelWidth: 110
                                                        },
                                                        {
                                                            name: 'Partner',
                                                            allwaysReadOnly: true,
                                                            readOnly: true,
                                                            labelWidth: 110
                                                        },
                                                        {
                                                            name: 'Status',
                                                            allwaysReadOnly: true,
                                                            readOnly: true,
                                                            labelWidth: 110
                                                        },
                                                        {
                                                            name: 'ReqCustomsDeliveryConditions',
                                                            labelWidth: 110,
                                                            regex: new RegExp('^(?:\\w{3} {1})*\\w{3}$'),
                                                            itemId: 'deliveryConditions'
                                                        },
                                                        {
                                                            name: 'ReqCustomsContract',
                                                            labelWidth: 110
                                                        }
                                                    ]
                                                },
                                                {
                                                    xtype: 'fieldset',
                                                    title: 'Документы на перевозку',
                                                    flex: 1,
                                                    height: 200,
                                                    layout: 'fit',
                                                    margin: '0 5 0 0',
                                                    items: [
                                                        {
                                                            region: 'center',
                                                            title: '',
                                                            height: 200,
                                                            width: 340,
                                                            flex: 1,
                                                            xtype: 'WebClient.common.controls.EntityGridWithFilter',
                                                            layout: 'fit',
                                                            structureName: 'CstTransportDocumentList',
                                                            itemId: 'cstDocTransportGrid',
                                                            editOnDblClick: false,
                                                            gridConfig: {
                                                                tbar: { items: [] },
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
                                                                                text: 'Создать',
                                                                                itemId: 'addTrDoc'
                                                                            },
                                                                            {
                                                                                itemId: 'delete',
                                                                                text: 'Удалить',
                                                                                disabled: true,
                                                                                handler: function () {
                                                                                    var selection = cstDocTransportGrid.getView().getSelectionModel().getSelection();
                                                                                    if (selection)
                                                                                        cstDocTransportGrid.store.remove(selection);
                                                                                }
                                                                            }
                                                                        ]
                                                                    }
                                                                ]
                                                            }
                                                        }
                                                    ]
                                                }
                                            ]
                                        },
                                        {
                                            layout: { type: 'hbox' },
                                            itemId: 'accountsPanel',
                                            items: [
                                                {
                                                    xtype: 'fieldset',
                                                    title: 'Счета за перевозку',
                                                    height: 200,
                                                    width: 307,
                                                    margin: '0 5 0 5',
                                                    items: [
                                                        {
                                                            xtype: 'gridpanel',
                                                            height: 200,
                                                            itemId: 'accountsGrid',
                                                            columns: [
                                                                { dataIndex: 'AccountNumber', header: 'Номер', flex: 1 },
                                                                { dataIndex: 'AccountAmount', header: 'Сумма', flex: 2 },
                                                                { dataIndex: 'AccountCurrency', header: 'Валюта', flex: 1 }
                                                            ]
                                                        }
                                                    ]
                                                },
                                                {
                                                    xtype: 'fieldset',
                                                    flex: 1,
                                                    layout: 'fit',
                                                    title: 'Транспортные договоры',
                                                    height: 200,
                                                    margin: '0 5 0 0',
                                                    items: [
                                                        {
                                                            region: 'center',
                                                            title: '',
                                                            flex: 1,
                                                            height: 200,
                                                            width: 340,
                                                            xtype: 'WebClient.common.controls.EntityGridWithFilter',
                                                            layout: 'fit',
                                                            structureName: 'CstTransportContractList',
                                                            itemId: 'transportContgrid',
                                                            editOnDblClick: false,
                                                            gridConfig: {
                                                                tbar: { items: [] },
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
                                                                                text: 'Создать',
                                                                                itemId: 'addTrCont'
                                                                            },
                                                                            {
                                                                                itemId: 'delete',
                                                                                text: 'Удалить',
                                                                                disabled: true,
                                                                                handler: function () {
                                                                                    var selection = cstTransportContractGrid.getView().getSelectionModel().getSelection();
                                                                                    if (selection)
                                                                                        cstTransportContractGrid.store.remove(selection);
                                                                                }
                                                                            }
                                                                        ]
                                                                    }
                                                                ]
                                                            }
                                                        }
                                                    ]

                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'fieldset',
                                            title: 'Накладные',
                                            layout: 'fit',
                                            margin: '0 5 0 5',
                                            items: [
                                                {
                                                    region: 'center',
                                                    flex: 1,
                                                    title: '',
                                                    height: 200,
                                                    xtype: 'WebClient.common.controls.EntityGridWithFilter',
                                                    layout: 'fit',
                                                    structureName: 'CstReqCustoms2WBList',
                                                    itemId: 'reqCustoms2WBGrid',
                                                    editOnDblClick: false,
                                                    gridConfig: {
                                                        tbar: { items: [] },
                                                        selModel: { type: 'checkboxmodel', mode: 'MULTI', checkboxSelect: true },
                                                        dockedItems: [
                                                            {
                                                                xtype: 'toolbar',
                                                                items: [
                                                                    {
                                                                        text: 'Добавить',
                                                                        itemId: 'addBtnId'
                                                                    },
                                                                    {
                                                                        itemId: 'deleteWayBill',
                                                                        text: 'Удалить',
                                                                        disabled: true
                                                                    },
                                                                    {
                                                                        text: 'Открыть',
                                                                        itemId: 'openWaybill',
                                                                        disabled: true
                                                                    }
                                                                ]
                                                            }
                                                        ]
                                                    }
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'panel',
                                    itemId: 'customsPanel',
                                    width: 600,
                                    layout: { xtype: 'vbox', align: 'stretch' },
                                    items: [
                                        {
                                            xtype: 'fieldset',
                                            layout: { type: 'hbox' },
                                            title: 'Таможенные органы',
                                            items: [
                                                {
                                                    layout: { type: 'vbox' },
                                                    defaults: {
                                                        padding: '0 15 0 0'
                                                    },
                                                    items: [
                                                        {
                                                            labelAlign: 'top',
                                                            name: 'ReqCustomsPost',
                                                            itemId: 'post'
                                                        },
                                                        {
                                                            labelAlign: 'top',
                                                            fieldLabel: 'Дата въезда/выезда',
                                                            name: 'ReqCustomsPostDate',
                                                            itemId: 'postDate'
                                                        }
                                                    ]
                                                },
                                                {
                                                    layout: { type: 'vbox' },
                                                    defaults: {
                                                        padding: '0 15 0 0'
                                                    },
                                                    items: [
                                                        {
                                                            labelAlign: 'top',
                                                            name: 'ReqCustomsLastPost'
                                                        },
                                                        {
                                                            labelAlign: 'top',
                                                            name: 'ReqCustomsLastPostDate',
                                                            itemId: 'lastPostDate'
                                                        }
                                                    ]
                                                },
                                                {
                                                    labelAlign: 'top',
                                                    name: 'ReqCustomsNextPost'
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'fieldset',
                                            title: 'Транспортные средства',
                                            layout: { type: 'fit' },
                                            items: [
                                                {
                                                    layout: { type: 'hbox' },
                                                    items: [
                                                        {
                                                            xtype: 'fieldset',
                                                            title: 'TIR',
                                                            flex: 1,
                                                            layout: { type: 'vbox' },
                                                            defaults: {
                                                                padding: '0 15 5 0',
                                                                flex: 1
                                                            },
                                                            items: [
                                                                {
                                                                    labelAlign: 'left',
                                                                    fieldLabel: 'Номер',
                                                                    name: 'ReqCustomsTIRNumber',
                                                                    labelWidth: 70
                                                                },
                                                                {
                                                                    labelAlign: 'left',
                                                                    fieldLabel: 'Дата',
                                                                    name: 'ReqCustomsTIRDate',
                                                                    labelWidth: 70
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            xtype: 'fieldset',
                                                            title: 'TDD',
                                                            flex: 1,
                                                            layout: { type: 'vbox' },
                                                            margin: '0 0 0 5',
                                                            defaults: {
                                                                padding: '0 15 5 0',
                                                                flex: 1
                                                            },
                                                            items: [
                                                                {
                                                                    labelAlign: 'left',
                                                                    fieldLabel: 'Номер',
                                                                    name: 'ReqCustomsTTDNumber',
                                                                    labelWidth: 70
                                                                },
                                                                {
                                                                    labelAlign: 'left',
                                                                    fieldLabel: 'Дата',
                                                                    name: 'ReqCustomsTTDDate',
                                                                    labelWidth: 70
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                },
                                                {
                                                    layout: { type: 'vbox' },
                                                    items: [
                                                        {
                                                            labelAlign: 'left',
                                                            name: 'ReqCustomsVehicleStamp',
                                                            padding: '0 0 0 11',
                                                            labelWidth: 70
                                                        },
                                                        {
                                                            xtype: 'fieldset',
                                                            flex: 3,
                                                            title: 'На границе',
                                                            layout: { type: 'hbox' },
                                                            defaults: {
                                                                padding: '0 15 5 0',
                                                                flex: 1
                                                            },
                                                            items: [
                                                                {
                                                                    labelAlign: 'top',
                                                                    fieldLabel: 'Идентификация',
                                                                    name: 'ReqCustomsVehicleOutRef',
                                                                    itemId: 'vehOutRef'
                                                                },
                                                                {
                                                                    labelAlign: 'top',
                                                                    fieldLabel: 'Код ТС',
                                                                    name: 'ReqCustomsVehicleOutCode',
                                                                    itemId: 'vehOutCode'
                                                                },
                                                                {
                                                                    labelAlign: 'top',
                                                                    fieldLabel: 'Страна',
                                                                    name: 'ReqCustomsVehicleOutCountry',
                                                                    itemId: 'vehOutCountry'
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            layout: { type: 'hbox' },
                                                            items: [
                                                                {
                                                                    layout: { type: 'vbox' },
                                                                    padding: '0 0 5 11',
                                                                    items: [
                                                                        {
                                                                            xtype: 'button',
                                                                            itemId: 'fillTrFieldsBtn',
                                                                            text: 'Заполнить'
                                                                        }
                                                                    ]
                                                                }
                                                            ]

                                                        },
                                                        {
                                                            xtype: 'fieldset',
                                                            title: 'Внутри страны',
                                                            margin: '0 15 5 0',
                                                            flex: 3,
                                                            layout: { type: 'hbox' },
                                                            defaults: {
                                                                padding: '0 15 5 0',
                                                                flex: 1
                                                            },
                                                            items: [
                                                                {
                                                                    labelAlign: 'top',
                                                                    fieldLabel: 'Идентификация',
                                                                    name: 'ReqCustomsVehicleInRef',
                                                                    itemId: 'vehInRef'

                                                                },
                                                                {
                                                                    labelAlign: 'top',
                                                                    fieldLabel: 'Код ТС',
                                                                    name: 'ReqCustomsVehicleInCode',
                                                                    itemId: 'vehInCode'
                                                                },
                                                                {
                                                                    labelAlign: 'top',
                                                                    fieldLabel: 'Страна',
                                                                    name: 'ReqCustomsVehicleInCountry',
                                                                    itemId: 'vehInCountry'
                                                                }
                                                            ]

                                                        }
                                                    ]
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'WebClient.common.controls.EntityGridWithFilter',
                            height: 600,
                            title: 'Позиции',
                            structureName: 'CstReqCustomsPosList',
                            itemId: 'posList',
                            disabled: config.mode == WebClient.CardViewMode.CREATE,
                            gridConfig: { tbar: { items: [] } }
                        }
                    ]
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        me.callParent([config]);
        cstDocTransportGrid = this.down('#cstDocTransportGrid').down('gridpanel');
        cstTransportContractGrid = this.down('#transportContgrid').down('gridpanel');
        reqCustoms2WBGrid = this.down('#reqCustoms2WBGrid').down('gridpanel');

        cstTransportContractGrid.getSelectionModel().on('selectionchange', function (selModel, selections) {
            cstTransportContractGrid.down('#delete').setDisabled(selections.length === 0);
        });

        cstDocTransportGrid.getSelectionModel().on('selectionchange', function (selModel, selections) {
            cstDocTransportGrid.down('#delete').setDisabled(selections.length === 0);
        });

        reqCustoms2WBGrid.getSelectionModel().on('selectionchange', function (selModel, selections) {
            reqCustoms2WBGrid.down('#deleteWayBill').setDisabled(selections.length === 0);
            reqCustoms2WBGrid.down('#openWaybill').setDisabled(selections.length !== 1);
        });
    }
});
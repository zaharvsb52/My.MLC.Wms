Ext.define('MLC.wms.yExternalTraffic.ExternalTrafficCard', {
    extend: 'WebClient.common.controls.AutoCard',

    requires: [
        'WebClient.common.ComponentConfigEnricher',
        'WebClient.common.controls.EntityGrid',
        'MLC.wms.controls.ImageField',
        'MLC.wms.controls.PhoneText'
    ],

    mixins: {
        recordstructureaware: 'WebClient.common.controls.RecordStructureAwareMixin'
    },

    constructor: function (config) {

        var lblAlign = Ext.getBody().getViewSize().width <= 1280 ? 'top' : 'left';

        var defaultConfig =
        {
            xtype: 'panel',
            layout: 'vbox',
            items: [
                {
                    xtype: 'panel',
                    layout: { type: 'hbox' },
                    width: '100%',
                    maxHeight: 70,
                    cls: 'whitebg',
                    padding: '5 0 2 0',
                    items: [
                        {
                            name: 'ExternalTrafficPassNumber',
                            labelWidth: 180,
                            padding: '30 30 20 30',
                            rowspan: 2,
                            fieldCls: 'biggertext',
                            labelCls: 'biggertext'
                        },
                        {
                            labelWidth: 80,
                            padding: '30 30 20 30',
                            rowspan: 2,
                            fieldCls: 'biggertext',
                            labelCls: 'biggertext',
                            name: 'Status',
                            itemId: 'status'
                        }
                    ]
                },
                {
                    xtype: 'panel',
                    width: '100%',
                    maxHeight: 40,
                    padding: '0 0 2 0',
                    cls: 'graybg',
                    items: [
                        {
                            height: 30,
                            padding: '0 0 35 0',
                            xtype: 'toolbar',
                            itemId: 'commandToolbar'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    layout: 'fit',
                    itemId: 'driverpanel',
                    width: '100%',
                    items: [
                        {
                            xtype: 'panel',
                            layout: 'hbox',
                            items: [
                                {
                                    xtype: 'panel',
                                    flex: 1,
                                    layout: {
                                        type: 'vbox',
                                        pack: 'start',
                                        align: 'stretch'
                                    },
                                    defaults: {
                                        padding: '10 0 0 10'
                                    },
                                    items: [
                                        {
                                            xtype: 'panel',
                                            header: {
                                                title: 'Водитель'
                                            },
                                            layout: {
                                                align: 'stretch'
                                            },
                                            items: [
                                                {
                                                    xtype: 'panel',
                                                    layout:
                                                    {
                                                        type: 'vbox',
                                                        align: 'stretch'
                                                    },
                                                    padding: '5 0 0 10',
                                                    items: [
                                                        {
                                                            xtype: 'panel',
                                                            flex: 1,
                                                            layout: {
                                                                type: 'hbox',
                                                                align: 'stretch'
                                                            },
                                                            items: [
                                                                {
                                                                    xtype: 'panel',
                                                                    margin: '0 10 0 0',
                                                                    flex: 3,
                                                                    layout: {
                                                                        align: 'stretch',
                                                                        type: 'vbox'
                                                                    },
                                                                    items: [
                                                                        {
                                                                            labelAlign: lblAlign,
                                                                            name: 'ExternalTrafficDriver',
                                                                            labelWidth: 100,
                                                                            itemId: 'driver'
                                                                        },
                                                                        {
                                                                            labelAlign: lblAlign,
                                                                            labelWidth: 100,
                                                                            name: 'ExternalTrafficDriver_WorkerPhoneMobile',
                                                                            xtype: 'phonefield'
                                                                        },
                                                                        {
                                                                            labelAlign: lblAlign,
                                                                            labelWidth: 100,
                                                                            name: 'ExternalTrafficDriver_WorkerBirthday'
                                                                        },
                                                                        {
                                                                            labelAlign: lblAlign,
                                                                            labelWidth: 100,
                                                                            name: 'WorkerPass',
                                                                            itemId: 'wrkpass'
                                                                        },
                                                                        {
                                                                            xtype: 'panel',
                                                                            layout: {
                                                                                align: 'stretch',
                                                                                type: 'hbox'
                                                                            },
                                                                            items: [
                                                                                {
                                                                                    xtype: 'textareafield',
                                                                                    flex: 1,
                                                                                    grow: true,
                                                                                    padding: '0 10 0 0',
                                                                                    labelAlign: 'top',
                                                                                    name: 'VDriverPass'
                                                                                },
                                                                                {
                                                                                    xtype: 'textareafield',
                                                                                    flex: 1,
                                                                                    grow: true,
                                                                                    padding: '0 0 0 10',
                                                                                    labelAlign: 'top',
                                                                                    name: 'VDriverAddress'
                                                                                }
                                                                            ]
                                                                        }
                                                                    ]
                                                                },
                                                                {
                                                                    xtype: 'MLC.wms.controls.ImageField',
                                                                    name: 'ExternalTrafficDriver_WorkerPhoto',
                                                                    fieldLabel: ''
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'panel',
                                            title: 'Автомобиль',
                                            flex: 1,
                                            layout: {
                                                type: 'vbox',
                                                align: 'stretch'
                                            },
                                            items: [
                                                {
                                                    name: 'Vehicle',
                                                    itemId: 'vehicle',
                                                    labelAlign: lblAlign,
                                                    labelWidth: 80,
                                                    padding: '10 0 0 10'
                                                },
                                                {
                                                    xtype: 'panel',
                                                    flex: 1,
                                                    align: 'stretchmax',
                                                    layout: {
                                                        type: 'hbox',
                                                        pack: 'start',
                                                        align: 'stretchmax'
                                                    },
                                                    items: [
                                                        {
                                                            xtype: 'panel',
                                                            flex: 1,
                                                            layout: {
                                                                pack: 'start',
                                                                align: 'stretchmax'
                                                            },
                                                            padding: '10 0 0 10',
                                                            items: [
                                                                {
                                                                    labelWidth: 80,
                                                                    labelAlign: lblAlign,
                                                                    xtype: 'displayfield',
                                                                    name: 'Vehicle_VehicleRN'
                                                                },
                                                                {
                                                                    labelWidth: 80,
                                                                    labelAlign: lblAlign,
                                                                    xtype: 'displayfield',
                                                                    name: 'Vehicle_VehicleVIN'
                                                                },
                                                                {
                                                                    labelWidth: 80,
                                                                    labelAlign: lblAlign,
                                                                    xtype: 'displayfield',
                                                                    fieldLabel: 'Цвет',
                                                                    name: 'Vehicle_VehicleColor_UserEnumName'
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            xtype: 'panel',
                                                            flex: 1,
                                                            layout: {
                                                                pack: 'start',
                                                                align: 'stretchmax'
                                                            },
                                                            defaults: { labelWidth: 130, padding: '5 0 0 10' },
                                                            padding: '10 0 0 0',
                                                            items: [
                                                                {
                                                                    fieldLabel: 'Тип автомобиля',
                                                                    labelAlign: lblAlign,
                                                                    name: 'Vehicle_VehicleType_UserEnumName'
                                                                },
                                                                {
                                                                    xtype: 'displayfield',
                                                                    labelAlign: lblAlign,
                                                                    name: 'Vehicle_VehicleMaxWeight'
                                                                },
                                                                {
                                                                    xtype: 'displayfield',
                                                                    labelAlign: lblAlign,
                                                                    name: 'Vehicle_VehicleEmptyWeight'
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            xtype: 'panel',
                                                            flex: 1,
                                                            layout: {
                                                                pack: 'start',
                                                                align: 'stretchmax'
                                                            },
                                                            defaults: { labelWidth: 100, padding: '5 0 0 10' },
                                                            padding: '10 0 0 0',
                                                            items: [
                                                                {
                                                                    xtype: 'displayfield',
                                                                    fieldLabel: 'Владелец ЮР',
                                                                    labelAlign: lblAlign,
                                                                    name: 'Vehicle_VehicleOwnerLegal_PartnerName'
                                                                },
                                                                {
                                                                    xtype: 'displayfield',
                                                                    fieldLabel: 'Владелец ФИЗ',
                                                                    labelAlign: lblAlign,
                                                                    name: 'Vehicle_VehiclePerson_WorkerLastName'
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                }
                                            ]
                                        }
                                    ]
                                },
                                { xtype: 'tbspacer', width: 10 },
                                {
                                    xtype: 'panel',
                                    flex: 1,
                                    layout: {
                                        type: 'vbox',
                                        pack: 'start',
                                        align: 'stretch'
                                    },
                                    defaults: {
                                        padding: '10 0 0 10'
                                    },
                                    items: [
                                        {
                                            xtype: 'panel',
                                            title: 'Рейс',
                                            flex: 1,
                                            layout: {
                                                pack: 'middle',
                                                align: 'stretch'
                                            },
                                            items: [
                                                {
                                                    xtype: 'panel',
                                                    layout: 'hbox',
                                                    padding: '10 0 0 10',
                                                    items: [
                                                        {
                                                            xtype: 'panel',
                                                            flex: 1,
                                                            defaults: { labelWidth: 110 },
                                                            items: [
                                                                {
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficPlanArrived'
                                                                },
                                                                {
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficFactArrived'
                                                                },
                                                                {
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficFactDeparted'
                                                                },
                                                                {
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficHostRef'
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            xtype: 'panel',
                                                            layout: {
                                                                type: 'vbox',
                                                                align: 'stretch'
                                                            },
                                                            flex: 1,
                                                            defaults: { padding: '0 10 0 10' },
                                                            items: [
                                                                {
                                                                    labelWidth: 100,
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficVerified'
                                                                },
                                                                {
                                                                    labelWidth: 100,
                                                                    labelAlign: lblAlign,
                                                                    name: 'Parking'
                                                                },
                                                                {
                                                                    labelWidth: 100,
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficTrailerRN'
                                                                },
                                                                {
                                                                    labelWidth: 100,
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficForvarder'
                                                                },
                                                                {
                                                                    labelWidth: 100,
                                                                    labelAlign: lblAlign,
                                                                    name: 'ExternalTrafficCarrier'
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                }
                                            ]

                                        },
                                        {
                                            xtype: 'form',
                                            layout: 'fit',
                                            items: [
                                                {
                                                    xtype: 'textareafield',
                                                    grow: true,
                                                    padding: '0 10 0 10',
                                                    labelAlign: 'top',
                                                    name: 'ExternalTrafficDesc',
                                                    fieldLabel: 'Описание'
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
                    layout: 'fit',
                    height: 300,
                    width: '100%',
                    items: [
                        {
                            xtype: 'WebClient.common.controls.EntityGridWithFilter',
                            dataService: 'WMS.DataServices.ExternalTraffic.DataService',
                            title: 'Внутренние рейсы',
                            structureName: 'InternalTrafficList',
                            itemId: 'internaltrafficgrid',
                            gridConfig: {
                                editOnDblClick: true
                            }
                        }
                    ]
                }
            ]
        };

        config = Ext.merge(defaultConfig, config);

        this.callParent([config]);
    }
});
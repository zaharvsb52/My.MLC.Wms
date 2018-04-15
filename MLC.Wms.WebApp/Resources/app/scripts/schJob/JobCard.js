Ext.define('MLC.wms.schJob.JobCard', {
    extend: 'WebClient.common.controls.EntityCard',

    constructor: function (config) {

        var defaultConfig =
        {
            xtype: 'panel',
            items: [
                {
                    xtype: 'panel',
                    layout: {
                        type: 'hbox',
                        align: 'stretch'
                    },
                    title: 'Основная информация',
                    items: [
                        {
                            type: 'panel',
                            bodyBorder: false,
                            layout: {
                                type: 'vbox',
                                align: 'stretch'
                            },
                            flex: 1,
                            margin: '0 5 0 0',
                            items: [
                                {
                                    name: 'Code',
                                    itemId: 'jobCode'
                                },
                                { name: 'Scheduler' },
                                {
                                    name: 'JobType',
                                    itemId: 'jobType'
                                }
                            ]
                        },
                        {
                            type: 'panel',
                            bodyBorder: false,
                            flex: 1,
                            layout: {
                                type: 'vbox',
                                align: 'stretch'
                            },
                            margin: '0 0 0 5',
                            items: [
                                { name: 'JobGroup' },
                                { name: 'Description' }
                            ]
                        }
                    ]
                },
                 {
                     xtype: 'panel',
                     layout: {
                         type: 'hbox',
                         align: 'stretch'
                     },
                     margin: '10 0 0 0',
                     height: Ext.getBody().getViewSize().height * 0.7,
                     items: [
                         {
                             xtype: 'panel',
                             title: 'Параметры',
                             layout: {
                                 type: 'fit',
                                 align: 'stretch'
                             },
                             margin: '0 5 0 0',
                             flex: 1,
                             disabled: config.mode == WebClient.CardViewMode.CREATE,
                             items: [
                                 {
                                     xtype: 'WebClient.common.controls.EntityGridWithFilter',
                                     title: '',
                                     structureName: 'SchJobParamList',
                                     itemId: 'jobparamgrid',
                                     autoLoad: true,
                                     entityType: 'SchJobParam',
                                     gridConfig: {
                                         editOnDblClick: true
                                     }
                                 }
                             ]
                         },
                         {
                             margin: '0 0 0 5',
                             xtype: 'tabpanel',
                             flex: 1,
                             activeTab: 0,
                             items: [
                                 {
                                     xtype: 'panel',
                                     title: 'Cron триггеры',
                                     layout: {
                                         type: 'fit',
                                         align: 'stretch'
                                     },
                                     disabled: config.mode == WebClient.CardViewMode.CREATE,
                                     items: [
                                         {
                                             xtype: 'WebClient.common.controls.EntityGridWithFilter',
                                             title: '',
                                             structureName: 'SchCronTriggerList',
                                             itemId: 'crontriggergrid',
                                             autoLoad: true,
                                             entityType: 'SchCronTrigger',
                                             gridConfig: {
                                                 editOnDblClick: true
                                             }
                                         }
                                     ]
                                 },
                                 {
                                     xtype: 'panel',
                                     title: 'Simple триггеры',
                                     layout: {
                                         type: 'fit',
                                         align: 'stretch'
                                     },
                                     disabled: config.mode == WebClient.CardViewMode.CREATE,
                                     items: [
                                         {
                                             xtype: 'WebClient.common.controls.EntityGridWithFilter',
                                             title: '',
                                             structureName: 'SchSimpleTriggerList',
                                             itemId: 'simpletriggerrid',
                                             autoLoad: true,
                                             entityType: 'SchSimpleTrigger',
                                             gridConfig: {
                                                 editOnDblClick: true
                                             }
                                         }
                                     ]
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
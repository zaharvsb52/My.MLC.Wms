Ext.define('MLC.wf.controls.FileUpload', {

    extend: 'Ext.form.Panel',

    requires: [
        'MLC.wf.controller.Dispatcher',
        'MLC.wf.attributes.FileFieldAttributes'
    ],
    
    constructor: function (cfg) {
        var me = this;
        var defaultCfg = {
            layout: 'fit',
            autoScroll: true,
            items: [
            {
                xtype: 'form',
                border: 0,
                bodyPadding: 10,
                api: {
                    submit: Server.OMS.DataServices.WWF.DataService.submitFile
                },
                items: [
                    {
                        xtype: 'filefield',
                        name: 'fileValue',
                        id: 'fileField',
                        emptyText: 'Выберите файл для загрузки',
                        buttonText: 'Обзор',
                        fieldLabel: 'Файл',
                        allowBlank: false,
                        fileInputAttributes: {
                            accept: '.xlsx,.xls'
                        },
                        anchor: '100%'
                    }
                ],
                buttons: [
                    {
                        text: 'Загрузить',
                        name: "Save",
                        id: "btnSave",
                        handler: function () {
                            var btnSave = Ext.getCmp('btnSave');
                            var btnCancel = Ext.getCmp('btnCancel');
                            //var fileField = Ext.getCmp('fileField');
                            var form = this.up('form').getForm();
                            if (form.isValid()) {
                                btnSave.setDisabled(true);
                                btnCancel.setDisabled(true);
                                form.submit({
                                    waitMsg: 'Идет загрузка файла...',
                                    success: function (form, action) {
                                        var field = Ext.getCmp('fileField');
                                        field.button.setDisabled(true);
                                        field.mask('Идет анализ файла...', "x-mask-loading");
                                        me.fireEvent('success', action.result.FilePath);
                                    },
                                    failure: function(form, action) {
                                        me.fireEvent('failure', 'Не удалось загрузить файл');
                                        btnSave.setDisabled(false);
                                        btnCancel.setDisabled(false);
                                    },
                                    scope: this
                                });
                            }
                        }
                    },
                    {
                        text: 'Отмена',
                        name: "Cancel",
                        id: "btnCancel",
                        handler: function() {
                            me.fireEvent('failure', 'Cancel');
                        },
                        scope: this
                    }
                ]
            }
            ]
        };

        cfg = Ext.Object.merge(defaultCfg, cfg);

        this.callParent([cfg]);
    }

});
Ext.define('MLC.wms.LoginForm', {
    extend: 'Ext.window.Window',

    loginCookieName: 'LastSuccessLogin',

    rootpath: undefined,

    productVersion: undefined,

    formPanel: undefined,

    loginField: undefined,

    passwordField: undefined,

    submitButton: undefined,

    capsLockIndicator: undefined,

    constructor: function (config) {

        var me = this,
            lastSuccessfulLogin = Ext.util.Cookies.get(me.loginCookieName),
            defaultConfig = {
                width: 400,
                height: 220,
                closable: false,
                title: config.productVersion,
                layout: 'fit',
                modal: true,
                items: [
                    {
                        xtype: 'form',
                        itemId: 'formPanel',
                        activeItem: 0,
                        url: (config.rootpath || '') + 'security/login',
                        bodyPadding: 15,
                        border: false,

                        defaults: {
                            anchor: '100%',
                            allowBlank: false,
                            xtype: 'textfield',
                            msgTarget: 'side',
                            enableKeyEvents: true,
                            listeners: {
                                keypress: function (field, e, eOpts) {
                                    var key = e.getKey();
                                    if (key !== e.ENTER) {
                                        var newValue = me.isCapslock(e) ? 'CapsLock включен' : me.isRussianLang(e) ? 'Русская раскладка' : newValue;
                                        me.capsLockIndicator.setValue(newValue);
                                    }
                                }
                            }
                        },

                        items: [
                            {
                                xtype: 'displayfield',
                                value: 'Пожалуйста, войдите в систему, чтобы продолжить',
                                hideLabel: true
                            }, {
                                itemId: 'loginField',
                                name: 'login',
                                fieldLabel: 'Имя пользователя',
                                value: lastSuccessfulLogin
                            }, {
                                itemId: 'passwordField',
                                name: 'password',
                                fieldLabel: 'Пароль',
                                inputType: 'password'
                            }, {
                                xtype: 'displayfield',
                                itemId: 'capsLockIndicator',
                                name: 'capsLockIndicator',
                                hideLabel: true,
                                fieldStyle: {
                                    color: 'red',
                                    textAlign: 'center'
                                }
                            }
                        ],

                        listeners: {
                            afterrender: function (form) {
                                var keynav = new Ext.util.KeyNav(me.formPanel.getEl(), {
                                    'enter': function (e) {
                                        me.onLoginClick();
                                    }
                                });
                            }
                        },

                        buttons: [
                            {
                                xtype: 'button',
                                itemId: 'submitButton',
                                text: 'Войти',
                                type: 'submit',
                                formBind: true,
                                handler: me.onLoginClick,
                                scope: me
                            }
                        ]
                    }
                ]
            };

        config = Ext.merge(defaultConfig, config);

        me.callParent([config]);

        me.formPanel = me.down('#formPanel');
        me.loginField = me.down('#loginField');
        me.passwordField = me.down('#passwordField');
        me.submitButton = me.down('#submitButton');
        me.capsLockIndicator = me.down('#capsLockIndicator');
    },

    getDefaultFocus: function () {
        var me = this,
            loginField = me.down('#loginField'),
            passwordField = me.down('#passwordField');

        return !loginField.getValue() ? loginField : passwordField;
    },

    onLoginClick: function () {
        var me = this;
        var loginForm = me.formPanel.getForm();

        if (loginForm.isValid()) {
            Ext.Msg.wait('Осуществляется вход...');

            loginForm.submit({
                success: me.onSuccessLogin,
                failure: me.onFailedLogin,
                scope: me
            });
        }
    },

    onSuccessLogin: function (form, action) {
        var me = this;

        Ext.Msg.hide();

        var expirationDate = new Date();
        expirationDate.setFullYear(expirationDate.getFullYear() + 1);
        Ext.util.Cookies.set(me.loginCookieName, me.loginField.value, expirationDate);
       
        me.fireEvent('loginsuccess');
    },

    onFailedLogin: function (form, action) {
        var me = this;

        Ext.Msg.hide();

        me.passwordField.setRawValue(null);

        var messageBox = new Ext.window.MessageBox({
            listeners: {
                hide: function () {
                    me.passwordField.focus();
                }
            }
        });

        messageBox.show({
            title: 'Ошибка',
            msg: me.getErrorMessage(action),
            buttons: Ext.Msg.OK,
            icon: Ext.Msg.ERROR
        });

        me.fireEvent('loginfailure');
    },

    getErrorMessage: function (action) {
        if (action.failureType == Ext.form.Action.SERVER_INVALID)
            return action.result.errors.title;

        if (action.failureType == Ext.form.Action.CONNECT_FAILURE)
            return 'Веб-приложение не доступно. (HTTP статус: ' + action.response.status + ' ' + action.response.statusText + ')';

        return 'Неизвестный тип ошибки.';
    },

    isCapslock: function (e) {
        e = (e) ? e : window.event;

        var charCode = false;
        if (e.which) {
            charCode = e.which;
        } else if (e.keyCode) {
            charCode = e.keyCode;
        }

        var shifton = false;
        if (e.shiftKey) {
            shifton = e.shiftKey;
        } else if (e.modifiers) {
            shifton = !!(e.modifiers & 4);
        }

        if (charCode >= 97 && charCode <= 122 && shifton) {
            return true;
        }

        if (charCode >= 65 && charCode <= 90 && !shifton) {
            return true;
        }

        return false;
    },

    isRussianLang: function (e) {
        e = (e) ? e : window.event;

        var charCode = false;
        if (e.which) {
            charCode = e.which;
        } else if (e.keyCode) {
            charCode = e.keyCode;
        }

        if (charCode >= 1025 && charCode <= 1105) {
            return true;
        }

        return false;
    }
});
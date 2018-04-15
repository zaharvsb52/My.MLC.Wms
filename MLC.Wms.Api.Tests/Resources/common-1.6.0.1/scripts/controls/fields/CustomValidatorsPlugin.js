Ext.define('WebClient.common.controls.fields.CustomValidatorsPlugin', {
    extend: 'Ext.AbstractPlugin',

    alias: ['plugin.customValidators'],

    requires: [
        'WebClient.common.validator.Validator',
        'WebClient.common.controls.fields.IconPlugin'
    ],

    customValidators: [],

    init: function(cmp) {
        var me = this,
            icon;

        me.icon = icon = new WebClient.common.controls.fields.IconPlugin();
        icon.init(cmp);
        me.setCmp(cmp);

        Ext.override(cmp, {
            getErrors: function(value) {
                if (cmp.isDisabled() || cmp.readOnly)
                    return this.callParent(arguments);

                var errors = [];
                Ext.Array.each(me.customValidators, function(v) {
                    if (v.getLevel() !== WebClient.common.validator.Validator.ERROR)
                        return;
                    if (v.validate(cmp.getValue()))
                        return;
                    errors.push(v.getDisplayMessage());
                });
                return errors.length ? errors : this.callParent(arguments);
            },

            validate: function() {
                var valid = true;
                cmp.getIcon().hide();

                if (cmp.isDisabled() || cmp.readOnly)
                    return this.callParent(arguments);

                Ext.Array.each(me.customValidators, function(v) {
                    if (v.validate(cmp.getValue()))
                        return true;
                    icon.show(v.getLevel(), v.getDisplayMessage());
                    if (v.getLevel() === WebClient.common.validator.Validator.ERROR)
                        valid = false;
                    return false;
                });

                return !valid ? false : this.callParent(arguments);
            }

        });
    },

    destroy: function() {
        this.icon.destroy();
    }
});
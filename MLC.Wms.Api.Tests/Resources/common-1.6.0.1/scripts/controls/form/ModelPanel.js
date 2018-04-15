Ext.define('WebClient.common.controls.form.ModelPanel', {
    extend: 'Ext.form.Panel',
    alias: ['widget.WebClient.common.controls.form.ModelPanel'],

    requires: [
        'WebClient.common.controls.form.Model'
    ],

    /**
     * @type Ext.data.Model Модель данных с которыми работает эта форма
     */
    model: undefined,

    /**
     * @private
     * @override
     */
    createForm: function() {
        var cfg = {},
            props = this.basicFormConfigs,
            len = props.length,
            i = 0,
            prop;

        for (; i < len; ++i) {
            prop = props[i];
            cfg[prop] = this[prop];
        }
        return new WebClient.common.controls.form.Model(this, cfg);
    }
});
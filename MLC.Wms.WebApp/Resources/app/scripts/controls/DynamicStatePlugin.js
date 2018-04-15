Ext.define('MLC.wms.controls.DynamicStatePlugin', {
    extend: 'Ext.AbstractPlugin',

    alias: ['plugin.dynamicStatePlugin'],

    requires: [
        'MLC.wms.controls.IStateProvider',
        'WebClient.common.Site'
    ],

    /*
        {
            disabled: ['formReadOnly', 'userIsNotAllowedToEdit', 'state3'],
            disabledComb: 'any' //'any'
        }
    */

    rules: undefined,

    init: function (cmp) {
        var me = this;
        me.setCmp(cmp);
        cmp.on('render', me.onCmpRender, me);
    },

    onCmpRender: function () {
        var site = WebClient.common.Site.getSite(this.getCmp());
        var stateProvider = site.getService('MLC.wms.controls.IStateProvider');
        var states = stateProvider.getStates();
        this.applyRules(states);
    },

    applyRules: function (states) {
        if (!this.rules)
            return;
        var cmp = this.getCmp();
        for (var rule in this.rules) {
            if (!this.rules.hasOwnProperty(rule))
                continue;

            var ruleExpression = this.rules[rule];
            var ruleValue = this.evaluateRule(ruleExpression, states);
            if (ruleValue) {
                cmp.setConfig(rule, ruleValue);
            }
        }
    },

    evaluateRule: function (ruleExpression, states) {
        return true;
    }
});

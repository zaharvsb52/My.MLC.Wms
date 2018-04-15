Ext.define('MLC.wms.controls.IStateProvider', {
    extend: 'WebClient.common.Interface',

    getStates: function () { },

    notifyOnStatesChange: function (callback, scope) { }
});
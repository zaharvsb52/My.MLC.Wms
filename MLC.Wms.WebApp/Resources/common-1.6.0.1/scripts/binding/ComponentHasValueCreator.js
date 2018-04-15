Ext.define('WebClient.common.binding.ComponentHasValueCreator', {
    extend: 'WebClient.common.binding.HasValueCreator',

    knownValueNames: { enabled: '$enabled' },

    createHasValue: function(vo, control, valueName, mappedField) {
        if (valueName == 'enabled') {
            vo.get = function() {
                return !control.isDisabled();
            };

            vo.set = function(v) {
                control.setDisabled(!v);
            };

            control.on('enable', function(c) {
                vo.fire(true);
            });

            control.on('disable', function(c) {
                vo.fire(false);
            });
            return true;
        }
        return false;
    },

    supports: function(control) {
        return control.isComponent;
    }
});
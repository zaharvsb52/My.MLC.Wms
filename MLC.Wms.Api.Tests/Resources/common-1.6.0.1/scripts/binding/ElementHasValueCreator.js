Ext.define('WebClient.common.binding.ElementHasValueCreator', {
    extend: 'WebClient.common.binding.HasValueCreator',

    supportedTypes: ['Ext.Element'],

    knownValueNames: { innerText: '$innerText' },

    defaultValueName: 'innerText',

    createHasValue: function(vo, el, valueName, mappedField) {
        if (valueName == 'innerText') {
            vo.get = function() {
                return el.dom.innerText;
            };

            vo.set = function(v) {

                if (el.dom.innerText !== undefined) { //for IE
                    el.dom.innerText = v;
                } else
                    el.dom.textContent = v; //for FireFox
                vo.fire(v);
            };

            return true;
        }
        return false;
    }
});
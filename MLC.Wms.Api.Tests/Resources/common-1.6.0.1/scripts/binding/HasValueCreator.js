/**
 * Создает или возвращает один из доступных {@link WebClient.common.binding.HasValue} для переданного контрола. Не каждый Creator подходит каждому control-у - 
 * Creator захочет работать только с теми контролами, для которых метод supports возвращает true. Обратите внимание - метод supports вызвается только один раз
 * для класса контрола, то есть тот Creator который скажет "моё" для первого textbox-а в системе - будет работать со всеми textbox-ами (но не обязательно наследниками)
 * до конца своих дней (пока страничка не перезагрузится).
 * Во время создания HasValue, Creator устанавливает нужные функции в set и get создаваемого HasValue, а также подписывается на нужные события control-а так, чтобы 
 * перевызвать событие 'changed' у этого HasValue. И вся эта логика зависит от имени HasValue.   
 */
Ext.define('WebClient.common.binding.HasValueCreator', {
    requires: [
        'WebClient.common.binding.HasValue'
    ],

    /** @type {Array}  */
    supportedTypes: [],

    /** Если сам Creator не смог создать нужный HasValue (ну не знает он, что такое enabled, ну чтоже делать ....),
     *  он делегирует этот вопрос своим вложенным Creator-ам, пока кто-то не откликнется.  
     *  Массив имен классов вложенных Creator-ов. Каждый элемент будет заменен соответсвующим instance-ом. 
     *  Не забудьте указать каждый используемый класс в requires
     * @type {Array}
     */
    nestedCreators: [],

    /**
     * Объект задающий маппинг "имя HasValue" - "название member-а компонента в котором будет храниться instance созданного HasValue".
     * Например: { value: '$hasValue' }
     */
    knownValueNames: {},

    /** @private */
    allKnownValueNames: undefined,


    defaultValueName: 'value',

    constructor: function() {
        var csclasses = this.nestedCreators,
            cs = [];

        this.allKnownValueNames = Ext.clone(this.knownValueNames);


        for (var i = 0, l = csclasses.length; i < l; i++) {
            cs.push(Ext.create(csclasses[i]));
            Ext.applyIf(this.allKnownValueNames, cs[i].allKnownValueNames);
        }
        this.nestedCreators = cs;
    },

    /**
     * Возвращает (создает первый раз) HasValue с указанным именем (например 'value', или 'selected', или 'selectedids').
     * @param {Ext.Component} control
     * @param {String} valueName Optional. Если не передан, использукется defaultValueName.
     * @return {WebClient.common.binding.HasValue}
     */
    get: function(control, valueName) {
        if (!valueName)
            valueName = this.defaultValueName;

        var mappedField = this.allKnownValueNames[valueName];
        if (!mappedField)
            Ext.Error.raise('Value "' + valueName + '" used for binding is unknown for control ' + Ext.getClassName(control));

        var vo = control[mappedField];
        if (!vo) {
            vo = new WebClient.common.binding.HasValue();
            if (!this.createHasValue(vo, control, valueName, mappedField))
                Ext.Error.raise('Creator didn\'t create HasValue');
            control[mappedField] = vo;
        }
        return vo;
    },

    createHasValue: function(vo, control, valueName, mappedField) {

        var cs = this.nestedCreators;
        if (cs) {
            for (var i = 0, l = cs.length; i < l; i++) {
                if (cs[i].createHasValue.apply(cs[i], arguments))
                    return true;
            }
        }
        return false;
    },

    supports: function(control) {
        var types = this.supportedTypes,
            l = types.length,
            i = 0;

        for (; i < l; i++) {
            if (control instanceof Ext.ClassManager.get(types[i]))
                return true;
        };
        return false;
    }
});
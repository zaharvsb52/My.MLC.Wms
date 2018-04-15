/**
 * Руководитель, я бы даже сказал менеджер проектов, всего механизма binding-а. Он умеет доставать HasValue у переданного контрола (при помощи 
 * массива зарегистрированных {@link WebClient.common.binding.HasValueCreator}-ов). Но главное, в методе bind он создает связь ({@link WebClient.common.binding.Binding}) 
 * между этим контролом как источником и другим контролом как приемником (между их HasValue) - так, что когда изменяется value источника, оно просовывается в приемник. 
 */
Ext.define('WebClient.common.binding.Binder', {
    requires: [
        'WebClient.common.binding.Binding',
        'WebClient.common.binding.ComponentHasValueCreator',
        'WebClient.common.binding.FormFieldHasValueCreator',
        'WebClient.common.binding.GridHasValueCreator',
        'WebClient.common.binding.ComboBoxHasValueCreator',
        'WebClient.common.binding.ElementHasValueCreator',
        'WebClient.common.binding.TagFieldHasValueCreator'
    ],


    singleton: true,

    /**
     * Массив объектов-наследников {@link WebClient.common.binding.HasValueCreator}. Если вы добавляете свой HasValueCreator: порядок объектов 
     * в массиве важен - если кто-то из creator-ов до вас скажет "supports" для нового контрола - работать будет с ним только он, а не ваш Creator, 
     * так что вставляйте свои Creator-ы в самое начало.   
     */
    creators: [],

    /**
     * @private
     */
    map: new Ext.util.MixedCollection(),

    constructor: function() {
        this.creators.push(new WebClient.common.binding.GridHasValueCreator());
        this.creators.push(new WebClient.common.binding.TagFieldHasValueCreator());
        this.creators.push(new WebClient.common.binding.ComboBoxHasValueCreator());
        this.creators.push(new WebClient.common.binding.FormFieldHasValueCreator());
        this.creators.push(new WebClient.common.binding.ComponentHasValueCreator());
        this.creators.push(new WebClient.common.binding.ElementHasValueCreator());
    },

    /**
     * Создает связь ({@link WebClient.common.binding.Binding}) между sourceControl как источником и другим контролом 
     * как приемником (между их HasValue) - так, что когда изменяется value источника, оно просовывается в приемник.
     * Приемник устанавливается в самой связи. Там же опционально устанавливаются конверсии   
     * @param {Ext.Component/WebClient.common.binding.HasValue} sourceControlOrHasValue
     * @param {String} (optional) sourceControlValueName
     * @return {WebClient.common.binding.Binding}
     */
    bind: function(sourceControl, sourceControlValueName) {
        if (!sourceControl)
            Ext.Error.raise('sourceControl параметр пуст');
        var vs = this.getHasValue(sourceControl, sourceControlValueName);
        return new WebClient.common.binding.Binding(vs);
    },

    /**
     * Создает или возвращает созданный HasValue от переданного компонента по имени HasValue.
     * @param {Object} control
     * @param {string} valueName optional Берется HasValue по умолчанию если не указано. См. 
     * {@link WebClient.common.binding.HasValueCreator#defaultValueName}, а также его наследников 
     * @return {WebClient.common.binding.HasValue}
     */
    getHasValue: function(control, valueName) {
        if (control instanceof WebClient.common.binding.HasValue)
            return control;
        else {
            var c = this.getCreator(control);
            return c.get(control, valueName);
        }
    },

    /**
     * Создает HasValue представляющую простую переменную. 
     * @param {Object} initialValue начальное значение переменной внутри создавамеого HasValue 
     * @return {}
     */
    createVariableHasValue: function(initialValue) {
        var vo = new WebClient.common.binding.HasValue({
            v: initialValue
        });

        vo.get = function() {
            return vo.v;
        };

        vo.set = function(v) {
            vo.v = v;
            vo.fire(v);
        };
        return vo;
    },

    /**
     * Возвращает объект, который создает\достает HasValue у переданного контрола
     * @private
     * @param {Object} control
     */
    getCreator: function(control) {
        var cls = Ext.getClassName(control),
            creator = this.map.get(cls),
            creators = this.creators;


        if (!creator) {
            for (var i = 0, l = creators.length; i < l; i++) {
                if (creators[i].supports(control)) {
                    creator = creators[i];
                    this.map.add(cls, creator);
                    break;
                }
            }
        }

        if (!creator)
            Ext.Error.raise('Control "' + cls + '" cannot be used for binding');

        return creator;
    },

    /**
     * Принимает любое количество HasValue (не менее двух), и возвращает объединенный HasValue, 
     * значение которого есть массив значений всех переданных HasValue 
     * @param {WebClient.common.binding.HasValue\Array} hasValue1
     * @param {WebClient.common.binding.HasValue} hasValue2
     */
    combineHasValues: function(hasValue1, hasValue2) {
        var hasValues;
        if (Ext.isArray(hasValue1))
            hasValues = hasValue1;
        else {
            Assert.isTrue(arguments.length > 1);
            hasValues = arguments;
        }

        var vo = new WebClient.common.binding.HasValue();
        var isBeingSet = false;

        vo.get = function() {
            var ret = [];
            for (var i = 0, l = hasValues.length; i < l; i++)
                ret.push(hasValues[i].get());
            return ret;
        };

        vo.set = function(varray) {
            try {
                isBeingSet = true;
                for (var i = 0, l = hasValues.length; i < l; i++)
                    hasValues[i].set(varray[i]);
            } finally {
                isBeingSet = false;
            }
        };

        for (var i = 0, l = hasValues.length; i < l; i++)
            hasValues[i].on('change', Ext.Function.bind(this.collectValuesFromAllHasValuesAndFire, this, [i, hasValues, vo, isBeingSet], 1));

        return vo;
    },

    /**
     * @private
     */
    collectValuesFromAllHasValuesAndFire: function(explicitValue, explicitValueIdx, allHasValues, combinedHasValue, ignore) {
        if (ignore)
            return;

        var ret = [];
        for (var i = 0, l = allHasValues.length; i < l; i++)
            ret.push(i == explicitValueIdx ? explicitValue : allHasValues[i].get());

        combinedHasValue.fire(ret);
    }
});
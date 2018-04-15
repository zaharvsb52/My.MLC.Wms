/**
* Связь между двумя HasValue, так, что когда изменяется value источника, оно просовывается в приемник.
* Сама связь создается в классе Binder на основе контрола-источника, приемник устанавливается в самой связи. 
* Здесь же опционально устанавливаются конверсии.
 */
Ext.define('WebClient.common.binding.Binding', {

    /**
     * Цепочка функций которые преобразуют исходной значениие из источника-HasValue в приемник-HasValue
     * @type {Array}
     * @private
     */
    convertors: undefined,

    /**
     * Цепочка обратных функций которые преобразуют исходной значениие из приемника-HasValue в источник-HasValue. 
     * Используется только если Binding двухсторонний.
     * @type {Array}
     * @private
     */
    backConvertors: undefined,

    /**
     * @type WebClient.common.binding.HasValue
     * @private 
     */
    source: undefined,

    /**
     * @private
     * @type {Array}
     */
    combinedWith: undefined,

    /**
     * @type WebClient.common.binding.HasValue
     * @private 
     */
    target: undefined,

    /** @private */
    shouldPropagate: undefined,

    /** @private */
    sourceSealed: false,

    /** @private */
    targetSealed: false,

    /** @private */
    isTwoWay: false,

    /** 
     * @private
     * @type {Boolean} 
     */
    isDataFlowing: undefined,

    constructor: function(source) {
        this.source = source;
    },


    /**
     * Добавляет функцию конверсии значения из источника перед засовыванием его в приемник. Вы можете устанавливать несколько 
     * функций-конверсий, тогда они будут вызваны одна за другой так, что результат предыдущей будет передаваться в следующую перед
     * отправкой в приемник
     * @param {function} fn
     * @return {WebClient.common.binding.Binding}
     */
    convert: function(fn) {
        this.convertors = this.convertors || [];
        this.convertors.push(fn);
        return this;
    },

    /**
     * Добавляет обратную функцию конверсии значения из приемника перед засовыванием его в источник. 
     * Используется только если Binding двухсторонний. Вы можете устанавливать несколько обратных
     * функций-конверсий, тогда они будут вызваны одна за другой так, что результат предыдущей будет передаваться в следующую перед
     * отправкой в источник
     * @param {function} fn
     * @return {WebClient.common.binding.Binding}
     */
    backConvert: function(fn) {
        this.backConvertors = this.backConvertors || [];
        this.backConvertors.push(fn);
        return this;
    },

    /**
     * Устанавливает опцию, при которой текущее значение из источника  будет сразу переброшено в приемник, в момент создания binding-а.
     * @return {WebClient.common.binding.Binding} 
     */
    propagateNow: function() {
        if (this.shouldPropagate !== false) //already propagated
        {
            if (this.target)
                this.evokePropagate();
            else
                this.shouldPropagate = true;
        }
        return this;
    },

    /**
     * Объединяет переданный HasValue с текущим источником-HasValue. После этого метода, исходным значением
     * объединенного источника будет массив значений из каждого элемента. Событие изменения будет возникать
     * @param {} sourceControlOrHasValue
     * @param {} sourceControlValueName
     * @return {WebClient.common.binding.Binding}
     */
    combineWith: function(sourceControlOrHasValue, sourceControlValueName) {

        Assert.isFalse(this.sourceSealed, 'После вызова метода "to" нельзя добавлять HasValue для комбинации');

        var anotherSourceValue = WebClient.common.binding.Binder.getHasValue(sourceControlOrHasValue, sourceControlValueName);

        this.combinedWith = this.combinedWith || [];
        this.combinedWith.push(anotherSourceValue);
        return this;
    },

    /**
     * Устанавливает приемник значений. Внутри возьмется HasValue из targetControl и его метод 'set' будет вызываться при изменении источника 
     * @param {Ext.Component/WebClient.common.binding.HasValue} targetControlOrHasValue
     * @param {String} targetControlValueName Optional
     * @return {WebClient.common.binding.Binding}
     */
    to: function(targetControlOrHasValue, targetControlValueName) {
        this.target = WebClient.common.binding.Binder.getHasValue(targetControlOrHasValue, targetControlValueName);
        this.sealSource();
        if (this.shouldPropagate)
            this.evokePropagate();
        return this;
    },

    /**
     * Определяет, что текущий Binding - двухсторонний, что означает, что изменения от источника-HasValue будут
     * прокидиываться в приемник-HasValue, и обратно, причем гаранитируется отсутсвие зацикленности
     * @return {WebClient.common.binding.Binding}
     */
    twoWay: function() {
        this.isTwoWay = true;
        this.sealTarget();
        return this;
    },


    /**
     * Насильно вызывает переброску значения из source в target
     */
    evokePropagate: function() {
        this.onSourceChange(this.source.get());
        this.shouldPropagate = false;
    },

    destroy: function() {
        if (this.source) {
            this.source.un('change', this.onSourceChange, this);
            this.source = null;
        }
        if (this.isTwoWay)
            this.target.un('change', this.onTargetChange, this);
        this.target = null;
    },

    /**
     * @private
     */
    onSourceChange: function(newValue) {
        if (!this.target)
            return;

        if (this.isDataFlowing)
            return;

        try {

            if (this.convertors) {
                var cs = this.convertors,
                    l = cs.length;

                for (var i = 0; i < l; i++)
                    newValue = cs[i](newValue);
            }

            this.isDataFlowing = true;

            this.target.set(newValue);
        } finally {
            this.isDataFlowing = false;
        }
    },

    /**
     * @private
     */
    onTargetChange: function(newValue) {
        if (this.isDataFlowing)
            return;

        try {
            if (this.backConvertors) {
                var cs = this.backConvertors,
                    l = cs.length;

                for (var i = 0; i < l; i++)
                    newValue = cs[i](newValue);
            }

            this.isDataFlowing = true;
            this.source.set(newValue);
        } finally {
            this.isDataFlowing = false;
        }
    },

    /**
     * @private
     */
    sealSource: function() {
        Assert.isFalse(this.sourceSealed);
        Assert.isDefined(this.source);
        if (this.combinedWith && this.combinedWith.length) {

            var hasValues = [this.source].concat(this.combinedWith);
            this.source = WebClient.common.binding.Binder.combineHasValues(hasValues);
        }
        this.source.on('change', this.onSourceChange, this);
        this.sourceSealed = true;
    },

    /**
     * @private
     */
    sealTarget: function() {
        Assert.isFalse(this.targetSealed);
        Assert.isDefined(this.target);

        if (this.isTwoWay) {
            this.target.on('change', this.onTargetChange, this);
            this.targetSealed = true;
        }
    }
});
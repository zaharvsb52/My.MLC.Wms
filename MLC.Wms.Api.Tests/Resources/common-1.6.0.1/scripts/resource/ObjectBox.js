/**
 * Этот ресурс представляет объект указанного класса и создаваемый с использованием указанной конфигурации.
 */
Ext.define('WebClient.common.resource.ObjectBox', {
    extend: 'WebClient.common.resource.Resource',

    className: undefined,

    config: undefined,

    /**
     * Служебная
     * @inner
     */
    isBox: true,

    constructor: function(className, config) {
        Assert.notEmpty(className);
        this.id = 'Class:' + className;

        this.className = className;
        this.config = config || {};
    },

    require: function(resourceLoadingSession) {
        if (!Ext.ClassManager.isCreated(this.className))
            resourceLoadingSession.addResource(this);
    },

    load: function(callback, callbackScope) {
        var me = this;
        Ext.Loader.require(me.className, function() {
            Ext.callback(callback, callbackScope, [me]);
        });
    },

    value: function() {
        if (!Ext.isDefined(this.v)) {
            if (!Ext.ClassManager.isCreated(this.className)) {
                Ext.Error.raise('Требуемый ресурс "' + Ext.getClassName(this) +
                    '" не был запрошен методом require, или значение запрашивается без ожидания загрузки (он пока еще не получен).' +
                    'id:' + this.id);
            }

            this.v = Ext.create(this.className, this.config);
        }
        return this.v;
    }
});
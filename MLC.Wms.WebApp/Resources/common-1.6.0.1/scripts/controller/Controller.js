Ext.define('WebClient.common.controller.Controller', {
    requires: [
        'WebClient.common.data.binding.Manager',
        'WebClient.common.Site',
        'WebClient.common.util.History',
        'WebClient.common.workspace.MainRoomContainer'
    ],

    mixins: {
        'observable': 'Ext.mixin.Observable',
        'refsmixin': 'WebClient.common.util.RefsMixin'
    },

    viewClassName: undefined,

    /**
     * Ресурс на инстанс view класс которого будет загружен. Его можно передать в конфигурации, иначе
     * будет создаваться для класса viewClassName.
     * @type WebClient.common.resource.ObjectBox 
     */
    viewBox: undefined,

    /**
     * Контейнер для отрисовки представления
     * @type WebClient.common.workspace.Container
     */
    container: undefined,

    /**
     * DataContext с которым работает контроллер. Передается во view через механизм data context binding-а.
     * @type WebClient.common.data.DataContext 
     */
    dataContext: undefined,

    /**
     * Инстанс view, компонента. Доступен только после вызова метода Run 
     * @protected
     * @type Ext.Component
     */
    view: undefined,

    /**
     * Копия конфига для элемента истории.
     * @private
     */
    configClone: undefined,

    /**
     * Возвращает массив команд\кнопок для отрисовки в контейнере.
     * @return {}
     */
    getContainerCommandList: function() {
        return [];
    },

    /**
     * @protected
     * @return {Boolean}
     */
    isFirstRun: function() {
        return !this.view;
    },

    constructor: function(cfg) {
        this.configClone = Ext.clone(cfg);
        Ext.merge(this, cfg);

        if (!this.container)
            Ext.Error.raise('container должен быть передан в контроллер');

        this.mixins.observable.constructor.call(this, cfg);
        this.mixins.refsmixin.constructor.call(this, function () { return this.view; });
    },

    /**
     * 
     * @return {WebClient.common.data.DataContext}
     */
    getDataContext: function() {
        if (!this.dataContext)
            Ext.Error.raise('dataContext не был создан/передан в контроллер');
        return this.dataContext;
    },

    /**
     * Запустить переданную функцию в биндинг-контексте.
     * Обычно используется для функций, которые перестраивают представление, в котором
     * есть ссылки на текущий биндинг-контекст.
     * @protected
     * @param {Function} fn
     */
    runInDataBindingContext: function(fn) {
        Assert.isTrue(Ext.isFunction(fn), 'Ext.isFunction(fn)');

        WebClient.common.data.binding.Manager.plunge(
            new WebClient.common.data.binding.Context({
                dataContext: this.dataContext,
                dataContextModel: this.dataContext ? this.dataContext.getModel() : undefined
            }),
            fn,
            this
        );
    },

    /**
     * Основной метод контроллера.
     * @protected
     */
    process: function() {
        var me = this;

        if (me.isFirstRun()) {
            if (!me.viewBox)
                me.viewBox = WebClient.lazy(me.viewClassName);
            me.adjustViewConfig();
            me.applyContainerToViewConfig();
        }

        WebClient.require(me, function() {
            me.runInDataBindingContext(me.processRevive);
        });
    },

    adjustViewConfig: function() {
    },

    applyContainerToViewConfig: function() {
        this.container.applyContainerToViewConfig(this.viewBox.config);
    },

    /**
     * Продолжение основного метода контроллера.
     */
    processRevive: function() {
        var me = this;

        if (me.isFirstRun()) {
            me.view = me.viewBox.value();
            me.onViewCreated();
            me.onInitialized();
            me.putViewIntoContainer();
            me.displayView();
            me.onViewDisplayed();
        }
        me.loadData();

        if (me.container === WebClient.common.workspace.MainRoomContainer.instance)
            WebClient.common.util.History.update(me);
    },

    onViewCreated: function() {
        var vsite = WebClient.common.Site.asSite(this.view);
        var controllerSite = WebClient.common.Site.asSite(this);
        vsite.bindToSite(controllerSite);
    },

    onInitialized: function () {
    },

    putViewIntoContainer: function() {
        this.container.putView(this.view);
    },

    displayView: function() {
        this.container.displayView(this.getContainerCommandList());
    },

    onViewDisplayed: function() {
    },

    loadData: function() {
    }
});
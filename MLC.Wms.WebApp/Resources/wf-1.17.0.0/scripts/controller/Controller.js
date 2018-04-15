Ext.define('MLC.wf.controller.Controller', {
    requires: [
        'WebClient.common.data.binding.Manager',
        'WebClient.common.Site'
    ],

    mixins: {
        'refsmixin': 'WebClient.common.util.RefsMixin'
    },
    /**
     * Ресурс на инстанс view класс которого будет загружен
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
     * Инстанс view, компонента.
     * @private
     * @type Ext.Component
     */
    view: undefined,

    /**
     * Допустимые переходы к следующим этапам.
     * @type MLC.wf.type.Action[]
     */
    actions: undefined,

    /**
     * @private
     * @type Function
     */
    actionCallBack: undefined,

    workflowIdentity: undefined,

    workflowInstanceIdentity: undefined,

    /**
     * Hotkey
     * @type Ext.util.KeyMap
     */
    keyMap: undefined,

    constructor: function(cfg) {
        Ext.merge(this, cfg);

        if (!this.container)
            Ext.Error.raise('container должен быть передан в контроллер');

        if (!this.viewBox)
            Ext.Error.raise('viewBox должен быть передан в контроллер');

        if (!this.actions)
            Ext.Error.raise('actions должен быть передан в контроллер');

        this.mixins.refsmixin.constructor.call(this, function() { return this.view; });
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

    run: function(actionCallBack) {
        var me = this;
        me.actionCallBack = actionCallBack;

        me.adjustViewConfig();
        me.applyContainerToViewConfig();

        WebClient.require(me, function() {
            me.runInDataBindingContext(me.processRun);
        });
    },


    adjustViewConfig: function() {

    },

    applyContainerToViewConfig: function() {
        this.container.applyContainerToViewConfig(this.viewBox.config);
    },

    processRun: function() {
        var me = this;

        me.view = me.viewBox.value();
        me.onViewCreated();
        me.putViewIntoContainer();
        me.displayView();
        me.onViewDisplayed();
        me.loadData();
    },

    onViewCreated: function() {
        var me = this,
            vsite = WebClient.common.Site.asSite(me.view),
            controllerSite = WebClient.common.Site.asSite(me);
        vsite.bindToSite(controllerSite);
    },

    putViewIntoContainer: function() {
        this.container.putView(this.view);
    },

    displayView: function() {
        this.container.displayView([]);
    },

    onViewDisplayed: function () {
        var me = this;

        // перове поле в фокус
        if (me.view.focusField) {
            var field = me.view.down(me.view.focusField);
            if (field)
                field.focus(true, 200);
        } else {
            var isNeedSelectText = false;
            var editableFields = Ext.ComponentQuery.query('field:not(hiddenfield)[disabled=false][readOnly=false]', me.view);
            if (!editableFields || !editableFields.length)
                editableFields = Ext.ComponentQuery.query('field:not(hiddenfield)[disabled=false]', me.view);
            else
                isNeedSelectText = true;
            if (!editableFields || !editableFields.length)
                editableFields = Ext.ComponentQuery.query('field:not(hiddenfield)', me.view);

            if (editableFields && editableFields.length)
                editableFields[0].focus(isNeedSelectText, 200);
            else {
                var buttons = Ext.ComponentQuery.query('button[disabled=false]', me.view);
                if (!buttons || !buttons.length)
                    buttons = Ext.ComponentQuery.query('button', me.view);

                if (buttons && buttons.length)
                    buttons[0].focus(false, 200);
                else {
                    var focusable = Ext.ComponentQuery.query(':focusable');
                    if (focusable && focusable.length)
                        focusable[0].focus(false, 200);
                }
            }
        }

        // привязываем горячие клавиши
        if (me.keyMap) {
            me.keyMap = Ext.Array.map(me.keyMap, function (km) {
                var target = km.target ? me.view.down(km.target) : me.view.getEl(),
                    action = Ext.Array.findBy(me.actions, function (a) { return a.code === km.actionCode; });

                if (!target)
                    Ext.Error.raise('Target с кодом ' + km.target + ' не найден');

                if (!action)
                    Ext.Error.raise('Action с кодом ' + km.actionCode + ' не найден');

                // HACK, см. enableKeyEvents в Ext.form.field.Text
                if (target.inputEl)
                    target = target.inputEl;

                var map = new Ext.util.KeyMap({
                    eventName: 'keydown',
                    target: target,
                    key: km.key,
                    shift: km.shift,
                    ctrl: km.ctrl,
                    alt: km.alt,
                    defaultEventAction: 'stopEvent',
                    fn: Ext.bind(me.handleAction, me, [action])
                });
                return map;
            });
        }
    },

    maskView: function() {
        if (this.view)
            this.view.mask('Загрузка...');
    },

    unmaskView: function() {
        if (this.view)
            this.view.unmask();
    },

    loadData: function() {
    },

    getRequestParams: function(action) {
        return { cancelAction: false, requestData: null };
    },

    handleAction: function(action) {
        if (action.disabled)
            return;
        var me = this,
            p = me.getRequestParams(action);
        if (!p.cancelAction)
            me.actionCallBack(action, p.requestData);
    },

    getToolBars: function() {

        var topBarActions = [],
            bottomActions = [],
            toolBars = [],
            me = this,
            actions = me.actions;

        if (!actions)
            return null;

        Ext.Array.forEach(actions, function(a) {
            a.position === "top" ? topBarActions.push(a) : bottomActions.push(a);
        });

        if (topBarActions.length > 0)
            toolBars.push({
                xtype: 'toolbar',
                dock: 'top',
                layout: {
                    type: 'hbox',
                    align: 'middle'
                },
                ui: 'footer',
                items: Ext.Array.map(topBarActions, function(a) {
                    var ac = MLC.wf.type.Action.create(a);
                    if (!ac.handler)
                        ac.setHandler(Ext.bind(me.handleAction, me, [a]));

                    return new Ext.button.Button(ac);
                })
            });

        if (bottomActions.length > 0)
            toolBars.push({
                xtype: 'toolbar',
                dock: 'bottom',
                layout: {
                    type: 'hbox',
                    align: 'middle',
                    pack: 'end'
                },
                ui: 'footer',
                items: Ext.Array.map(bottomActions, function(a) {
                    var ac = MLC.wf.type.Action.create(a);
                    if (!ac.handler)
                        ac.setHandler(Ext.bind(me.handleAction, me, [a]));

                    return new Ext.button.Button(ac);
                })
            });

        return toolBars;
    },

    destroy: function () {
        Ext.destroy(this.keyMap);
    }
});
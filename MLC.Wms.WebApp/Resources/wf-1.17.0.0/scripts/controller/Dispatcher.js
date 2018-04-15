Ext.define('MLC.wf.controller.Dispatcher', {

    mixins: ['Ext.mixin.Observable'],

    requires: [
        'Ext.window.MessageBox',
        'WebClient.common.workspace.TabContainer',
        'WebClient.common.workspace.WindowContainer',
        'MLC.wf.WfViewKind'
    ],

    statics: {
        DEFAULT_WORKFLOW_DATASERVICE_NAME: 'DataServices.WorkflowDataService',

        DEFAULT_EXECUTE_WORKFLOW_METHOD_NAME: 'executeWorkflow',
        DEFAULT_BEGIN_EXECUTE_WORKFLOW_METHOD_NAME: 'beginExecuteWorkflow',
        DEFAULT_END_EXECUTE_WORKFLOW_METHOD_NAME: 'endExecuteWorkflow',
        DEFAULT_ISCOMPLETED_METHOD_NAME: 'isCompleted',
        DEFAULT_CHECK_COMPLETION_INTERVAL: 5000
    },

    inArguments: undefined,

    /**
     * Имя класса сервиса с которым будет вестись обмен
     * @type String
     */
    workflowDataServiceName: undefined,

    /**
     * Имя метода для запуска workflow
     * @type String
     */
    executeWorkflowMethodName: undefined,

    /**
     * Имя метода начала async workflow
     * @type String
     */
    beginExecuteWorkflowMethodName: undefined,

    /**
     * Имя метода завершения async workflow
     * @type String
     */
    endExecuteWorkflowMethodName: undefined,

    /**
     * Имя метода проверки готовности async workflow
     * @type String
     */
    isCompletedMethodName: undefined,

    /**
     * Интервал проверки готовности async workflow
     * @type Integer
     */
    completionCheckInterval: undefined,

    /**
     * Результат асинхронной работы
     * @type {WfAsyncResult}
     */
    asyncResult: undefined,

    /**
     * Контейнер для отрисовки представлений
     * @type WebClient.common.workspace.Container
     */
    container: undefined,

    /**
     * Идентификатор воркфлоу
     * @type MLC.wf.type.WorkflowIdentity
     */
    workflowIdentity: undefined,

    /**
     * Идентификатор инстанса воркфлоу. Появляется во время запуска.
     * @type MLC.wf.type.WorkflowInstanceIdentity
     */
    workflowInstanceIdentity: undefined,

    /**
     * TimeOut запуска Workflow
     * @type Integer
     */
    timeOutInMs: undefined,

    /**
     * Ext.direct Action - набор серверных методов доступа к данным и метаданным
     * @private
     * @type {Object} 
     */
    serverMethods: undefined,

    /**
     * Признак исполнения workflow
     * @private
     * @type {Boolean} 
     */
    isRunning: false,

    /**
     * Последний запущенный Action
     * @private
     * @type MLC.wf.type.Action
     */
    lastAction: undefined,

    currentController: undefined,

    /**
     * Диалог отображения ошибок уровня Dispatcher
     * @private
     * @type Ext.window.MessageBox
     */
    messageBox: undefined,

    constructor: function (cfg) {
        Ext.apply(this, cfg, {
            workflowDataServiceName: this.self.DEFAULT_WORKFLOW_DATASERVICE_NAME,
            executeWorkflowMethodName: this.self.DEFAULT_EXECUTE_WORKFLOW_METHOD_NAME,
            beginExecuteWorkflowMethodName: this.self.DEFAULT_BEGIN_EXECUTE_WORKFLOW_METHOD_NAME,
            endExecuteWorkflowMethodName: this.self.DEFAULT_END_EXECUTE_WORKFLOW_METHOD_NAME,
            isCompletedMethodName: this.self.DEFAULT_ISCOMPLETED_METHOD_NAME,
            completionCheckInterval: this.self.DEFAULT_CHECK_COMPLETION_INTERVAL,
            container: WebClient.common.workspace.MainRoomContainer.instance
        });

        if (!this.workflowIdentity)
            Ext.Error.raise('workflowIdentity должен быть передан');

        this.serverMethods = WebClient.getByPath(Server, this.workflowDataServiceName);
        if (!this.serverMethods)
            Ext.Error.raise('Было передано имя несуществующего серверного класса, либо имя по-умолчанию указывает на несуществующий класс. workflowDataServiceName:' + this.workflowDataServiceName);

        if (!this.serverMethods[this.executeWorkflowMethodName])
            Ext.Error.raise('Было передано имя несуществующего метода серверного класса, либо имя по-умолчанию указывает на несуществующий метод. workflowDataServiceName: ' + this.workflowDataServiceName + '. executeWorkflowMethodName: ' + this.executeWorkflowMethodName);

        this.mixins.observable.constructor.call(this, cfg);

        this.messageBox = new Ext.window.MessageBox({
            alwaysOnTop: true
        });
    },

    run: function () {
        var me = this,
            request = { workflowIdentity: me.workflowIdentity, inArguments: me.inArguments, timeOutInMs: me.timeOutInMs };
        if (me.beginRequest()) {
            me.serverMethods[me.executeWorkflowMethodName](request, Ext.bind(me.onWfResponse, me));
            me.fireEvent('beginwait');
        }
    },

    runAsync: function () {
        var me = this,
            request = { workflowIdentity: me.workflowIdentity, inArguments: me.inArguments, timeOutInMs: me.timeOutInMs };
        if (me.beginRequest()) {
            me.serverMethods[me.beginExecuteWorkflowMethodName](request, Ext.bind(me.beginWorkflowResponse, me));
            me.fireEvent('beginwait');
        }
    },

    beginWorkflowResponse: function (asyncResult, event) {
        if (!WebClient.common.ExtDirectHelper.responseOk(event, this)) //uses onError
            return;

        var me = this;
        me.asyncResult = asyncResult;

        window.setTimeout(Ext.bind(me.checkCompletion, me), me.completionCheckInterval);
    },

    checkCompletion: function () {
        var me = this;
        me.serverMethods[me.isCompletedMethodName]({ asyncResult: me.asyncResult }, Ext.bind(me.checkCompletionResponse, me));
    },

    checkCompletionResponse: function (response, event) {
        if (!WebClient.common.ExtDirectHelper.responseOk(event, this)) //uses onError
            return;

        var me = this;
        if (response === true) {
            me.serverMethods[me.endExecuteWorkflowMethodName]({ asyncResult: me.asyncResult }, Ext.bind(me.onWfResponse, me));
        } else {
            window.setTimeout(Ext.bind(me.checkCompletion, me), me.completionCheckInterval);
        }
    },

    onWfResponse: function (response, event) {
        var me = this;
        me.endRequest();

        me.fireEvent('wfResponse', { response: response });
        if (me.currentController)
            me.currentController.unmaskView();

        if (!WebClient.common.ExtDirectHelper.responseOk(event, me)) //uses onError
            return;

        if (response.reload)
            me.fireEvent('reload', me, response);

        var wfInstanceIdentity = response.workflowInstanceIdentity;
        if (wfInstanceIdentity.state === 'Closed') {
            me.fireEvent('endwait');
            if (me.container instanceof WebClient.common.workspace.TabContainer) {
                me.container.tab.tab.tabBar.closeTab(me.container.tab.tab);
            } else if (this.container instanceof WebClient.common.workspace.WindowContainer) {
                if (me.container.window)
                    me.container.window.close();
            }
            return;
        }

        var viewKind = response.viewKind,
            controllerCfg = Ext.merge({
                serverMethods: me.serverMethods,
                workflowIdentity: me.workflowIdentity,
                workflowInstanceIdentity: wfInstanceIdentity
            }, response.controllerConfig),
            controllerClassName = me.getControllerClassName(response.controllerClassName, viewKind),
            viewCfg = Ext.merge({}, response.viewConfig),
            viewClassName = me.getViewClassName(response.viewClassName, viewKind);

        me.workflowInstanceIdentity = wfInstanceIdentity;

        Ext.apply(controllerCfg, {
            container: me.container,
            viewBox: WebClient.lazy(viewClassName, viewCfg),
            actions: response.actions,
            keyMap: response.keyMap
        });

        var controllerBox = WebClient.lazy(controllerClassName, controllerCfg);

        WebClient.require(controllerBox, Ext.bind(me.onControllerLoaded, me, [controllerBox]));

        // возвращаем фокус на окно с ошибкой, если оно отображается
        if (me.messageBox.isVisible())
            me.messageBox.focus();
    },

    getControllerClassName: function (responseClassName, viewKind) {
        if (!!responseClassName)
            return responseClassName;

        if (viewKind === MLC.wf.WfViewKind.CARD)
            return 'MLC.wf.controller.Card';
        else if (viewKind === MLC.wf.WfViewKind.LIST)
            return 'MLC.wf.controller.List';
        else if (viewKind === MLC.wf.WfViewKind.MENU)
            return 'MLC.wf.controller.Menu';
        else if (viewKind === MLC.wf.WfViewKind.DIALOG)
            return 'MLC.wf.controller.Dialog';
        else if (viewKind === MLC.wf.WfViewKind.PRINT)
            return 'MLC.wf.controller.Print';

        Ext.Error.raise('Unsupported viewKind: ' + viewKind);
    },

    getViewClassName: function (responseClassName, viewKind) {
        if (!!responseClassName)
            return responseClassName;

        if (viewKind === MLC.wf.WfViewKind.CARD)
            return 'MLC.wf.controls.Card';
        else if (viewKind === MLC.wf.WfViewKind.LIST)
            return 'MLC.wf.controls.List';
        else if (viewKind === MLC.wf.WfViewKind.MENU)
            return 'MLC.wf.controls.Menu';
        else if (viewKind === MLC.wf.WfViewKind.DIALOG)
            return 'MLC.wf.controls.Dialog';
        else if (viewKind === MLC.wf.WfViewKind.PRINT)
            return 'MLC.wf.controls.Print';

        Ext.Error.raise('Unsupported viewKind: ' + viewKind);
    },

    onControllerLoaded: function (controllerBox) {
        var me = this,
            controller = controllerBox.value();

        if (me.currentController)
            Ext.destroy(me.currentController);

        me.currentController = controller;
        controller.run(Ext.pass(me.onAction, [controller], me));
    },

    onAction: function (controller, action, requestParams) {
        var me = this,
            request = {
                workflowIdentity: me.workflowIdentity,
                workflowInstanceIdentity: me.workflowInstanceIdentity,
                actionCode: action.code,
                timeOutInMs: action.timeOutInMs,
                parameters: requestParams
            };
        if (me.beginRequest(action)) {
            me.lastAction = action;

            if (action.isLongRunning === true) {
                me.serverMethods[me.beginExecuteWorkflowMethodName](request, Ext.bind(me.beginWorkflowResponse, me));
            } else {
                me.serverMethods[me.executeWorkflowMethodName](request, Ext.bind(me.onWfResponse, me));
            }
        }
    },

    /**
     * Обработка запуска workflow. Ограничивает повторный запуск.
     * @private
     */
    beginRequest: function (newAction) {
        var me = this;

        if (me.isRunning) {
            var actionsMsg;
            if (me.lastAction && newAction && me.lastAction.code === newAction.code)
                actionsMsg = me.lastAction.code;
            else {
                actionsMsg = +(me.lastAction === undefined ? 'NULL' : me.lastAction.code) + ',' + (newAction === undefined ? 'NULL' : newAction.code);
            }
            me.messageBox.show({
                title: 'Ошибка',
                msg: 'Процесс исполняется. Пожалуйста, дождитесь завершения текущего действия и повторите попытку.\nДействия: ' + actionsMsg,
                buttons: Ext.Msg.OK,
                modal: true,
                icon: Ext.MessageBox.WARNING
            });
            return false;
        }

        me.isRunning = true;
        me.fireEvent('beginrequest', me);

        if (me.currentController)
            me.currentController.maskView();

        return true;
    },

    endRequest: function () {
        var me = this;
        me.isRunning = false;
        me.fireEvent('endrequest', me);
    }
});
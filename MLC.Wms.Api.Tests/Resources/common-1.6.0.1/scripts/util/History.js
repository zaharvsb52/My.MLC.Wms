// TODO: Вынести работу с историей в Controller в mixin
Ext.define('WebClient.common.util.History', {
    singleton: true,

    /**
     * Массив с информацией, необходимой для навигации по истории.
     * @private
     */
    historyList: [],

    /**
     * Индекс последнего отображенного элемента истории.
     * @private
     */
    historyIndex: -1,

    /**
     * Инициализирует работу с историей.
     */
    init: function() {
        Ext.require('Ext.util.History', function() {
            Ext.util.History.init(function() {
                Ext.util.History.on('change', WebClient.common.util.History.navigate);
            });
        });
    },

    /**
     * Обновляет список истории по отображаемому презентеру.
     */
    update: function(controller) {
        var History = WebClient.common.util.History;
        if (History.historyIndex === 'navigate') {
            History.historyIndex = Ext.util.History.getToken();
            return;
        }

        while (History.historyList.length > History.historyIndex + 1)
            History.historyList.pop();

        History.historyList.push({
            controllerClassName: controller.$className,
            config: controller.configClone,
            dataParams: controller.dataParamsClone
        });
        History.historyIndex = History.historyList.length - 1;
        Ext.util.History.add(History.historyIndex);
    },

    /** Обрабатывает переход по истории.
     * @private
     */
    navigate: function(historyToken) {
        var History = WebClient.common.util.History;
        historyToken = Ext.value(historyToken, -1, false);

        if (historyToken == History.historyIndex)
            return;
        if (historyToken < 0 || historyToken >= History.historyList.length)
            return;

        var historyData = History.historyList[historyToken];
        History.historyIndex = 'navigate';
        var controller = Ext.create(historyData.controllerClassName, historyData.config);
        controller.run(historyData.dataParams);
    }
});
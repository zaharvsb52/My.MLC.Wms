/**
 * ВАЖНО! В основном типе должен быть метод process.
 */
Ext.define('WebClient.common.controller.StandAloneControllerMixin', {
    /**
     * @protected
     * Параметры к вызову сервера при чтении данных, например, { id: 123 }. Передан в методе {@link #run}.
     * @type Object
     */
    dataParams: undefined,

    /**
     * Копия параметров запуска для элемента истории.
     * @private
     */
    dataParamsClone: undefined,

    /**
     * @param {Object} dataParams Например, { id: 123 }
     */
    run: function(dataParams) {
        this.dataParamsClone = Ext.clone(dataParams);
        this.dataParams = dataParams;
        this.process();
    }
});
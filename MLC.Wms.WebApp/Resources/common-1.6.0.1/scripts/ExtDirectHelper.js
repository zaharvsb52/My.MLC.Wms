Ext.define('WebClient.common.ExtDirectHelper', {
    requires: [
        'WebClient.common.error.DefaultHandlerProvider'
    ],

    singleton: true,

    /**
     * Helper функция, возвращает true если ответ от Ext direct запроса не содержит ошибок. 
     * Иначе, если у context есть метод onError - вызывает его, если нет - стандартный {@link WebClient.common.error.DefaultHandlerProvider}
     * @param {Ext.direct.Event} directEvent
     * @param {Object} context Опционально
     * @param {Array} args дополнительные параметры, передаваемые в context.onError (если чуществует)  

     * @return {Boolean}
     */
    responseOk: function(directEvent, context, args) {
        if (!directEvent.status) {
            if (context && context.onError) {
                args = Ext.Array.from(args);
                args.unshift(directEvent);
                context.onError.apply(window, args);
            } else {
                var handler = WebClient.common.error.DefaultHandlerProvider.getErrorHandler();
                handler.onError(directEvent);
            }
            return false;
        }
        return true;
    }
});
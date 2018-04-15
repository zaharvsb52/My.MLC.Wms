Ext.define('WebClient.common.error.DefaultHandler', {
    requires: ['WebClient.common.error.MessageBox'],

    /**
     * @param {Ext.direct.Event/Ext.direct.ExceptionEvent} event
     */
    onError: function(event) {
        var error = event.error;
        if (!error) {
            var httpStatus = event.xhr.status;
            var msg = httpStatus == 0
                ? 'Сервер не доступен'
                : 'Произошла ошибка при передаче данных на сервер';

            error = {
                title: 'Системная ошибка',
                items: [
                    {
                        severity: WebClient.ErrorSeverity.ERROR,
                        userMessage: msg,
                        technicalMessage: 'Ошибка протокола HTTP. Код: ' + httpStatus + '. Ответ с сервера: \r\n' + event.xhr.responseText
                    }
                ]
            };
        }

        WebClient.common.error.MessageBox.show(error);
    }
});
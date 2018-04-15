/**
 * Базовый класс для всех интерфейсных классов 
 */
Ext.define('WebClient.common.Interface',
    {
        /**
     * @private
     */
        onClassExtended: function(cls, data) {
            for (var i in data) {
                if (data.hasOwnProperty(i) && i !== 'onBeforeClassCreated' && i !== 'onClassCreated' && i !== 'constructor') {
                    if (Ext.isFunction(data[i])) {
                        var clsName = Ext.getClassName(data),
                            mname = i;

                        data[i] = function() { Ext.Error.raise('Method "' + mname + '" declared in interface "' + clsName + '" was not overriden. Current scope: ' + Ext.getClassName(this)); };
                    }
                }
            }
        }
    });
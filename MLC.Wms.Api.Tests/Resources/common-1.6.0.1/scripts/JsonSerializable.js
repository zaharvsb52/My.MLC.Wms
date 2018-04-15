/**
 * Этот класс есть mixin который вы используете, чтобы задекларировать, что ваш класс содержит кастомную логику сериализации в json
 */
Ext.define('WebClient.common.JsonSerializable', {

    /**
    * Переопределяйте этот метод в вашем классе, чтобы управлять, какие данные вашего объекта будут сериализованы в JSON.
    * @return {Object} Объект, данные которого будут отданы в JSON сериализацию 
    */
    toJSON: function() { Ext.Error.raise('Method "toJSON" was not overriden. Current scope: ' + Ext.getClassName(this)); }
});
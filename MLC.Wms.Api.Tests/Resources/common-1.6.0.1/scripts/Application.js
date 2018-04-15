Ext.define('WebClient.common.Application', {
    extend: 'Ext.app.Application',

    enableQuickTips: false // иначе не работают типы на валидации (бага в отсутствии клонирования tagConfig типов при запуске Ext.app.Application. Правильный пример - см. Labelable.initTip (tip.tagConfig = Ext.apply(...); 

});
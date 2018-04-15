Ext.define('WebClient.common.controls.CrudEntityGrid', {
    extend: 'WebClient.common.controls.EntityGrid',
    alias: ['widget.WebClient.common.controls.CrudEntityGrid'],

    requires: [
        'WebClient.common.commands.CreateEntity',
        'WebClient.common.commands.list.EditEntity',
        'WebClient.common.commands.list.DestroyEntity'
    ],

    inheritableStatics: {
        /**
         * Метод возвращает стандартный список кнопок для редактирования (просмотра), создания и удаления сущностей
         * @param {Object} config конфигурация переданная в конструктор инстанса грида. Анализируется readOnly
         * @return {}
         */
        getTbarItems: function(config) {
            if (config && config.readOnly) {
                return [
                    Ext.create('WebClient.common.commands.list.ViewEntity', { itemId: 'viewentity' })
                ];
            } else {
                return [
                    Ext.create('WebClient.common.commands.list.EditEntity', { itemId: 'editentity' }),
                    Ext.create('WebClient.common.commands.list.DestroyEntity', { itemId: 'destroyentity' }),
                    Ext.create('WebClient.common.commands.CreateEntity', { itemId: 'createentity' })
                ];
            }
        }
    },

    /**
    * @cfg {Boolean} readOnly
    * Признак, управляющий списком кнопок на панели
    */
    editOnDblClick: false,

    constructor: function(config) {
        var me = this,
            menuCommandList = me.self.getTbarItems(config);

        config = Ext.merge({
            selModel: {
                type: 'checkboxmodel',
                mode: 'MULTI',
                checkboxSelect: true
            },
            tbar: {
                items: menuCommandList
            }
        }, config);
        this.callParent([config]);

        if (me.editOnDblClick) {
            Ext.Array.findBy(config.tbar.items, function (menuCommand, commandIndex) {
                if (menuCommand.itemId === 'editentity')
                    me.on('itemdblclick', menuCommand.execute, menuCommand);
            });
        }
    }
});
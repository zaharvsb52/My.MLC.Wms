Ext.define('WebClient.common.commands.list.DestroyEntity', {
    extend: 'WebClient.common.commands.Command',

    mixins: {
        entitylistviewaware: 'WebClient.common.commands.list.EntityListViewAwareMixin'
    },

    uses: [
        'WebClient.common.controller.IList'
    ],

    text: 'Удалить',

    glyph: 'xf4c5@ionicons',

    minWidth: 75,

    /**
     * @protected
     */
    handler: function () {
        var me = this;

        if (!me.controller)
            me.controller = me.getSite().getService('WebClient.common.controller.IList');

        if (!me.items.length)
            Ext.Error.raise({ msg: 'Cannot get command\'s any components', owner: me });

        var grid = me.items[0].up('gridpanel');
        if (!grid)
            Ext.Error.raise('Команда Destroy поддерживается только внутри грида');

        var records = WebClient.common.binding.Binder.getHasValue(grid, 'selected').get();

        if (records.length > 0) {
            Ext.MessageBox.show({
                title: 'Подтверждение',
                msg: 'Удалить выбранные записи?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNO,
                fn: function (buttonId) {
                    if (buttonId === 'yes')
                        me.controller.destroy(records);
                }
            });
        }
    }

});
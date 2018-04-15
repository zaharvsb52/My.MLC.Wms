Ext.define('MLC.wms.controller.FocusCard', {
    extend: 'MLC.wf.controller.Card',

    /**
     * @override
     */
    onViewDisplayed: function() {
        var me = this;
        me.callParent();
        
        var focusEl = me.view.items.getByKey(me.viewBox.config['focusFieldDefault']);
        if (focusEl)
            focusEl.focus(true, true);
        
        var enterEl = me.view.items.getByKey(me.viewBox.config['enterFieldDefault']);
        if (enterEl) {
            enterEl.enableKeyEvents = true;
            enterEl.getEl().on('keypress', function (event, field, options) {
                if (event.getKey() === event.ENTER) {
                    me.handleAction({ code: 'OK' });
                }
            });
        };
    }
});
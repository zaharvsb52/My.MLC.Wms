Ext.override(Ext.fx.Anim, {
    duration: 0
});

Ext.define('Ext.theme.crisp.view.Table', {
    override: 'Ext.view.Table',
    stripeRows: true,
    trackOver: false
});

Ext.define('Ext.theme.crisp.panel.Table', {
    override: 'Ext.panel.Table',
    trackMouseOver: false
});

Ext.define('Ext.theme.crisp.view.AbstractView', {
    override: 'Ext.view.AbstractView',
    overItemCls: undefined
});

Ext.onReady(function() {
    Ext.getDoc().on('keypress', function(event, target) {
        var targetEl = Ext.get(target.id),
            fieldEl = targetEl.up('[class*=x-field]') || {},
            field = Ext.getCmp(fieldEl.id);

        if (field instanceof Ext.form.field.TextArea)
            return;

        if (event.ENTER == event.getKey() && field && field.isValid()) {
            do {
                var next = event.shiftKey ? field.prev('[isFormField]:focusable') : field.next('[isFormField]:focusable');
                if (next) {
                    event.stopEvent();
                    next.focus();
                    return;
                }
                field = field.up();
            } while(field)
        }
    });
});

Ext.require('WebClient.common.type.EntityRef', function() {
    Ext.override(WebClient.common.type.EntityRef, {
        toJSON: function() {
            if (!this.id || !this.type)
                return Ext.JSON.encode(null);
            return Ext.JSON.encode({ id: this.id, type: this.type, values: this.values });
        }
    });
});

Ext.require('WebClient.common.data.field.EntityRef', function() {
    Ext.override(WebClient.common.data.field.EntityRef, {
        serialize: function(value) {
            if (!value)
                return null;

            return { id: value.id, type: value.type, values: value.values };
        }
    });
});
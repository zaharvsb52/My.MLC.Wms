Ext.define('MLC.wf.attributes.FileFieldAttributes', {
    override: 'Ext.form.field.File',

    onRender: function () {
        var me = this,
            attr = me.fileInputAttributes,
            fileInputEl, name;

        me.callParent();
        fileInputEl = me.getTrigger('filebutton').component.fileInputEl.dom;
        for (name in attr) {
            fileInputEl.setAttribute(name, attr[name]);
        }
    }
});
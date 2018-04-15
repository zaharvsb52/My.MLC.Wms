// http://stackoverflow.com/questions/17527870/how-does-trello-access-the-users-clipboard
Ext.define('WebClient.common.util.ClipboardHelper', {
    singleton: true,

    /**
     * @type(String)
     **/
    clipboard: undefined,

    /**
     * @type(Ext.dom.Element)
     **/
    lastFocusedElement: undefined,

    set: function (value) {
        this.clipboard = value;
    },

    getClipboardContainer: function () {
        return Ext.get('clipboard-container');
    },

    clearClipboardContainer: function (container) {
        var clipboardControl = container.first();
        if (clipboardControl)
            clipboardControl.remove();
    }
}, function () {
    var me = this;

    //<div id="clipboard-container"><textarea id="clipboard"></textarea></div>
    Ext.getBody().appendChild({ tag: 'div', id: 'clipboard-container', children: [{ tag: 'textarea', id: 'clipboard' }] });
    var doc = Ext.getDoc();

    doc.on('keydown', function (e, t, eOpts) {
        // early exits
        if (!(e.ctrlKey || e.metaKey)) {
            return;
        }

        if (e.target.nodeName.toLowerCase() === 'textarea' ||
            e.target.nodeName.toLowerCase() === 'input') {
            return;
        }

        // Abort if it looks like they've selected some text (maybe they're trying
        // to copy out a bit of the description or something)
        if (window.getSelection
          && window.getSelection()
          && window.getSelection().toString()) {
            return;
        }

        if (document.selection && document.selection.createRange().text) {
            return;
        }

        var helper = WebClient.common.util.ClipboardHelper;
        if (!helper.clipboard)
            return;

        var container = helper.getClipboardContainer();
        helper.clearClipboardContainer(container);
        container.show();

        var cc = container.appendChild({ tag: 'textarea', id: 'clipboard' });
        cc.dom.value = helper.clipboard;
        cc.dom.focus();
        cc.dom.select();

        helper.lastFocusedElement = e.target;
    }, me);

    doc.on('keyup', function (e, t, eOpts) {
        if (e.target.id === 'clipboard') {
            var helper = WebClient.common.util.ClipboardHelper;
            var container = helper.getClipboardContainer();
            helper.clearClipboardContainer(container);
            if (helper.lastFocusedElement)
                helper.lastFocusedElement.focus();
            return container.hide();
        }
    }, me);
});
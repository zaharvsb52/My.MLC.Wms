Ext.define('MLC.wf.type.UrlAction', {
    extend: 'MLC.wf.type.Action',

    alias: 'action.urlaction',

    /**
     * @type String
     */
    url: undefined,

    handler: function () {
        if (!this.url)
            Ext.Error.raise('url должен быть передан в UrlAction');
        window.open(url);
    }
});
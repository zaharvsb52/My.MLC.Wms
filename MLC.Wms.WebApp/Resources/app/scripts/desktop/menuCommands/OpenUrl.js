Ext.define('MLC.wms.desktop.menuCommands.OpenUrl', {
    extend: "MLC.wms.desktop.menuCommands.BaseCommand",

    mixins: {
        observable: 'Ext.util.Observable'
    },

    config: {
        rootpath: undefined
    },

    constructor: function (config) {
        Ext.apply(this, config);
        this.mixins.observable.constructor.call(this, config);

        this.callParent([config]);
    },

    getWindowId: function (params) {
        return 'openUrl_' + params.url;
    },

    handler: function (params, container) {
        var me = this,
            root = '~/',
            url = params.url.substring(0, root.length) == root ? me.rootpath + params.url.substring(root.length) : params.url,
            viewCfg = {
                xtype: 'panel',
                title: params.title || 'Новое окно',
                tools: [
                    {
                        type: 'refresh',
                        tooltip: 'Обновить',
                        tooltipType: 'title',
                        callback: function (panel, tool, ev) {
                            panel.getEl().down('iframe').dom.contentWindow.location.reload(true);
                            me.fireEvent('refresh', url);
                        }
                    }, {
                        type: 'maximize',
                        tooltip: 'Открыть в новом окне',
                        tooltipType: 'title',
                        callback: function (panel, tool, ev) {
                            var wnd = window.open(url, '_blank');
                            if (!wnd)
                                WebClient.showError('Невозможно открыть в новом окне', 'Выключите блокировщик всплывающих окон. Открываемая ссылка: ' + url);
                            else
                                me.fireEvent('open', url);
                        }
                    }
                ],
                html: '<iframe src="' + url + '" width="100%" height="100%" frameborder="0"></iframe>'
            };
        container.applyContainerToViewConfig(viewCfg);
        container.putView(new Ext.panel.Panel(viewCfg));
        container.displayView();
        me.fireEvent('refresh', url);
    }
});
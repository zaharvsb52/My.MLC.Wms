Ext.define('WebClient.common.controls.WindowHelper', {

    singleton: true,

    /**
     * Если у внутренней панели объекта Window выставлен width, этот метод настраивает ширину Window так, 
     * чтобы его внутренняя панель имела желаемую ширину.
     * @param {Object} windowCfg
     */
    adjustWindowSizeByContentSize: function (windowCfg) {
        var items = windowCfg.items;
        if (!Ext.isArray(items)) {
            items = [items];
        }

        if (items.length > 0) {
            var view = items[0];

            if (view.width) {
                windowCfg.width = view.width +
                    (windowCfg.bodyPadding || 0) * 2 +
                    (windowCfg.border || 0) * 2;
            }
        }
        return windowCfg;
    }
});
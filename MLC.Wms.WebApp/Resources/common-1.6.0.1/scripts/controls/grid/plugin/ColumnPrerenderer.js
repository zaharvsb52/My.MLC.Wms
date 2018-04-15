/**
 * Этот plugin удобно использовать если вы хотите управлять стилями\цветом ячейки, не влезая в логику 
 * стандартных renderer-ов, преобразующих значения из store в html.
 * <p> 
 * Этот plugin подключаемый для колонки, позволяет указать в колонке свойство '<b>prerenderer</b>' такой же как 
 * {@link Ext.grid.column.Column#renderer}. Во время вывода значения ячейки перед вызовом renderer вызовется
 * prerenderer. Если prerenderer вернет значение оно передастся в renderer.<p>
 * 
 */
Ext.define('WebClient.common.controls.grid.plugin.ColumnPrerenderer', {
    alias: 'plugin.WebClient.common.controls.grid.plugin.ColumnPrerenderer',

    init: function(column) {
        column.on('render', this.onColumnRender, this, { single: true });
    },

    onColumnRender: function(column) {
        if (column.prerenderer) {
            Assert.isTrue(Ext.isFunction(column.prerenderer), 'Ext.isFunction(column.prerenderer)');

            if (column.renderer) {
                var renderer = column.renderer,
                    prerenderer = column.prerenderer;

                //Если есть column.renderer то объединяем в вызов сначала prerenderer потом renderer
                column.renderer = function() {
                    var ret = prerenderer.apply(Ext.global, arguments);

                    var args;
                    if (ret !== undefined) {
                        args = Ext.Array.slice(arguments, 0); //copy arguments
                        args[0] = ret;
                    } else
                        args = arguments;

                    return renderer.apply(Ext.global, args);
                };
            } else
                column.renderer = column.prerenderer;
        }
    }

});
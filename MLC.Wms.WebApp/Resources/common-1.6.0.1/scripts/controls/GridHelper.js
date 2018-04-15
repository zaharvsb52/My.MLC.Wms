/**
 * Хелпер-функции для работы с гридом
 */
Ext.define('WebClient.common.controls.GridHelper', {
    singleton: true,

    /**
     * Пемеремотать скролл к строке в гриде, если она есть
     * @param {Ext.grid.Panel} grid
     * @param {String} recordId
     */
    scrollToRecord: function(grid, recordId) {
        var store = grid.getStore(),
            view = grid.getView(),
            record = store.getById(recordId);
        if (record)
            view.focusRow(record);
    }
});
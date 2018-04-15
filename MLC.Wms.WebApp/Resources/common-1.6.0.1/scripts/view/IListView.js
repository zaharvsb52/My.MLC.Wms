Ext.define('WebClient.common.view.IListView', {
    extend: 'WebClient.common.Interface',

    getFilterable: function() {},

    /**
     * Тоже что и 'selectedId' HasValue у грида.
     * @return {WebClient.common.binding.HasValue}
     */
    getSelectedId: function() {},

    /**
     * Тоже что и 'selected' HasValue у грида. 
     * @return {WebClient.common.binding.HasValue}
     */
    getSelected: function() {}
});
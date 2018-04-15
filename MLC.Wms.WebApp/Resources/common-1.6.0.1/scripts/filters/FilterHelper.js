Ext.define('WebClient.common.filters.FilterHelper', {
    singleton: true,

    filterBindingConvertorForEntityRefCollectionEditorThatDoesNotFilterIfNothingIsSelected: function(v) {
        return v && v.items && v.items.length > 0 ? v.items : null;
    }

});
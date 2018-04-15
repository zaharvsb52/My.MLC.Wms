Ext.ns('Assert');

Ext.apply(Assert, {
    notEmpty: function(expression, expressionAsText) {
        if (!expression)
            Ext.Error.raise('"' + (expressionAsText || 'Value ') + '" must not be empty');
    },

    isFalse: function(expression, expressionAsText) {
        if (expression !== false)
            Ext.Error.raise('"' + (expressionAsText || 'Value ') + '" must be false');
    },

    isTrue: function(expression, expressionAsText) {
        if (expression !== true)
            Ext.Error.raise('"' + (expressionAsText || 'Value ') + '" must be true');
    },

    isDefined: function(expression, expressionAsText) {
        if (expression === undefined)
            Ext.Error.raise('"' + (expressionAsText || 'Value ') + '" must be defined');
    }
});
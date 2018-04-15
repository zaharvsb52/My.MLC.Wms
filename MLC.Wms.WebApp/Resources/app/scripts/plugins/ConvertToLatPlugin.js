Ext.define('MLC.wms.plugins.ConvertToLatPlugin', {
    extend: 'Ext.plugin.Abstract',

    alias: 'plugin.converttolat',

    init: function(field) {
        if (!field || !field.isFormField)
            return;

        this.field = field;
        if (field.rendered) {
            this.assignEl();
        } else {
            field.on('render', this.assignEl, this);
        }
    },

    assignEl: function() {
        this.field.inputEl.on('keypress', this.processKeyPress, this);
        this.field.inputEl.on('paste', this.processPaste, this);
    },

    processKeyPress: function(e) {
        var char;

        if (e.isSpecialKey())
            return;

        char = String.fromCharCode(e.getCharCode()).toUpperCase();

        if (char in this.map)
            char = this.map[char];

        this.putText(char, e.getTarget());
        e.stopEvent();
    },

    processPaste: function(e) {
        var pastedText = '',
            chars,
            text;

        if (window.clipboardData && window.clipboardData.getData) {
            // IE
            pastedText = window.clipboardData.getData('Text');
        } else if (e.event.clipboardData && e.event.clipboardData.getData) {
            // Chrome + FF
            pastedText = e.event.clipboardData.getData('text/plain');
        }

        chars = pastedText.split('');
        for (var i = 0; i < chars.length; i++) {
            chars[i] = chars[i].toUpperCase();
            if (chars[i] in this.map)
                chars[i] = this.map[chars[i]];
        }
        text = chars.join('');

        this.putText(text, e.getTarget());
        e.stopEvent();
    },

    putText: function(text, htmlEl) {
        var range,
            start,
            end;

        if (document.selection) {
            // IE
            range = document.selection.createRange();
            range.text = text;
        } else if (htmlEl.selectionStart || htmlEl.selectionStart === 0) {
            // Chrome + FF
            start = htmlEl.selectionStart;
            end = htmlEl.selectionEnd;

            htmlEl.value = htmlEl.value.substring(0, start) + text + htmlEl.value.substring(end, htmlEl.value.length);

            // Двигаем курсор
            htmlEl.selectionStart = start + text.length;
            htmlEl.selectionEnd = start + text.length;
        } else {
            htmlEl.value = htmlEl.value + text;
        }
    },

    destroy: function() {
        this.field.inputEl.un('keypress', this.processKeyPress, this);
        this.field.inputEl.un('paste', this.processPaste, this);
        delete this.field;
    }
}, function(cls) {
    var map = {};
    // RUS -> LAT
    map['А'] = 'A';
    map['В'] = 'B';
    map['Е'] = 'E';
    map['К'] = 'K';
    map['М'] = 'M';
    map['Н'] = 'H';
    map['О'] = 'O';
    map['Р'] = 'P';
    map['С'] = 'C';
    map['Т'] = 'T';
    map['У'] = 'Y';
    map['Х'] = 'X';
    cls.prototype.map = map;
});
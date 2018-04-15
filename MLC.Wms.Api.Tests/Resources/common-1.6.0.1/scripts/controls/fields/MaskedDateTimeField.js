Ext.define('WebClient.common.controls.fields.MaskedDateTimeField', {
    extend: 'Ext.form.field.Date',

    alias: ['widget.WebClient.common.controls.fields.MaskedDateTimeField'],

    specSymbolsPositions: [2, 5, 10, 13, 16, 19], /* "dd.mm.yyyy hh:mi:ss.nnn" */

    positionsBeforeSpec: undefined,

    maskSize: undefined,

    constructor: function (cfg) {
        var defaultCfg = {
            listeners: {
                render: function (field, e, eOpts) {
                    this.field = field;
                    this.maskSize = this.getMaskSizeFromFormat(this.field.format);
                    this.positionsBeforeSpec = this.specSymbolsPositions.map(function (specSymbolPosition) { return specSymbolPosition - 1; });
                    if (field.rendered) {
                        this.assignEl();
                    } else {
                        field.on('render', this.assignEl, this);
                    }
                }
            }
        };
        cfg = Ext.merge(defaultCfg, cfg);
        this.callParent([cfg]);
    },

    assignEl: function () {
        this.field.inputEl.on('keypress', this.processKeyPress, this);
        this.field.inputEl.on('paste', this.processPaste, this);
    },

    processKeyPress: function (e) {
        var me = this,
            curPosition = e.getTarget().selectionStart,
            char = String.fromCharCode(e.getCharCode()),
            isSpecialKey = e.isSpecialKey(),
            target = e.getTarget();

        var res = me.correctCharAndTarget(char, target, curPosition, isSpecialKey);
        char = res.char;
        e.target = res.target;

        me.putText(char, e.getTarget());
        e.stopEvent();
    },

    processPaste: function (e) {
        var pastedText = '',
            chars,
            me = this;

        if (window.clipboardData && window.clipboardData.getData) {
            // IE
            pastedText = window.clipboardData.getData('Text');
        } else if (e.event.clipboardData && e.event.clipboardData.getData) {
            // Chrome + FF
            pastedText = e.event.clipboardData.getData('text/plain');
        }

        chars = pastedText.split('');
        chars = chars.filter(function (char) { return me.isDigit(char) || char === '.' || char === ':' || char === ' '; });

        chars.forEach(function (char, i, arr) {
            var curPosition = e.getTarget().selectionStart,
                isSpecialKey = e.isSpecialKey(),
                target = e.getTarget();

            var res = me.correctCharAndTarget(char, target, curPosition, isSpecialKey);
            char = res.char;
            e.target = res.target;

            me.putText(char, e.getTarget());
        });

        e.stopEvent();
    },

    correctCharAndTarget: function (char, target, curPosition, isSpecialKey) {
        var me = this;

        // ignore NonDigits & SpecSymbols & anything beyond format.length
        if (!me.isDigit(char) || isSpecialKey || curPosition > me.maskSize)
            char = '';

        // replace (not insert) character if already full mask.length
        if (target.value && target.value.length > me.maskSize)
            target.selectionEnd = target.selectionEnd + 1;

        if (me.format === 'd.m H:i') {
            // jump through spec symbol
            if ([1, 4, 7].indexOf(curPosition) >= 0 && curPosition < me.maskSize) {
                char = char + me.getSpecCharByPosition(curPosition + 1);
                target.selectionEnd = target.selectionEnd + 1;
            }

            // use spec symbol if specPosition
            if ([2, 5, 8].indexOf(curPosition) >= 0 && curPosition < me.maskSize) {
                char = me.getSpecCharByPosition(curPosition);
            }
        }
        else {
            // jump through spec symbol
            if (me.positionsBeforeSpec.indexOf(curPosition) >= 0 && curPosition < me.maskSize) {
                char = char + me.getSpecCharByPosition(curPosition + 1);
                target.selectionEnd = target.selectionEnd + 1;
            }

            // use spec symbol if specPosition
            if (me.specSymbolsPositions.indexOf(curPosition) >= 0 && curPosition < me.maskSize) {
                char = me.getSpecCharByPosition(curPosition);
            }
        }

        return { char: char, target: target };
    },

    isDigit: function (char) {
        var digitRegExp = /\d/;
        return digitRegExp.test(char);
    },

    getSpecCharByPosition: function (posNumber) {
        var char = '';

        if (this.format === 'd.m H:i' && posNumber) {
            switch (posNumber) {
                case 2:
                    char = '.';
                    break;
                case 5:
                    char = ' ';
                    break;
                case 8:
                    char = ':';
                    break;
                default:
                    char = '';
                    break;
            }
            return char;
        }

        if (posNumber)
            switch (posNumber) {
                case 2:
                case 5:
                case 19:
                    char = '.';
                    break;
                case 10:
                    char = ' ';
                    break;
                case 13:
                case 16:
                    char = ':';
                    break;
                default:
                    char = '';
                    break;
            }

        return char;
    },

    getMaskSizeFromFormat: function (format) {
        var size = 0;

        if (format)
            switch (format) {
                case 'F Y':
                    size = 7;
                    break;
                case 'd.m.Y':
                    size = 9;
                    break;
                case 'd.m.Y H:00':
                case 'd.m.Y H:i':
                    size = 15;
                    break;
                case 'd.m.Y H:i:s':
                    size = 18;
                    break;
                case 'd.m.Y H:i:s.u':
                    size = 22;
                    break;
                case 'd.m H:i':
                    size = 10;
                    break;
                default:
                    size = 0;
                    break;
            }

        return size;
    },

    putText: function (text, htmlEl) {
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

    destroy: function () {
        if (!this.field) return;
        this.field.inputEl.un('keypress', this.processKeyPress, this);
        this.field.inputEl.un('paste', this.processPaste, this);
        delete this.field;
    }
});
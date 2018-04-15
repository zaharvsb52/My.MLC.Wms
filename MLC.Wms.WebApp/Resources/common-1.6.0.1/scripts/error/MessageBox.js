/**
 * Класс для показа стурктуры с ошибками. См. ErrorDescriptor на сервере, метод #show.
 * 
 * <b>WebClient.common.error.MessageBox</b> - singleton этого класса, который можно напрямую использовать
 */
Ext.define('WebClient.common.error.MessageBox', {
    extend: 'Ext.window.MessageBox',
    xtype: 'errormessagebox',

    requires: ['WebClient.common.error.DetailsWindow'],

    resizable: true,

    areYouSureText: 'Вы хотите продолжить?',
    warningText: 'Предупреждение',
    errorText: 'Ошибка',
    internalErrorText: 'Внутренняя ошибка',

    /**
     * Массив error item-ов, которые переданы в открытую форму. Новые item-ы, передаваемую в форму, которая уже открыта,
     * будут дополнены к этому массиву, и показаны вместе.
     * @type {Array} 
     */
    passedItems: undefined,

    /**
     * Шаблон показа сообщений об ошибках\warning-ах
     * @type Ext.XTemplate 
     */
    msgTemplate:
        '<table class="c-error-msgbox-table"><tpl for="items">' +
            '<tr itemId="{#}" class="c-error-item item{#}">' +
            '<td class=\'c-error-item-msg\'>{[Ext.htmlEncode(values.userMessage || parent.owner.internalErrorText)]}</td>' +
            '<tpl if="!parent.isWarning"><td class="c-error-item-moreinfo"><tpl if="technicalMessage">(&nbsp;<a href="#" class="c-command">детали</a>&nbsp;)</tpl></td></tpl>' +
            '</tr></tpl>' +
            '<tpl if="isWarning"><tr class="c-error-confirmline"><td>{owner.areYouSureText}</td><td>&nbsp;</td></tr></tpl>' +
            '</table>',

    /**
     * Шаблон текста в clipboard при нажатии "Копировать"
     * @type Ext.XTemplate 
     */
    clipboardDataTemplate:
        '{title}\n' +
            '------------------------' +
            '<tpl for="allItems">\n' +
            'Severity: {[WebClient.getEnumName(WebClient.ErrorSeverity, values.severity)]}\n' +
            '<tpl if="userMessage">User message: {userMessage}\n<tpl if="technicalMessage">\n</tpl></tpl>' +
            '<tpl if="technicalMessage">Technical message: {[WebClient.toDebugString(values.technicalMessage)]}\n</tpl>' +
            '------------------------\n' +
            '</tpl>',

    //        
    //    SAMPLE FOR HTML
    //    ---------------
    //    clipboardDataTemplate: 
    //        '<h1>{[Ext.htmlEncode(values.title)]}</h1>\n' +
    //        '<tpl for="allItems"><hr><blockquote>\n' +
    //        '    <div><b>Severity</b>: {severity}</div>\n'+
    //        '<tpl if="userMessage">    <div><b>UserMessage</b>: {[Ext.htmlEncode(values.userMessage)]}</div>\n</tpl>'+
    //        '<tpl if="technicalMessage">    <div><b>TechnicalMessage</b>: {[Ext.htmlEncode(values.technicalMessage)]}</div>\n</tpl>'+
    //        '</blockquote>\n'+
    //        '</tpl>',


    /**
     * Run-time данные передаваемые между разными объектами (включая шаблоны) во время показа сообщения. Каждый вызов метода show создается заново.
     * Имеет свойства:<br>
     * - title<br>
     * - hasErrors<br>
     * - isWarning - в режиме показа warning-ов, не ошибок<br>
     * - items - для показа (неотфильтрованы по severity)<br>
     * - allItems - все<br>
     * - clipboardData - если указано, именно этот текст будет уходит в clipboard буффер при нажатии на кнопку "Копировать"<br>
     * - owner - текущий инстанс WebClient.error.MessageBox
     * @type 
     */
    context: undefined,

    initComponent: function() {
        this.callParent(arguments);

        this.msgTemplate = new Ext.XTemplate(this.msgTemplate);
        this.clipboardDataTemplate = new Ext.XTemplate(this.clipboardDataTemplate);

        //Добавляем кнопку "Скопировать" на bottom bar
        var me = this;
        me.bottomTb.style = 'margin-left:55';
        me.bottomTb.layout.pack = 'start';
        me.bottomTb.insert(0, { xtype: 'tbfill' });
        me.bottomTb.add([
            { xtype: 'tbfill' },
            {
                xtype: 'button',
                itemId: 'copyToBuffer',
                text: 'Скопировать',
                style: 'margin-left:10px',
                handler: function() {
                    WebClient.copyToClipboard((me.context && me.context.clipboardData) || me.msg.el.dom.innerHTML, me.down('#copyToBuffer').getEl());
                }
            }
        ]);
    },

    /**
     * Показывает сообщение с ошибками или warning-ами. Если warning-и, то пользователю предлагается повторить действие; при подтверждении, вызывается retryCallBack. 
     * <b>Пример</b>: <code>{source: myGrid1, itemId: "CustomerId", convertor: function(row) {return row.getId();} }</code>
     * @param {Object} errorDescr Структура ошибок:<ul>
     * <li><b>title</b> string : То, что покажется в title окна. Опционально.
     * <li><b>items</b> [{severity, userMessage, technicalMessage}]:  Массив ошибок\warning-ов. severity соответсвует WebClient.ErrorSeverity</li>
     * </ul>
     */
    show: function(errorDescr, retryCallBack, retryCallBackScope) {
        var me = this,
            ctx = me.context = { owner: this };

        ctx.title = errorDescr.title;
        var hasItems = errorDescr.items && errorDescr.items.length > 0; //items are returned, if no items are returned - error with predefined message
        ctx.hasErrors = !hasItems || this.hasErrors(errorDescr.items); //others are warnings
        ctx.isWarning = !ctx.hasErrors;

        if (!hasItems)
            errorDescr.items = [{ severity: WebClient.ErrorSeverity.ERROR, userMessage: this.internalErrorText, technicalMessage: 'Информация об ошибке не вернулась с сервера' }];


        if (me.passedItems) {
            me.passedItems = me.passedItems.concat(errorDescr.items);
            ctx.hasErrors = me.hasErrors(me.passedItems);
            errorDescr.items = me.passedItems;
        } else
            me.passedItems = errorDescr.items;

        if (!ctx.title)
            ctx.title = ctx.hasErrors ? this.errorText : this.warningText;

        //Если есть ошибка, выбираем только ошибки. Если нет, то все - это warnings 
        ctx.items = ctx.hasErrors ? Ext.Array.filter(errorDescr.items, function(item) { return item.severity > WebClient.ErrorSeverity.WARNING; })
            : errorDescr.items;
        ctx.allItems = errorDescr.items;

        var html = this.msgTemplate.apply(ctx);

        ctx.clipboardData = this.clipboardDataTemplate.apply(ctx);
        if (ctx.clipboardData && Ext.isWindows) {
            //Это необходимо, так как XTemplate заменяет \r\n на \n, а в clipboard IE нужно засовывать \r\n иначе в notepad текст вставляется в одну строку
            ctx.clipboardData = WebClient.replaceLineBreaksWith(ctx.clipboardData, '\r\n');
        }

        if (ctx.isWarning) {
            this.callParent([
                {
                    title: ctx.title,
                    msg: html,
                    buttons: Ext.MessageBox.YESNOCANCEL,
                    fn: function(btn) {
                        if (btn == 'yes' && retryCallBack)
                            retryCallBack.call(window || retryCallBackScope);
                    },
                    scope: this,
                    icon: Ext.MessageBox.WARNING
                }
            ]);
        } else {
            this.callParent([
                {
                    title: ctx.title,
                    msg: html,
                    buttons: Ext.MessageBox.OK,
                    icon: Ext.MessageBox.ERROR
                }
            ]);
        }

    },

    onShow: function() {
        this.callParent(arguments);
        this.getEl().select('a.c-command').each(function(el) {
                Ext.get(el).on('click', this.onDetailsClicked, this);
            },
            this
        );
    },

    /**
     * @private
     */
    hasErrors: function(items) {
        return Ext.Array.some(items, function(item) { return item.severity > WebClient.ErrorSeverity.WARNING; }); //others are warnings
    },

    onDetailsClicked: function(event, el) {
        var idx = Ext.fly(el).up('tr').getAttribute('itemId');
        var techMsg = this.context.items[idx - 1].technicalMessage;

        if (techMsg) {
            var w = new WebClient.common.error.DetailsWindow({ text: techMsg, animateTarget: el });
            w.show();
            w.focus();
        }
    },

    hide: function() {
        this.callParent(arguments);
        this.passedItems = undefined;
    }

}, function() {
    WebClient.common.error.MessageBox = new this();
});

//Фикс локализации. См. также похожий код в extjs-override
Ext.onReady(function() {
    for (var btnId in WebClient.common.error.MessageBox.buttonText)
        WebClient.common.error.MessageBox.msgButtons[btnId].setText(Ext.MessageBox.buttonText[btnId]);
});
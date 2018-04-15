/**
 * Иконка для поля на форме
 */
Ext.define('WebClient.common.controls.fields.IconPlugin', {
    extend: 'Ext.AbstractPlugin',

    alias: ['plugin.fieldIcon'],

    /**
     * @cfg {string} iconBaseCls Этот класс CSS 
     * добавляется к {@link #iconCls iconCls}
     */
    iconBaseCls: 'fa',

    /**
     * @cfg {string} iconCls класс иконки
     */
    iconCls: 'fa-circle',

    /**
     * @cfg {string} iconPath Путь к изображению иконки. Используется только 
     * если {@link #iconMode iconMode} равен '**img**'
     */

    /**
     * @cfg {string} iconMode Режим иконки. Допустимые значения
     * '**font**', '**img**' and '**css**'
     */
    iconMode: 'font',

    /**
     * @cfg {string} iconColor CSS спецификация цвета для иконки.
     * Она используется только для {@link #iconMode iconMode}  '**font**'
     */
    iconColor: '#C1DDF1',

    /**
     * @cfg {number} iconWidth Ширина иконки в пикселях
     */
    iconWidth: 16,

    /**
     * @cfg {number} iconHeight Высота иконки в пикселях
     */
    iconHeight: 16,

    /**
     * @cfg {number} cellWidthAdjust Ширина в пикселях для добавления к
     * iconWidth для расчета ширины оберточного элемента (div).
     */
    cellWidthAdjust: 10,

    /**
     * @cfg {string} iconCursor Стиль курсора над иконкой.
     */
    iconCursor: 'default',

    /**
     * @cfg {string} iconMargin CSS спецификация отступа для иконки.
     */
    iconMargin: '0 5px 0 5px',

    /**
     * @cfg {string} position Позиция, куда добавить иконку. Допустимые значения: 
     * '**beforeLabel**', '**afterLabel**', '**beforeInput**', '**afterInput**'.
     */
    position: 'afterInput',

    /**
     * @cfg {bool} highlightField true для подсветки поля цветом iconColor.
     */
    highlightField: true,

    /**
     * @cfg {Object} iconPresets Преднастроенные стили. Используются методом show. 
     */
    iconPresets: {
        information: { iconCls: 'fa-info-circle', iconColor: '#3892D3' },
        warning: { iconCls: 'fa-exclamation-triangle', iconColor: '#FED403' },
        error: { iconCls: 'fa-exclamation-circle', iconColor: '#D94E37' }
    },

    /**
     * @cfg {string[]} clickEvents События, которые перехватываются на иконке,
     * и вызываются на поле. К именам событий на поле добавляется `icon` (`iconclick`, `iconcontextmenu`).
     */
    clickEvents: ['click', 'contextmenu'],


    /**
     * @cfg {string/undefined} qtipTitle Заголовок, отображаемый на qtip.
     * Используется если {@link #tip tip} не определен.
     */

    /**
     * @cfg {string/undefined} qtip Текст, отображаемый на qtip.
     * Используется если {@link #tip tip} не определен.
     */

    /**
     * @cfg {Object/Ext.tip.ToolTip/undefined} tip Конфигурация или экземпляр
     * типа {@link Ext.tip.ToolTip Ext.tip.ToolTip} для отображения при наведении
     * указателя на иконку.
     */

    /**
     * @cfg {string} iconImg Путь к изображению иконки. Используется если
     * {@link #iconMode iconMode} равен '**img**'
     */

    /**
     * @readonly
     * @private
     * @property {Ext.dom.Element} iconEl Элемент иконки.
     */

    /**
     * @readonly
     * @private
     * @property {Ext.dom.Element} wrapEl Оберточный элемент.
     */

    /**
     * @event iconclick
     * @member Ext.form.field.Field
     * @param {Ext.form.field.Field} this
     * @param {Ext.EventObject} e
     */

    /**
     * @event iconcontextmenu
     * @member Ext.form.field.Field
     * @param {Ext.form.field.Field} this
     * @param {Ext.EventObject} e
     */

    statics: {
        /**
         * Используем свой синглтон QuickTip чтобы могли гибко настроить.
         * @static
         * @private
         */
        initTip: function() {
            var tip = this.tip,
                cfg;

            if (!tip) {
                cfg = {
                    id: 'ext-form-icon-tip',
                    sticky: true,
                    ui: 'default'
                };

                if (Ext.supports.Touch) {
                    cfg.dismissDelay = 0;
                    cfg.anchor = 'top';
                    cfg.showDelay = 0;
                    cfg.listeners = {
                        beforeshow: function() {
                            this.minWidth = Ext.fly(this.anchorTarget).getWidth();
                        }
                    };
                }
                tip = this.tip = Ext.create('Ext.tip.QuickTip', cfg);
                tip.tagConfig = Ext.apply({}, {
                    attribute: 'iconqtip'
                }, tip.tagConfig);
            }
        }
    },

    /**
     * Инициализация. Вызывается фреймворком.
     * @private
     * @param {Ext.form.Field} cmp Поле формы
     */
    init: function(cmp) {
        var me = this;

        me.setCmp(cmp);

        cmp.on({
            afterrender: {
                scope: me,
                single: true,
                fn: me.afterCmpRender
            }
        });

        Ext.apply(cmp, {
            /**
             * Возвращает экземпляр плагина
             * @member Ext.form.field.Field
             * @returns {WebClient.common.controls.fields.IconPlugin}
             */
            getIcon: function() {
                return me;
            }
        });
    },

    /**
     * @private
     */
    afterCmpRender: function() {
        var me = this,
            cmp = me.getCmp(),
            cfg = me.getIconConfig(),
            isTextArea = false,
            iconEl,
            wrapEl,
            wrapCfg = {
                tag: 'div',
                style: {
                    'width': (me.iconWidth + me.cellWidthAdjust) + 'px',
                    'display': 'none',
                    'vertical-align': 'middle'
                },
                cn: [cfg]
            };

        try {
            isTextArea = cmp instanceof Ext.form.field.TextArea;
        } catch (e) {
        };

        if (isTextArea) {
            Ext.apply(wrapCfg.style, {
                'vertical-align': 'top',
                'padding-top': '3px'
            });
        }

        switch (me.position) {
        case 'afterInput':
            wrapEl = cmp.bodyEl.insertSibling(wrapCfg, 'after');
            break;

        case 'beforeInput':
            wrapEl = cmp.bodyEl.insertSibling(wrapCfg, 'before');
            break;

        case 'afterLabel':
            wrapEl = cmp.labelEl.insertSibling(wrapCfg, 'after');
            break;

        case 'beforeLabel':
            wrapEl = cmp.labelEl.insertSibling(wrapCfg, 'before');
            break;

        default:
            Ext.Error.raise('unsupported position');
        }

        me.wrapEl = wrapEl;
        me.iconEl = iconEl = wrapEl.down('i');

        me.doHighlightField(me.highlightField);

        if (me.tip) {
            if (!(me.tip instanceof Ext.Base))
                me.tip = Ext.widget('tooltip', me.tip);
            me.tip.setTarget(iconEl);
        }

        me.initEvents();
    },

    /**
     * @private
     */
    doHighlightField: function(v) {
        var me = this,
            el = me.cmp.triggerWrap || me.cmp.bodyEl,
            borderColor = v ? me.iconColor : '',
            borderWidth = v ? '1px' : '',
            borderStyle = v ? 'solid' : '';

        if (!el)
            return;

        el.applyStyles({
            'border-color': borderColor,
            'border-width': borderWidth,
            'border-style': borderStyle
        });
    },

    /**
     * @private
     */
    initEvents: function() {
        var me = this,
            cmp = me.getCmp(),
            iconEl = me.iconEl;

        Ext.Array.each(me.clickEvents, function(ev) {
            iconEl.on(ev, function(e) {
                e.stopEvent();
                cmp.fireEvent('icon' + ev, cmp, e);
                return false;
            });
        });
    },

    /**
     * Настройка иконки
     * @returns {Object} конфигурация для Ext.DomHelper
     * @template
     */
    getIconConfig: function() {
        var me = this,
            // this cfg will do for iconMode font and css
            cfg = {
                tag: 'i',
                cls: Ext.String.format('{0} {1}', me.iconBaseCls, me.iconCls),
                style: {
                    'width': me.iconWidth + 'px',
                    'height': me.iconHeight + 'px',
                    'font-size': me.iconHeight + 'px',
                    'line-height': '100%',
                    'color': me.iconColor,
                    'cursor': me.iconCursor,
                    'margin': me.iconMargin,
                    'text-align': 'center'
                }
            };

        // handling of iconMode img
        if ('img' === me.iconMode && me.iconPath) {
            cfg.cls = me.iconBaseCls;
            cfg.cn = [
                {
                    tag: 'img',
                    src: me.iconPath,
                    style: {
                        'vertical-align': 'middle'
                    }
                }
            ];

        }

        // use qtip config options only if we don't have tip
        if (!me.tip) {
            WebClient.common.controls.fields.IconPlugin.initTip();
            if (me.qtipTitle)
                cfg['data-iconqtitle'] = me.qtipTitle;
            if (me.qtip)
                cfg['data-iconqtip'] = me.qtip;
        }
        return cfg;
    },

    /**
     * Отобразить иконку по преднастройкам.
     * @param {string} p Имя преднастройки
     * @param {string/undefined} q Текст qtip
     */
    show: function(p, q) {
        var me = this,
            preset = me.iconPresets[p];

        if (preset) {
            me.setIconCls(preset.iconCls);
            me.setIconColor(preset.iconColor);
        }

        me.setIconTip(q);

        me.wrapEl.setStyle('display', 'table-cell');
        me.doHighlightField(me.highlightField);
    },

    /**
     * Спрятать иконку.
     */
    hide: function() {
        this.wrapEl.setStyle('display', 'none');
        this.doHighlightField(false);
    },

    /**
     * Поменять иконку путем замены {@link WebClient.common.controls.fields.IconPlugin#iconCls iconCls}
     * @param {string} cls Новое имя класса иконки
     */
    setIconCls: function(cls) {
        this.iconEl.replaceCls(this.iconCls, cls);
        this.iconCls = cls;
    },

    /**
     * Установить стиль иконки
     * @param {string} style Стиль иконки
     */
    setIconStyle: function(style) {
        this.iconEl.applyStyles(style);
    },

    /**
     * Установить цвет иконки. Используется если
     * {@link WebClient.common.controls.fields.IconPlugin#iconMode iconMode} равен '**font**'
     * @param {string} color Цвет иконки
     */
    setIconColor: function(color) {
        var me = this;
        me.setIconStyle({ color: color });
        me.iconColor = color;
        me.doHighlightField(me.highlightField);
    },

    /**
     * Установить текст qtip. 
     * @param {string} text Текст
     */
    setIconTip: function(text) {
        this.iconEl.set({ 'data-iconqtip': text });
    },

    /**
     * Установить заголовок qtip.
     * @param {string} text Заголовок
     */
    setIconTipTitle: function(text) {
        this.iconEl.set({ 'data-iconqtitle': text });
    },

    /**
     * @private
     */
    destroy: function () {
        var iconEl = this.iconEl;

        if (!iconEl && this.cmp) {
            this.cmp.clearListeners();
            return;
        }

        iconEl.clearListeners();
        Ext.destroy(iconEl);
    }

});
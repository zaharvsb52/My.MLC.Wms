Ext.define('WebClient.common.controls.grid.plugin.MultiSearch', {

    extend: 'Ext.container.Container',

    alternateClassName: 'Ext.ux.grid.MultiSearch',

    alias: ['plugin.gms'],

    requires: ['WebClient.common.filters.FilterBinder'],

    config: {
        /**
         * @private
         * @cfg {Ext.data.Store} store Автоматически устанавливается из грида
         */
        store: null,

        /**
         * @private
         * @cfg {Ext.grid.header.Column[]} columns Автоматически устанавливается из грида
         */
        columns: null
    },

    /**
     * @private
     * @cfg {Object} layout
     */
    layout: {
        type: 'hbox',
        align: 'stretch'
    },

    /**
     * @private
     * @cfg {String} dock Определяет положение полей фильтрации. Единственное проверенное и разумное значение - 'top'
     */
    dock: 'top',

    baseCls: 'gms-ct',

    /**
     * @cfg {Number}
     * Высота строки с полями фильтрации. Измените это значение в зависимости от
     * используемой в вашем приложении темы. Значение по умолчанию (34) хорошо смотрится с
     * Ext Crisp темой.
     */
    height: 34,

    /**
     * @cfg {Number}
     * Должно быть достаточно высоким, чтобы сделать строку фильтра под заголовком грида.
     */
    weight: 1000,

    /**
     * @private
     * @type {WebClient.common.filters.FilterBinder}
     */
    filterBinder: null,

    /**
     * @private
     */
    updateStore: function(newStore, oldStore) {
        this.filterBinder.setFilterable(newStore);
    },

    /**
     * @private
     */
    updateColumns: function(newColumns, oldColumns) {
        var me = this,
            headerCt = me.headerCt,
            selModel = me.grid.getSelectionModel();

        // Отключаем события и лайоуты
        Ext.suspendLayouts();
        headerCt.suspendEvents();

        // пересоздаем поля фильтрации
        me.removeAll(true);
        me.add(me.createItems(newColumns));

        if (selModel instanceof Ext.selection.CheckboxModel) {
            me.items.insert(selModel.injectCheckbox, Ext.widget({
                itemId: 'item-' + selModel.injectCheckbox,
                xtype: 'component',
                cls: 'gms-nofilter',
                height: me.height
            }));
        }

        me.filterBinder.setBindings(WebClient.common.filters.FilterBinder.getFilterBindings(me));

        // Включаем обратно
        headerCt.resumeEvents();
        Ext.resumeLayouts(true);
    },

    /**
     * @private
     * @param {Ext.grid.Panel} grid
     */
    init: function(grid) {
        var me = this,
            headerCt = grid.getView().getHeaderCt();

        Ext.apply(me, {
            grid: grid,
            headerCt: headerCt,
            filterBinder: new WebClient.common.filters.FilterBinder()
        });

        headerCt.on({
            afterlayout: { fn: me.afterHdLayout, scope: me },
            afterrender: { fn: me.afterHdRender, scope: me, single: true }
        });

        grid.on({
            reconfigure: me.onReconfigure,
            columnmove: me.onColumnMove,
            scope: me
        });

        me.on({
            afterrender: { fn: me.onAfterRender, scope: me, single: true }
        });

        me.onReconfigure(grid, grid.store, grid.columns);

        grid.getFilter = function() { return me; };
    },

    /**
     * @private 
     * @returns {Ext.grid.Panel} 
     */
    getRefOwner: function() {
        return this.grid;
    },

    /**
     * @private
     * @param {Ext.grid.Panel} grid
     * @param {Ext.data.Store} store
     * @param {Ext.grid.column.Column[]} columns
     */
    onReconfigure: function(grid, store, columns) {
        if (columns)
            this.setColumns(columns);

        if (store)
            this.setStore(store);
    },

    /**
     * Создание полей фильтрации.
     * @private
     * @param {Ext.grid.column.Column[]} columns
     * @returns {Ext.form.Field[]}
     */
    createItems: function(columns) {
        var me = this,
            items = [];
        Ext.Array.each(columns, function(col, i) {
            var filter = col.filterField || col.filter,
                cfg = { xtype: 'component' },
                item = null;
            if (true === filter)
                cfg.xtype = 'textfield';
            else if (filter && filter.isComponent)
                cfg = filter;
            else if ('string' === typeof filter)
                cfg.xtype = filter;
            else if (Ext.isObject(filter))
                Ext.apply(cfg, filter);
            else {
                cfg.cls = 'gms-nofilter';
                cfg.height = me.height;
            }
            // важен itemId так как по нему ищутся поля при пересортировке столбцов
            item = Ext.widget({
                xtype: 'container',
                itemId: col.itemId ? col.itemId : col.dataIndex || 'item' + i,
                padding: '4px 2px 4px 1px',
                layout: 'fit',
                items: [cfg]
            });
            items.push(item);
        });
        return items;
    },

    /**
     * Установка обработчика события scroll, вызванного переходом по Tab по полям фильтрации.
     * @private
     */
    onAfterRender: function() {
        var me = this,
            scrollerEl = me.getScrollerEl();
        scrollerEl.on('scroll', me.onFilterScroll, me);
    },

    /**
     * Вызывается во время скролла из - за перехода по полям фильтрации.
     * Прокручивает грид на такую же величину.
     * @private
     */
    onFilterScroll: function() {
        var me = this,
            scrollLeft = me.getScrollerEl().getScrollLeft();
        me.grid.getView().scrollTo(scrollLeft, 0);
    },

    /**
     * Синхронизация перемещения колонок в гриде с полями фильтрации.
     * @private
     */
    onColumnMove: function() {
        var me = this;
        me.syncOrder();
    },

    /**
     * Упорядочивание полей фильтрации согласно колонкам грида.
     * @private
     */
    syncOrder: function() {
        var me = this,
            cols = me.headerCt.getGridColumns(), // не .getColumns() так как могут быть "невидимые" колонки, например, с чекбоксом из SelectionModel
            i,
            field;

        Ext.suspendLayouts();
        for (i = 0; i < cols.length; i++) {
            field = me.items.get(cols[i].dataIndex);
            if (field)
                me.items.insert(i, field);
        }
        Ext.resumeLayouts(true);
    },

    /**
     * Синхронизация UI после перерисовки заголовка.
     * @private
     */
    afterHdLayout: function() {
        var me = this;
        if (!me.grid.reconfiguring)
            me.syncUi();
    },

    /**
     * Синхронизация интерфейса фильтра с фактическим состоянием фильтрации.
     * @private
     */
    syncUi: function() {
        var me = this;
        if (!me.rendered)
            return;

        Ext.suspendLayouts();
        me.syncColsWidth();
        me.markFilteredCols();
        Ext.resumeLayouts(true);
    },

    /**
     * Синхронизация ширины колонок с полями фильтрации.
     * @private
     */
    syncColsWidth: function() {
        var me = this,
            cols = me.headerCt.getGridColumns(), // не .getColumns() так как могут быть "невидимые" колонки, например, с чекбоксом из SelectionModel
            hdWidth = me.headerCt.layout.innerCt.getWidth();

        Ext.Array.each(cols, function(col, i) {
            var filter = me.items.getAt(i);
            if (filter)
                filter.setWidth(col.getWidth());
        });
        me.layout.targetEl.setWidth(hdWidth);
    },

    /**
     * @private 
     */
    markFilteredCols: function() {
        var me = this,
            store = me.getStore(),
            filters = store.getFilters(),
            cols = me.getColumns();

        Ext.each(cols, function(c) {
            var colEl = c.getEl();
            colEl.removeCls('gms-filtered');
        });

        filters.each(function(f) {
            var col = Ext.Array.findBy(cols, function(c) { return c.dataIndex === f.getProperty(); });
            if (!col)
                return;
            var colEl = col.getEl();
            colEl.addCls('gms-filtered');
        });
    },

    /**
     * Выполняется один раз. Добавляет плагин в грид и проводит дополнительную инициализацию.
     * @private
     */
    afterHdRender: function() {
        var me = this,
            grid = me.grid;
        grid.dockedItems.add(me);
        grid.getView().on({
            scroll: { fn: me.onGridScroll, scope: me }
        });
    },

    /**
     * Синхронизация прокрутки грида с полями фильтрации.
     * @private
     */
    onGridScroll: function() {
        var me = this,
            scroll = me.grid.getView().getEl().getScroll(),
            scrollEl = me.getLayout().innerCt;
        scrollEl.scrollTo('left', scroll.left);
    }
});
Ext.define('WebClient.common.controls.grid.plugin.MultiSort', {

    extend: 'Ext.grid.feature.Feature',

    alternateClassName: 'Ext.ux.grid.MultiSort',

    alias: ['feature.gmsrt'],

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
     * @cfg {String} removeSortText Название пунтка меню для очистки сортировки
     */
    removeSortText: 'Убрать из сортировки',

    /**
     * @cfg {Boolean} displaySortOrder Отображать порядок сортировки в заголовках
     */
    displaySortOrder: false,

    /**
     * @private
     */
    updateStore: function(newStore, oldStore) {
        if (oldStore && newStore) {

            var sortersToCopy = [];
            oldStore.getSorters().each(function(s) {
                sortersToCopy.push({
                    property: s.getProperty(),
                    direction: s.getDirection()
                });
            });

            var newSorters = newStore.getSorters();
            newSorters.suspendEvents();
            newSorters.addSort(sortersToCopy);
            newSorters.resumeEvents();

            newStore.fireEvent('sort', newStore, newSorters.getRange());
        }

        if (oldStore) {
            var oldSorters = oldStore.getSorters();
            oldSorters.suspendEvents();
            oldSorters.clear();
            oldSorters.resumeEvents();

            oldStore.fireEvent('sort', newStore, newStore.getSorters().getRange());
        }
    },

    /**
     * @private
     */
    updateColumns: function(newColumns, oldColumns) {
        var me = this,
            headerCt = me.view.getHeaderCt();

        // Отключаем события и лайоуты
        Ext.suspendLayouts();
        headerCt.suspendEvents();

        me.updateSorteredColumns();

        // Включаем обратно
        headerCt.resumeEvents();
        Ext.resumeLayouts(true);
    },

    /**
     * @private
     */
    init: function(grid) {
        var me = this,
            view = me.view,
            headerCt = view.getHeaderCt();

        grid.on({
            reconfigure: { fn: me.onReconfigure, scope: me }
        });

        view.on({
            afterrender: { fn: me.afterViewRender, scope: me, single: true }
        });

        headerCt.on({
            headerclick: { fn: me.onHeaderClick, scope: me }
        });

        headerCt.onHeaderCtEvent = function(e, t) {
            var oldSortClickVal = headerCt.sortOnClick;
            if (e.altKey)
                headerCt.sortOnClick = false;
            // тут происходит сортировка без ALT, если headerCt.sortOnClick == true
            Ext.grid.header.Container.prototype.onHeaderCtEvent.apply(headerCt, [e, t]);
            headerCt.sortOnClick = oldSortClickVal;
        };
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
     * @private
     * Создание пунктов меню и обновление заголовков
     */
    afterViewRender: function() {
        var me = this;
        me.injectMultiSortMenu();
        me.updateSorteredColumns();
    },

    /**
     * @private
     */
    onHeaderClick: function(ct, column, e) {
        var me = this,
            store = me.view.getStore(),
            sorter;

        me.removeOldSorterLabels();
        if (e.altKey) {
            sorter = store.getSorters().getByKey(column.dataIndex);
            if (sorter) {
                sorter.toggle();
                store.sort();
            } else {
                store.sort(column.dataIndex, 'ASC', 'append');
            }
        }
        me.updateSorteredColumns();
    },

    /**
     * @private
     * Подстановка нового меню
     */
    injectMultiSortMenu: function() {
        var me = this,
            headerCt = me.view.getHeaderCt();
        if (headerCt.sortable) {
            headerCt.getMenuItems = me.getMenuItems();
            headerCt.getMenu().on({
                beforeshow: function(menu) {
                    menu.down('#remSortItem').setDisabled(!menu.activeHeader.enableRemSortItem);
                }
            });
        }
    },

    /**
     * @private
     * Очистка заголовков и меню всех колонок
     */
    removeOldSorterLabels: function() {
        var me = this,
            headerCt = me.view.getHeaderCt();
        Ext.each(headerCt.getGridColumns(), function(column) {
            column.enableRemSortItem = false;
            if (me.displaySortOrder)
                column.setText(column.text.split(' <small>(')[0]);
        });
    },

    /**
     * @private
     * Обновление заголовков и меню отсортированных колонок
     */
    updateSorteredColumns: function() {
        var me = this,
            headerCt = me.view.getHeaderCt(),
            store = me.view.getStore(),
            col,
            sorters = store.getSorters(),
            sortersCount = sorters.getCount(),
            sorter,
            text,
            dataIndex,
            i;

        for (i = 0; i < sortersCount; i++) {
            sorter = sorters.getAt(i);
            dataIndex = sorter.getProperty();
            col = headerCt.down('[dataIndex=' + dataIndex + ']');
            if (col) {
                col.enableRemSortItem = true;
                col.setSortState(sorter);
                if (me.displaySortOrder) {
                    text = col.text.split(' <small>');
                    col.setText(text[0] + ' <small>(' + (i + 1) + ')</small>');
                }
            }
        }
    },

    /**
     * @private
     * Строит меню сортировки
     * @returns {Function} 
     */
    getMenuItems: function() {
        var me = this,
            headerCt = me.view.getHeaderCt(),
            getMenuItems = headerCt.getMenuItems;

        return function() {
            var o = getMenuItems.call(this),
                index = o.length;

            Ext.each(o, function(item, idx) {
                if (item.itemId === 'ascItem') {
                    item.handler = me.onSortAscClick;
                    item.scope = me;
                }
                if (item.itemId === 'descItem') {
                    item.handler = me.onSortDescClick;
                    item.scope = me;
                    index = idx + 1;
                }
            });

            Ext.Array.insert(o, index, [
                {
                    itemId: 'remSortItem',
                    text: me.removeSortText,
                    handler: me.onRemoveSortClick,
                    disabled: true,
                    scope: me
                }
            ]);

            return o;
        };
    },

    /**
     * @private
     * Выполняет сортировку
     */
    onSortAscClick: function() {
        this.onSortClick('ASC');
    },

    /**
     * @private
     * Выполняет сортировку
     */
    onSortDescClick: function() {
        this.onSortClick('DESC');
    },

    /**
     * @private
     * Выполняет сортировку
     */
    onSortClick: function(direction) {
        var me = this,
            headerCt = me.view.getHeaderCt(),
            menu = headerCt.getMenu(),
            activeHeader = menu.activeHeader,
            dataIndex = activeHeader.dataIndex,
            store = me.view.getStore(),
            sorters = store.getSorters(),
            sorter = sorters.getByKey(dataIndex);

        activeHeader.enableRemSortItem = true;

        if (sorter) {
            sorters.suspendEvents();
            sorters.removeAtKey(dataIndex);
            sorters.resumeEvents();
        }

        store.sort(dataIndex, direction, 'append');
        me.updateSorteredColumns();
    },

    /**
     * @private
     * Удаляет сортировку
     */
    onRemoveSortClick: function() {
        var me = this,
            headerCt = me.view.getHeaderCt(),
            menu = headerCt.getMenu(),
            activeHeader = menu.activeHeader,
            dataIndex = activeHeader.dataIndex,
            text = activeHeader.text.split(' <small>'),
            store = me.view.getStore(),
            sorters = store.getSorters(),
            sorter = sorters.getByKey(dataIndex);

        if (sorter) {
            sorters.removeAtKey(dataIndex);
        }

        if (sorters.length === 0 && store.remoteSort)
            store.load();

        activeHeader.enableRemSortItem = false;
        activeHeader.setSortState();

        if (me.displaySortOrder) {
            activeHeader.setText(text[0]);
            me.updateSorteredColumns();
        }
    }
});
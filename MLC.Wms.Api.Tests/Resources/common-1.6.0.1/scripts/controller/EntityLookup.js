Ext.define('WebClient.common.controller.EntityLookup', {
    extend: 'WebClient.common.controller.Entity',

    alias: ['widget.WebClient.common.controller.EntityLookup'],

    mixins: {
        standAlone: 'WebClient.common.controller.StandAloneControllerMixin'
    },

    /**
     * {@link WebClient.common.dataServices.DataServiceProxy} из которого контроллер берет мета информацию, а также серверные методы для CRUD операций
     * @type WebClient.common.dataServices.DataServiceProxy 
     */
    dataServiceProxy: undefined,

    constructor: function(cfg) {
        this.mixins.standAlone.constructor.call(this, cfg);
        this.callParent(arguments);

        if (!this.dataContext && !this.dataServiceProxy)
            Ext.Error.raise('ни dataContext ни dataServiceProxy не были переданы в авто controller для entity lookup');
        if (!this.dataContext)
            this.dataContext = this.dataServiceProxy.createDataContext();
    },

    /**
     * @override
     */
    deriveStructureName: function() {
        return this.entityType + 'Lookup';
    },

    onViewCreated: function () {
        var me = this;
        me.view.on({
            itemdblclick: function (panel, record, item, index, e, eOpts) {
                me.fireEvent('itemselected', me, record);
            },
            itemkeydown: function(panel, record, item, index, e, eOpts) {
                if(e.getKey() === Ext.event.Event.ENTER)
                    me.fireEvent('itemselected', me, record);
            }
        });
    },

    loadData: function() {
        var store = this.dataContext.takeStore(this.structureName),
            proxy = store.getProxy();
        proxy.setExtraParam('queryText', this.dataParams.queryText);
        proxy.setExtraParam('encloseValueInPercent', this.dataParams.encloseValueInPercent);

        if (store.isLoading() || (store instanceof Ext.data.TreeStore)) //иерархический store автоматически начинает грузить данные рутового нода
            return;

        this.fireEvent('beforeload', this, store);
        store.load({ scope: this, callback: this.onLoad });
    },

    onLoad: function () {
        var store = this.dataContext.takeStore(this.structureName);
        this.fireEvent('load', this, store);
    },

    getPageData: function () {
        var store = this.dataContext.takeStore(this.structureName),
            pageSize = store.getPageSize(),
            totalCount = store.getTotalCount();

        return {
            total: totalCount,
            currentPage: store.currentPage,
            pageCount: Math.ceil(totalCount / pageSize),
            fromRecord: ((store.currentPage - 1) * pageSize) + 1,
            toRecord: Math.min(store.currentPage * pageSize, totalCount)

        };
    },

    loadPrevPage: function() {
        var store = this.dataContext.takeStore(this.structureName),
            pageData = this.getPageData();
        
        if (pageData.currentPage > 1)
            store.previousPage({ scope: this, callback: this.onLoad });
    },

    loadNextPage: function() {
        var store = this.dataContext.takeStore(this.structureName),
            pageData = this.getPageData();

        if (pageData.currentPage < pageData.pageCount)
            store.nextPage({ scope: this, callback: this.onLoad });
    },

    selectItem: function (item) {
        var grid = this.view,
            gridView,
            selectionModel;

        if (!grid || !item)
            return;

        selectionModel = grid.getSelectionModel();
        gridView = grid.getView();
        gridView.scrollRowIntoView(item);
        selectionModel.select(item);
    },

    selectNextItem: function() {
        var me = this,
            grid = me.view,
            store,
            selectionModel,
            selection,
            record,
            index,
            nextRecord;

        if (!grid)
            return;

        store = me.dataContext.takeStore(me.structureName);
        selectionModel = grid.getSelectionModel();
        selection = selectionModel.getSelection();

        if (!selection.length)
            return;

        record = selection[selection.length - 1];
        index = store.indexOf(record) + 1;

        if (index === store.getCount() || index === 0) {
            return;
        } else {
            nextRecord = store.getAt(index);
            me.selectItem(nextRecord);
        }
    },

    selectPrevItem: function() {
        var me = this,
            grid = me.view,
            store,
            selectionModel,
            selection,
            record,
            index,
            prevRecord;

        if (!grid)
            return;

        store = me.dataContext.takeStore(me.structureName);
        selectionModel = grid.getSelectionModel();
        selection = selectionModel.getSelection();

        if (!selection.length)
            return;

        record = selection[selection.length - 1];
        index = store.indexOf(record) - 1;

        if (index < 0) {
            return;
        } else {
            prevRecord = store.getAt(index);
            me.selectItem(prevRecord);
        }
    },

    selectFirstItem: function() {
        var store = this.dataContext.takeStore(this.structureName);
        this.selectItem(store.first());
    },

    selectLastItem: function() {
        var store = this.dataContext.takeStore(this.structureName);
        this.selectItem(store.last());
    },

    getSelectedItem: function() {
        var view = this.view,
            selectionModel,
            selection;

        if (!view)
            return null;

        selectionModel = view.getSelectionModel();
        selection = selectionModel.getSelection();

        if (selection.length)
            return selection[selection.length - 1];

        return null;
    }
});
Ext.define('WebClient.common.controller.EntityList', {
    extend: 'WebClient.common.controller.Entity',

    alias: ['widget.WebClient.common.controller.EntityList'],

    mixins: {
        standAlone: 'WebClient.common.controller.StandAloneControllerMixin',
        //interfaces
        'WebClient.common.controller.IList': 'WebClient.common.controller.IList'
    },

    requires: [
        'WebClient.common.commands.Close'
    ],

    /**
     * {@link WebClient.common.dataServices.DataServiceProxy} из которого контроллер берет мета информацию, а также серверные методы для CRUD операций
     * @type WebClient.common.dataServices.DataServiceProxy 
     */
    dataServiceProxy: undefined,

    /**
     * Вызывать редактирование при двойном клике на строчке
     * @type Boolean
     */
    editOnDblClick: undefined,

    constructor: function(cfg) {
        this.mixins.standAlone.constructor.call(this, cfg);
        this.callParent(arguments);

        if (!this.dataContext && !this.dataServiceProxy)
            Ext.Error.raise('ни dataContext ни dataServiceProxy не были переданы в авто controller для entity list');
        if (!this.dataContext)
            this.dataContext = this.dataServiceProxy.createDataContext();
    },

    /**
     * @override
     */
    getContainerCommandList: function() {
        return this.mode === WebClient.ListViewMode.BROWSE ? [new WebClient.common.commands.Close()] : [];
    },

    /**
     * @override
     */
    deriveStructureName: function() {
        return this.entityType + 'List';
    },

    /**
     * @override
     */
    adjustViewConfig: function() {
        this.callParent(arguments);
        this.viewBox.config = Ext.merge({ editOnDblClick: this.editOnDblClick }, this.viewBox.config);
    },

    /**
     * 
     * @param {Array} records массив записей
     */
    destroy: function(records) {
        var store = this.dataContext.takeStore(this.structureName);
        store.remove(records);

        //собираем изменения
        var changeSet = WebClient.common.data.change.SetCollector.collect(this.getDataContext());
        if (changeSet.isEmpty()) {
            WebClient.showError('Данные на форме не изменились');
            return;
        }

        new WebClient.common.data.DataContextProxy().commit(
            changeSet,
            this.dataServiceProxy.getCommitMethod(),
            {
                entityType: this.entityType
            },
            this.loadData,
            this
        );
    },

    /**
     * @override
     */
    onInitialized: function () {
        var store = this.dataContext.takeStore(this.structureName);
        if (this.dataParams && this.dataParams.filters)
            store.addFilter(this.dataParams.filters);

        if (this.dataParams && this.dataParams.sorters)
            store.setSorters(this.dataParams.sorters);

        if (this.dataParams && this.dataParams.page)
            store.currentPage = this.dataParams.page;
    },

    loadData: function() {
        var store = this.dataContext.takeStore(this.structureName);
        if (store.isLoading() || (store instanceof Ext.data.TreeStore)) //иерархический store автоматически начинает грузить данные рутового нода
            return;

        store.load();
    }
});
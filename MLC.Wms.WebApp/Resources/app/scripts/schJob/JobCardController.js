Ext.define('MLC.wms.schJob.JobCardController', {
    extend: 'WebClient.common.controller.EntityCard',

    requires: [
        'WebClient.common.dataServices.DataServiceProxy',
        'WebClient.common.filters.FilterBinder'
    ],

    mixins: {
        standAlone: 'WebClient.common.controller.StandAloneControllerMixin',
        //interfaces
        'WebClient.common.controller.IList': 'WebClient.common.controller.IList'
    },

    refs: {
        jobparamgrid: '#jobparamgrid',
        jobType: '#jobType',
        jobCode: '#jobCode'
    },

    constructor: function (cfg) {
        this.mixins.standAlone.constructor.call(this, cfg);
        var dataServiceProxy = new WebClient.common.dataServices.DataServiceProxy({
            actionName: 'WMS.DataServices.Job.DataService',
            modelName: 'SchJob'
        });

        var defaultConfig =
            {
                viewBox: WebClient.lazy('MLC.wms.schJob.JobCard'),
                structureName: 'SchJobCard',
                dataServiceProxy: dataServiceProxy
            };

        cfg = Ext.merge(defaultConfig, cfg);

        this.callParent([cfg]);
    },

    onViewCreated: function () {
        var me = this,
            jobTypeItem = me.getJobType(),
            jobCodeItem = me.getJobCode();

        jobTypeItem.readOnly = jobCodeItem.readOnly = me.mode !== WebClient.CardViewMode.CREATE;
        me.callParent(arguments);
    },

    loadData: function () {
        var me = this;
        me.callParent(arguments);
        var paramStore = me.dataContext.takeStore('SchJobParamList'),
            cronStore = me.dataContext.takeStore('SchCronTriggerList'),
            simpleStore = me.dataContext.takeStore('SchSimpleTriggerList'),
            jobParamFilter = new Ext.util.Filter({
                itemId: 'Job',
                property: 'Job',
                operator: WebClient.FilterOps.EQ
            });

        jobParamFilter.setValue([me.dataParams.id]);
        paramStore.addFilter(jobParamFilter);
        paramStore.load();

        cronStore.addFilter(jobParamFilter);
        cronStore.load();

        simpleStore.addFilter(jobParamFilter);
        simpleStore.load();
    },

    destroy: function (records) {

        var storeParam = this.dataContext.takeStore('SchJobParamList');
        storeParam.remove(records);

        var storeCron = this.dataContext.takeStore('SchCronTriggerList');
        storeCron.remove(records);

        var storeSimple = this.dataContext.takeStore('SchSimpleTriggerList');
        storeSimple.remove(records);


        //собираем изменения
        var changeSet = WebClient.common.data.change.SetCollector.collect(this.getDataContext());
        new WebClient.common.data.DataContextProxy().commit(
            changeSet,
            this.dataServiceProxy.getCommitMethod(),
            {
                entityType: this.entityType
            },
            function () {
                this.loadData();
            },
            this
        );
    }
});
Ext.define('WebClient.common.controller.EntityCard', {
    extend: 'WebClient.common.controller.Entity',

    alias: ['widget.WebClient.common.controller.EntityCard'],

    mixins: {
        standAlone: 'WebClient.common.controller.StandAloneControllerMixin',
        //interfaces
        'WebClient.common.controller.ICard': 'WebClient.common.controller.ICard'
    },

    requires: [
        'WebClient.common.controls.FormPanelHelper',
        'WebClient.common.data.change.SetCollector',
        'WebClient.common.data.DataContextProxy',
        'WebClient.common.util.doT',
        'WebClient.common.commands.Reload',
        'WebClient.common.commands.Save',
        'WebClient.common.commands.Ok',
        'WebClient.common.commands.Cancel',
        'WebClient.common.commands.Close'
    ],

    /**
     * {@link WebClient.common.dataServices.DataServiceProxy} из которого контроллер берет мета информацию, а также серверные методы для CRUD операций
     * @type WebClient.common.dataServices.DataServiceProxy 
     */
    dataServiceProxy: undefined,

    /**
     * Callback при сохранении, срабатывает если карточка в отдельном окне, можно подписать обновление списка
     * @type Function
     */
    ////TO BE REPLACED WITH EVENT. ANALYSE USAGE
    onSave: undefined,

    /**
     * Шаблон для заголовка карточки.
     * @private
     * @type Function
     */
    cardTitleFn: undefined,

    constructor: function(cfg) {
        this.mixins.standAlone.constructor.call(this, cfg);
        this.callParent(arguments);

        if (!this.dataContext && !this.dataServiceProxy)
            Ext.Error.raise('ни dataContext ни dataServiceProxy не были переданы в авто controller для entity card');

        if (!this.dataContext)
            this.dataContext = this.dataServiceProxy.createDataContext();
    },

    /**
     * @override
     */
    getContainerCommandList: function() {
        var isEditable = this.mode != WebClient.CardViewMode.VIEW;
        if (isEditable)
            return [
                new WebClient.common.commands.Reload({ handler: this.reload, scope: this }),
                new WebClient.common.commands.Save({ handler: this.save, scope: this }),
                new WebClient.common.commands.Ok({ handler: this.save, scope: this }),
                new WebClient.common.commands.Cancel()
            ];
        else
            return [
                new WebClient.common.commands.Reload({ handler: this.reload, scope: this }),
                new WebClient.common.commands.Close()];
    },

    /**
     * @override
     */
    deriveStructureName: function() {
        return this.entityType + 'Card';
    },

    /**
     * @override
     */
    onInitialized: function () {
        var structure = this.getDataContext().getModel().getStructure(this.structureName);
        this.cardTitleFn = structure.prototype.title ? WebClient.common.util.doT.compile(structure.prototype.title) : null;
        this.callParent(arguments);
    },

    /**
     * @override
     */
    onViewDisplayed: function() {
        this.callParent(arguments);
        var editableFields = Ext.ComponentQuery.query('field:not(hiddenfield)[disabled=false][readOnly=false]', this.view);
        if (editableFields && editableFields.length)
            editableFields[0].focus(true, 200);
    },

    /** @override */
    loadData: function() {
        var store = this.getDataContext().takeStore(this.structureName);
        WebClient.common.controls.FormPanelHelper.takeMaskForPanelAndBindToStore(this.view, store);

        if (this.mode == WebClient.CardViewMode.EDIT || this.mode == WebClient.CardViewMode.VIEW) {
            Assert.notEmpty(this.dataParams, 'this.dataParams');
            Assert.notEmpty(this.dataParams.id, 'this.dataParams.id');

            store.load({
                params: this.dataParams,
                scope: this,
                callback: this.loadDataCallback
            });
        } else if (this.mode == WebClient.CardViewMode.CREATE) {
            var modelClass = store.model;
            var rec = new modelClass(this.dataParams ? this.dataParams.defaultValues : {});
            rec.setId(null);
            store.add(rec);
            if (this.cardTitleFn)
                this.view.setTitle(this.cardTitleFn(rec.getData()));
            this.view.getForm().loadRecord(rec);
            this.view.getForm().isValid(); // для отображения невалидных полей
        } else
            Ext.Error.raise('Mode ' + this.mode + ' is not supported');
    },


    loadDataCallback: function (records, operation, success) {
        if (this.cardTitleFn && records.length > 0)
            this.view.setTitle(this.cardTitleFn(records[0].getData()));
        WebClient.common.controls.FormPanelHelper.loadDataCallback(this.view, records, operation, success);
        this.view.getForm().isValid(); // для отображения невалидных полей
    },

    /*
     *  WebClient.common.controller.ICard REALIZATION  
     */
    save: function(successCallback, successScope, options) {
        var me = this;
        options = options || {};

        if (me.view.getForm().isValid()) {

            var form = me.view.getForm();
            var rec = form.getRecord();
            form.updateRecord(rec);

            //собираем изменения
            var changeSet = WebClient.common.data.change.SetCollector.collect(me.getDataContext());
            if (changeSet.isEmpty()) {
                WebClient.showError('Данные на форме не изменились');
                return;
            }

            var callOnSave = function () {
                me.callOnSave(successCallback, successScope);
                if (!form.isDestroyed) {
                    var fields = form.getFields();
                    fields.each(function (f) { f.resetOriginalValue(); });
                }
            };

            /////////////////////
            //TO BE REFACTORED //
            /////////////////////            
            var callback = options.success //it is function. To be refactored
                ? Ext.Function.createSequence(options.success, callOnSave)
                : callOnSave;

            //сохраняем изменения
            new WebClient.common.data.DataContextProxy().commit(
                changeSet,
                this.dataServiceProxy.getCommitMethod(),
                {
                    entityType: me.entityType
                },
                callback,
                me
            );
        }
    },

    callOnSave: function(successCallback, successScope) {
        if (this.onSave) {
            try {
                this.onSave();
            } catch (e) {
                Ext.log(e);
            }
        }
        Ext.callback(successCallback, successScope);
    },

    reload: function () {
        var me = this,
            form = me.view.getForm(),
            changeSet = WebClient.common.data.change.SetCollector.collect(me.getDataContext());

        if (!form.isDirty() && changeSet.isEmpty())
            me.loadData();
        else {
            Ext.MessageBox.show({
                title: 'Подтверждение',
                msg: 'Есть несохраненные изменения. Отменить их и обновить?',
                icon: Ext.MessageBox.QUESTION,
                buttons: Ext.MessageBox.YESNO,
                fn: function (buttonId) {
                    if (buttonId === 'yes')
                        me.loadData();
                }
            });
        }
    }
});
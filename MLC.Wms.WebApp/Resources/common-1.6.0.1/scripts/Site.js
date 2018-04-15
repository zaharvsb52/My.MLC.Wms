/**
 * @class WebClient.common.Site
 *
 * Контекстный сервис-локатор. Позволяет для любого компонента запросить текущий Site и 
 * через него нужный сервис - вернется сервис, максимально близкий по контексту для запрошенного компонента.
 * 
 * Site-ы образуют иерархию, через иерархию компонент. Некоторые компоненты могу быть связанны с Site-ом через метод {@link #asSite}. Рутовый Site связан с body HTML 
 * элементом, и он всегда является родителем Site-ов привязанных к компонентам без родителей (например window). 
 * 
 * Сайт привязывается к компоненту или HTML элементу {@link #belongsTo}. Все дочерние (внучатые...) компоненты могут обращаться к этому инстансу Site-а 
 * через статический метод {@link #getSite}.
 *  
 * Все интерфейсы, которые реализует {@link #belongsTo} становятся сразу доступны. Остальные нужно регистрировать через {@link #registerService}. Если 
 * запрашиваемый сервис неизвестен в текущем Site-е, система попытается найти сервис в родительском Site-е.
 * 
 * Также, можно привязать один Site к другому методом {@link #bindToSite} для того чтобы сервисы зарегистрированные в другом сайте стали доступны и в текущем   
 */
Ext.define('WebClient.common.Site', {

    /** 
     * @type Ext.util.Observable Также тип может быть Ext.Element
     */
    belongsTo: undefined,

    /** 
     * @private
     * @type Ext.util.MixedCollection 
     */
    myServiceMap: undefined,

    /**
     * @private 
     * @type Array
     * */
    boundToSites: undefined,


    constructor: function(cfg) {
        Ext.apply(this, cfg);
        Assert.notEmpty(this.belongsTo, 'this.belongsTo');
        this.myServiceMap = new Ext.util.MixedCollection();
        this.boundToSites = [];
    },


    /**
     * Возвращает реализацию запрошенного сервиса, или null если не зарегистрирован
     * @return Object
     * @param Class Интерфейс (сервис) реализация которого запрашивается 
     */
    tryGetService: function(serviceType) {
        serviceType = WebClient.getClassName(serviceType);
        var ret = this.getServiceAtMyLevel(serviceType);
        if (ret)
            return ret;
        else {
            var parentSite = this.getParent();
            return parentSite ? parentSite.tryGetService(serviceType) : null;
        }
    },

    /**
     * Возвращает реализацию запрошенного сервиса, или генерит ошибку если не зарегистрирован
     * @return Object
     * @param Class Интерфейс (сервис) реализация которого запрашивается 
     */
    getService: function(serviceType) {
        var ret = this.tryGetService(serviceType);
        if (!ret) {
            var sname = typeof serviceType === 'string' ? serviceType : Ext.getClassName(serviceType);
            Ext.Error.raise('Service "' + sname + '" was not found in ' + this.toString() + ' or in its parent sites');
        }
        return ret;
    },

    /**
     * Регистрирует реализацию указанного сервиса. Если запись с таким сервисом уже зарегистрирована - перетирает.  
     * @param  {Class} serviceType Класс или полное имя интерфейса 
     * @param {Object} service объект, реализующий этот интерфейс 
     */
    registerService: function(serviceType, service) {
        this.myServiceMap[WebClient.getClassName(serviceType)] = service;
    },

    /**
     * Подключает текущий Site к сервисам переданного. 
     * Удобно, когда нужно чтобы родительская панель предоставляла сервисы реально подключенные к вложенной панели; в этом случае
     * достаточно связать (bind) Site родительской панели (this) с Site-ом вложенной (переданной параметром).
     * Защиты от циклического связывания нет.    
     * @param {WebClient.common.Site} site
     */
    bindToSite: function(site) {
        Assert.notEmpty(site);
        Assert.isTrue(site !== WebClient.common.Site.root);

        var sites = this.boundToSites;
        if (!Ext.Array.contains(sites, site)) {
            if (Ext.isFunction(site.belongsTo.on)) //на случай, если site это не компонент
            {
                site.belongsTo.on({
                    destroy: this.onBoundSiteComponentDestroy,
                    scope: this,
                    site: site //for options in even handler
                });
            }
            sites.push(site);
        }
    },

    /**
     * @param {WebClient.common.Site} site
     * @param {boolean} siteBeingDestroyed optional
     */
    unbindFromSite: function(site, siteBeingDestroyed) {
        Assert.notEmpty(site, 'site');

        var sites = this.boundToSites,
            index = Ext.Array.indexOf(sites, site);

        if (index !== -1) {
            Ext.Array.erase(sites, index, 1);
            if (!siteBeingDestroyed) {
                site.belongsTo.un({
                    destroy: this.onBoundSiteComponentDestroy,
                    scope: this
                });
            }
        }
    },

    onBoundSiteComponentDestroy: function(cmp, options) {
        this.unbindFromSite(options.site, true);
    },

    /** @private */
    getServiceAtMyLevel: function(serviceName) {
        var ret = this.myServiceMap.get(serviceName);
        if (ret)
            return ret;
        else if (WebClient.implementsInterface(this.belongsTo, serviceName))
            return this.belongsTo;
        else if (this.boundToSites.length > 0) {
            Ext.Array.each(this.boundToSites, function(site) {
                ret = site.getServiceAtMyLevel(serviceName);
                if (ret)
                    return false; //stop iteration  
            });
        }

        return ret;
    },

    /** @private */
    getParent: function() {
        if (this === WebClient.common.Site.root)
            return null;

        if (!this.belongsTo.isComponent)
            Ext.Error.raise('Getting parent site from html element is not supported yet');

        var owner = this.belongsTo.ownerCt;
        return (owner) ? WebClient.common.Site.getSite(owner) : WebClient.common.Site.root;
    },

    toString: function() {
        return 'site[belongsTo = ' + Ext.getClassName(this.belongsTo) + ' id='
            + (this.belongsTo.getId ? this.belongsTo.getId() : this.belongsTo.id)
            + ']';
    },

    statics: {

        /** @private */
        SITE_FIELD_NAME: '__site',

        /** @private */
        QUERY: '*[__site]',

        /**
         * @type WebClient.common.Site
         */
        root: undefined,

        /**
         * @return {WebClient.common.Site}
         */
        getSite: function(componentOrElement) {
            if (!componentOrElement.isComponent)
                Ext.Error.raise('Getting site from html element is not supported yet');

            var ret = componentOrElement[this.SITE_FIELD_NAME];
            if (ret)
                return ret;

            var owner = componentOrElement.up(WebClient.common.Site.QUERY);
            return (owner) ? owner[WebClient.common.Site.SITE_FIELD_NAME] : this.root;
        },

        /**
         * 
         * @param {Ext.Component} getOrAttachTo
         * @return {WebClient.common.Site}
         */
        asSite: function(getOrAttachTo) {
            var ret = getOrAttachTo[this.SITE_FIELD_NAME];
            if (!ret) {
                ret = new WebClient.common.Site({ belongsTo: getOrAttachTo });
                getOrAttachTo[this.SITE_FIELD_NAME] = ret;
            }
            return ret;
        },

        isSite: function(componentOrElement) {
            return componentOrElement[this.SITE_FIELD_NAME];
        }
    }
}, function(cls) {
    cls.root = cls.asSite(Ext.getBody());
});
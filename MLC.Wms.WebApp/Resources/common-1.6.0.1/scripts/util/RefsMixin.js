/**
 * Mixin, позволяющий указывать "refs" в вашем классе так же, как и в {@link Ext.app.Controller#refs}.   
 */
Ext.define('WebClient.common.util.RefsMixin', {

    /**
     * @cfg {Object[]} refs
     * Array of configs to build up references to views on page. См. {@link Ext.app.Controller#refs}
     * 
     */

    /**
     * Функция, которая вернет root компонент, начиная с которого будет применяться selector, указанный в каждом ref.
     * Опционально. 
     * @type Function Ext.container.Container 
     */
    rootGetter: undefined,

    constructor: function(rootGetter) {
        var me = this;

        me.rootGetter = rootGetter;

        if (me.refs) {
            var refs = [];
            if (Ext.isObject(me.refs)) {
                for (var i in me.refs) {
                    refs.push({
                        ref: i,
                        selector: me.refs[i]
                    });
                }
            } else
                refs = Ext.Array.from(me.refs);

            var i = 0,
                length = refs.length,
                info,
                ref,
                fn;

            for (; i < length; i++) {
                info = refs[i];
                ref = info.ref;
                fn = 'get' + Ext.String.capitalize(ref);

                if (!me[fn])
                    me[fn] = Ext.Function.pass(me.getRef, [ref, info], me);
            }
        }
    },

    getRef: function(ref, info, config) {
        this.refCache = this.refCache || {};
        info = info || {};
        config = config || {};

        Ext.apply(info, config);

        if (info.forceCreate)
            return Ext.ComponentManager.create(info, 'component');

        var me = this,
            cached = me.refCache[ref];

        if (!cached) {

            var root = undefined;
            if (Ext.isFunction(me.rootGetter)) {
                root = me.rootGetter.call(me);
                if (!root)
                    Ext.Error.raise('Класс не вернул рутовый компонент (view), у которого должны запрашиваться компоненты для каждого ref в конфигурации класса "refs"');
            }

            me.refCache[ref] = cached = Ext.ComponentQuery.query(info.selector, root)[0];
            if (!cached) {
                if (info.autoCreate)
                    me.refCache[ref] = cached = Ext.ComponentManager.create(info, 'component');
                else
                    Ext.Error.raise('В элементе конфигурации класса "refs" указан selector на несуществующий компонент. ref: ' + WebClient.toDebugString(info));
            }
            if (cached) {
                cached.on('beforedestroy', function() {
                    me.refCache[ref] = null;
                });
            }
        }

        return cached;
    }

});
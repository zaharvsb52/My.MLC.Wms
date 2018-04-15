Ext.define('MLC.wf.type.Action', {
    extend: 'Ext.Action',

    mixins: [
        'Ext.mixin.Factoryable'
    ],

    alias: 'action.base',

    /**
     * @type Boolean
     */
    //disabled: false,

    /**
     * @type Boolean
     */
    //hidden: false,

    /**
     * @type Number
     */
    glyph: undefined,

    /**
     * @type String
     */
    //text: undefined,

    /**
     * @type String
     */
    code: undefined,

    /**
     * @type Boolean
     */
    ignoreValidation: false,

    /**
     * @type String
     */
    type: undefined,

    factoryConfig: {
        defaultType: 'wfaction',
        defaultProperty: 'type'
    }
});
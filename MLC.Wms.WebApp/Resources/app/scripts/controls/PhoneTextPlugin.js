/*!
 * MaskIt 1.0
 * Allan Brazute Alves (EthraZa)
 * http://www.ghsix.com.br/allan
 * 
 * ExtJs plugin to mask a form field
 */
Ext.define('MLC.wms.controls.PhoneTextPlugin', {
    extend: 'Ext.plugin.Abstract',

    mixin: 'Ext.util.Observable',

    alias: 'plugin.phonetextplugin',

    init: function (field) {
        if (!field.isFormField)
            return false;
        var hasFocus = false;
        this.setCmp(field);
        // Defaults
        Ext.applyIf(field, {
            /**
         * @cfg {String}
         * Word characters are word characters, 
         * numbers limit the max number 
         * and non word, numbers or the placeholder char are the mask it self. 
         * Default is '(999)999-99-99', Russian 10 digit phone number 
         */
            mask: '+7(###)###-##-##',
            template: '+7(___)___-__-__',
            /**
         * @cfg {Bool/String}
         * If set, it generally will be '_' and the field will be filled with the place holder plus the mask. 
         */
            placeholder: '_',
            /**
         * @cfg {RegEx}
         * The RegExp to remove the mask and return the value only characters. 
         * Default is /(\W|_)/g that take out any non word or number char plus the underscore. 
         */
            unmaskRe: /(\W|_)/g,
            /**
         * @cfg {Bool}
         * If true, the getValue method will return the unmasked value. Default is true
         */
            getUnmasked: true,
            /**
         * @cfg {Bool}
         * If true, it applies the value plus the mask to the field, 
         * the function maskIt will just return the value masked and do nothing to the field. Default is true.
         */
            applyValue: true
        });

        // Apply
        Ext.apply(field, {
            validationDelay: 0,
            validateOnBlur: false,

            getCursor: function () {
                var el = this.inputEl.dom;
                if (typeof (el.selectionStart) === "number") {
                    return el.selectionStart;
                } else if (document.selection && el.createTextRange) {
                    var range = document.selection.createRange();
                    range.collapse(true);
                    range.moveStart("character", -el.value.length);
                    return range.text.length;
                } else {
                    throw 'getCaretPosition() not supported';
                }
            },

            setCursor: function (pos) {
                if (!hasFocus)
                    return;
                var el = this.inputEl.dom;
                if (typeof (el.selectionStart) === "number") {
                    el.focus();
                    el.setSelectionRange(pos, pos);
                } else if (el.createTextRange) {
                    var range = el.createTextRange();
                    range.move("character", pos);
                    range.select();
                } else {
                    throw 'setCaretPosition() not supported';
                }
            },

            /**
         * @param {string} (optional) The string to be masked. Default to field raw value
         * @param {bool} (optional) If true the masked value will be set to the field, if false the masked value will be just returned
         * 
         * Apply the defined mask to a string.
         */
            maskIt: function (sValue, bApplyValue) {
                bApplyValue = (!Ext.isEmpty(bApplyValue)) ? bApplyValue : this.applyValue || false;
                sValue = (sValue) ? String(sValue) : this.unmaskIt(this.getRawValue());
                var shortValue = sValue.replace('+7', '');

                var vp = 0; //value position
                var mp = 0; //mask position
                var cp = 0; //increase cursor position in

                var r = ''; //return isValid
                var isPlaceHolder = false;

                while (r.length < this.mask.length) {
                    var mm = this.mask.charAt(mp); //get next mask char
                    var vv = shortValue.charAt(vp); //get next val char
                    if (mm !== '#') {
                        r += mm;
                        if (vp === 0 && (vv === '8' || vv === '7') && shortValue.length === 11) {
                            vp++;
                        }
                        if(!isPlaceHolder)
                            cp++;
                    } else {
                        if (vv !== null && vv !== '') {
                            r += vv;
                            vp++;
                            cp++;
                        } else {
                            r += this.placeholder;
                            isPlaceHolder = true;
                        }
                    }
                    mp++;
                }

                // Fire mask event passing scope, old value and new masked value
                if (bApplyValue) {
                    try {
                        this.suspendCheckChange = 1;
                        this.setRawValue(this.unmaskIt(r));
                        this.setValue(r);
                        this.setCursor(cp);
                    } catch (err) {
                    } finally {
                        this.suspendCheckChange = 0;
                    }
                    return true;
                } else {
                    return r;
                }
            },

            /**
         * @param {string} The string to be unmasked
         * 
         * Replace a string mask characters with "" (empty) using the defined unmaskRe RegExp.
         */
            unmaskIt: function (sValue) {
                var result = (Ext.isString(sValue)) ? sValue.replace(this.unmaskRe, '') : '';
                if (result !== null && result !== '' && result[0] === '7')
                    result = "+" + result;
                return result === '+7' ? '' : result;
            },

            extGetValue: field.getValue,

            getValue: function () {
                return (this.getUnmasked) ? this.unmaskIt(this.extGetValue()) : this.extGetValue();
            }
        });

        Ext.override(field, {

            validate: function () {
                this.maskIt();
                return this.callParent(arguments);
            },

            onFocus: function () {
                hasFocus = true;
                this.callParent(arguments);
                this.maskIt(this.getValue(), true);
            },

            onBlur: function () {
                hasFocus = false;
                var value = this.getValue();
                if (value === null || value === '') {
                    this.setValue(null);
                }
                this.callParent(arguments);
            }
        });
        
        return false;
    }
});
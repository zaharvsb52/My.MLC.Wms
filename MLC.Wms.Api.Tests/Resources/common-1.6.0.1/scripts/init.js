Ext.ns('WebClient.ViewKind');
WebClient.ViewKind.LIST = 'list';
WebClient.ViewKind.CARD = 'card';

Ext.ns('WebClient.ListViewMode');
WebClient.ListViewMode.BROWSE = 'browse';
WebClient.ListViewMode.SELECT = 'select';
WebClient.ListViewMode.LOOKUP = 'lookup';
WebClient.ListViewMode.UNDEFINED = undefined;
WebClient.ListViewMode.ANY = WebClient.ListViewMode.UNDEFINED;

Ext.ns('WebClient.CardViewMode');
WebClient.CardViewMode.EDIT = 'edit';
WebClient.CardViewMode.CREATE = 'create';
WebClient.CardViewMode.VIEW = 'view';
WebClient.CardViewMode.UNDEFINED = undefined;
WebClient.CardViewMode.ANY = WebClient.CardViewMode.UNDEFINED;

Ext.ns('WebClient.FilterOps');
/** Equal to */
WebClient.FilterOps.EQ = 'eq';
/** Not equal to */
WebClient.FilterOps.NOTEQ = 'noteq';
/** Greater than, > */
WebClient.FilterOps.GT = 'gt';
/** Greater than or equals to, >= */
WebClient.FilterOps.GTE = 'gte';
/** Less than, < */
WebClient.FilterOps.LT = 'lt';
/** Less than or equals to, <= */
WebClient.FilterOps.LTE = 'lte';
/** In list */
WebClient.FilterOps.IN = 'in';
/** NotIn list */
WebClient.FilterOps.NOTIN = 'notin';
/** Between */
WebClient.FilterOps.BTW = 'btw';
/** Like */
WebClient.FilterOps.LIKE = 'like';
/** Like wildcard*/
WebClient.FilterOps.LIKEW = 'likew';
/** Not like*/
WebClient.FilterOps.NOTLIKE = 'notlike';
/** Not like wildcard*/
WebClient.FilterOps.NOTLIKEW = 'notlikew';
/** field LIKE v[0] OR field LIKE v[1] ... */
WebClient.FilterOps.LIKELIST = 'likelist';
WebClient.FilterOps.LIKELISTW = 'likelistw';

Ext.ns('WebClient.ErrorSeverity');
WebClient.ErrorSeverity.WARNING = 4;
WebClient.ErrorSeverity.ERROR = 8;

Ext.require([
    'WebClient.common.Interface',
    'WebClient.common.resource.DirectMethodCall',
    'WebClient.common.resource.ObjectBox',
    'WebClient.common.resource.PostponedCall',
    'WebClient.common.resource.Script',
    'WebClient.common.resource.Loader'
]);


Ext.apply(WebClient, {
    INTERNAL_ERROR_MSG: 'Произошла внутренняя ошибка',

    /**
     * Признак что текущая веб страничка находится в режиме debug-а. 
     * Сейчас это так, если query string (http://en.wikipedia.org/wiki/Query_string) текущего url 
     * браузера содержит слово debug 
     */
    isDebugMode: function() {
        return window.location.search.indexOf('debug') >= 0;
    },

    /**
     * {Boolean} False если copy to clipboard эмулируется через input диалог для пользователя
     */
    supportsDirectCopyToClipboard: !!window.clipboardData,

    notImplementedFn: function() { Ext.Error.raise('Функционал не реализован'); },

    notSupportedFn: function(subject) { Ext.Error.raise((subject || 'Функционал') + ' не поддерживается'); },

    /**
     * Возвращает значение свойства оъекта по переданному пути
     */
    getByPath: function(obj, path) {
        var paths = path.split('.'),
            current = obj,
            i;

        for (i = 0; i < paths.length; ++i) {
            if (current[paths[i]] == undefined)
                return undefined;
            else
                current = current[paths[i]];
        }
        return current;
    },

    /**
    * Возвращает ресурс для отложенного вызова Direct функции.
    * @param {Function} extDirectFn Direct-функция для вызова
    * @param {Object} args Хеш-массив параметров вызова direct-функции
    */
    postponedDirectMethodCall: function(extDirectFn, args) {
        return new WebClient.common.resource.DirectMethodCall(extDirectFn, args);
    },

    /**
     * Возвращает "ресурс", представляющий обертку над будущим объектом указанного класса. Объект будет создаваться используя указанный config.
     * При загрузки этого ресурса будет загружен указанный класс, если необходимо. 
     * @param {String} className
     * @param {Object} config optional
     * @return {WebClient.common.resource.ObjectBox}
     */
    lazy: function(className, config) {
        return new WebClient.common.resource.ObjectBox(className, config);
    },

    /**
     * Возвращает "ресурс", представляющий результат отложенного вызова функции.
     * Функция вызовется только один раз в момент чтения значения ресурса
     * @param {Function} fn
     * @param {} fnScope
     * @return {}
     */
    postponed: function(fn, fnScope, args) {
        return new WebClient.common.resource.PostponedCall(fn, fnScope, args);
    },

    /**
     * Возвращает "ресурс", представляющий js-сценарий. При загрузки этого ресурса будет загружен указанный сценарий. 
     */
    script: function(url) {
        return new WebClient.common.resource.Script(url);
    },

    /**
     * Возвращает загруженный объект ресурса, или сам переданный параметр (если это не ресурс). Используется для удобства 
     * классами, в которые могут передать живой объект, или ресурс на него.
     * @param {WebClient.common.resource.Resource/Object} resourceOrValue
     * @return {Object}
     */
    unbox: function(resourceOrValue) {
        return WebClient.common.resource.Resource.unbox(resourceOrValue);
    },

    /**
     * Вызывает загрузку переданных ресурсов, или ресурсов внутри свойств переданных объектов (иерархически).
     * Когда все ресурсы загружены, управление отдается в callback. 
     * @param {Object/Array/WebClient.common.resource.Resource} objectsOrResources
     * @param {Function} callback
     * @param {Object} callbackScope optional
     */
    require: function(objectsOrResources, callback, callbackScope) {
        WebClient.common.resource.Loader.require(objectsOrResources, callback, callbackScope);
    },

    /**
     * Тоже самое что и {@link Ext#getClassName} но на вход может принимать и строку-полное имя класса, возвращается она же.
     * @param {} classOrName
     * @return {}
     */
    getClassName: function(classOrName) {
        return typeof classOrName === 'string' ? classOrName : Ext.getClassName(classOrName);
    },

    /**
     * Возвращает признак реализует ли класс переданного объекта указанный интерфейс
     * @param {Object} obj
     * @param {string} interfaceClassOrName
     * @return {boolean}
     */
    implementsInterface: function(obj, interfaceClassOrName) {
        var iname = this.getClassName(interfaceClassOrName);
        var cls = Ext.getClass(obj);
        var mixins = cls.prototype.mixins;
        if (mixins) {
            if (mixins[iname])
                return true;

            for (var p in mixins) {
                if (p.substr(0, 'WebClient'.length) === 'WebClient') //go deep for our classes/interfaces
                {
                    if (this.implementsInterface(mixins[p], interfaceClassOrName))
                        return true;
                }
            }
        }

        return false;
    },

    defineInterface: function(interfaceName, config, createdFn) {
        config.extend = 'WebClient.common.Interface';
        Ext.define.apply(this, arguments);
    },

    concat: function(string1, string2, separator) {
        if (!string1)
            return string2;
        else if (!string2)
            return string1;
        else
            return string1 + separator + string2;
    },

    /**
     * Возвращает первый найденый элемент коллекции/массива согласно значению указанного свойства. Если не найдено - генерит исключение
     * @param {Ext.util.AbstractMixedCollection|Array} collectionOrArray
     * @param {string} property
     * @param {} value
     * @return {Object} найденный элемент
     */
    firstByProperty: function(collectionOrArray, property, value) {
        if (collectionOrArray instanceof Ext.util.AbstractMixedCollection) {
            var f = function(o) { return o && o[property] === value; };

            var idx = collectionOrArray.findIndexBy(f);
            if (idx < 0)
                Ext.Error.raise('Элемент со свойством "' + property + '" равным значению "' + value + '" не найден');
            return collectionOrArray.getAt(idx);
        } else if (Ext.isArray(collectionOrArray)) {
            for (var i = 0, l = collectionOrArray.length; i < l; i++) {
                if (collectionOrArray[i] && collectionOrArray[i][property] === value)
                    return collectionOrArray[i];
            }
            Ext.Error.raise('Элемент со свойством "' + property + '" равным значению "' + value + '" не найден');
        } else
            Ext.Error.raise('Переданный аргумент не является ни Ext.util.AbstractMixedCollection ни массивом. Аргумент: ' + collectionOrArray);
    },

    /**
     * Для каждого элемента коллекции/массива со значением указанного свойства запускает функцию
     * @param {Ext.util.AbstractMixedCollection|Array} collectionOrArray
     * @param {string} property
     * @param {} value
     */
    forEachByProperty: function(collectionOrArray, property, value, fn, fnScope) {
        var f = function(o) {
            if (o && o[property] === value)
                Ext.callback(fn, fnScope, [o]);
        };

        var arr;
        if (collectionOrArray instanceof Ext.util.AbstractMixedCollection)
            arr = collectionOrArray.items;
        else if (Ext.isArray(collectionOrArray))
            arr = collectionOrArray;
        else
            Ext.Error.raise('Переданный аргумент не является ни Ext.util.AbstractMixedCollection ни массивом. Аргумент: ' + collectionOrArray);

        Ext.Array.forEach(arr, f);
    },

    /** @private */
    lineBreaksRe: /(\r\n|\r|\n)/g,

    removeLineBreaks: function(text) {
        return text.replace(this.lineBreaksRe, '');
    },

    replaceLineBreaksWith: function(text, replaceWith) {
        return text.replace(this.lineBreaksRe, replaceWith);
    },

    replaceLineBreaksWithBr: function(text) {
        return this.replaceLineBreaksWith(text, '<br>');
    },

    /** 
     * Либо копирует в clipboard, если браузер поддерживает непосредственное копирование, либо открывает окно с текстом, где пользователь
     * может удобно выбрать текст и нажать CTRL+C 
     * @param {} text
     * @param {HtmlElement} animateTarget - id или объект html елемента, из которого анимировать окно (если оно используется)
     */
    copyToClipboard: function(text, animateTarget) {
        if (!text)
            return;

        if (window.clipboardData) //IE
            window.clipboardData.setData('Text', text);
        else {
            var w = new WebClient.common.error.DetailsWindow({
                text: text,
                title: 'Чтобы cкопировать в буффер, выделите текст и нажмите CTRL+C',
                animateTarget: animateTarget
            });
            w.show();
            w.focus();
        }
    },

    /**
     * Проверяет содержит ли объект хоть одно неунаследованное свойство
     * @param {Object} o
     */
    hasProperties: function(o) {
        for (var i in o) {
            if (o.hasOwnProperty(i))
                return true;
        }
        return false;
    },

    /**
     * Возвращает имя константы с заданным значением из указанного перечисления. Если не обнаружено, возвращает обратно значение
     * @param {} enumClass
     * @param {} value
     */
    getEnumName: function(enumClass, value) {
        for (p in enumClass) {
            if (enumClass[p] === value)
                return p;
        }
        return value;
    },

    /**
     * Возвращает объект содержащий параметры в query string (http://en.wikipedia.org/wiki/Query_string) текущего url браузера 
     * @return {Object}
     */
    getQueryStringParams: function() {
        return Ext.isEmpty(window.location.search) ? {} : Ext.urlDecode(window.location.search.substring(1));
    },

    /**
     * Показывает диалог с ошибкой, при помощи WebClient.common.error.MessageBox, если возможно, или window.alert если нет. 
     * @param {string} userMessage 
     * @param {string} technicalMessage @optional
     * @requires {WebClient.common.error.MessageBox}
     */
    showError: function(userMessage, technicalMessage) {
        if (Ext.ClassManager.isCreated('WebClient.common.error.MessageBox')) {
            WebClient.common.error.MessageBox.show({
                items: [
                    {
                        severity: WebClient.ErrorSeverity.ERROR,
                        userMessage: userMessage,
                        technicalMessage: technicalMessage
                    }
                ]
            });
        } else
            alert('ОШИБКА\r\n------------\r\n' + userMessage + (technicalMessage ? '\r\n------------\r\nТехнические детали:\r\n' + technicalMessage : ''));
    },

    /**
     * Показывает диалог с текстом, что произошла внутренняя ошибка. 
     * Используется в случаях, когда пользователю не будет пользы от текста настоящей ошибки. Однако технические детали, 
     * передаваемые в параметре, могут быть очень полезны службе поддержки. 
     * @param {string} technicalMessage
     */
    showInternalError: function(technicalMessage) {
        this.showError(this.INTERNAL_ERROR_MSG, technicalMessage);
    },

    /**
     * Функция, вызываемая при возникновении не пойманной JavaScript ошибки
     * @inner
     * @param {String} msg Текстовое описание ошибки, определяется браузером
     * @param {String} fileUrl Optional информация о файле в котором произошла ошибка
     * @param {Number} line Optional строка в вышеуказанном файле, где возникла ошибка
     */
    globalErrorHandler: function(msg, fileUrl, line) {
        this.showInternalError('Сообщение: ' + msg + '\r\nФайл: ' + fileUrl + '\r\nСтрока: ' + line);
        globalErrorBeingHandled = false;
    },

    toString: function(obj) {
        if (obj === undefined || obj === null)
            return '';
        return obj.toString();
    },

    /**
     * Возвращает значение параметра для вывода в debug сообщениях.
     * @param {Any} simpleOrObject
     * @return {String}
     */
    toDebugString: function(value) {
        if (!value)
            return value;

        if (Ext.isString(value))
            return value;

        return WebClient.ToDebugStringConvertor.encode(value);
    },

    /**
     * Возвращает функцию-обертку, которая вызывает исходную не чаще, чем указано в интервале
     * @param {Function} func функция, которую необходимо обернуть
     * @param {Object} scope
     * @param {Number} wait интервал вызова исходной функции
     * @param {Boolean} immediate
     * @return {Function} throttled
     */
    debounce: function (func, scope, wait, immediate) {
        var timeout, args, context, timestamp, result;

        var later = function () {
            var last = new Date().getTime() - timestamp;

            if (last < wait && last >= 0) {
                timeout = setTimeout(later, wait - last);
            } else {
                timeout = null;
                if (!immediate) {
                    result = func.apply(context, args);
                    if (!timeout) context = args = null;
                }
            }
        };

        return function () {
            context = scope || this;
            args = arguments;
            timestamp = new Date().getTime();
            var callNow = immediate && !timeout;
            if (!timeout) timeout = setTimeout(later, wait);
            if (callNow) {
                result = func.apply(context, args);
                context = args = null;
            }

            return result;
        };
    },

    /**
     * Merges any number of objects or arrays recursively without referencing them or their children.
     * @param {Object} destination The object into which all subsequent objects are merged.
     * @param {Object...} object Any number of objects to merge into the destination.
     * @return {Object} merged The destination object with all passed objects merged in.
     */
    mergeEx: function (destination) {
        var i = 1,
                ln = arguments.length,
                mergeFn = Ext.Object.merge,
                cloneFn = Ext.clone,
                arrayMergeFn = Ext.Array.merge,
                object, key, value, sourceKey;

        for (; i < ln; i++) {
            object = arguments[i];

            for (key in object) {
                value = object[key];
                if (value) {
                    if (value.constructor === Object) {
                        sourceKey = destination[key];
                        if (sourceKey && sourceKey.constructor === Object) {
                            mergeFn(sourceKey, value);
                        }
                        else {
                            destination[key] = cloneFn(value);
                        }
                    }
                    else if (value.constructor === Array) {
                        sourceKey = destination[key];
                        if (sourceKey && sourceKey.constructor === Array) {
                            destination[key] = arrayMergeFn(sourceKey, value);
                        }
                        else {
                            destination[key] = cloneFn(value);
                        }
                    } else {
                        destination[key] = cloneFn(value);
                    }
                }
                else {
                    destination[key] = value;
                }
            }
        }

        return destination;
    }
});


/**
 * Похож на JSON, однако русские символы не преобразует в уродские коды типа \u041c
 */
WebClient.ToDebugStringConvertor = new (function() {

    var pad = function(n) {
            return n < 10 ? '0' + n : n;
        },

        doEncode = function(o) {
            if (!Ext.isDefined(o) || o === null)
                return 'null';
            else if (Ext.isArray(o))
                return encodeArray(o);
            else if (Ext.isDate(o))
                return Ext.JSON.encodeDate(o);
            else if (Ext.isString(o))
                return encodeString(o);
            else if (typeof o == 'number')
                return isFinite(o) ? String(o) : 'null';
            else if (Ext.isBoolean(o))
                return String(o);
            else if (Ext.isObject(o)) {
                if (typeof o.toJSON === 'function') {
                    o = o.toJSON();
                    if (!o)
                        return null;
                }
                return encodeObject(o);

            } else if (typeof o === 'function')
                return 'null';
            return 'undefined';
        },
        m = {
            "\b": ' ',
            "\t": '\\t',
            "\n": '\\n',
            "\f": '\\f',
            "\r": '\\r',
            '"': '\'',
            "\\": '\\\\',
            '\x0b': '\\u000b'
        },
        charToReplace = /[\\\"\x00-\x1f]/g,
        encodeString = function(s) {
            return '"' + s.replace(charToReplace, function(a) {
                var c = m[a];
                return typeof c === 'string' ? c : '\\u' + ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
            }) + '"';
        },
        encodeArray = function(o) {
            var a = ['[', ''],

                len = o.length,
                i;
            for (i = 0; i < len; i += 1)
                a.push(doEncode(o[i]), ',');

            a[a.length - 1] = ']';
            return a.join('');
        },
        encodeObject = function(o) {
            var a = ['{', ''],
                i;
            for (i in o) {
                if (o.hasOwnProperty(i))
                    a.push(encodeString(i), ':', doEncode(o[i]), ',');
            }

            a[a.length - 1] = '}';
            return a.join('');
        };

    this.encode = doEncode;
})();


var globalErrorBeingHandled = false;
var currentErrorAlreadyHandled = false;
window.onerror = function(msg, fileUrl, line) {
    if (currentErrorAlreadyHandled) {
        currentErrorAlreadyHandled = false;
        return;
    }

    if (!globalErrorBeingHandled) {
        globalErrorBeingHandled = true;
        try {
            Ext.defer(WebClient.globalErrorHandler, 10, WebClient, [msg, fileUrl, line]);
        } catch (e) {
            globalErrorBeingHandled = false;
        }
    }
};

//Process debugMode
if (WebClient.isDebugMode()) {
    //set Ext.direct.RemotingProvider.maxRetries to 0 for debug mode
    Ext.direct.Manager.providers.on('add', function(i, o, k, e) {
        o.maxRetries = 0;
    });
}
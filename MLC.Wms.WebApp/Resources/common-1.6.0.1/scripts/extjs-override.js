// warnings:push:off

Ext.require('WebClient.common.error.DefaultHandlerProvider');

// Добавлено отображение ошибок в нашу консоль
Ext.apply(Ext, {
    log: (function () {

        var primitiveRe = /string|number|boolean/;
        function dumpObject(object, level, maxLevel, withFunctions) {
            var member, type, value, name, prefix, suffix,
                members = [];
            if (Ext.isArray(object)) {
                prefix = '[';
                suffix = ']';
            } else if (Ext.isObject(object)) {
                prefix = '{';
                suffix = '}';
            }
            if (!maxLevel) {
                maxLevel = 3;
            }
            if (level > maxLevel) {
                return prefix + '...' + suffix;
            }
            level = level || 1;
            var spacer = (new Array(level)).join('    ');
            for (name in object) {
                if (object.hasOwnProperty(name)) {
                    value = object[name];
                    type = typeof value;
                    if (type === 'function') {
                        if (!withFunctions) {

                            continue;
                        }
                        member = type;
                    } else if (type === 'undefined') {
                        member = type;
                    } else if (value === null || primitiveRe.test(type) || Ext.isDate(value)) {
                        member = Ext.encode(value);
                    } else if (Ext.isArray(value)) {
                        member = this.dumpObject(value, level + 1, maxLevel, withFunctions);
                    } else if (Ext.isObject(value)) {
                        member = this.dumpObject(value, level + 1, maxLevel, withFunctions);
                    } else {
                        member = type;
                    }
                    members.push(spacer + name + ': ' + member);
                }
            }
            if (members.length) {
                return prefix + '\n    ' + members.join(',\n    ') + '\n' + spacer + suffix;
            }
            return prefix + suffix;
        }
        function log(message) {
            var options, dump,
                con = Ext.global.console,
                level = 'log',
                indent = log.indent || 0,
                prefix, stack, fn, out, max;
            log.indent = indent;
            if (typeof message !== 'string') {
                options = message;
                message = options.msg || '';
                level = options.level || level;
                dump = options.dump;
                stack = options.stack;
                prefix = options.prefix;
                fn = options.fn;
                if (options.indent) {
                    ++log.indent;
                } else if (options.outdent) {
                    log.indent = indent = Math.max(indent - 1, 0);
                }
                if (dump && !(con && con.dir)) {
                    message += dumpObject(dump);
                    dump = null;
                }
            }
            if (arguments.length > 1) {
                message += Array.prototype.slice.call(arguments, 1).join('');
            }
            if (prefix) {
                message = prefix + ' - ' + message;
            }
            message = indent ? Ext.String.repeat(' ', log.indentSize * indent) + message : message;
            if (level !== 'log') {
                message = '[' + level.charAt(0).toUpperCase() + '] ' + message;
            }
            if (fn) {
                message += '\nCaller: ' + fn.toString();
            }
            /* BEGIN MODIFICATIONS */
            if (level === 'error') {
                if (WebClient.isDebugMode()) {
                    debugger;
                } else {
                    //Выставляем признак, чтобы в глобальном перехватчике ошибок не возникло еще одного сообщения
                    currentErrorAlreadyHandled = true;
                    WebClient.showInternalError(message);
                }
            }
            /* END MODIFICATIONS */
            if (con) {
                if (con[level]) {
                    con[level](message);
                } else {
                    con.log(message);
                }
                if (dump) {
                    con.dir(dump);
                }
                if (stack && con.trace) {
                    if (!con.firebug || level !== 'error') {
                        con.trace();
                    }
                }
            } else if (Ext.isOpera) {
                opera.postError(message);
            } else
            {
                out = log.out;
                max = log.max;
                if (out.length >= max) {
                    Ext.Array.erase(out, 0, out.length - 3 * Math.floor(max / 4));
                }
                out.push(message);
            }
            ++log.count;
            ++log.counters[level];
        }
        function logx(level, args) {
            if (typeof args[0] === 'string') {
                args.unshift({});
            }
            args[0].level = level;
            log.apply(this, args);
        }
        log.error = function() {
            logx('error', Array.prototype.slice.call(arguments));
        };
        log.info = function (){
            logx('info', Array.prototype.slice.call(arguments));
        };
        log.warn = function (){
            logx('warn', Array.prototype.slice.call(arguments));
        };
        log.count = 0;
        log.counters = {
            error: 0,
            warn: 0,
            info: 0,
            log: 0
        };
        log.indentSize = 2;
        log.out = [];
        log.max = 750;
        return log;
    }()) || (function() {
        var nullLog = function () { };
        nullLog.info = nullLog.warn = nullLog.error = Ext.emptyFn;
        return nullLog;
    }())
});

// По-умолчанию будем делать все поля Nullable
Ext.override(Ext.data.field.Field, {
    allowNull: true
});

// По-умолчанию формат ISO8601. Пример: 2000-02-13T21:25:33
Ext.override(Ext.data.field.Date, {
    dateFormat: 'c'
});

// Забыли локализовать
Ext.define('Ext.locale.ru.LoadMask', {
    override: 'Ext.LoadMask',
    msg: 'Загрузка...'
});

// Для поддержки кастомных настроек прокси (см. pagingUnsupported). Без нее кастомные настройки не переносятся на инстансы прокси.
Ext.override(Ext.data.proxy.Direct, {
    $configStrict: false
});

// Глобальный обработчик ошибок
Ext.mixin.Observable.observe(Ext.data.proxy.Direct);
Ext.data.proxy.Direct.on('exception', function (me, response, operation, opts) {
    var onError = me.onError;
    if (!Ext.isFunction(onError)) {
        var errorHandler = WebClient.common.error.DefaultHandlerProvider.getErrorHandler();
        onError = errorHandler.onError;
    }

    onError(response, operation);
});
// http://www.sencha.com/forum/showthread.php?291276-Ext.Factory-is-broken-on-type-after-it-is-made-observable
delete Ext.data.proxy.Direct.isInstance;

// Показ ошибок при загрузке файлов
var COULD_NOT_LOAD_RESOURCE_MSG = 'Необходимый ресурс не смог быть загружен с сервера. Возможно, сервер перегружен. \rПопробуйте обновить страницу браузера (клавиши CTRL+F5).';

var baseLoaderOnSuccess = Ext.Loader.onLoadSuccess;
Ext.override(Ext.Loader, {
    onLoadSuccess: function () {
        var loader = Ext.Loader;

        baseLoaderOnSuccess.apply(this, arguments);

        if (!loader.syncModeEnabled && !loader.scriptsLoading && loader.isLoading && !loader.hasFileLoadError) {
            var missingClasses = [],
                missingPaths = [],
                details;

            for (var missingClassName in loader.missingQueue) {
                missingClasses.push(missingClassName);
                missingPaths.push(loader.missingQueue[missingClassName]);
            }

            if (missingClasses.length) {
                details = 'Следующие типы не были объявлены, несмотря на то, что их файлы были загружены '
                    + missingClasses.join('", "') + '. Пожалуйста, проверьте объявление типов в связанных файлах: '
                    + missingPaths.join('", "');

                WebClient.showError(COULD_NOT_LOAD_RESOURCE_MSG, details);
            }
        }
    },

    onLoadFailure: function (loaderOptions) {
        var options = this,
            onError = options.onError;

        /* AFTER */
        var missingClasses = [],
            details;
        /* END AFTER */

        Ext.Loader.hasFileLoadError = true;
        --Ext.Loader.scriptsLoading;

        if (onError) {
            onError.call(options.userScope, options);
        } else {
            /* BEFORE
             Ext.log.error("[Ext.Loader] Some requested files failed to load.");
             */

            /* AFTER*/
            if (loaderOptions.entries) {
                for (var failIndex = 0; failIndex < loaderOptions.entries.length; failIndex++) {
                    if (loaderOptions.entries[failIndex].error)
                        missingClasses.push(loaderOptions.entries[failIndex].url);
                }

                if (missingClasses.length) {
                    details = 'Не удалось загрузить следующие типы: '
                        + missingClasses.join('", "') + '. Пожалуйста, проверьте существование данных типов.';

                    WebClient.showError(COULD_NOT_LOAD_RESOURCE_MSG, details);
                }
            }
            /* END AFTER */
        }
        Ext.Loader.checkReady();
    }
});

// Поменяли стандартные фильтры в дочерних сторах на наши
Ext.override(Ext.data.schema.Role, {
    createAssociationStore: function(session, from, records, isComplete) {
        var me = this,
            association = me.association,
            foreignKeyName = association.getFieldName(),
            isMany = association.isManyToMany,
            storeConfig = me.storeConfig,
            /* BEFORE
            id = from.getId(),
            */
            /* AFTER */
            id = Ext.isFunction(from.getEntityId) ? from.getEntityId() : from.getId(),
            /* END AFTER */
            config = {
                model: me.cls,
                role: me,
                session: session,
                associatedEntity: from,
                disableMetaChangeEvent: true,
                /* BEFORE
                pageSize: null,
                */
                /* AFTER */
                remoteSort: true,
                autoFilter: false,
                /* END AFTER */
                remoteFilter: true,
                trackRemoved: !session
            },
            store;
        if (isMany) {
            /* BEFORE
            config.filters = [
                {
                    property: me.inverse.field,
                    value: id,
                    exactMatch: true
                }
            ];
            */

            /* AFTER */
            config.filters = [new Ext.util.Filter({
                property: me.inverse.field,
                operator: WebClient.FilterOps.EQ,
                value: [id]
            })];
            /* END AFTER */
        } else if (foreignKeyName) {
            /* BEFORE
            config.filters = [
                {
                    property: foreignKeyName,
                    value: id,
                    exactMatch: true
                }
            */

            /* AFTER */
            config.filters = [new Ext.util.Filter({
                property: foreignKeyName,
                operator: WebClient.FilterOps.EQ,
                value: [id]
            })];
            /* END AFTER */
            config.foreignKeyName = foreignKeyName;
        }
        if (storeConfig) {
            Ext.apply(config, storeConfig);
        }
        store = Ext.Factory.store(config);
        me.onStoreCreate(store, session, id);
        if (foreignKeyName || (isMany && session)) {
            store.on({
                scope: me,
                add: 'onAddToMany',
                remove: 'onRemoveFromMany',
                clear: 'onRemoveFromMany'
            });
        }
        if (records) {
            store.loadData(records);
            store.complete = !!isComplete;
        }
        return store;
    }
});

// Ext.toolbar.Paging учим переходить на предыдущие страницы, если на текущей нет записей
Ext.override(Ext.toolbar.Paging, {
    updateInfo: function() {
        var me = this,
            displayItem = me.child('#displayItem'),
            store = me.store,
            pageData = me.getPageData(),
            count, msg;
        if (displayItem) {
            /* BEFORE
            count = store.getCount();
            */
            /* AFTER */
            count = store.getTotalCount();
            /* END AFTER */
            if (count === 0) {
                msg = me.emptyMsg;
            } else {
                msg = Ext.String.format(me.displayMsg, pageData.fromRecord, pageData.toRecord, pageData.total);
            }
            displayItem.setText(msg);
        }
    },
    onLoad: function() {
        var me = this,
            pageData, currPage, pageCount, afterText, count, isEmpty, item;
        /* BEFORE
        count = me.store.getCount();
        */
        /* AFTER */
        count = me.store.getTotalCount();
        /* END AFTER */
        isEmpty = count === 0;
        if (!isEmpty) {
            pageData = me.getPageData();
            currPage = pageData.currentPage;
            pageCount = pageData.pageCount;
            if (currPage > pageCount) {
                if (pageCount > 0) {
                    me.store.loadPage(pageCount);
                } else
                {
                    me.getInputItem().reset();
                }
                return;
            }
            afterText = Ext.String.format(me.afterPageText, isNaN(pageCount) ? 1 : pageCount);
        } else {
            currPage = 0;
            pageCount = 0;
            afterText = Ext.String.format(me.afterPageText, 0);
        }
        Ext.suspendLayouts();
        item = me.child('#afterTextItem');
        if (item) {
            item.setText(afterText);
        }
        item = me.getInputItem();
        if (item) {
            item.setDisabled(isEmpty).setValue(currPage);
        }
        me.setChildDisabled('#first', currPage === 1 || isEmpty);
        me.setChildDisabled('#prev', currPage === 1 || isEmpty);
        me.setChildDisabled('#next', currPage === pageCount || isEmpty);
        me.setChildDisabled('#last', currPage === pageCount || isEmpty);
        me.setChildDisabled('#refresh', false);
        me.updateInfo();
        Ext.resumeLayouts(true);
        if (!me.calledInternal) {
            me.fireEvent('change', me, pageData || me.emptyPageData);
        }
    }
});

// В версии 5.1.1 убрали настройку autoFilter, которая очень нужна для FilterBinder. Вернул.
Ext.override(Ext.data.AbstractStore, {
    onFilterEndUpdate: function() {
        var me = this,
            suppressNext = me.suppressNextFilter;
        if (me.autoFilter !== false) {
            if (me.getRemoteFilter()) {
                me.getFilters().each(function(filter) {
                    if (filter.getInitialConfig().filterFn) {
                        Ext.Error.raise('Unable to use a filtering function in conjunction with remote filtering.');
                    }
                });
                me.currentPage = 1;
                if (!suppressNext) {
                    me.attemptLoad();
                }
            } else {
                if (!suppressNext) {
                    me.fireEvent('datachanged', me);
                    me.fireEvent('refresh', me);
                }
            }
        }
        if (me.trackStateChanges) {
            me.saveStatefulFilters = true;
        }
        me.fireEvent('filterchange', me, me.getFilters().getRange());
    }
});

//Плавующая ошибка очистки layout. Решение взято из https://www.sencha.com/forum/showthread.php?181284
Ext.override(Ext.container.DockingContainer, {
    getDockedItems: function (selector, beforeBody) {
        if (typeof (this.getComponentLayout().getDockedItems) === 'function')
            return this.callOverridden([selector, beforeBody]);
        else
            return [];
    }
});

// warnings:pop
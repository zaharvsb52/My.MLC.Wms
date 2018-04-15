using System;
using System.Collections.Generic;
using System.Linq;

namespace MLC.Eps.Impl
{
    public class MacroProcessor : IMacroProcessor
    {
        #region .  Fields & Consts  .
        private const string MacroStart = "${";
        private const string MacroEnd = "}";

        private static readonly string[] KnownCodes = {
            "SYSUSERNAME", "SYSDOMAINNAME", "SYSMACHINENAME", "NEWLINE", "DATE", "LONGDATE", "TIME", "LONGTIME", "PATHDATE",
            "PATHTIME", "PATHLONGTIME", "PATHDATETIME", "SYSCURRENTDIRECTORY", "LISTGLOBALMACROSES", "GUID"
        };

        readonly Dictionary<string, string> _items;
        readonly Dictionary<string, Func<string, string>> _actions;
        #endregion

        public MacroProcessor()
        {
            _items = KnownCodes.ToDictionary(i => i, i => (string)null);
            _actions = new Dictionary<string, Func<string, string>>();
        }

        public virtual string Process(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            if (!source.Contains(MacroStart))
                return source;

            // запоминаем дату, чтобы во всех подстановка была одна и та же
            var currentDate = DateTime.Now;

            // даты прогоняем отдельно, т.к. возможен формат
            var res = ProcessDateMacroses(source, currentDate);

            // пробегаем по остальным макросам
            foreach (var item in _items)
            {
                var macroKey = MacroStart + item.Key + MacroEnd;
                if (res.Contains(macroKey))
                    res = res.Replace(macroKey, GetMacroValue(item.Key, currentDate));
            }

            // пробегаем по возможным дополнительным макросам
            if (_actions.Count > 0)
                res = _actions.Aggregate(res, ProcessAction);
            return res;
        }

        private string ProcessAction(string source, KeyValuePair<string, Func<string, string>> action)
        {
            var macroStart = MacroStart + action.Key;
            if (!source.Contains(macroStart))
                return source;

            var startIdx = source.IndexOf(macroStart);
            var endIdx = source.LastIndexOf(MacroEnd);
            var macroString = source.Substring(startIdx, endIdx - startIdx + 1);

            var macroResult = source.Replace(macroString, action.Value(macroString));
            // рекурсивно проверяем все ли поменяли
            return ProcessAction(macroResult, action);
        }

        private string ProcessDateMacroses(string source, DateTime currentDate)
        {
            var startPref = MacroStart + "DATE:";
            var startIdx = source.IndexOf(startPref, StringComparison.Ordinal);
            if (startIdx == -1)
                return source;

            // смещаем на длину преффикса
            startIdx += startPref.Length;

            var endIdx = source.IndexOf(MacroEnd, startIdx, StringComparison.Ordinal);
            if (endIdx == -1)
                throw new Exception("Ошибка в распознавании формата конвертации макроса DATE. Не найдено окончание макроса.");

            var format = source.Substring(startIdx, endIdx - startIdx);
            var data = currentDate.ToString(format);
            var res = source.Replace(string.Format("{0}{1}:{2}{3}", MacroStart, "DATE", format, MacroEnd), data);
            return ProcessDateMacroses(res, currentDate);
        }

        private string GetMacroValue(string macroKey, DateTime currentDate)
        {
            var value = _items[macroKey];
            if (value != null)
                return value;

            switch (macroKey)
            {
                case "SYSUSERNAME":
                    return Environment.UserName;

                case "SYSDOMAINNAME":
                    return Environment.UserDomainName;

                case "SYSMACHINENAME":
                    return Environment.MachineName;

                case "NEWLINE":
                    return Environment.NewLine;

                case "DATE":
                    return currentDate.ToShortDateString();

                case "LONGDATE":
                    return currentDate.ToLongDateString();

                case "TIME":
                    return currentDate.ToShortTimeString();

                case "LONGTIME":
                    return currentDate.ToLongTimeString();

                case "PATHDATE":
                    return currentDate.ToShortDateString();

                case "PATHTIME":
                    return currentDate.ToShortTimeString().Replace(":", ".");

                case "PATHLONGTIME":
                    return currentDate.ToLongTimeString().Replace(":", ".");

                case "PATHDATETIME":
                    return currentDate.ToShortDateString() + "-" + currentDate.ToShortTimeString().Replace(":", ".");

                case "SYSCURRENTDIRECTORY":
                    return Environment.CurrentDirectory;

                case "LISTGLOBALMACROSES":
                    return string.Join(";", _items
                        .Where(i => i.Key != "LISTGLOBALMACROSES")
                        .Select(i => string.Format("{0}={1}", i.Key, GetMacroValue(i.Key, currentDate))));

                case "GUID":
                    // В формате 32 цифры
                    return Guid.NewGuid().ToString("N");

                default:
                    throw new NotSupportedException(string.Format("Macro with key {0} is not supported.", macroKey));
            }
        }

        public virtual void Add(string key, string value)
        {
            _items.Add(key, value);
        }

        public virtual void Add(string key, Func<string, string> valueAction)
        {
            _actions.Add(key, valueAction);
        }

        public virtual void AddOrReplace(string key, Func<string, string> valueAction)
        {
            _actions[key] = valueAction;
        }

        public virtual IMacroProcessor GetChildProcessor()
        {
            var res = new MacroProcessor();
            foreach(var item in _items)
                if (!res._items.ContainsKey(item.Key))
                    res._items.Add(item.Key, item.Value);
            foreach (var action in _actions)
                if (!res._actions.ContainsKey(action.Key))
                    res._actions.Add(action.Key, action.Value);
            return res;
        }
    }
}
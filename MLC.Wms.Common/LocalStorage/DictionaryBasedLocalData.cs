using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using WebClient.Common.Utils;

namespace MLC.Wms.Common.LocalStorage
{
    /// <summary>
    /// Реализация локального хранилища на основе Dictionary.
    /// </summary>
    public abstract class DictionaryBasedLocalData : ILocalData
    {
        protected abstract IDictionary<object, object> LocalDictionary { get;}

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
        {
            foreach (var item in LocalDictionary)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Возвращает true, если для указанного ключа существует значение.
        /// </summary>
        public bool ContainsValueFor(object key)
        {
            Contract.Requires(key != null);
            return LocalDictionary.Keys.Contains(key);
        }

        private void EnsureValueExistsFor(object key)
        {
            if (!ContainsValueFor(key))
                throw new ArgumentException("Element not found.\r\nKey: {0}".FormatWith(key), "key");
        }

        /// <summary>
        /// Возвращает типизированное значение для указанного ключа. Если значения нет - вызывает ArgumentException.
        /// </summary>
        public T GetValueFor<T>(object key)
        {
            Contract.Requires(key != null);
            EnsureValueExistsFor(key);
            return (T) LocalDictionary[key];
        }

        /// <summary>
        /// Возвращает значение для указанного ключа. Если значения нет - вызывает ArgumentException.
        /// </summary>
        public object GetValueFor(object key)
        {
            Contract.Requires(key != null);
            EnsureValueExistsFor(key);
            return LocalDictionary[key];
        }

        /// <summary>
        /// Возвращает типизированное значение для указанного ключа. Если значения нет - возвращает переданное значение.
        /// </summary>
        public T GetValueForOrDefault<T>(object key, T defaultValue)
        {
            Contract.Requires(key != null);
            return !ContainsValueFor(key) ? defaultValue : GetValueFor<T>(key);
        }

        /// <summary>
        /// Возвращает типизированное значение для указанного ключа. Если значения нет - возвращает значение по-умолчанию.
        /// </summary>
        public T GetValueForOrDefault<T>(object key)
        {
            return GetValueForOrDefault(key, default(T));
        }

        /// <summary>
        /// Сохраняет значение по ключу.
        /// </summary>
        public void SetValueFor<T>(object key, T value)
        {
            Contract.Requires(key != null);
            LocalDictionary[key] = value;
        }

        /// <summary>
        /// Удаляет значение для ключа.
        /// </summary>
        public void RemoveValueFor(object key)
        {
            Contract.Requires(key != null);
            LocalDictionary.Remove(key);
        }

        /// <summary>
        /// Очищает хранилище.
        /// </summary>
        public void Clear()
        {
            LocalDictionary.Clear();
        }
    }
}
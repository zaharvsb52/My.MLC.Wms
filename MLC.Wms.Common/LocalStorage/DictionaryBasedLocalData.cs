using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using WebClient.Common.Utils;

namespace MLC.Wms.Common.LocalStorage
{
    /// <summary>
    /// ���������� ���������� ��������� �� ������ Dictionary.
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
        /// ���������� true, ���� ��� ���������� ����� ���������� ��������.
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
        /// ���������� �������������� �������� ��� ���������� �����. ���� �������� ��� - �������� ArgumentException.
        /// </summary>
        public T GetValueFor<T>(object key)
        {
            Contract.Requires(key != null);
            EnsureValueExistsFor(key);
            return (T) LocalDictionary[key];
        }

        /// <summary>
        /// ���������� �������� ��� ���������� �����. ���� �������� ��� - �������� ArgumentException.
        /// </summary>
        public object GetValueFor(object key)
        {
            Contract.Requires(key != null);
            EnsureValueExistsFor(key);
            return LocalDictionary[key];
        }

        /// <summary>
        /// ���������� �������������� �������� ��� ���������� �����. ���� �������� ��� - ���������� ���������� ��������.
        /// </summary>
        public T GetValueForOrDefault<T>(object key, T defaultValue)
        {
            Contract.Requires(key != null);
            return !ContainsValueFor(key) ? defaultValue : GetValueFor<T>(key);
        }

        /// <summary>
        /// ���������� �������������� �������� ��� ���������� �����. ���� �������� ��� - ���������� �������� ��-���������.
        /// </summary>
        public T GetValueForOrDefault<T>(object key)
        {
            return GetValueForOrDefault(key, default(T));
        }

        /// <summary>
        /// ��������� �������� �� �����.
        /// </summary>
        public void SetValueFor<T>(object key, T value)
        {
            Contract.Requires(key != null);
            LocalDictionary[key] = value;
        }

        /// <summary>
        /// ������� �������� ��� �����.
        /// </summary>
        public void RemoveValueFor(object key)
        {
            Contract.Requires(key != null);
            LocalDictionary.Remove(key);
        }

        /// <summary>
        /// ������� ���������.
        /// </summary>
        public void Clear()
        {
            LocalDictionary.Clear();
        }
    }
}
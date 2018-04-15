using System.Collections.Generic;

namespace MLC.Wms.Common.LocalStorage
{
    /// <summary>
    /// ���������, ��������� ��� ����� ��� �������.
    /// </summary>
    public interface ILocalData : IEnumerable<KeyValuePair<object, object>>
    {
        /// <summary>
        /// ���������� true, ���� ��� ���������� ����� ���������� ��������.
        /// </summary>
        bool ContainsValueFor(object key);

        /// <summary>
        /// ���������� �������������� �������� ��� ���������� �����. ���� �������� ��� - �������� ArgumentException.
        /// </summary>
        T GetValueFor<T>(object key);

        /// <summary>
        /// ���������� �������� ��� ���������� �����. ���� �������� ��� - �������� ArgumentException.
        /// </summary>
        object GetValueFor(object key);

        /// <summary>
        /// ���������� �������������� �������� ��� ���������� �����. ���� �������� ��� - ���������� �������� ��-���������.
        /// </summary>
        T GetValueForOrDefault<T>(object key);

        /// <summary>
        /// ���������� �������������� �������� ��� ���������� �����. ���� �������� ��� - ���������� ���������� ��������.
        /// </summary>
        T GetValueForOrDefault<T>(object key, T defaultValue);

        /// <summary>
        /// ��������� �������� �� �����.
        /// </summary>
        void SetValueFor<T>(object key, T value);

        /// <summary>
        /// ������� �������� ��� �����.
        /// </summary>
        void RemoveValueFor(object key);

        /// <summary>
        /// ������� ���������.
        /// </summary>
        void Clear();
    }
}
using System.Collections.Generic;

namespace MLC.Wms.Common.LocalStorage
{
    /// <summary>
    /// Хранилище, локальное для треда или запроса.
    /// </summary>
    public interface ILocalData : IEnumerable<KeyValuePair<object, object>>
    {
        /// <summary>
        /// Возвращает true, если для указанного ключа существует значение.
        /// </summary>
        bool ContainsValueFor(object key);

        /// <summary>
        /// Возвращает типизированное значение для указанного ключа. Если значения нет - вызывает ArgumentException.
        /// </summary>
        T GetValueFor<T>(object key);

        /// <summary>
        /// Возвращает значение для указанного ключа. Если значения нет - вызывает ArgumentException.
        /// </summary>
        object GetValueFor(object key);

        /// <summary>
        /// Возвращает типизированное значение для указанного ключа. Если значения нет - возвращает значение по-умолчанию.
        /// </summary>
        T GetValueForOrDefault<T>(object key);

        /// <summary>
        /// Возвращает типизированное значение для указанного ключа. Если значения нет - возвращает переданное значение.
        /// </summary>
        T GetValueForOrDefault<T>(object key, T defaultValue);

        /// <summary>
        /// Сохраняет значение по ключу.
        /// </summary>
        void SetValueFor<T>(object key, T value);

        /// <summary>
        /// Удаляет значение для ключа.
        /// </summary>
        void RemoveValueFor(object key);

        /// <summary>
        /// Очищает хранилище.
        /// </summary>
        void Clear();
    }
}
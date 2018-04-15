using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Exceptions
{
    /// <summary>
    /// Базовая ошибка процессов интеграции
    /// </summary>
    [Serializable]
    public class BaseIntegrationException : Exception
    {
        #region .  Ctors  .

        public BaseIntegrationException()
        {
        }

        public BaseIntegrationException(string message) : base(message)
        {
        }

        public BaseIntegrationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BaseIntegrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion

        /// <summary>
        /// Тип очереди, в которую должно записаться сообщение об ошибке
        /// </summary>
        public string QueueMessageTypeName { get; set; }

        #region Output error message parameters

        /// <summary>
        /// Uri, который должен записаться в сообщение об ошибке
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Selector, который должен записаться в сообщение об ошибке
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// Id клиента, который должен записаться в сообщение об ошибке
        /// </summary>
        public Guid? ClientID { get; set; }

        /// <summary>
        /// Код процесса, который должен записаться в сообщение об ошибке
        /// </summary>
        public string ProcessCode { get; set; }

        #endregion

        /// <summary>
        /// Делегат, который будет вызван после окончания обработки ошибки
        /// Костыль. Стараться не использовать
        /// Сейчас используется для "сделать еще что-нибудь" в workflow после обработки (н-р: записать событие)
        /// <remarks>Входной параметр - это сессия (ISession)</remarks>
        /// </summary>
        public Func<object, object> ActionHandler { get; set; }
    }
}
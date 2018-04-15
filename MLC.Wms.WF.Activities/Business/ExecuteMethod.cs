using System;
using System.Activities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using MLC.WF.Core.Common.Impl;
using MLC.WF.Core.Extensions.UnityWF;
using MLC.WF.Core.Helpers;

namespace MLC.Wms.WF.Activities.Business
{
    /// <summary>
    /// Активити, которая позволяет запускть методы класса TTarget
    /// Используется reflection
    /// </summary>
    /// <typeparam name="TTarget">Класс, методы которого нужно запустить</typeparam>
    public class ExecuteMethod<TTarget> : NativeActivity, IMethodContainer
        where TTarget : class
    {
        private static readonly ConcurrentDictionary<string, Lazy<MethodInfo>> MethodCache = new ConcurrentDictionary<string, Lazy<MethodInfo>>();

        #region .  Properties  .
        /// <summary>
        /// Наименование API.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Name { get; set; }

        /// <summary>
        /// Параметры API.
        /// </summary>
        public InArgument<Dictionary<string, object>> Parameters { get; set; }

        /// <summary>
        /// Ошибка.
        /// </summary>
        public OutArgument Exception { get; set; }
        //TODO: public OutArgument<Exception> Exception { get; set; }

        /// <summary>
        /// Результат исполнения.
        /// </summary>
        public OutArgument Result { get; set; }

        #endregion .  Properties  .

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            var collection = new Collection<RuntimeArgument>();

            AddCacheMetadata(collection, metadata, Name, "Name");
            AddCacheMetadata(collection, metadata, Parameters, "Parameters");
            AddCacheMetadata(collection, metadata, Exception, "Exception", false);
            AddCacheMetadata(collection, metadata, Result, "Result", false);

            metadata.SetArgumentsCollection(collection);
        }

        //fixed method from ActivityHelper
        public static void AddCacheMetadata(ICollection<RuntimeArgument> collection, NativeActivityMetadata metadata, Argument argument, string argumentname, bool isRequired = true)
        {
            RuntimeArgument runtimeArgument = new RuntimeArgument(argumentname, argument == null ? typeof(object) : argument.ArgumentType, argument == null ? ArgumentDirection.In : argument.Direction, isRequired);
            metadata.Bind(argument, runtimeArgument);
            collection.Add(runtimeArgument);
        }

        protected override void Execute(NativeActivityContext context)
        {
            var methodName = Name.Get(context);
            var parameters = Parameters.Get(context);

            var api = CreateTarget(context);

            try
            {
                var methodInfo = GetMethod(typeof (TTarget), methodName);
                var methodParams = methodInfo.GetParameters();

                var args = new List<object>();
                foreach (var p in methodParams)
                {
                    args.Add(parameters != null && parameters.ContainsKey(p.Name)
                        ? parameters[p.Name]
                        : GetDafaultValue(p.ParameterType));
                }

                var resultValue = methodInfo.Invoke(api, args.ToArray());
                // если есть что и куда вернуть - возвращаем (иначе ничего не делаем. ругаться не нужно)
                if (methodInfo.ReturnType != typeof (void) && Result != null)
                    Result.Set(context, resultValue);
            }
            catch (Exception ex)
            {
                // если контейнер для ошибки не передали - срубаем прямо здесь
                if (Exception == null)
                    throw;

                // заполняем контейнер ошибки
                if (ex is TargetInvocationException && ex.InnerException != null)
                    Exception.Set(context, ex.InnerException);
                else
                    Exception.Set(context, ex);
            }
        }

        protected virtual TTarget CreateTarget(NativeActivityContext context)
        {
            return context.GetDependency<TTarget>();
        }

        private object GetDafaultValue(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null;
        }

        MethodInfo[] IMethodContainer.GetMethods()
        {
            return typeof (TTarget).GetMethods();
        }

        /// <summary>
        /// Получение метода по имени
        /// NOTE: не учитывает возможности переопределения методов!!!
        /// </summary>
        private static MethodInfo GetMethod(Type type, string methodName)
        {
            var key = string.Format("{0}.{1}", type.FullName, methodName);
            return MethodCache.GetOrAddSafe(key, k => type.GetMethod(methodName));
        }
    }
}

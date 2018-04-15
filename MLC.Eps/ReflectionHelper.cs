using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace MLC.Eps
{
    /// <summary>
    /// <remarks>Забрал данный класс из WebClient. Чтобы не делать лишних ссылок</remarks>
    /// </summary>
    internal static class ReflectionHelper
    {
        private static readonly Type[] NoClasses = Type.EmptyTypes;

        public static bool IsNumeric(this Type type)
        {
            Contract.Requires(type != null);

            type = type.GetNonNullableType();
            if (!type.IsEnum)
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.SByte:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        return true;
                }
            }
            return false;
        }

        public static Type GetNonNullableType(this Type type)
        {
            Contract.Requires(type != null);

            if (type.IsNullableType())
                return type.GetGenericArguments()[0];
            return type;
        }

        public static bool IsNullableType(this Type type)
        {
            Contract.Requires(type != null);

            return (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }

        public static ConstructorInfo GetDefaultConstructor(Type type)
        {
            if (IsAbstractClass(type))
                return (ConstructorInfo)null;
            try
            {
                return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.HasThis, NoClasses, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Конструктор по-умолчанию не найден для типа: " + type.FullName, ex);
            }
        }

        public static bool IsAbstractClass(Type type)
        {
            if (!type.IsAbstract)
                return type.IsInterface;
            else
                return true;
        }

        public static object ConvertTo(this object obj, Type toType)
        {
            Contract.Requires(toType != null);

            if (toType.IsInstanceOfType(obj))
                return obj;

            if (toType.IsNullableType())
            {
                if (obj == null)
                    return null;

                toType = Nullable.GetUnderlyingType(toType);
            }

            var s = obj as string;

            if (s != null && toType == typeof(Guid))
                return new Guid(s);

            if (toType.IsEnum)
                return s != null ? Enum.Parse(toType, s) : Enum.ToObject(toType, obj);

            return Convert.ChangeType(obj, toType);
        }

        public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider from)
        {
            TAttribute attr;
            if (!TryGetAttribute<TAttribute>(from, out attr))
            {
                throw new InvalidOperationException("No attributes of type " +
                                                    typeof(TAttribute).FullName + " are defined at ICustomAttributeProvider " +
                                                    TryGetName(from));
            }
            return attr;
        }

        /// <summary>
        /// May return null if the attribute is not found
        /// </summary>
        public static TAttribute TryGetAttribute<TAttribute>(this ICustomAttributeProvider from)
        {
            TAttribute foundAttribute;
            TryGetAttribute(from, out foundAttribute);
            return foundAttribute;
        }


        public static bool HasAttribute<TAttribute>(this ICustomAttributeProvider from)
        {
            TAttribute foundAttribute;
            return TryGetAttribute(from, true, out foundAttribute);
        }

        public static bool TryGetAttribute<TAttribute>(this ICustomAttributeProvider from, out TAttribute foundAttribute)
        {
            return TryGetAttribute(from, true, out foundAttribute);
        }

        public static bool TryGetAttribute<TAttribute>(this ICustomAttributeProvider from, bool inherit, out TAttribute foundAttribute)
        {
            return TryGetAttribute<TAttribute>(from, inherit, null, out foundAttribute);
        }

        public static bool TryGetAttribute<TAttribute>(
            this ICustomAttributeProvider from,
            bool inherit,
            Func<TAttribute, bool> filter,
            out TAttribute foundAttribute)
        {
            return TryGetAttribute<TAttribute>(from, inherit, filter, null, out foundAttribute);
        }

        public static bool TryGetAttribute<TAttribute>(
            this ICustomAttributeProvider from,
            bool inherit,
            Func<TAttribute, bool> filter,
            Func<TAttribute, bool> alternativeFilter,
            out TAttribute foundAttribute)
        {
            return TryGetAttribute<TAttribute>
                (
                    from,
                    from.GetCustomAttributes(typeof(TAttribute), inherit),
                    filter,
                    alternativeFilter,
                    out foundAttribute
                );
        }

        /// <param name="from"></param>
        /// <param name="memberAttrs"></param>
        /// <param name="filter"></param>
        /// <param name="alternativeFilter">If specified, then attribute by the first filter will be sought first,
        ///  and if not found, then by alternative. This parameter is considered only if filter is not null</param>
        /// <param name="foundAttribute"></param>
        public static bool TryGetAttribute<TAttribute>(
            this ICustomAttributeProvider from,
            object[] memberAttrs,
            Func<TAttribute, bool> filter,
            Func<TAttribute, bool> alternativeFilter,
            out TAttribute foundAttribute)
        {
            Contract.Requires(from != null);
            Contract.Requires(memberAttrs != null);

            foundAttribute = default(TAttribute);

            if (memberAttrs.Length > 1)
            {
                if (filter == null)
                {
                    throw new InvalidOperationException("More than one attribute of type " +
                                                        typeof(TAttribute).FullName + " are defined at ICustomAttributeProvider " +
                                                        TryGetName(from));
                }

                bool found = false;
                bool alternativeFilterFound = false;
                TAttribute altAttr = default(TAttribute);
                foreach (TAttribute attr in memberAttrs)
                {
                    if (filter(attr))
                    {
                        if (found)
                        {
                            throw new InvalidOperationException("More than one attribute of type " +
                                                                typeof(TAttribute).FullName +
                                                                " matching the same criteria are defined at ICustomAttributeProvider " +
                                                                TryGetName(from));
                        }

                        foundAttribute = attr;
                        found = true;
                    }
                    else if (alternativeFilter != null && alternativeFilter(attr))
                    {
                        if (alternativeFilterFound)
                        {
                            throw new InvalidOperationException("More than one attribute of type " +
                                                                typeof(TAttribute).FullName +
                                                                " matching the same alternative criteria are defined at ICustomAttributeProvider " +
                                                                TryGetName(from));
                        }
                        alternativeFilterFound = true;
                        altAttr = attr;
                    }
                }

                if (!found && alternativeFilterFound)
                {
                    foundAttribute = altAttr;
                    return true;
                }

                return found;
            }
            else if (memberAttrs.Length == 1)
            {
                TAttribute attr = (TAttribute)memberAttrs[0];
                if (filter == null || (filter(attr) || (alternativeFilter != null && alternativeFilter(attr))))
                {
                    foundAttribute = attr;
                    return true;
                }
            }
            return false;
        }

        private static string TryGetName(ICustomAttributeProvider from)
        {
            Type t = from as Type;
            if (t != null)
                return t.FullName;
            else
            {
                MemberInfo m = from as MemberInfo;
                if (m != null)
                    return m.ReflectedType.FullName + "." + m.Name;
                else
                {
                    Assembly ass = from as Assembly;
                    if (ass != null)
                        return ass.FullName;
                    else
                        return from.ToString();
                }
            }
        }

        public static IList<string> GetMemberNames(Expression expression)
        {
            Contract.Requires(expression != null);
            Contract.Ensures(Contract.Result<IList<string>>() != null);

            var lambdaExpr = expression as LambdaExpression;
            if (lambdaExpr != null)
                expression = lambdaExpr.Body;

            var parts = new List<string>();
            while (true)
            {
                var memberExpression = expression as MemberExpression;
                if (memberExpression != null)
                {
                    if (memberExpression.Member.DeclaringType.IsNullableType() && memberExpression.Member.Name == "Value")
                    {
                        expression = memberExpression.Expression;
                        continue;
                    }
                    else
                    {
                        parts.Insert(0, memberExpression.Member.Name);
                        expression = memberExpression.Expression;
                        continue;
                    }
                }

                var unaryExpression = expression as UnaryExpression;
                if (unaryExpression != null)
                {
                    if (unaryExpression.NodeType == ExpressionType.Convert
                        || unaryExpression.NodeType == ExpressionType.ConvertChecked
                        || unaryExpression.NodeType == ExpressionType.TypeAs)
                    {
                        expression = unaryExpression.Operand;
                        continue;
                    }
                    else
                        throw new Exception("Cannot interpret member from " + expression);
                }

                if (expression is ParameterExpression)
                    return parts;

                throw new Exception("Could not determine member from " + expression);
            }
        }

        private static Type Substitute(Type t, IDictionary<Type, Type> env)
        {
            // We only really do something if the type 
            // passed in is a (constructed) generic type.
            if (t.IsGenericType)
            {
                var targs = t.GetGenericArguments();
                for (int i = 0; i < targs.Length; i++)
                    targs[i] = Substitute(targs[i], env); // recursive call
                t = t.GetGenericTypeDefinition();
                t = t.MakeGenericType(targs);
            }
            // see if the type is in the environment and sub if it is.
            return env.ContainsKey(t) ? env[t] : t;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace ClubArcada.Common
{
    public static class Extensions
    {
        public static T AddNew<T>(this ICollection<T> collection, T item)
        {
            collection.Add(item);
            return item;
        }

        public static void AddRange<T>(this ICollection<T> collection, ICollection<T> itemsCollection)
        {
            itemsCollection.ForEach(collection.Add);
        }

        public static T CastAs<T>(this object obj) where T : class
        {
            return obj as T;
        }

        public static void CastAs<T>(this object obj, Action<T> castAction) where T : class
        {
            obj.CastAs<T>().IsNotNull(castAction);
        }

        public static void CastAs<T>(this object obj, Action<T> castAction, Action<object> elseAction) where T : class
        {
            var castObject = obj.CastAs<T>();
            castObject.IsNotNull().True(() => castAction(castObject), () => elseAction(obj));
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static bool Contains<T>(this IEnumerable<T> ienumerable, Func<T, bool> predicate)
        {
            return ienumerable.FirstOrDefault(predicate).IsNotNull();
        }

        public static TB ConvertTo<TA, TB>(this TA a)
        {
            var nameA = typeof(TA).Name;
            var nameB = typeof(TB).Name;

            return a
                .SerializeComplexObject()
                .Replace("<" + nameA, "<" + nameB)
                .Replace("</" + nameA + ">", "</" + nameB + ">")
                .DeserializeComplexObject<TB>();
        }

        public static string ConvertToString(this Exception exception)
        {
            var prefix = "";

            var sb = new StringBuilder();

            while (null != exception)
            {
                sb.Append(prefix);
                sb.AppendLine(exception.Message);
                sb.AppendLine(exception.StackTrace);

                prefix = "Innner Exception: ";
                exception = exception.InnerException;
            }

            return sb.ToString();
        }

        public static List<T> CreateList<T>(this T item)
        {
            return new List<T> { item };
        }

        public static List<T> CreateListOrNull<T>(this T item)
        {
            return item.IsNull() ? null : new List<T> { item };
        }

        /// <summary>
        /// Only returns TRUE if the boolean HasValue AND is equal false
        /// </summary>
        /// <param name="boolean"></param>
        /// <param name="actionFalse"></param>
        /// <param name="actionTrue"></param>
        /// <param name="actionNull"></param>
        /// <returns></returns>
        public static bool False(this bool? boolean, Action actionFalse = null, Action actionTrue = null, Action actionNull = null)
        {
            if (boolean.HasValue && boolean.Value)
            {
                actionTrue.IsNotNull(a => a());
            }
            else if (boolean.HasValue)
            {
                actionFalse.IsNotNull(a => a());
            }
            else
            {
                actionNull.IsNotNull(a => a());
            }
            return boolean.HasValue && !boolean.Value;
        }

        public static bool False(this bool boolean, Action actionFalse = null, Action actionTrue = null)
        {
            if (boolean)
            {
                actionTrue.IsNotNull(a => a());
            }
            else
            {
                actionFalse.IsNotNull(a => a());
            }
            return boolean;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
                action(item);

            return sequence;
        }

        public static string GetExceptionDetails(this Exception ex)
        {
            var sb = new StringBuilder(128);

            for (var i = 0; ex != null; ex = ex.InnerException, i++)
            {
                if (i == 0)
                    sb.AppendFormat("\n\nException ({0}) :\n-----------------", ex.GetType());
                else
                    sb.AppendFormat("\n\nInner Exception ({0}) [{1}]:\n-----------------", ex.GetType(), i);

                // Message
                sb.Append("\nError Message: " + ex.Message);

                // Data
                if (ex.Data != null)
                {
                    var data = string.Empty;

                    foreach (DictionaryEntry de in ex.Data)
                        data += string.Format("\nThe key is: '{0}' and the value is: {1}", de.Key, de.Value);

                    if (data.IsNotNullOrEmpty())
                        sb.Append("\nError Data: " + data);
                }

                sb.Append("\n\nError Stack Trace:\n" + ex.StackTrace);
            }

            return sb.ToString();
        }

        public static T? GetNullableValue<T>(this PropertyInfo propertyInfo, object row) where T : struct
        {
            return propertyInfo.GetValue(row, null) as T?;
        }

        public static List<PropertyInfo> GetPropertiesOfType<T>(this Type propertyType, bool hasSetter = false)
        {
            var properties = propertyType.GetProperties().Where(p => p.PropertyType == typeof(T));

            if (hasSetter)
                properties = properties.Where(p => p.GetSetMethod().IsNotNull());

            return properties.ToList();
        }

        public static List<PropertyInfo> GetPropertiesWithInterface(this Type propertyType, bool hasSetter = false, params Type[] interfaces)
        {
            var properties = propertyType.GetProperties().Where(p => p.PropertyType.GetInterfaces().Any(interfaces.Contains));

            if (hasSetter)
                properties = properties.Where(p => p.GetSetMethod().IsNotNull());

            return properties.ToList();
        }

        public static PropertyInfo GetPropertyByName<T>(this Type propertyType, Expression<Func<T>> expression)
        {
            return propertyType.GetProperties().FirstOrDefault(p => p.Name == expression.GetPropertyName());
        }

        public static Type GetPropertyDeclaringType(this Expression expression)
        {
            while (!(expression is MemberExpression))
            {
                if (expression is LambdaExpression)
                    expression = ((LambdaExpression)expression).Body;
                else if (expression is UnaryExpression)
                    expression = ((UnaryExpression)expression).Operand;
            }
            return ((MemberExpression)expression).Member.DeclaringType;
        }

        public static string GetPropertyName(this Expression expression)
        {
            while (!(expression is MemberExpression))
            {
                if (expression is LambdaExpression)
                    expression = ((LambdaExpression)expression).Body;
                else if (expression is UnaryExpression)
                    expression = ((UnaryExpression)expression).Operand;
            }
            return ((MemberExpression)expression).Member.Name;
        }

        public static T GetValue<T>(this PropertyInfo propertyInfo, object row) where T : class
        {
            return propertyInfo.GetValue(row, null) as T;
        }

        public static Guid GetValue(this Guid? value, Guid defaultValue = new Guid())
        {
            return value.IsNotNullOrEmpty() ? value.Value : defaultValue;
        }

        public static T GetValue<T>(this T value, T defaultValue)
        {
            return value.IsNotNull() ? value : defaultValue;
        }

        public static T2 GetValue<T1, T2>(this T1 value, T2 nullValue, T2 notNullValue)
        {
            return value.IsNotNull() ? notNullValue : nullValue;
        }

        public static IEnumerable<T> If<T>(this IEnumerable<T> ienumerable, bool condition)
        {
            return condition ? ienumerable : new T[0];
        }

        public static IEnumerable<T> IfNotNull<T>(this IEnumerable<T> ienumerable)
        {
            return !ienumerable.IsNull() ? ienumerable : new T[0];
        }

        public static IEnumerable<T> IfNotNullOrEmpty<T>(this IEnumerable<T> ienumerable)
        {
            return !ienumerable.IsNull() && ienumerable.Any() ? ienumerable : new T[0];
        }

        public static bool In<T>(this T? enumerator, params T[] values) where T : struct, IConvertible
        {
            if (values.Length == 0)
                return false;

            return enumerator.IsNotNull() && values.Any(v => enumerator.Value.Equals(v));
        }

        public static int IndexOf<T>(this IEnumerable<T> ienumerable, Func<T, bool> predicate)
        {
            var foundIdx = -1;

            var idx = 0;
            foreach (var item in ienumerable)
            {
                if (predicate(item))
                {
                    foundIdx = idx;
                    break;
                }
                idx++;
            }
            return foundIdx;
        }

        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        public static bool IsNotEmpty(this Guid value)
        {
            return value != Guid.Empty;
        }

        public static bool IsNotNull<T>(this T obj)
        {
            return obj != null;
        }

        public static bool IsNotNull<T>(this T obj, Action<T> action)
        {
            if (obj.IsNotNull())
                action(obj);
            return obj.IsNotNull();
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> ienumerable)
        {
            return ienumerable.IsNotNull() && ienumerable.Any();
        }

        public static bool IsNotNullOrEmpty(this Guid? value)
        {
            return value.IsNotNull() && value.Value.IsNotEmpty();
        }

        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> ienumerable)
        {
            return ienumerable.IsNull() || !ienumerable.Any();
        }

        public static bool IsNullOrEmpty(this Guid? value)
        {
            return value.IsNull() || value.Value.IsEmpty();
        }

        public static T[] Iterate<T>(this T enumType) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return (
              from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
              where field.IsLiteral
              select (T)field.GetValue(null)
            ).ToArray();
        }

        public static void Raise<T>(this PropertyChangedEventHandler handler, Expression<Func<T>> propertyExpression)
        {
            if (handler != null)
            {
                var body = propertyExpression.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("'propertyExpression' should be a member expression");

                var expression = body.Expression as ConstantExpression;
                if (expression == null)
                    throw new ArgumentException("'propertyExpression' body should be a constant expression");

                object target = Expression.Lambda(expression).Compile().DynamicInvoke();

                var e = new PropertyChangedEventArgs(body.Member.Name);
                handler(target, e);
            }
        }

        public static void Raise(this PropertyChangedEventHandler helper, object thing, string name)
        {
            if (helper != null)
            {
                helper(thing, new PropertyChangedEventArgs(name));
            }
        }

        public static void Raise(this Action action)
        {
            action.IsNotNull(a => a());
        }

        public static void Raise<T>(this Action<T> action, T t)
        {
            action.IsNotNull(a => a(t));
        }

        public static void Raise<T1, T2>(this Action<T1, T2> action, T1 t1, T2 t2)
        {
            action.IsNotNull(a => a(t1, t2));
        }

        public static void SetValue<T>(this PropertyInfo propertyInfo, object row, T value)
        {
            propertyInfo.SetValue(row, value, null);
        }

        public static bool ToBool(this string value, bool defaultValue)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            bool result;
            return bool.TryParse(value, out result) ? result : defaultValue;
        }

        public static byte[] ToByteArray(this MemoryStream memoryStream)
        {
            var byteData = new byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(byteData, 0, byteData.Length);
            memoryStream.Close();

            return byteData;
        }

        public static int ToInt(this string value, int defaultValue)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static decimal? ToNullableDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            decimal result;
            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            return null;
        }

        public static string ToString<T>(this IEnumerable<T> ienumerable, string separator, int maxValues = -1)
        {
            if (maxValues > 0)
                return string.Join(separator, ienumerable.Take(maxValues)) + (ienumerable.Count() > maxValues ? separator + "..." : "");
            return string.Join(separator, ienumerable);
        }

        public static bool True(this bool? boolean, Action actionTrue = null, Action actionFalse = null, Action actionNull = null)
        {
            if (boolean.HasValue && boolean.Value)
            {
                actionTrue.IsNotNull(a => a());
            }
            else if (boolean.HasValue)
            {
                actionFalse.IsNotNull(a => a());
            }
            else
            {
                actionNull.IsNotNull(a => a());
            }
            return boolean.HasValue && boolean.Value;
        }

        public static bool True(this bool boolean, Action actionTrue = null, Action actionFalse = null)
        {
            if (boolean)
            {
                actionTrue.IsNotNull(a => a());
            }
            else
            {
                actionFalse.IsNotNull(a => a());
            }
            return boolean;
        }

        public static T Value<T>(this T? value, T defaultValue) where T : struct
        {
            return value.HasValue ? value.Value : defaultValue;
        }

        public static IEnumerable<T> WhereIsNotNull<T>(this IEnumerable<T> ienumerable)
        {
            return ienumerable.Where(i => i.IsNotNull());
        }

        public static string SerializeComplexObject<T>(this T source)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var reader = new StreamReader(memoryStream))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(memoryStream, source);
                    memoryStream.Position = 0;
                    return reader.ReadToEnd();
                }
            }
        }

        public static string SerializeComplexObject(this object source, Type type)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var reader = new StreamReader(memoryStream))
                {
                    var serializer = new DataContractSerializer(type);
                    serializer.WriteObject(memoryStream, source);
                    memoryStream.Position = 0;
                    return reader.ReadToEnd();
                }
            }
        }

        public static T DeserializeComplexObject<T>(this string xml)
        {
            using (var stream = new MemoryStream())
            {
                var data = Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                var deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(stream);
            }
        }

        public static object DeserializeComplexObject(this string xml, Type type)
        {
            using (var stream = new MemoryStream())
            {
                var data = Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                var deserializer = new DataContractSerializer(type);
                return deserializer.ReadObject(stream);
            }
        }

        public static string OptimizePhoneNumber(this string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return string.Empty;
            }
            else
            {
                if (phoneNumber.StartsWith("00421"))
                {
                    return phoneNumber.Trim().Replace(" ", string.Empty);
                }
                else if (phoneNumber.StartsWith("09"))
                {
                    return string.Format("00421{0}", phoneNumber.Remove(0, 1)).Replace(" ", string.Empty).Trim();
                }
                else
                {
                    return phoneNumber.Trim().Replace(" ", string.Empty);
                }
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}
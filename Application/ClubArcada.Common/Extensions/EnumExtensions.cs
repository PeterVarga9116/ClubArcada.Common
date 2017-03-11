using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ClubArcada.Common
{
    public static partial class EnumExtensions
    {
        public static bool NotIn<T>(this T enumerator, params T[] values)
             where T : struct, IConvertible
        {
            return !enumerator.In(values);
        }

        public static bool In<T>(this T enumerator, params T[] values)
             where T : struct, IConvertible
        {
            if (values.Length == 0)
                return false;

            return values.Any(v => enumerator.Equals(v));
        }

        public static T ToEnum<T>(this int value, T defaultValue)
            where T : struct
        {
            if (!Enum.IsDefined(typeof(T), value))
                return defaultValue;

            return (T)Enum.ToObject(typeof(T), value);
        }

        public static T ToEnum<T>(this string text, T defaultValue, bool ignoreCase = false)
            where T : struct
        {
            T value;
            var result = Enum.TryParse(text, ignoreCase, out value);
            return result ? value : defaultValue;
        }

        public static bool? ToNullableBool<T>(this T value, bool? defaultValue = null)
            where T : struct
        {
            if (!Enum.IsDefined(typeof(T), value))
                return defaultValue;

            var enumIntValue = (int)Enum.ToObject(typeof(T), value);

            if (enumIntValue.NotIn(0, 1))
                return defaultValue;

            return enumIntValue == 1;
        }

        public static T ToEnumFromDescription<T>(this string value, T defaultValue, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (ignoreCase && attribute.Description.ToLower() == value.ToLower())
                        return (T)field.GetValue(null);
                    if (attribute.Description == value)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value)
                        return (T)field.GetValue(null);
                }
            }

            return defaultValue;
        }

        public static string GetDescription<T>(this T enumerator)
        {
            var fi = enumerator.GetType().GetField(enumerator.ToString());
            var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().ToArray();

            if (attributes.Length > 0)
                return attributes.First().Description;
            return enumerator.ToString();
        }

        public static string GetDescription(this Enum enumerator)
        {
            var fi = enumerator.GetType().GetField(enumerator.ToString());
            var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().ToArray();

            if (attributes.Length > 0)
                return attributes.First().Description;
            return enumerator.ToString();
        }

        public static bool IsEnumValue<TEnum, T>(this T value)
            where TEnum : struct, IConvertible
            where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
        {
            return GetEnumValues<TEnum, T>().Any(value.Equals);
        }

        public static TEnum[] GetEnumValues<TEnum>()
            where TEnum : struct
        {
            return typeof(TEnum).GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => (TEnum)Enum.Parse(typeof(TEnum), fi.Name, false)).ToArray();
        }

        public static T[] GetEnumValues<TEnum, T>()
            where TEnum : struct, IConvertible
            where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var values = GetEnumValues<TEnum>();
            if (typeof(T) == typeof(char))
                return values.Select(e => (T)Convert.ChangeType(Convert.ToChar(e), typeof(T), CultureInfo.InvariantCulture)).ToArray();
            if (typeof(T) == typeof(int))
                return values.Select(e => (T)Convert.ChangeType(Convert.ToInt32(e), typeof(T), CultureInfo.InvariantCulture)).ToArray();
            return values.Select(e => (T)Convert.ChangeType(e, typeof(T), CultureInfo.InvariantCulture)).ToArray();
        }

        public static T[] GetEnums<T>()
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

        public static string[] GetEnumStrings<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return (
              from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
              where field.IsLiteral
              select field.Name
            ).ToArray();
        }

        public static bool EnumHasFlags<T>(this T value, T flags)
            where T : struct, IConvertible
        {
            var num = Convert.ToUInt64(flags);

            return ((Convert.ToUInt64(value) & num) == num);
        }

        public static string GetGameTypeColor(this eGameType item)
        {
            if (item.In(eGameType.CashGame))
                return "#013c9b";
            if (item.In(eGameType.DoubleChance))
                return "#00701d";
            if (item.In(eGameType.DoubleTrouble))
                return "#700059";
            if (item.In(eGameType.Final))
                return "#706200";
            if (item.In(eGameType.Freeroll))
                return "#703900";
            if (item.In(eGameType.FreezeOut))
                return "#1c0070";
            if (item.In(eGameType.QualFinal))
                return "#706200";
            if (item.In(eGameType.Qualification))
                return "#345266";
            if (item.In(eGameType.RebuyLimited))
                return "#67007a";
            if (item.In(eGameType.RebuyUnlimited))
                return "#773d00";
            if (item.In(eGameType.TripleChance))
                return "#7a0000";

            return "#FFFFFF";
        }
    }
}
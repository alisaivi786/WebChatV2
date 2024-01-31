using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebChat.Extension.Extensions
{
    public static partial class Ext
    {

        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }
       
        public static long ToLong(this object obj)
        {
            try
            {
                return long.Parse(obj.ToString());
            }
            catch
            {
                return 0L;
            }
        }

        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return null;
            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }


        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;
            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }


        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }


        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return null;
            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }


        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }


        public static decimal ToDecimal(this object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }


        public static decimal? ToDecimalOrNull(this object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }


        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }


        public static DateTime ToDate(this object data)
        {
            if (data == null)
                return DateTime.MinValue;
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        }


        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return null;
            DateTime result;
            bool isValid = DateTime.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }


        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            return bool.TryParse(data.ToString(), out result) && result;
        }

        private static bool? GetBool(this object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "否":
                    return false;
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return null;
            }
        }

        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            bool isValid = bool.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }


        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return IsEmpty(value.Value);
        }

        public static bool IsEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                return true;
            return false;
        }

        public static bool IsInteger(this decimal value)
        {
            if (value % 1 == 0)
                return true;
            else
                return false;
        }


        public static IEnumerable<TResult> CastSuper<TResult>(this IEnumerable source)
        {
            foreach (object item in source)
            {
                yield return (TResult)Convert.ChangeType(item, typeof(TResult));
            }
        }

        public static long ParseToLong(this object obj)
        {
            try
            {
                return long.Parse(obj.ToString());
            }
            catch
            {
                return 0L;
            }
        }

        public static long ParseToLong(this string str, long defaultValue)
        {
            try
            {
                return long.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ParseToInt(this object str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }


        public static int ParseToInt(this object str, int defaultValue)
        {
            if (str == null)
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static short ParseToShort(this object obj)
        {
            try
            {
                return short.Parse(obj.ToString());
            }
            catch
            {
                return 0;
            }
        }


        public static short ParseToShort(this object str, short defaultValue)
        {
            try
            {
                return short.Parse(str.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ParseToDecimal(this object str, decimal defaultValue)
        {
            try
            {
                return decimal.Parse(str.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }


        public static decimal ParseToDecimal(this object str)
        {
            try
            {
                return decimal.Parse(str.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static bool ParseToBool(this object str)
        {
            try
            {
                return bool.Parse(str.ToString());
            }
            catch
            {
                return false;
            }
        }


        public static bool ParseToBool(this object str, bool result)
        {
            try
            {
                return bool.Parse(str.ToString());
            }
            catch
            {
                return result;
            }
        }

        public static float ParseToFloat(this object str)
        {
            try
            {
                return float.Parse(str.ToString());
            }
            catch
            {
                return 0;
            }
        }


        public static float ParseToFloat(this object str, float result)
        {
            try
            {
                return float.Parse(str.ToString());
            }
            catch
            {
                return result;
            }
        }

        public static Guid ParseToGuid(this string str)
        {
            try
            {
                return new Guid(str);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static DateTime ParseToDateTime(this string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return DateTime.MinValue;
                }
                if (str.Contains("-") || str.Contains("/"))
                {
                    return DateTime.Parse(str);
                }
                else
                {
                    int length = str.Length;
                    switch (length)
                    {
                        case 4:
                            return DateTime.ParseExact(str, "yyyy", System.Globalization.CultureInfo.CurrentCulture);
                        case 6:
                            return DateTime.ParseExact(str, "yyyyMM", System.Globalization.CultureInfo.CurrentCulture);
                        case 8:
                            return DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                        case 10:
                            return DateTime.ParseExact(str, "yyyyMMddHH", System.Globalization.CultureInfo.CurrentCulture);
                        case 12:
                            return DateTime.ParseExact(str, "yyyyMMddHHmm", System.Globalization.CultureInfo.CurrentCulture);
                        case 14:
                            return DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                        default:
                            return DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    }
                }
            }
            catch
            {
                return DateTime.MinValue;
            }
        }


        public static DateTime ParseToDateTime(this string str, DateTime? defaultValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return defaultValue.GetValueOrDefault();
                }
                if (str.Contains("-") || str.Contains("/"))
                {
                    return DateTime.Parse(str);
                }
                else
                {
                    int length = str.Length;
                    switch (length)
                    {
                        case 4:
                            return DateTime.ParseExact(str, "yyyy", System.Globalization.CultureInfo.CurrentCulture);
                        case 6:
                            return DateTime.ParseExact(str, "yyyyMM", System.Globalization.CultureInfo.CurrentCulture);
                        case 8:
                            return DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                        case 10:
                            return DateTime.ParseExact(str, "yyyyMMddHH", System.Globalization.CultureInfo.CurrentCulture);
                        case 12:
                            return DateTime.ParseExact(str, "yyyyMMddHHmm", System.Globalization.CultureInfo.CurrentCulture);
                        case 14:
                            return DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                        default:
                            return DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    }
                }
            }
            catch
            {
                return defaultValue.GetValueOrDefault();
            }
        }

        public static string ParseToString(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return string.Empty;
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string ParseToStrings<T>(this object obj)
        {
            try
            {
                var list = obj as IEnumerable<T>;
                if (list != null)
                {
                    return string.Join(",", list);
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }

        }

        public static double ParseToDouble(this object obj)
        {
            try
            {
                return double.Parse(obj.ToString());
            }
            catch
            {
                return 0;
            }
        }


        public static double ParseToDouble(this object str, double defaultValue)
        {
            try
            {
                return double.Parse(str.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }
        public static IList<Type> GetAllTypes(this object[] objectArray)
        {
            List<Type> types = new List<Type>();

            foreach (var obj in objectArray)
            {
                types.Add(obj.GetType());
            }

            return types;
        }

        public static bool EqualList(this IList<Type> types, IList<Type> sourceTypes)
        {
            bool isItEquals = true;

            foreach (var type in types)
            {
                var isAssigned = sourceTypes.Any(t => type.IsAssignableFrom(t));
                if (!isAssigned)
                {
                    isItEquals = false;
                }
            }

            return isItEquals;
        }

        public static IList<Type> GetParaTypes(this IList<ParameterInfo> paras)
        {
            IList<Type> paraTypes = new List<Type>();

            foreach (var para in paras)
            {
                paraTypes.Add(para.ParameterType);
            }

            return paraTypes;
        }

        public static string RemoveWhiteSpaces(this string source)
        {
            if (source.IsEmpty()) return source;
            return Regex.Replace(source, @"\s+", "");
        }


        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
                return true;
            else
            {
                string objStr = obj.ToString();
                return string.IsNullOrEmpty(objStr);
            }
        }


        public static string SerializeToJson(this object data, Formatting formatting, string dateTimeFormat = "yyyy-MM-dd HH:mm:ss")
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter()
            {
                DateTimeFormat = dateTimeFormat
            };
            return JsonConvert.SerializeObject(data, formatting, timeConverter);
        }


        public static decimal ConvertToDecimal(this decimal num, int scale)
        {
            if (num.IsEmpty()) return Convert.ToDecimal("0.00");

            string numToString = num.ToString();

            int index = numToString.IndexOf(".");
            int length = numToString.Length;

            if (index != -1)
            {
                var result = string.Format("{0}.{1}",
                    numToString.Substring(0, index),
                    numToString.Substring(index + 1, Math.Min(length - index - 1, scale)));
                return Convert.ToDecimal(result);
            }
            else
            {
                return Convert.ToDecimal(num.ToString());
            }
        }


        public static string RemoveDecimalPoint(this string amount, string value = "0")
        {
            var result = "";
            try
            {
                result = Convert.ToString(amount);
                if (!string.IsNullOrEmpty(value) && value == "1")
                {
                    if (Convert.ToString(amount).IndexOf('.') > 0)
                    {
                        var decimalPointNum = amount.Substring(amount.IndexOf(".") + 1, amount.Length - amount.IndexOf(".") - 1).ToInt();
                        if (decimalPointNum == 0)
                        {
                            result = Convert.ToString(amount).Substring(0, Convert.ToString(amount).IndexOf('.'));
                        }
                    }
                }
            }
            catch (Exception)
            {
                result = Convert.ToString(amount);
            }
            return result;
        }


        public static string RemoveAllDecimalPoint(this decimal amount, string value = "0")
        {
            var result = "";
            try
            {
                result = Convert.ToString(amount);
                if (!string.IsNullOrEmpty(value) && value == "1")
                {
                    if (result.IndexOf('.') > 0)
                    {
                        result = result.Substring(0, result.IndexOf('.'));
                    }
                }
            }
            catch (Exception)
            {
                result = Convert.ToString(amount);
            }
            return result;
        }


        public static string RemoveAllDecimalPoint(this string amount, string value = "0")
        {
            var result = "";
            try
            {
                result = amount;
                if (!string.IsNullOrEmpty(value) && value == "1")
                {
                    if (result.IndexOf('.') > 0)
                    {
                        result = result.Substring(0, result.IndexOf('.'));
                    }
                }
            }
            catch (Exception)
            {
                result = Convert.ToString(amount);
            }
            return result;
        }
    }
}

using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;
using WebChat.Extension.AttributeHelper;

namespace WebChat.Extension.Extensions
{
    public static partial class Extensions
    {
       
        public static Dictionary<int, string> EnumToDictionary(this Type enumType)
        {
            Dictionary<int, string> dictionary = new();
            Type typeDescription = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            int sValue = 0;
            string sText = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    sValue = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute da = (DescriptionAttribute)arr[0];
                        sText = da.Description;
                    }
                    else
                    {
                        sText = field.Name;
                    }
                    dictionary.Add(sValue, sText);
                }
            }
            return dictionary;
        }
        public static string EnumToDictionaryString(this Type enumType)
        {
            List<KeyValuePair<int, string>> dictionaryList = EnumToDictionary(enumType).ToList();
            var sJson = JsonConvert.SerializeObject(dictionaryList);
            return sJson;
        }

        //public static string EnumClassNameToJson(this string enumClassName)
        //{
        //    Type type = Type.GetType("WaterCloud.Code." + enumClassName);
        //    return type.EnumToDictionaryString();
        //}
        public static string GetDescription(this System.Enum enumType)
        {
            FieldInfo EnumInfo = enumType.GetType().GetField(enumType.ToString());
            if (EnumInfo != null)
            {
                DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (EnumAttributes.Length > 0)
                {
                    return EnumAttributes[0].Description;
                }
            }
            return enumType.ToString();
        }
        
        public static string GetDefaultValue(this System.Enum enumType)
        {
            FieldInfo EnumInfo = enumType.GetType().GetField(enumType.ToString());
            if (EnumInfo != null)
            {
                DefaultValueAttribute[] EnumAttributes = (DefaultValueAttribute[])EnumInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                if (EnumAttributes.Length > 0)
                {
                    return EnumAttributes[0].Value.ToString();
                }
            }
            return enumType.ToString();
        }
        public static int GetIntValueByEnum<T>(this object obj)
        {
            var tEnum = System.Enum.Parse(typeof(T), obj.ParseToString()) as System.Enum;
            return tEnum.ParseToInt();
        }
        public static string GetDescriptionByEnum<T>(this object obj) where T : struct
        {
            T tEnum;
            var isOk = System.Enum.TryParse<T>(obj.ParseToString(), out tEnum);
            if (!isOk) return "未知状态";
            var description = (tEnum as Enum).GetDescription();
            return description;
        }

        public static int GetTypeValue(this Enum em)
        {
            int res = -1;
            FieldInfo EnumInfo = em.GetType().GetField(em.ToString());
            if (EnumInfo != null)
            {
                EnumTypeAttribute EnumAttributes = (EnumTypeAttribute)EnumInfo.GetCustomAttribute(typeof(EnumTypeAttribute), false);

                res = EnumAttributes.StartNum;
            }
            return res;
        }
    }
}

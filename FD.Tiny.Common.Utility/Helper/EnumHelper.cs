using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.Common.Utility.Helper
{
    public static class EnumHelper
    {
        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T ToEnum<T>(int value, T defaultT) where T : struct
        {
            string enumName = Enum.GetName(typeof(T), value);

            return ToEnum<T>(enumName, defaultT);
        }

        public static string ToDescription(int value, Type enumType)
        {
            var enumValue = Enum.ToObject(enumType, value);
            FieldInfo fi = enumType.GetField(enumValue.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// 获取枚举类子项描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>        
        public static string GetEnumDescription(Enum enumSubitem)
        {
            string strValue = enumSubitem.ToString();

            FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);
            Object[] objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0)
            {
                return strValue;
            }
            else
            {
                DescriptionAttribute da = (DescriptionAttribute)objs[0];
                return da.Description;
            }
        }



        public static T ToEnum<T>(string enumName, T defaultT) where T : struct
        {
            if (string.IsNullOrWhiteSpace(enumName))
            {
                return defaultT;
            }

            T result;

            if (!Enum.TryParse<T>(enumName.Trim(), out result))
            {
                return defaultT;
            }

            if (Enum.IsDefined(typeof(T), result))
            {
                return result;
            }

            return defaultT;
        }

        public static IDictionary<int, string> ToDictionary(this Type enumType)
        {
            return Enum.GetValues(enumType)
            .Cast<object>()
            .ToDictionary(k => (int)k, v => ((Enum)v).ToEnumDescription());
        }

        public static string ToEnumDescription(this Enum en) //ext method
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        /// <summary>
        /// 获取枚举类型的Dictionary形式，用于绑定界面列表控件
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetEnumItems(Type enumType)
        {
            List<KeyValuePair<int, string>> _EnumList = new List<KeyValuePair<int, string>>();
            if (enumType.IsEnum != true)
            {
                // 不是枚举类型 
                throw new InvalidOperationException();
            }
            // 获得特性Description的类型信息 
            Type typeDescription = typeof(DescriptionAttribute);
            // 获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值） 
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            // 检索所有字段 
            foreach (FieldInfo field in fields)
            {
                // 过滤掉一个不是枚举值的，记录的是枚举的源类型 
                if (field.FieldType.IsEnum == false)
                    continue;
                // 通过字段的名字得到枚举的值 
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                string text = string.Empty;
                // 获得这个字段的所有自定义特性源码天空，这里只查找Description特性 
                object[] arr = field.GetCustomAttributes(typeDescription, true);
                if (arr.Length > 0)
                {
                    // 因为Description自定义特性不允许重复，所以只取第一个 
                    DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                    // 获得特性的描述值 
                    text = aa.Description;
                }
                else
                {
                    // 如果没有特性描述，那么就显示英文的字段名 
                    text = field.Name;
                }
                _EnumList.Add(new KeyValuePair<int, string>(value, text));
            }
            return _EnumList;
        } 
    }
}

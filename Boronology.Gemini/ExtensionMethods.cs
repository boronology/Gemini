using System;
using System.Reflection;
namespace Boronology.Gemini
{
    public static class ExtensionMethods
    {
        public static object DeepClone (this object value)
        {
            if (object.Equals(value, null))
            {
                return null;
            }
            Type type = value.GetType();
            return InternalClone(type, value);
        }

        private static object InternalClone(Type type, object value)
        {
            if (type.IsValueType)
            {
                if (type.IsEnum)
                {
                    return value;
                }
                else if (type.IsPrimitive)
                {
                    //プリミティブ型はそのまま返せる
                    return value;
                }
                else if (type == typeof(decimal))
                {
                    return value;
                }
                else
                {
                    //再帰的なCloneが必要
                    return InternalCloneRecursive(type, value);
                }
            }
            else if (type.IsArray)
            {
                Array sourceArray = (Array)value;
                Array cloneArray = Array.CreateInstance(type.GetElementType(), sourceArray.Length);
                for (int i = 0; i < sourceArray.Length; i++)
                {
                    var element = sourceArray.GetValue(i);

                    cloneArray.SetValue(InternalClone(element.GetType(), element), i);
                }
                return cloneArray;
            }
            else if (type.IsClass)
            {
                if (type == typeof(string))
                {
                    string str = value as string;
                    return new string(str.ToCharArray());
                }
                else
                {
                    //再帰的なCloneが必要
                    return InternalCloneRecursive(type, value);
                }
            }
            else
            {
                throw new ArgumentException($"typeは具体的な型のはず。type = {type.Name}, value = {value}");
            }
        }

        private static object InternalCloneRecursive(Type sourcetype, object sourceValue)
        {
            object clone;
            if (sourcetype.IsValueType)
            {
                clone = sourceValue;
            }
            else
            {
                clone = System.Runtime.Serialization.FormatterServices.GetSafeUninitializedObject(sourcetype);
            }

            Type baseType = sourcetype;
            while(true)
            {
                //publicフィールド・privateフィールド・backing field全部取れる
                foreach(var field in baseType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
                {
                    field.SetValue(clone, InternalClone(field.FieldType, field.GetValue(sourceValue)));
                }

                if (sourcetype == baseType.BaseType || baseType == null || baseType == typeof(ValueType))
                {
                    break;
                }
                baseType = baseType.BaseType;
            }

            return clone;
        }

    }
}
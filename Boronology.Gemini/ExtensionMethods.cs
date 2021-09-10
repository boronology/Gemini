using System;

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
                    throw new NotImplementedException();
                }
            }
            else if (type.IsClass)
            {
                if (type == typeof(string))
                {
                    string str = value as string;

                    //DeepCloneしてもインターン文字列になる可能性があるのでそのまま返しておく
                    return value;
                }
                else
                {
                    //再帰的なCloneが必要
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new ArgumentException($"typeは具体的な型のはず。type = {type.Name}, value = {value}");
            }
        }

    }
}
using System;

[System.Serializable]
public static class EnumHelper
{
    public static T GetEnum<T>(int value) where T : struct,IConvertible
    {
        Type enumType = typeof(T);
        if (!enumType.IsEnum)
        {
            throw new Exception("Not an enum");
        }
        return (T)Enum.ToObject(enumType, value);
    }
}

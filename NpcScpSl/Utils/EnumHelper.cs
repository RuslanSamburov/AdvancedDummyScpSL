using System;

namespace NpcScpSl.Utils
{
    public static class EnumHelper
    {
        public static T? GetEnumValue<T>(string input) where T : struct, Enum
        {
            if (int.TryParse(input, out int index))
            {
                var values = Enum.GetValues(typeof(T));
                if (index >= 0 && index < values.Length)
                {
                    return (T)values.GetValue(index);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (Enum.TryParse<T>(input, out T result) && Enum.IsDefined(typeof(T), result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

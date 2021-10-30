using System;
using System.ComponentModel;

namespace VanhackTest.Core.Utils
{
    public static class EnumUtils
    {
          public static string GetEnumDescription(this Enum value)
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
        
    }
}
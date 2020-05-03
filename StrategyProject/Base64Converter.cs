using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StrategyProject
{
    /// <summary>
    /// A class used to convert into base64
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Base64Converter<T> : IConverter<T>
    {
        /// <summary>
        /// Own implementation of 'ConvertFrom' method
        /// </summary>
        /// <param name="element">Element for converting</param>
        /// <returns></returns>
        public string ConvertFrom(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Base64Converter ConvertFrom Argument Exception");
            }

            return element.GetType().GetMembers()
                .Where(memberInfo => memberInfo.MemberType.Equals(MemberTypes.Property))
                .Select(memberInfo =>
                {
                    var value = element.GetType().GetProperty(memberInfo.Name).GetValue(element, null).ToString();
                    var bytes = Encoding.UTF8.GetBytes(value);
                    return Convert.ToBase64String(bytes);
                }
                )
                .Aggregate((string1, string2) => string1 + "." + string2);
        }
    }
}

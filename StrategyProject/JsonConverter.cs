using Newtonsoft.Json;
using System;

namespace StrategyProject
{
    /// <summary>
    /// A class for converting into JSON format
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonConverter<T> : IConverter<T>
    {
        /// <summary>
        /// Own 'ConvertFrom' implementation 
        /// </summary>
        /// <param name="element">Element for converting</param>
        /// <returns></returns>
        public string ConvertFrom(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("JsonConverter ConvertFrom ArgumentException");
            }

            //Serialize the object
            return JsonConvert.SerializeObject(element, Formatting.Indented);
        }
    }
}

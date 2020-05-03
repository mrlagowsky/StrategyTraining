using System.Collections.Generic;
using System.Linq;

namespace StrategyProject
{
    /// <summary>
    /// A class to change the strategy during runtime
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicConverter<T>
    {
        private IConverter<T> converter;

        public void SetConversionStrategy(ConversionType conversionType)
        {
            switch (conversionType)
            {
                case ConversionType.JSON:
                    converter = new JsonConverter<T>();
                    break;
                case ConversionType.BASE64:
                    converter = new Base64Converter<T>();
                    break;
            }
        }

        public List<string> ConvertFrom(List<T> elements) =>
            elements.Select(element => converter.ConvertFrom(element)).ToList();

    }
}

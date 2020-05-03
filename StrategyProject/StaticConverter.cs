using System.Collections.Generic;
using System.Linq;

namespace StrategyProject
{
    /// <summary>
    /// A class used to decide the strategy of conversion 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="C"></typeparam>
    public class StaticConverter<T, C> where C : IConverter<T>, new()
    {
        private IConverter<T> converter = new C();

        public List<string> Convert(List<T> elements) =>
            elements.Select(element => converter.ConvertFrom(element)).ToList();
    }
}

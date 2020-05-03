using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrategyProject
{

    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>()
            {
                new User() {Username = "user", Password = "1234"},
                new User() {Username = "admin", Password = "5678"},
                new User() {Username = "super", Password = "9012"}
            };

            var dynamicConverter = new DynamicConverter<User>();

            dynamicConverter.SetConversionStrategy(ConversionType.JSON);
            Console.WriteLine("\n-----------------------\nJSON DYNAMIC CONVERSION");
            dynamicConverter.ConvertFrom(users).ForEach(Console.WriteLine);

            dynamicConverter.SetConversionStrategy(ConversionType.BASE64);
            Console.WriteLine("\n-----------------------\nBASE64 DYNAMIC CONVERSION");
            dynamicConverter.ConvertFrom(users).ForEach(Console.WriteLine);


            var staticConverter1 = new StaticConverter<User, JsonConverter<User>>();
            Console.WriteLine("\n-----------------------\nJSON STATIC CONVERSION");
            staticConverter1.Convert(users).ForEach(Console.WriteLine);

            var staticConverter2 = new StaticConverter<User, Base64Converter<User>>();
            Console.WriteLine("\n-----------------------\nBASE64 STATIC CONVERSION");
            staticConverter2.Convert(users).ForEach(Console.WriteLine);
        }
    }
}

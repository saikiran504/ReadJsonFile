using System;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace ReadJsonFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var configurationBuilder = new ConfigurationBuilder ();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory ());
            configurationBuilder.AddJsonFile("testdata.json", optional : true, reloadOnChange : true);
            IConfigurationRoot configuration = configurationBuilder.Build ();

            Console.WriteLine(configuration.GetConnectionString ("SqlDb"));
            Console.WriteLine(configuration.GetConnectionString ("OracleDb"));
            Console.WriteLine(configuration.GetConnectionString ("MangoDb"));

            //using GetSession method user defined values and defaultvalues 

            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest:QA").Value);
            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest:Stage").Value);
            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest:Prod").Value);

            Console.WriteLine (configuration.GetSection ("ConnectionStrings:SqlDb").Value);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings:OracleDb").Value);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings:MangoDb").Value);


            //d/f method 

            Console.WriteLine (configuration.GetSection ("ConnectionStrings")["SqlDb"]);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings")["OracleDb"]);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings")["MangoDb"]);

            
            
           
        }
    }
}

using System;
using System.Configuration;

namespace SpecFlowRestAPITest.Utilities
{
    public static class Data
    {
        public static string WeatherBaseURL => ConfigurationManager.AppSettings["WeatherBaseURL"];
        public static string ZipCodeBaseURL => ConfigurationManager.AppSettings["ZipCodeBaseURL"];
    }
}

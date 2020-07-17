using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BeerTasters.API
{
    public static class AppSettings
    {
        //public static string WebApiBaseAddress => Retrieve("WebApiBaseAddress");

        public static string PunkApiBaseAddress => Retrieve("PunkApiBaseAddress");

        private static string Retrieve(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
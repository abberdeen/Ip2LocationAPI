using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Ip2LocationAPI.Models;
using Ip2LocationUpdate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Ip2LocationUpdater
{
    class GeoLite2CityLocations
    {
        public static void ImportCSV(string csvFile)
        {
            var context = new GeolocationContext();
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (var reader = new StreamReader(csvFile, Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                csvReader.Configuration.HasHeaderRecord = true;
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.IgnoreQuotes = true;
                csvReader.Configuration.RegisterClassMap<CSVMap>();
                var addresses = csvReader.GetRecords<Address>().ToArray();
                context.Addresses.RemoveRange(context.Addresses);
                context.AddRange(addresses);
                context.SaveChanges();
            }
        }

        private sealed class CSVMap : ClassMap<Address>
        {
            public CSVMap()
            {
                Map(m => m.GeonameId).Index(0);
                Map(m => m.LocaleCode).Index(1);
                Map(m => m.ContinentCode).Index(2);
                Map(m => m.ContinentName).Index(3);
                Map(m => m.CountryCode).Index(4);
                Map(m => m.CountryName).Index(5);
                Map(m => m.Subdivision1IsoCode).Index(6);
                Map(m => m.District).Index(7);
                Map(m => m.Subdivision2IsoCode).Index(8);
                Map(m => m.Region).Index(9);
                Map(m => m.CityName).Index(10);
                Map(m => m.MetroCode).Index(11);
                Map(m => m.TimeZone).Index(12);
                Map(m => m.IsInEuropeanUnion).Index(13); 
                
               
            }
        }
         

       
    }


}

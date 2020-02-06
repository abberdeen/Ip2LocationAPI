
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
    class GeoLite2BlocksIPv4
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
                var geolocations = csvReader.GetRecords<Geolocation>().ToArray();
                context.Database.ExecuteSqlCommand("Delete from \"Geolocations\"");
                context.AddRange(geolocations);
                context.SaveChanges();
            }
        }
        private sealed class CSVMap : ClassMap<Geolocation>
        {
            public CSVMap()
            {
                Map(m => m.Network).Index(0).TypeConverter<IPNetworkConverter<IPAddress>>();
                Map(m => m.GeonameId).Index(1);
                Map(m => m.RegisteredCountryGeonameId).Index(2);
                Map(m => m.RepresentedCountryGeonameId).Index(3);
                Map(m => m.IsAnonymousProxy).Index(4);
                Map(m => m.IsSatelliteProvider).Index(5);
                Map(m => m.PostCode).Index(6);
                Map(m => m.Latitude).Index(7).TypeConverter<DoubleConverter<double>>();
                Map(m => m.Longitude).Index(8).TypeConverter<DoubleConverter<double>>();
                Map(m => m.AccuracyRadius).Index(9);
            }
        }

        private sealed class IPNetworkConverter<T> : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                var n = text.Split("/");
                return (IPAddress.Parse(n[0]), int.Parse(n[1]));
            }

            public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            {
                return value.ToString();
            }
        }

        private sealed class DoubleConverter<T> : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (text.Trim() == "") return (double) 0;
                return double.Parse(text.Replace(".", ",")); 
            }

            public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            {
                return value.ToString();
            }
        }
    }



}

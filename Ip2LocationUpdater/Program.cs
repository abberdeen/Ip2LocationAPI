using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;
using System.Reflection;
using CsvHelper;
using System.Text;
using Ip2LocationAPI.Models;
using Ip2LocationUpdate.Models;
using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace Ip2LocationUpdater
{
    class Program
    {

        static void Main(string[] args)
        { 
            while (true)
            {
                Console.WriteLine("Ip2LocationWorker running at:{0}", DateTimeOffset.Now);
                //
                var dbPath = @"tmp/";

                if (Directory.Exists(dbPath))
                {
                    Directory.Delete(dbPath, true);
                }

                Directory.CreateDirectory(dbPath);

                var dbFile = dbPath + @"geodb.zip";

                Console.WriteLine("Ip2LocationWorker GeoLite2 database donwload started at:{0}", DateTimeOffset.Now);
                DownloadGeoipDB(dbFile);

                ZipFile.ExtractToDirectory(dbFile, dbPath);

                string csvPath = Directory.EnumerateDirectories(dbPath).First();
            
                Console.WriteLine("Ip2LocationWorker import GeoLite2BlocksIPv4 started at:{0}", DateTimeOffset.Now);
                GeoLite2BlocksIPv4.ImportCSV(csvPath + "\\GeoLite2-City-Blocks-IPv4.csv");

                Console.WriteLine("Ip2LocationWorker import GeoLite2CityLocations started at:{0}", DateTimeOffset.Now);
                GeoLite2CityLocations.ImportCSV(csvPath + "\\GeoLite2-City-Locations-en.csv");
                                                                        
                Console.WriteLine("Ip2LocationWorker running at:{0}", DateTimeOffset.Now);

                Thread.Sleep(24 * 60 * 1000); //24 hours * 60 min * 1000ms = 1day
            }
        }

        private static void DownloadGeoipDB(string path)
        {
            using (var client = new WebClient())
            {
                Console.WriteLine("Ip2LocationWorker started downloading db:{0}", DateTimeOffset.Now);
                client.DownloadFile(new Uri(MaxmindGeoipDBAddress()), path);
                Console.WriteLine("Ip2LocationWorker ended downloading db:{0}", DateTimeOffset.Now);
            }
        }

        private static string MaxmindGeoipDBAddress()
        {
            var LicenceKey = "Noj1fefmmFLAaXfN";
            var EditionId = "GeoLite2-City-CSV";
            var Address = "https://download.maxmind.com/app/geoip_download?edition_id=" + EditionId + "&license_key=" + LicenceKey + "&suffix=zip";
            return Address;
        }

        
    }
}

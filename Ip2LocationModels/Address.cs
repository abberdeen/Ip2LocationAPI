using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ip2LocationAPI.Models
{
  public class Address
    {

        [JsonIgnore]
        [Column("geoname_id"), Key]
        public int GeonameId { get; set;}
      
        [JsonIgnore]
        [Column("locale_code")]
        public string LocaleCode { get; set;}
      
        [JsonIgnore]
        [Column("continent_code")]
        public string ContinentCode { get; set;}

        [Column("continent_name")]
        public  string ContinentName { get; set;}

        [Column("country_iso_code")]
        public string CountryCode { get; set;}

        [Column("country_name")]
        public  string CountryName { get; set;}

        [JsonIgnore]
        [Column("subdivision_1_iso_code")]
        public string Subdivision1IsoCode { get; set;}

        [Column("subdivision_1_name")]
        public string District{ get; set;}

        [JsonIgnore]
        [Column("subdivision_2_iso_code")]
        public string Subdivision2IsoCode { get; set;}

        [Column("subdivision_2_name")]
        public string Region { get; set;}

        [Column("city_name")]
        public string CityName { get; set;}

        [JsonIgnore]
        [Column("metro_code")]
        public string MetroCode { get; set;}

        [JsonIgnore]
        [Column("time_zone")]
        public string TimeZone { get; set;}

        [JsonIgnore]
        [Column("is_in_european_union")]
        public bool IsInEuropeanUnion { get; set;}
         
        [NotMapped]
        public Geolocation Geolocation { get; set; }
    }
} 
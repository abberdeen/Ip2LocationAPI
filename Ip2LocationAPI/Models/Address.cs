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
        public int GeonameId { get; internal set; }

        [Column("continent_name")]
        public  string ContinentName { get; internal set; }

        [Column("country_iso_code")]
        public string CountryCode { get; internal set; }

        [Column("country_name")]
        public  string CountryName { get; internal set; }

        [Column("subdivision_1_name")]
        public string District{ get; internal set; }

        [Column("subdivision_2_name")]
        public string Region { get; internal set; }

        [Column("city_name")]
        public string CityName { get; internal set; }
        
        [NotMapped]
        public Geolocation Geolocation { get; set; }
    }
}

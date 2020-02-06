using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ip2LocationAPI.Models
{ 
    public class Geolocation
    { 
        [JsonIgnore]
        [Column("network"),Key]
        public (IPAddress, int) Network { get; set; }

        [JsonIgnore]
        [Column("geoname_id")] 
        public int? GeonameId { get; set; }
     
        [JsonIgnore]
        [Column("registered_country_geoname_id")]
        public int? RegisteredCountryGeonameId { get; set; }

        [JsonIgnore]
        [Column("represented_country_geoname_id")]
        public string RepresentedCountryGeonameId { get; set; }
     
        [JsonIgnore]
        [Column("is_satellite_provider")]
        public int? IsSatelliteProvider { get; set; }

        [JsonIgnore]
        [Column("is_anonymous_proxy")]
        public int? IsAnonymousProxy { get; set; }

        [Column("postal_code")]
        public string PostCode { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }
         
        [Column("longitude")]
        public double Longitude { get; set; }
                
        [Column("accuracy_radius")]
        public int? AccuracyRadius { get; set; }
         
    }
}

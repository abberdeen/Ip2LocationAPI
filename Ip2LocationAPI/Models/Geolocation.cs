using NpgsqlTypes;
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
        [Column("network"), Key]
        public IPAddress Network { get; internal set; }

        [JsonIgnore]
        [Column("geoname_id")] 
        public int GeonameId { get; internal set; }
          
        [Column("latitude")]
        public double Latitude { get; internal set; }
         
        [Column("longitude")]
        public double Longitude { get; internal set; }

        
        [Column("accuracy_radius")]
        public int AccuracyRadius { get; internal set; }
         
        [Column("postal_code")]
        public string PostCode { get; internal set; }
    }
}

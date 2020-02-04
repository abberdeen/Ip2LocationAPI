using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ip2LocationAPI.Models
{
    public class Geolocation
    {
        [JsonIgnore]
        public int GeonameId { get; internal set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; internal set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; internal set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; internal set; }

        [JsonPropertyName("accuracy_radius")]
        public string AccuracyRadius { get; internal set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ip2LocationAPI.Models
{
    public class Address
    {
        [JsonIgnore]
        public int GeonameId { get; internal set; }

         [JsonPropertyName("continent_name")]
        public  string ContinentName { get; internal set; }

        [JsonPropertyName("country_iso_code")]
        public string CountryCode { get; internal set; }

        [JsonPropertyName("country_name")]
        public  string CountryName { get; internal set; }

        [JsonPropertyName("subdivision_1_name")]
        public string District{ get; internal set; }

        [JsonPropertyName("subdivision_2_name")]
        public string Region { get; internal set; }

        [JsonPropertyName("city_name")]
        public string CityName { get; internal set; }

        [JsonPropertyName("postal_code")]
        public string PostCode { get; internal set; }

    }
}

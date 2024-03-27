using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Prosegur.Models
{
    public class AddressModel
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street_name")]
        public string StreetName { get; set; }

        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coordinates")]
        public CoordinatesModel Coordinates { get; set; }
    }
}

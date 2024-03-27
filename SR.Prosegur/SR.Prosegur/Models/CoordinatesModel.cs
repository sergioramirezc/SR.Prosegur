using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Prosegur.Models
{
    public class CoordinatesModel
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
}

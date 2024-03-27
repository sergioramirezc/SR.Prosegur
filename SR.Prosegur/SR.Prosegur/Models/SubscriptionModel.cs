using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Prosegur.Models
{
    public class SubscriptionModel
    {
        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }
    }
}

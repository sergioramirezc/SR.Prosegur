using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Prosegur.Models
{
    public class CreditCardModel
    {
        [JsonProperty("cc_number")]
        public string CcNumber { get; set; }
    }
}

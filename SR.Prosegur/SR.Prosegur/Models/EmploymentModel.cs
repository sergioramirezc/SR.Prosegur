using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Prosegur.Models
{
    public class EmploymentModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("key_skill")]
        public string KeySkill { get; set; }
    }
}

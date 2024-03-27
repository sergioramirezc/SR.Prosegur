using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.Prosegur.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("social_insurance_number")]
        public string SocialInsuranceNumber { get; set; }

        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("employment")]
        public EmploymentModel Employment { get; set; }

        [JsonProperty("address")]
        public AddressModel Address { get; set; }

        [JsonProperty("credit_card")]
        public CreditCardModel CreditCard { get; set; }

        [JsonProperty("subscription")]
        public SubscriptionModel Subscription { get; set; }
    }
}

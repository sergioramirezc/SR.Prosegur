using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using SR.Prosegur.Services;
using System.Collections.Generic;

namespace SR.Prosegur.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private static HttpClient instance;

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            try
            {
                HttpClient httpClient = await CreateHttpClient(uri);
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                }
                HttpResponseMessage response = await httpClient.GetAsync(uri);

                string serialized = await response.Content.ReadAsStringAsync();

                TResult result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

                return result;
            }
            catch (Exception ex)
            {
                //Track error in appcenter
                throw ex;
            }
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "")
        {
            try
            {
                HttpClient httpClient = await CreateHttpClient(uri);

                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(String.Empty, token);
                }

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                string serialized = await response.Content.ReadAsStringAsync();

                TResult result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

                return result;
            }
            catch (Exception ex)
            {
                //Track error in appcenter
                return default(TResult);
            }
        }

        public async Task<TOutput> PostAsync<TOutput, TInput>(string uri, TInput data, string token = "", string header = "")
        {
            try
            {
                HttpClient httpClient = await CreateHttpClient(uri);

                if (!string.IsNullOrEmpty(header))
                {
                    AddHeaderParameter(httpClient, header);
                }

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                string serialized = await response.Content.ReadAsStringAsync();

                TOutput result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings));

                return result;
            }
            catch (Exception ex)
            {
                //Track error in appcenter
                return default(TOutput);
            }
        }
        private async Task<HttpClient> CreateHttpClient(string uri = "")
        {
            var httpClient = GetInstance();
            return httpClient;
        }

        private static HttpClient GetInstance()
        {
            if (instance == null)
            {
                instance = new HttpClient();
                instance.Timeout = TimeSpan.FromSeconds(30);
                instance.MaxResponseContentBufferSize = 256000;
                instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            return instance;
        }

        private void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (httpClient == null)
                return;

            if (string.IsNullOrEmpty(parameter))
                return;

            httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }
    }
}
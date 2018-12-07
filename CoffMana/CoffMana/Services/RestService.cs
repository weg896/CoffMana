using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoffMana.Models;
using System.Diagnostics;

namespace CoffMana.Services
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<User> RestLogin(User u)
        {
            Uri uri = new Uri(CONSTANTS.RestUrl + "/data/login");
            string json = "{" +
                "\"username\":" + "\"" + u.username + "\"," +
                "\"password\":" + "\"" + u.password + "\"" +
                "}";
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(uri, requestContent);

            // Debug.WriteLine(@" ~~~~~ "+ client.MaxResponseContentBufferSize + "~~~");
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                TokenHelper t = JsonConvert.DeserializeObject<TokenHelper>(responseContent);
                u.temp_token = t.token;
                return u;
            }

            return null;
        }
        
        private class TokenHelper
        {
            public string token
            {
                get; set;
            }
        }
    }
}

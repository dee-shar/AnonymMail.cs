using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AnonymMailApi
{
    public class AnonymMail
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://anonymmail.net/api";
        public AnonymMail()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/141.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }
        public async Task<string> CreateEmail(string email)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
            });
            var response = await httpClient.PostAsync($"{apiUrl}/create", data);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetDomains()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/getDomains");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetInbox(string email)
        {
            var data = new FormUrlEncodedContent(new[]
                       {
                new KeyValuePair<string, string>("email", email),
            });
            var response = await httpClient.PostAsync($"{apiUrl}/get", data);
            return await response.Content.ReadAsStringAsync();
        }
    }
}

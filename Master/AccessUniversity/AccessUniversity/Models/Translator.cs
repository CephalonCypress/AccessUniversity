﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Install Newtonsoft.Json with NuGet

namespace AccessUniversity.Models
{
    public class Translator
    {
        private static readonly string subscriptionKey = "af950b238a904823a99070fb6c1bccfa";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";

        public static async Task Translate(string textToTranslate, string langDir = "en")
        {
            // Input and output languages are defined as parameters.
            string route = "/translate?api-version=3.0&from=en&to=" + langDir;
            //string textToTranslate = "Hello, world!";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
        }
    }
}
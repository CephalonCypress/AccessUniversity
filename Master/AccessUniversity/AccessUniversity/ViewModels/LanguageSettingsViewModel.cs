using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json; // Install Newtonsoft.Json with NuGet
using Newtonsoft.Json.Linq;
using System.Data;

namespace AccessUniversity.ViewModels
{

    public class LanguageSettingsViewModel : INotifyPropertyChanged
    {

        public class Translation
        {
            public string text { get; set; }
            public string to { get; set; }
        }

        public class MyArray
        {
            public List<Translation> translations { get; set; }
        }

        public class Root
        {
            public List<MyArray> MyArray { get; set; }
        }

        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Language> LanguageList { get; set; }

        private Language _selectedLanguage { get; set; }
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    //Functionality when changed
                    //CurrentLanguage = "Current Language: " + _selectedLanguage.Name;
                    CurrentLanguage = Translate("Current Language: " + _selectedLanguage.Name, _selectedLanguage.dir).Result;
                }
            }
        }

        private string _currentLanguage { get; set; }
        public string CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    NotifyPropertyChanged(nameof(CurrentLanguage));
                }
            }
        }

        public LanguageSettingsViewModel()
        {
            LanguageList = GetLanguages().OrderBy(t => t.Value).ToList();
        }
        public List<Language> GetLanguages()
        {
            var languages = new List<Language>()
            {
                new Language(){Value = 1, Name = "English", dir = "en"},
                new Language(){Value = 2, Name = "German", dir = "de"},
                new Language(){Value = 3, Name = "French", dir = "fr"},
                new Language(){Value = 4, Name = "Russian", dir = "ru"},
                new Language(){Value = 5, Name = "Japanese", dir = "ja"},
                new Language(){Value = 6, Name = "Chinese Simplified", dir = "zh-Hans"},
                new Language(){Value = 7, Name = "Chinese Traditional", dir = "zh-Hant"},
                new Language(){Value = 8, Name = "Korean", dir = "ko"},
                new Language(){Value = 9, Name = "Indonesian", dir = "id"},
                new Language(){Value = 10, Name = "Hindi", dir = "hi"}
            };
            return languages;
        }
        public class Language
        {
            public int Value { get; set; }
            public string Name { get; set; }
            public string dir { get; set; }
        }

        private static readonly string subscriptionKey = "370629984e5249e6b7824ba431591d23";
        private static readonly string region = "australiaeast";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";

        public async Task<string> Translate(string textToTranslate, string langDir = "en")
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
                request.Headers.Add("Ocp-Apim-Subscription-Region", region);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(result);
                string result = responseBody;

                // Extract required text from JSON
                
                // Below are few methods that I've tried but didn't work
                /*JObject joResponse = JObject.Parse(responseBody);
                JObject ojObject = (JObject)joResponse["translations"];
                JArray array = (JArray)ojObject[""];
                string result = Convert.ToString(joResponse);*/

                /*JToken token = JObject.Parse(@responseBody);
                var a = token.Select(o => o.First);
                string result = a.ToString();*/

                /*DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(responseBody);
                DataTable dataTable = dataSet.Tables["translations"];
                string result = dataSet.ToString();*/

                /*Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseBody);
                string result = myDeserializedClass.MyArray[0].translations[0].text;
                string result = JToken.Parse(responseBody).ToObject<Root>().ToString();*/


                return result;
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


}

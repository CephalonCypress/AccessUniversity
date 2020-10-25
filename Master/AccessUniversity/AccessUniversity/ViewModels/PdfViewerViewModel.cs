using System.IO;
using System.Reflection;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Xfa;
using Syncfusion.SfPdfViewer.XForms;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json; // Install Newtonsoft.Json with NuGet
using Newtonsoft.Json.Linq;
using System.Data;

namespace AccessUniversity.ViewModels
{
    class PdfViewerViewModel : INotifyPropertyChanged
    {
        private Stream m_pdfDocumentStream;

        /// <summary>
        /// Default Text
        /// </summary>
        public string extractedText = "Not Extracted";

        /// <summary>
        /// Default Page No
        /// </summary>
        public string pageNo = "";

        public List<Language> LanguageList { get; set; }

        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The PDF document stream that is loaded into the instance of the PDF viewer. 
        /// </summary>
        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                NotifyPropertyChanged("PdfDocumentStream");
            }
        }

        /// <summary>
        /// Extracts text from Pdf
        /// </summary>
        public string PdfTextExtraction()
        {
            try
            {
                Stream docStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AccessUniversity.Assets.Lecture 1 Slides.pdf");

                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

                //Check text entered

                if (Int32.TryParse(PageNo, out int result) == false)
                {
                    return extractedText;
                }

                //Load the specified page.

                PdfPageBase page = loadedDocument.Pages[Int32.Parse(PageNo) - 1];

                //Extract text from first page

                TextLineCollection lineCollection = new TextLineCollection();

                extractedText = page.ExtractText(out lineCollection);

                //Close the document

                loadedDocument.Close(true);

                extractedText = Translate(extractedText, _selectedLanguage.dir).Result;

                return extractedText;
            }
            catch
            {
                return extractedText;
            }
        }

        private string _pageNo { get; set; }
        public string PageNo
        {
            get { return _pageNo; }
            set
            {
                if (_pageNo != value)
                {
                    _pageNo = value;
                    ExtractedText = PdfTextExtraction();
                }
            }
        }
        private Language _selectedLanguage { get; set; }
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    ExtractedText = PdfTextExtraction();
                }
            }
        }

        private string _extractedText { get; set; }
        public string ExtractedText
        {
            get { return _extractedText; }
            set
            {
                if (_extractedText != value)
                {
                    _extractedText = value;
                    NotifyPropertyChanged(nameof(ExtractedText));
                }
            }
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

                // Extract required text from JSON
                responseBody = responseBody.Substring(27);
                responseBody = responseBody.Substring(0, responseBody.Length - 13 - langDir.Length);
                string result = responseBody.Replace(@"\r\n", "\r\n");

                return result;
            }
        }

        /// <summary>
        /// Constructor of the view model class
        /// </summary>
        public PdfViewerViewModel()
        {
            //Accessing the PDF document that is added as embedded resource as stream.
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AccessUniversity.Assets.Lecture 1 Slides.pdf");

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

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

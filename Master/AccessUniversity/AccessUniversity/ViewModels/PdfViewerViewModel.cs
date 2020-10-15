using System.IO;
using System.Reflection;
using System.ComponentModel;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Diagnostics;
using Syncfusion.Pdf.Xfa;
using Syncfusion.SfPdfViewer.XForms;

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
        public string pageNo = "1";

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
        public string PdfTextExtraction
        {
            get
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

                    //Extract text from first page.

                    TextLineCollection lineCollection = new TextLineCollection();

                    extractedText = page.ExtractText(out lineCollection);

                    //Close the document

                    loadedDocument.Close(true);

                    return extractedText;
                }
                catch
                {
                    return extractedText;
                }
            }
            set
            {
                extractedText = value;
                NotifyPropertyChanged(nameof(PdfTextExtraction));
            }
        }

        /// <summary>
        /// Page No for extracting text
        /// </summary>
        public string PageNo
        {
            get
            {
                return pageNo;
                /*try
                {
                    if (Int32.Parse(pageNo) > 0)
                    {
                        return pageNo;
                    }
                    else
                    {
                        return pageNo;
                    }
                }
                catch (FormatException)
                {
                    return pageNo;
                }*/
            }
            set
            {
                pageNo = value;
                NotifyPropertyChanged(nameof(PageNo));
                NotifyPropertyChanged(nameof(PdfTextExtraction));

            }
        }

        /// <summary>
        /// Constructor of the view model class
        /// </summary>
        public PdfViewerViewModel()
        {
            //Accessing the PDF document that is added as embedded resource as stream.
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("AccessUniversity.Assets.Lecture 1 Slides.pdf");
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

using System;
using System.Collections.Generic;
using System.Text;


using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using AccessUniversity.Helper.Resources;



namespace AccessUniversity.ViewModels
{
    class ContentsPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Eng_Command { get; set; }

        public ICommand Jp_Command { get; set; }

        //public string Title = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Title;

        public string Topics = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Topics;

        public string Worksheets = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Worksheets;

        public string Title { get; set; }

        public ContentsPageViewModel()
        {
            Title = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Title;

            Eng_Command = new Command(() =>
            {
                CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                NotifyCulture();
                NotifyPropertyChanged(nameof(Title));
            });


            Jp_Command = new Command(() =>
            {
                CultureInfo.CurrentCulture = new CultureInfo("ja-JP", false);
                NotifyCulture();
                NotifyPropertyChanged(nameof(Title));
            });
        }

        void NotifyCulture()
        {
            Application.Current.MainPage.DisplayAlert("", "Language changed to " + CultureInfo.CurrentCulture.DisplayName, "Dismiss");
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

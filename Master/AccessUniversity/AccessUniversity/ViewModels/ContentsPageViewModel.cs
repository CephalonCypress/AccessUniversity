using System;
using System.Collections.Generic;
using System.Text;


using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using AccessUniversity.Helper.Resources;
using System.Collections.ObjectModel;

namespace AccessUniversity.ViewModels
{
    public class ContentsPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand Eng_Command { get; set; }

        //public ICommand Jp_Command { get; set; }

        //public string Title = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Title;

        //public string Topics = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Topics;

        //public string Worksheets = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Worksheets;

        //public string Title { get; set; }
        public ObservableCollection<Element> ContentList { get; set; }
        public ContentsPageViewModel()
        {
            ContentList = new ObservableCollection<Element>
            {
                new Element(){ Icon = "FolderIcon.png", Name = "Topics", Id = 1},
                new Element(){ Icon = "FolderIcon.png", Name = "Worksheets", Id = 0},
                new Element(){ Icon = "VideoIcon2.png", Name = "Lectures", Id = 0},
                new Element(){ Icon = "FolderIcon.png", Name = "Support", Id = 0}
            };
            //Title = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Title;

            /*Eng_Command = new Command(() =>
            {
                CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                NotifyCulture();
                NotifyPropertyChanged(nameof(Title));
            });*/


            /*Jp_Command = new Command(() =>
            {
                CultureInfo.CurrentCulture = new CultureInfo("ja-JP", false);
                NotifyCulture();
                NotifyPropertyChanged(nameof(Title));
            });*/
        }

        public class Element
        {
            public string Icon { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
        }

        /*void NotifyCulture()
        {
            Application.Current.MainPage.DisplayAlert("", "Language changed to " + CultureInfo.CurrentCulture.DisplayName, "Dismiss");
        }*/

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

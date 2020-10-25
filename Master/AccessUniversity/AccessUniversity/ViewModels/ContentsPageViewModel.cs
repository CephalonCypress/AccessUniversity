using System;
using System.Collections.Generic;
using System.Text;


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
        public ObservableCollection<Element> ContentList { get; set; }
        public int Trials = 0;
        public ContentsPageViewModel()
        {
            ContentList = new ObservableCollection<Element>
            {
                new Element(){ Icon = "FolderIcon.png", Name = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Topics, Id = 1},
                new Element(){ Icon = "FolderIcon.png", Name = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Worksheets, Id = 0},
                new Element(){ Icon = "VideoIcon2.png", Name = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Lectures, Id = 0},
                new Element(){ Icon = "FolderIcon.png", Name = AccessUniversity.Helper.Resources.AppResources.ContentsPage_Support, Id = 0}
            };

            if (Trials == 0)
            {
                Application.Current.MainPage.DisplayAlert("", "Change the device language to change the app language", "Dismiss");
                Trials += 1;
            }
        }

        public class Element
        {
            public string Icon { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
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

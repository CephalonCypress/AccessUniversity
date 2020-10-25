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
        /*private Element _selectedElement { get; set; }
        public Element SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                if (_selectedElement != value)
                {
                    _selectedElement = value;
                }
            }
        }*/
        public ContentsPageViewModel()
        {
            ContentList = new ObservableCollection<Element>
            {
                new Element(){ Icon = "FolderIcon.png", Name = "Topics", Id = 1},
                new Element(){ Icon = "FolderIcon.png", Name = "Worksheets", Id = 0},
                new Element(){ Icon = "VideoIcon2.png", Name = "Lectures", Id = 0},
                new Element(){ Icon = "FolderIcon.png", Name = "Support", Id = 0}
            };
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

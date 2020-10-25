using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace AccessUniversity.ViewModels
{
    public class ContentsPageDetailViewModel
    {
        public ObservableCollection<Element> ContentList { get; set; }
        public ContentsPageDetailViewModel()
        {
            ContentList = new ObservableCollection<Element>
            {
                new Element(){ Icon = "PDF.png", Name = AccessUniversity.Helper.Resources.AppResources.ContentsPageDetail_FileName, File = "Lecture 1 Slides.pdf"}
            };
        }

        public class Element
        {
            public string Icon { get; set; }
            public string Name { get; set; }
            public string File { get; set; }
        }
    }
}

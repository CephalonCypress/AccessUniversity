using System;
using System.Collections.Generic;
using System.Text;

namespace AccessUniversity.Models {
    public enum MenuItemType {
        Browse,
        About,
        Login,
        ContentsPDF,
        AssessmentPage,
        ContentsPage,
        LectureRecording
    }
    public class HomeMenuItem {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

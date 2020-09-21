using System;
using System.Collections.Generic;
using System.Text;

namespace AccessUniversity.Models {
    public enum MenuItemType {
        Login,
        ContentsPDF,
        AssessmentPage,
        AssessmentContent,
        ContentsPage,
        LectureRecording, 
        LandingPage,
        Announcements,
        EmergencyPage

    }
    public class HomeMenuItem {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

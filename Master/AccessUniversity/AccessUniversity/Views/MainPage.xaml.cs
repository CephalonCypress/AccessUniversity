using AccessUniversity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccessUniversity.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage() {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id) {
            if (!MenuPages.ContainsKey(id)) {
                switch (id) {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Login:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                    case (int)MenuItemType.ContentsPDF:
                        MenuPages.Add(id, new NavigationPage(new ContentsPDF()));
                        break;
                    case (int)MenuItemType.AssessmentPage:
                        MenuPages.Add(id, new NavigationPage(new AssessmentPage()));
                        break;
                    case (int)MenuItemType.AssessmentContent:
                        MenuPages.Add(id, new NavigationPage(new AssessmentContent()));
                        break;
                    case (int)MenuItemType.ContentsPage:
                        MenuPages.Add(id, new NavigationPage(new ContentsPage()));
                        break;
                    case (int)MenuItemType.LectureRecording:
                        MenuPages.Add(id, new NavigationPage(new LectureRecording()));
                        break;
                    case (int)MenuItemType.LandingPage:
                        MenuPages.Add(id, new NavigationPage(new LandingPage()));
                        break;
                    case (int)MenuItemType.Announcements:
                        MenuPages.Add(id, new NavigationPage(new Announcements()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage) {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
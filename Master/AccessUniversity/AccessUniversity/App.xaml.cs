using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AccessUniversity.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AccessUniversity {
    public partial class App : Application {

        public App() {
            InitializeComponent();
            Device.SetFlags(new string[] { "MediaElement_Experimental", "Expander_Experimental" });

            // MainPage = new MainPage();
            MainPage = new AppShell();
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}

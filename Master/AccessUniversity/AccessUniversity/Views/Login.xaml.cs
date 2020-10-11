using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessUniversity.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AccessUniversity.Helper.Resources;

namespace AccessUniversity.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
		{
			InitializeComponent();
        }

        private async void studentSignInProcess(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);
            if (user.VerifyLogin())
            {
                DisplayAlert("", AccessUniversity.Helper.Resources.AppResources.LoginSuccess, AccessUniversity.Helper.Resources.AppResources.OkConfirmation);
                await Navigation.PushAsync(new LandingPage());
            } else
            {
                DisplayAlert("", AccessUniversity.Helper.Resources.AppResources.LoginFail, AccessUniversity.Helper.Resources.AppResources.OkConfirmation);
            }
        }

        private async void interpreterSignInProcess(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);
            if (user.VerifyLogin())
            {
                DisplayAlert("", AccessUniversity.Helper.Resources.AppResources.LoginSuccess, AccessUniversity.Helper.Resources.AppResources.OkConfirmation);
                await Navigation.PushAsync(new LandingPage());
            }
            else
            {
                DisplayAlert("", AccessUniversity.Helper.Resources.AppResources.LoginFail, AccessUniversity.Helper.Resources.AppResources.OkConfirmation);
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessUniversity.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AccessUniversity.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
		{
			InitializeComponent();
        }

        private async void signInProcess(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);
            if (user.VerifyLogin())
            {
                DisplayAlert("", "Login Successful", "Ok");
                await Navigation.PushAsync(new LandingPage());
            } else
            {
                DisplayAlert("", "Login failed, username or passsword incorrect.", "Ok");
            }
        }

        
	}
}
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

        void signInProcess(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);

        }

        //private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    imgShowHide.Source = string.IsNullOrEmpty(PasswordEntry_TextChanged.Text) ? null : "eye_hide.png";
        //    imgShowHide.HeightRequest = 30;
        //}
	}
}
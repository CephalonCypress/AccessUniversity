using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessUniversity.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Globalization;
using System.Threading;


namespace AccessUniversity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsPage : ContentPage
    {
        public ContentsPage()
        {
            InitializeComponent();
            BindingContext = new ContentsPageViewModel();
        }
        
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = e.Item as ContentsPageViewModel;
            await Navigation.PushAsync(new ContentsPageDetail());
            /*switch (SelectedItem.Id)
            {
                case 0:
                    await Navigation.PushAsync(new ContentsPageDetail());
                    break;
            }*/
        }
    }
}
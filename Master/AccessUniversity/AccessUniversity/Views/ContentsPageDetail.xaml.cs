using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessUniversity.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccessUniversity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsPageDetail : ContentPage
    {
        public ContentsPageDetail()
        {
            InitializeComponent();
            BindingContext = new ContentsPageDetailViewModel();
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = e.Item as ContentsPageDetailViewModel;
            await Navigation.PushAsync(new PDFViewer());
        }
    }
}
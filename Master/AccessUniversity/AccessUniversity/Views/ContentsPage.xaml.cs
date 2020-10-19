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
    }
}
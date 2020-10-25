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
    public partial class LanguageSettings : ContentPage
    {
        public LanguageSettings()
        {
            InitializeComponent();
            BindingContext = new LanguageSettingsViewModel();
        }
    }
}
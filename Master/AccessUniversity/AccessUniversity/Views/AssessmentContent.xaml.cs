using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccessUniversity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentContent : ContentPage
    {
       

        public AssessmentContent()
        {
            InitializeComponent();

        }

        private void BtnUnit_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnStudent_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnLib_Clicked(object sender, EventArgs e)
        {

        }


        private void BtnEmergency_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new EmergencyPage());
        }

        private void BtnPDF_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentsPDF());
        }
    }
}
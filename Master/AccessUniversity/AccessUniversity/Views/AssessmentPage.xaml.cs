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
    public partial class AssessmentPage : ContentPage
    {
        int clickTotal_1;
        int clickTotal_2;
        int clickTotal_3;
        int clickTotal_4; 
        int clickTotal_5;
        int clickTotal_6;
        int clickTotal_7;

        public AssessmentPage()
        {
            InitializeComponent();
        }

        private void BtnAssess01_Clicked(object sender, EventArgs e)
        {
            clickTotal_1 += 1;
            label.Text = $"{clickTotal_1} Assessment01 Button click{(clickTotal_1 == 1 ? "" : "s")}";
        }

        private void BtnAssess02_Clicked(object sender, EventArgs e)
        {
            clickTotal_2 += 1;
            label.Text = $"{clickTotal_2} Assessment02 Button click{(clickTotal_2 == 1 ? "" : "s")}";
        }

        private void BtnAssess03_Clicked(object sender, EventArgs e)
        {
            clickTotal_3 += 1;
            label.Text = $"{clickTotal_3} Assessment03 Button click{(clickTotal_3 == 1 ? "" : "s")}";
        }

        private void BtnUnit_Clicked(object sender, EventArgs e)
        {
            clickTotal_4 += 1;
            label.Text = $"{clickTotal_4} Unit Button click{(clickTotal_4 == 1 ? "" : "s")}";
        }

        private void BtnStudent_Clicked(object sender, EventArgs e)
        {
            clickTotal_5 += 1;
            label.Text = $"{clickTotal_5} eStudent Button click{(clickTotal_5 == 1 ? "" : "s")}";
        }

        private void BtnLib_Clicked(object sender, EventArgs e)
        {
            clickTotal_6 += 1;
            label.Text = $"{clickTotal_6} Library Button click{(clickTotal_6 == 1 ? "" : "s")}";
        }

        private void BtnEmergency_Clicked(object sender, EventArgs e)
        {
            clickTotal_7 += 1;
            label.Text = $"{clickTotal_7} Emergency Button click{(clickTotal_7 == 1 ? "" : "s")}";

        }
    }
}
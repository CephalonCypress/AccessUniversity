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

        int clickTotal_1;
        int clickTotal_2;
        int clickTotal_3;
        int clickTotal_4;
        int clickTotal_5;

        public AssessmentContent()
        {
            InitializeComponent();
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            clickTotal_1 += 1;
            label.Text = $"{clickTotal_1} Back Button click{(clickTotal_1 == 1 ? "" : "s")}";
        }

        private void BtnUnit_Clicked(object sender, EventArgs e)
        {
            clickTotal_2 += 1;
            label.Text = $"{clickTotal_2} Unit Button click{(clickTotal_2 == 1 ? "" : "s")}";
        }

        private void BtnStudent_Clicked(object sender, EventArgs e)
        {
            clickTotal_3 += 1;
            label.Text = $"{clickTotal_3} Unit Button click{(clickTotal_3 == 1 ? "" : "s")}";
        }

        private void BtnLib_Clicked_1(object sender, EventArgs e)
        {
            clickTotal_4 += 1;
            label.Text = $"{clickTotal_4} Unit Button click{(clickTotal_4 == 1 ? "" : "s")}";
        }

        private void BtnEmergency_Clicked(object sender, EventArgs e)
        {
            clickTotal_5 += 1;
            label.Text = $"{clickTotal_5} Unit Button click{(clickTotal_5 == 1 ? "" : "s")}";
        }
    }
}
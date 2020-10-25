using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using FormsVideoLibrary;

namespace AccessUniversity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectureVideos : ContentPage
    {
        public LectureVideos()
        {
            InitializeComponent();
        }

        async void URLopen(object sender, EventArgs e)
        {
            videoPlayer.Source = new FileVideoSource { File = videoURL.Text };
            Localbutton.IsVisible = false;
            URLbutton.IsVisible = false;
            videoURL.IsVisible = false;
        }

        async void Localopen(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;

            string filename = await DependencyService.Get<IVideoPicker>().GetVideoFileAsync();

            if (!String.IsNullOrWhiteSpace(filename))
            {
                videoPlayer.Source = new FileVideoSource
                {
                    File = filename
                };
            }
            Localbutton.TextColor = Color.GhostWhite;
            Localbutton.BackgroundColor = Color.Black;
            URLbutton.TextColor = Color.GhostWhite;
            URLbutton.BackgroundColor = Color.DarkGray;
            videoURL.BackgroundColor = Color.Black;
            videoURL.Text = "Enter here";
            videoURL.TextColor = Color.GhostWhite;
            BackgroundColor = Color.Black;
            

            btn.IsEnabled = true;
        }
    }
}
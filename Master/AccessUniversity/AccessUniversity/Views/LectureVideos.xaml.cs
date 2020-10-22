using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xam.Forms.VideoPlayer;

namespace AccessUniversity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectureVideos : ContentPage
    {
        public LectureVideos()
        {
            InitializeComponent();
        }

        async void URLopen(System.Object sender, System.EventArgs e)
        {
            string filename = await DependencyService.Get<IVideoPicker>().GetVideoFileAsync();
            if (!string.IsNullOrWhiteSpace(filename))
            {
                selectedVideo.Source = new FileMediaSource
                {
                    File = filename

                };

                test.Text = "success";
            }
            test.Text = "2390fi32df2039if";
            test.FontSize = 50;
        }

        async void Localopen(System.Object sender, System.EventArgs e)
        {
            string filename = await DependencyService.Get<IVideoPicker>().GetVideoFileAsync();
            if (!string.IsNullOrWhiteSpace(filename))
            {
                selectedVideo.Source = new FileMediaSource
                {
                    File = filename

                };

                test.Text = "success";
            }
            test.Text = "2390fi32df2039if";
            test.FontSize = 50;
        }
    }
}
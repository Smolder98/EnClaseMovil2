using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;

namespace PM2P1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        public PhotoPage()
        {
            InitializeComponent();
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            var fotografia = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions { 
                
                Directory = "MisFotos",
                Name = "Test.jpg",
                SaveToAlbum = true,
                AllowCropping = true,
                RotateImage = true

            });


            await DisplayAlert("Direcctorio", fotografia.Path, "OK");


            if (fotografia != null)
            {
                Foto.Source = ImageSource.FromStream(() => {

                    return fotografia.GetStream();
                });
            }

        }
    }
}
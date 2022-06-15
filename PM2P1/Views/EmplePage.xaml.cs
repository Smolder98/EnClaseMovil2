using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2P1.Models;
using PM2P1.Controller;
using System.IO;
using Plugin.Media;

using Xamarin.Essentials;

namespace PM2P1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {

        Plugin.Media.Abstractions.MediaFile FileFoto = null;
        public EmplePage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(txtid.Text))
            {
                btnAdd.Text = "Modificar";
            }

            //var location = await Geolocation.GetLocationAsync();


        }

        private Byte[] ConvertImageToByteArray()
        {
            if (FileFoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = FileFoto.GetStream();

                    stream.CopyTo(memory);

                    return memory.ToArray();
                } 
            }

            return null;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (FileFoto==null)
            {
                await DisplayAlert("Error", "No se a tomado una fotografia", "OK");
                return;
            }

            var id = (string.IsNullOrEmpty(txtid.Text))?0:int.Parse(txtid.Text);

              var emple = new Empleado
              {
                  id = id,
                  nombre = txtnombre.Text,
                  edad = txtedad.Text,
                  genero = txtgenero.SelectedItem.ToString(),
                  fechaIngreso = txtfecha.Date,
                  foto = ConvertImageToByteArray()
              };


              var result = await App.DBase.insertUpdateEmpleado(emple);

              if (result > 0)
              {
                  await DisplayAlert("Empleado adicionado", "Aviso", "OK");
              }
              else
              {
                  await DisplayAlert("Ha ocurrido un error", "Aviso", "OK");
              }
            

        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {

            var emple = new Empleado
            {
                id = int.Parse(txtid.Text)
               
            };


            var result = await App.DBase.deleteEmpleado(emple);

            if (result > 0)
            {
                await DisplayAlert("Empleado eliminado", "Aviso", "OK");
            }
            else
            {
                await DisplayAlert("Ha ocurrido un error", "Aviso", "OK");
            }
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileFoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                    //Directory = "MisFotos",
                   // Name = "Test.jpg",
                    //SaveToAlbum = true,
                   // AllowCropping = true,
                    //RotateImage = true

                });

                await DisplayAlert("Direcctorio", FileFoto.Path, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Direcctorio", ex.Message, "OK");
            }

            

            if (FileFoto != null)
            {
                foto.Source = ImageSource.FromStream(() => {

                    return FileFoto.GetStream();
                });
            }

            //data/user/0/nombreDelPaquete/files/.local/share/NombreDeLaBaseDeDatos;
        }
    }
}
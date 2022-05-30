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

namespace PM2P1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {
        public EmplePage()
        {
            InitializeComponent();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
          
            //data/user/0/nombreDelPaquete/files/.local/share/NombreDeLaBaseDeDatos;
            
              var emple = new Empleado
              {
                  id = 0,
                  nombre = txtnombre.Text,
                  edad = txtedad.Text,
                  genero = txtgenero.SelectedItem.ToString(),
                  fechaIngreso = txtfecha.Date
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

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
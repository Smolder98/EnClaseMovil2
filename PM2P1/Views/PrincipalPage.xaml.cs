using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PM2P1.Models;

namespace PM2P1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();
        }

        

        private async void toolMenu1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmplePage());
        }

        private async void listaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Emple = (Empleado)e.Item;

            await DisplayAlert("","Elemento seleccionado: " + Emple.nombre + " Fecha: "+ Emple.fechaIngreso, "OK");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                listaEmpleados.ItemsSource = await App.DBase.getListEmpleado();
            }
            catch (Exception e)
            {

            }

            
        }
    }
}
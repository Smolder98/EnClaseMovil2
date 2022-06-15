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

        private async void listaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Emple = (Empleado)e.Item;

            //await DisplayAlert("","Elemento seleccionado: " + Emple.nombre + " Fecha: "+ Emple.fechaIngreso, "OK");

            EmplePage viewEmple = new EmplePage();
            viewEmple.BindingContext = Emple;

            await Navigation.PushAsync(viewEmple);
        }
        private async void toolMenu1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmplePage());
        }

        private async void toolMenu2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmplePageCollection());
        }

        private async void toolMenu3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePageCollection : ContentPage
    {
        public EmplePageCollection()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listEmple.ItemsSource = await App.DBase.getListEmpleado();
        }

        private void listEmple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
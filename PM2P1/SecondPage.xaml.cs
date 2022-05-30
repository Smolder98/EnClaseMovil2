using PM2P1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        public SecondPage(String nombre, String edad)
        {
            InitializeComponent();

            lblnombre.Text = nombre;
            lbledad.Text = edad;
        }

    }
}
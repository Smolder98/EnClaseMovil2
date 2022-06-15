using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2P1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewEmplePage : ContentPage
    {
        public ViewEmplePage()
        {
            InitializeComponent();
        }

        public ViewEmplePage(Empleado empleado)
        {
            InitializeComponent();

            empleName.Text = empleado.nombre;
            empleEdad.Text = empleado.edad;
            empleFecha.Text = empleado.fechaIngreso.ToString();

        }
    }
}
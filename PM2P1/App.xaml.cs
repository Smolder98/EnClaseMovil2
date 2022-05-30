using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2P1.Controller;
using System.IO;
using PM2P1.Views;

namespace PM2P1
{
    public partial class App : Application
    {

        static DataBase db;

        public static DataBase DBase
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Emple.db3");
                    
                    db = new DataBase(folderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PrincipalPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

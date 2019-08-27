using eFastFood.Login;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eFastFood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var id = Preferences.Get("User_id", -1);
            if (id != -1)
            {
                Preferences.Set("showContent", false);
                Prijava prijava = new Prijava();
                MainPage = prijava;
                prijava.id = id;
                prijava.PrijavaCommand.Execute(null);

            }
            else
                MainPage = new NavigationPage(new Prijava());
            //new NavigationPage(new Prijava());//new Navigacija.MDPage();  new Pages.Narudzbe(); new Prijava();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

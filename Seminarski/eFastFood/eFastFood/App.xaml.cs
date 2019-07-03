using eFastFood.Navigacija;
using Xamarin.Forms;

namespace eFastFood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MDPage();   //new NavigationPage(new Prijava());  new Pages.Narudzbe();  new Prijava();

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

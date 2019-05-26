using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pocetna : ContentPage
    {
        public Pocetna()
        {
            InitializeComponent();
        }

        private async void Cart_Clicked(object sender, EventArgs e)
        {
            var page = (Page)Activator.CreateInstance(typeof(Korpa));
            page.Title = "Korpa";
            await this.Navigation.PushAsync(page);
        }
    }
}
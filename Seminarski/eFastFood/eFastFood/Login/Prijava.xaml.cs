using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prijava : ContentPage
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void Prijava_Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Prijava", "Prijava kliknuta", "Zatvori");
        }

        private void Registracija_Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Registracija());
        }
    }
}
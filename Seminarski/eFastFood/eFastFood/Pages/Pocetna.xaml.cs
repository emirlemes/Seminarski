using eFastFood.ViewModels;
using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pocetna : ContentPage
    {
        public Pocetna()
        {
            InitializeComponent();
            BindingContext = new PocetnaVM(this);
        }

        private void ListaProizvoda_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var gp = e.Item as GotoviProizvod;
            this.Navigation.PushAsync(new GotoviProizvodDetalji(gp.GotoviProizvodID, false));
        }
    }
}
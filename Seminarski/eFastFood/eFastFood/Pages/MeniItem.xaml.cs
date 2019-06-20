using eFastFood.ViewModels;
using eFastFood_PCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeniItem : ContentPage
    {
        public MeniItem(string Title, List<GotoviProizvod> gotoviProizvodi)
        {
            InitializeComponent();
            BindingContext = new MeniItemVM(this, Title, gotoviProizvodi);
        }

        //private void AddToCart_Tapped(object sender, EventArgs e)
        //{
        //    DisplayAlert("Radi", "Radi", "OK");
        //}
    }
}
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
        private object bc;
        public MeniItem(string Title, List<GotoviProizvod> gotoviProizvodi)
        {
            InitializeComponent();
            bc = new MeniItemVM(this, Title, gotoviProizvodi);
            BindingContext = bc;
        }

        protected override void OnAppearing()
        {
            ((MeniItemVM)bc).PriceOfCart = Global.GetOrderPrice();
            base.OnAppearing();
        }
    }
}
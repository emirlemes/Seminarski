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
        public MeniItem()
        {
            InitializeComponent();
        }

        private void AddToCart_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Radi", "Radi", "OK");
        }
    }
}
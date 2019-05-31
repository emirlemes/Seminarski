using eFastFood;
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
    public partial class Korpa : ContentPage
    {
        public Korpa()
        {
            InitializeComponent();
            if (Global.trenutnaNarudzba==null && Global.trenutnaNarudzba?.NarudzbaStavka?.Count  == 0)
                textCentar.Text = "Korpa je prazna.";
            else
                LoadKorpa();
        }

        private void LoadKorpa()
        {
            
        }
    }
}
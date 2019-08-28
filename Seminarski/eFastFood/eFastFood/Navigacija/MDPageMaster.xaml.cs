using eFastFood.Login;
using eFastFood.Pages;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Navigacija
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageMaster : ContentPage
    {
        public RelayCommand LogOut { get; }
        public MDPageMaster()
        {
            LogOut = new RelayCommand(() => LO());
            InitializeComponent();
            listView.ItemsSource = new List<MDPageMenuItem>()
            {
                    new MDPageMenuItem { Id = 0, Title = "Početna", TargetType=typeof(Pocetna), ImageSource="home.png" },
                    new MDPageMenuItem { Id = 1, Title = "Meni" , TargetType=typeof(Meni), ImageSource="menu.png" },
                    new MDPageMenuItem { Id = 2, Title = "Korpa" , TargetType=typeof(Korpa), ImageSource="cart.png" },
                    new MDPageMenuItem { Id = 3, Title = "Narudžbe" , TargetType=typeof(Narudzbe), ImageSource="orders.png" },
                    new MDPageMenuItem { Id = 4, Title = "Profil" , TargetType=typeof(Profil), ImageSource="profil.png" },
            };
        }

        private void LO()
        {
            Preferences.Set("showContent", true);
            Preferences.Set("User_id", -1);
            Application.Current.MainPage = new NavigationPage(new Prijava());
        }
    }
}
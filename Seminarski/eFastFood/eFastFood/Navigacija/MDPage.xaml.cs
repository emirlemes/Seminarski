using eFastFood.Login;
using eFastFood.Pages;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Navigacija
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage
    {
        MDPageMaster masterPage;
        public RelayCommand LogOut { get; }

        public MDPage()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                LO();
            };
            masterPage = new MDPageMaster();
            Master = masterPage;
            Detail = new NavigationPage(new Pocetna());
            masterPage.listView.ItemSelected += OnItemSelected;
            masterPage.izlaz.GestureRecognizers.Add(tapGestureRecognizer);
        }


        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MDPageMenuItem;
            if (item != null)
            {
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
                var root = Detail.Navigation.NavigationStack[0];
                if (item.TargetType != root.GetType())
                {
                    //https://github.com/xamarin/Xamarin.Forms/issues/4398
                    //Delay je zbog Bug-a u Xamarinu koje jos nije popravljen
                    //if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(225);
                    //(Page)Activator.CreateInstance(item.TargetType);

                    Detail.Navigation.InsertPageBefore((Page)Activator.CreateInstance(item.TargetType), root);
                    await Detail.Navigation.PopToRootAsync(false);
                }

            }
        }
        private void LO()
        {
            Preferences.Set("showContent", true);
            Preferences.Set("User_id", -1);
            Application.Current.MainPage = new NavigationPage(new Prijava());
        }
        private void Cart_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Korpa)));
        }
    }
}
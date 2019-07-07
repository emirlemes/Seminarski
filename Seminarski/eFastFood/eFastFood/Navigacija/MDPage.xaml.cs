using eFastFood.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Navigacija
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage
    {
        MDPageMaster masterPage;

        public MDPage()
        {

            masterPage = new MDPageMaster();
            Master = masterPage;
            Detail = new NavigationPage(new Pocetna());
            masterPage.listView.ItemSelected += OnItemSelected;
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

        private void Cart_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Korpa)));
        }
    }
}
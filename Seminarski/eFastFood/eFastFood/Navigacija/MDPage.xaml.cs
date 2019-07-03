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


        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MDPageMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }

        private void Cart_Clicked(object sender, EventArgs e)
        {
            var page = (Page)Activator.CreateInstance(typeof(Korpa));
            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}
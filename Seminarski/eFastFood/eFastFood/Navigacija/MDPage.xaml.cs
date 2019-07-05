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
                var page = (Page)Activator.CreateInstance(item.TargetType);
                var root = Detail.Navigation.NavigationStack[0];
                masterPage.listView.SelectedItem = null;
                if (item.TargetType != root.GetType())
                {
                    //(Page)Activator.CreateInstance(item.TargetType);
                    Detail.Navigation.InsertPageBefore(page, root);
                    Device.BeginInvokeOnMainThread(async () => await Detail.Navigation.PopToRootAsync(false));
                }
                else
                    IsPresented = false;

                if (null != page)
                    page.Appearing += CloseMenuEvent;

            }
        }

        private void CloseMenuEvent(object o, EventArgs args)
        {
            IsPresented = false;
            var stack = Detail.Navigation.NavigationStack;
            if (null != stack && stack.Count > 0)
                Detail.Navigation.NavigationStack[0].Appearing -= CloseMenuEvent;
        }

        private void Cart_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Korpa)));
        }
    }
}
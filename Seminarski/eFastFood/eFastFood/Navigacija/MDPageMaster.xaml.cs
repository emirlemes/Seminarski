using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Pages;

namespace XamarinApp.Navigacija
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageMaster : ContentPage
    {
        public ListView ListView;

        public MDPageMaster()
        {
            InitializeComponent();

            BindingContext = new MDPageMasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPageMasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageMenuItem> MenuItems { get; set; }

            public MDPageMasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageMenuItem>(new[]
                {
                    new MDPageMenuItem { Id = 0, Title = "Početna", TargetType=typeof(Pocetna), ImageSource="home.png" },
                    new MDPageMenuItem { Id = 1, Title = "Meni" , TargetType=typeof(Meni), ImageSource="menu.png" },
                    new MDPageMenuItem { Id = 2, Title = "Korpa" , TargetType=typeof(Korpa), ImageSource="cart.png" },
                    new MDPageMenuItem { Id = 3, Title = "Narudžbe" , TargetType=typeof(Narudzbe), ImageSource="orders.png" },
                    new MDPageMenuItem { Id = 4, Title = "Profil" , TargetType=typeof(Profil), ImageSource="profil.png" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
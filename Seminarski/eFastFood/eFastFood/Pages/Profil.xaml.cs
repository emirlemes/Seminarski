using eFastFood.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profil : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Profil()
        {
            InitializeComponent();
            BindingContext = new ProfilVM(this);
        }
    }
}

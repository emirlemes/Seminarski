using eFastFood.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profil : ContentPage
    {
        public Profil()
        {
            InitializeComponent();
            BindingContext = new ProfilVM(this);
        }
    }
}

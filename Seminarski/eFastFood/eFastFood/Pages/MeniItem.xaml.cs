using eFastFood.ViewModels;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeniItem : ContentPage
    {
        private object bc;
        public MeniItem(string Title)
        {
            InitializeComponent();
            bc = new MeniItemVM(this, Title);
            BindingContext = bc;
        }

        protected override void OnAppearing()
        {
            ((MeniItemVM)bc).PriceOfCart = Global.GetOrderPrice();
            base.OnAppearing();
        }
    }
}
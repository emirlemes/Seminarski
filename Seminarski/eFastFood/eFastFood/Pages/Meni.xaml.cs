using eFastFood.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Meni : TabbedPage
    {
        public Meni()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            if (BindingContext == null)
                await Task.Run(() => BindingContext = new MeniVM(this));

            base.OnAppearing();
        }
    }
}
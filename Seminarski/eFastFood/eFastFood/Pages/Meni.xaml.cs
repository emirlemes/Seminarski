using eFastFood.ViewModels;

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
            BindingContext = new MeniVM(this);

        }
    }
}
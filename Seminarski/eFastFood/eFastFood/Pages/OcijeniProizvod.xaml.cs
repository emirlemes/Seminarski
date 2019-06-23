using eFastFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcijeniProizvod : ContentPage
    {
        public OcijeniProizvod()
        {
            InitializeComponent();
        }

        public OcijeniProizvod(int id)
        {
            InitializeComponent();
            BindingContext = new OcijeniProizvodVM(this, id);
        }
    }
}
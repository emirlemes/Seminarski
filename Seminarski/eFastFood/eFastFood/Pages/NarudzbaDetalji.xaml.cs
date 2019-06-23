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
    public partial class NarudzbaDetalji : ContentPage
    {
        public NarudzbaDetalji()
        {
            InitializeComponent();
            BindingContext = new NarudzbaDetaljiVM(this);
        }
    }
}
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
    public partial class GotoviProizvodDetalji : ContentPage
    {
        double StepValue = 1.0;
        public GotoviProizvodDetalji()
        {
            InitializeComponent();
        }

        public GotoviProizvodDetalji(int id, bool ocijeni)
        {
            InitializeComponent();
            BindingContext = new GotoviProizvodDetaljiVM(this, id, ocijeni);
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            slider.Value = newStep * StepValue;
        }
    }
}
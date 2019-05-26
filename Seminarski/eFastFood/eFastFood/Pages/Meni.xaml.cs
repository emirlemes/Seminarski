using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Meni : TabbedPage
    {
        public Meni()
        {
            InitializeComponent();
            //KategorijaPage
            this.Children.Add(new Pocetna() { Title = "Kategorija 1" });
            this.Children.Add(new Pocetna() { Title = "Kategorija 2" });
        }
    }
}
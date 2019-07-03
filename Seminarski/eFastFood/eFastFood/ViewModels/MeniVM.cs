using eFastFood.Pages;
using eFastFood_PCL.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    class MeniVM : INotifyPropertyChanged
    {
        private TabbedPage page { get; set; }

        public MeniVM(TabbedPage page)
        {
            this.page = page;
            LoadTabs();
        }

        private void LoadTabs()
        {
            IsBusy = true;
            List<string> kategorije = Global.proizvodi.Select(x => x.Kategorija.Naziv).Distinct().ToList();
            foreach (var naziv in kategorije)
                page.Children.Add(new MeniItem(naziv));
            IsBusy = false;
        }

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}

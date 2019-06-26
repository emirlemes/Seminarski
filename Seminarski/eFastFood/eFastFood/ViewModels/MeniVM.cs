using eFastFood.Pages;
using eFastFood_PCL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
            Task.Run(() => LoadTabs());
        }

        private void LoadTabs()
        {
            IsBusy = true;
            List<string> kategorije = Global.proizvodi.Select(x => x.Kategorija.Naziv).Distinct().ToList();
            foreach (var naziv in kategorije)
            {
                List<GotoviProizvod> proizvodi = Global.proizvodi.Where(x => x.Kategorija.Naziv == naziv).ToList();
                page.Children.Add(new MeniItem(naziv, proizvodi));
            }
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

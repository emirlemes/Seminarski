using eFastFood.Pages;
using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    public class KorpaVM : INotifyPropertyChanged
    {
        private Page page { get; set; }
        private ObservableCollection<GotoviProizvodXaml> _GotoviProizvodiList { get; set; } = new ObservableCollection<GotoviProizvodXaml>();


        public ObservableCollection<GotoviProizvodXaml> GotoviProizvodiList
        {
            get { return _GotoviProizvodiList; }
            set { _GotoviProizvodiList = value; OnPropertyChanged(); }
        }

        public RelayCommand Naruci { get; set; }

        public KorpaVM()
        {
        }

        public KorpaVM(Page page)
        {
            Naruci = new RelayCommand(async () => await ZakljuciNarudzbu(), canExecute);
            this.page = page;
            IsBusy = true;
            LoadProizvode();
            IsBusy = false;
        }

        private bool canExecute() { return GotoviProizvodiList.Count > 0; }

        private async Task ZakljuciNarudzbu()
        {
            await page.Navigation.PushAsync(new NarudzbaDetalji());

        }

        private void LoadProizvode()
        {
            foreach (var item in Global.stavkeNarudzbe)
            {
                var obj = Global.proizvodi.FirstOrDefault(x => x.GotoviProizvodID == item.GotoviProizvodID);
                GotoviProizvodXaml model = JsonConvert.DeserializeObject<GotoviProizvodXaml>(JsonConvert.SerializeObject(obj));
                GotoviProizvodiList.Add(model);
            }


            foreach (var item in GotoviProizvodiList)
                item.Kolicina = Global.stavkeNarudzbe.Where(x => x.GotoviProizvodID == item.GotoviProizvodID).FirstOrDefault().Kolicina;
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

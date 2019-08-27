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
        private float _PriceOfCart { get; set; }

        public string Title { get; set; } = "Korpa";

        public ObservableCollection<GotoviProizvodXaml> GotoviProizvodiList
        {
            get { return _GotoviProizvodiList; }
            set { _GotoviProizvodiList = value; OnPropertyChanged(); }
        }

        public float PriceOfCart
        {
            get { return _PriceOfCart; }
            set { _PriceOfCart = value; OnPropertyChanged(); }
        }

        public RelayCommand Naruci { get; set; }

        public KorpaVM(Page page)
        {
            this.page = page;
            LoadProizvode();
            Naruci = new RelayCommand(async () => await ZakljuciNarudzbu(), () => GotoviProizvodiList.Count > 0);
            PriceOfCart = Global.GetOrderPrice();
        }

        private async Task ZakljuciNarudzbu()
        {
            if (GotoviProizvodiList.Where(x => x.Kolicina == 0).ToList().Count > 0)
                await page.DisplayAlert(Messages.error, Messages.quantity_zero, Messages.ok);
            else
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

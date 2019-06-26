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
    public class NarudzbeVM : INotifyPropertyChanged
    {
        private APIHelper narudzbeService = new APIHelper(Global.ApiUrl, Global.NarudzbeRoute);

        private Page page { get; set; }
        private ObservableCollection<GotoviProizvod> _OrdersList { get; set; }

        public ObservableCollection<GotoviProizvod> OrdersList
        {
            get { return _OrdersList; }
            set { _OrdersList = value; OnPropertyChanged(); }
        }


        public NarudzbeVM() { }

        public NarudzbeVM(Page page)
        {

            this.page = page;
            IsBusy = true;
            Task.Run(async () => await LoadData());
            IsBusy = false;
        }

        private async Task LoadData()
        {
            HttpResponseMessage responseN = await narudzbeService.GetActionResponse("UserOrders", Global.prijavnjeniKorisnik.KlijentID.ToString());

            if (responseN.IsSuccessStatusCode)
            {
                List<int> orders = JsonConvert.DeserializeObject<List<int>>(await responseN.Content.ReadAsStringAsync());

                ObservableCollection<GotoviProizvod> list = new ObservableCollection<GotoviProizvod>();
                Global.proizvodi.Where(x => orders.Contains(x.GotoviProizvodID)).ToList().ForEach(c => list.Add(c));
                OrdersList = list;
            }
            else
                await page.DisplayAlert(Messages.error, responseN.ReasonPhrase, Messages.ok);
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

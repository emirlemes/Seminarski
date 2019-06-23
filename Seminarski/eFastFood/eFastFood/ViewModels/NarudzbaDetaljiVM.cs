using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    public class NarudzbaDetaljiVM : INotifyPropertyChanged
    {
        private APIHelper narudzbeService = new APIHelper(Global.ApiUrl, Global.NarudzbeRoute);
        private APIHelper dostavaService = new APIHelper(Global.ApiUrl, Global.DostavaRoute);

        private Page page { get; set; }
        private bool _AddressaShow { get; set; }
        private bool _PreuzmiURestoran { get; set; }
        private string _AddressText { get; set; } = "";

        public string AddressText
        {
            get { return _AddressText; }
            set
            {
                if (_AddressText.Length <= 49)
                {
                    _AddressText = value;
                    OnPropertyChanged();
                    if (_AddressText.Length > 3)
                        NaruciBtn.RaiseCanExecuteChanged();
                }
            }
        }

        public bool AddressaShow
        {
            get { return _AddressaShow; }
            set { _AddressaShow = value; OnPropertyChanged(); }
        }

        public bool PreuzmiURestoran
        {
            get { return _PreuzmiURestoran; }
            set { _PreuzmiURestoran = value; OnPropertyChanged(); }
        }

        public RelayCommand DostavaBtn { get; set; }

        public RelayCommand PreuzmiURestoranuBtn { get; set; }

        public RelayCommand NaruciBtn { get; set; }

        public NarudzbaDetaljiVM(Page page)
        {
            DostavaBtn = new RelayCommand(ShowDostava);
            PreuzmiURestoranuBtn = new RelayCommand(ShowPreuzmi);
            NaruciBtn = new RelayCommand(async () => await Naruci(), canExecute);
            this.page = page;
        }

        private bool canExecute() => AddressText.Length > 3;

        private async Task Naruci()
        {
            Narudzba narudzba = new Narudzba()
            {
                Datum = DateTime.Now,
                KlijentID = Global.prijavnjeniKorisnik.KlijentID,
                Status = "Nova",
                VrstaNarudzbe = "ONLINE"
            };
            narudzba.NarudzbaStavka = Global.stavkeNarudzbe.ToList();
            decimal ukupnaCijena = 0;
            foreach (var item in Global.stavkeNarudzbe)
                ukupnaCijena += Global.proizvodi.Where(x => x.GotoviProizvodID == item.GotoviProizvodID).Select(c => c.Cijena * item.Kolicina).Sum();

            narudzba.UkupnaCijena = ukupnaCijena;

            HttpResponseMessage responseN = new HttpResponseMessage();
            if (AddressaShow)
            {
                responseN = await narudzbeService.PostActionResponse("MobileOrder", narudzba);
                Narudzba n = JsonConvert.DeserializeObject<Narudzba>(await responseN.Content.ReadAsStringAsync());
                HttpResponseMessage responseD = await dostavaService.PostActionResponse("DostavaNaAdresu/" + n.NarudzbaID.ToString() + "/" + AddressText, new { nadudzbaId = n.NarudzbaID, adresaDostave = AddressText }); //narudzbaId,adresaDostave
                if (!responseD.IsSuccessStatusCode)
                    await page.DisplayAlert(Messages.error, responseD.ReasonPhrase, Messages.ok);
            }
            else if (PreuzmiURestoran)
                responseN = await narudzbeService.PostActionResponse("MobileOrder", narudzba);

            if (responseN != null)
            {
                if (responseN.IsSuccessStatusCode)
                {
                    await page.DisplayAlert(Messages.success, Messages.order_success, Messages.ok);
                    Global.stavkeNarudzbe.Clear();
                }
                else
                    await page.DisplayAlert(Messages.error, responseN.ReasonPhrase, Messages.ok);
            }
            else
                await page.DisplayAlert(Messages.error, Messages.connec_err, Messages.ok);
        }

        private void ShowPreuzmi()
        {
            if (AddressaShow) AddressaShow = false;
            AddressText = "Restoran";
            PreuzmiURestoran = true;
        }

        private void ShowDostava()
        {
            AddressText = "";
            if (PreuzmiURestoran) PreuzmiURestoran = false;
            AddressaShow = true;
        }

        public NarudzbaDetaljiVM() { }



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

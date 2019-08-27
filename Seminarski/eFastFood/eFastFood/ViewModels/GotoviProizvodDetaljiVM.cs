using eFastFood.Pages;
using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    public class GotoviProizvodDetaljiVM : INotifyPropertyChanged
    {
        APIHelper gotoviPPService = new APIHelper(Global.ApiUrl, Global.GPProizvodRoute);
        APIHelper ocjenaService = new APIHelper(Global.ApiUrl, Global.OcjenaRoute);


        private Page page { get; set; }
        private bool _ShowOcijeni { get; set; }
        private GotoviProizvod _GP { get; set; }
        private ObservableCollection<string> _Sastojci { get; set; }
        private int _SastojciVisina { get; set; }
        private string _Komentar { get; set; }
        private int _SliderValue { get; set; }

        public int SliderValue
        {
            get { return _SliderValue; }
            set { _SliderValue = value; OnPropertyChanged(); }
        }

        public string Komentar
        {
            get { return _Komentar; }
            set { _Komentar = value; OnPropertyChanged(); }
        }

        public bool ShowOcijeni
        {
            get { return _ShowOcijeni; }
            set { _ShowOcijeni = value; OnPropertyChanged(); }
        }

        public GotoviProizvod GP
        {
            get { return _GP; }
            set { _GP = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Sastojci
        {
            get { return _Sastojci; }
            set { _Sastojci = value; OnPropertyChanged(); }
        }

        public int SastojciVisina
        {
            get { return _SastojciVisina; }
            set { _SastojciVisina = value; OnPropertyChanged(); }
        }

        public RelayCommand OcijeniBtn { get; set; }

        public GotoviProizvodDetaljiVM(Page page, int id, bool ocijeni)
        {
            OcijeniBtn = new RelayCommand(async () => await Ocijeni());
            ShowOcijeni = ocijeni;
            this.page = page;
            GP = Global.proizvodi.Find(x => x.GotoviProizvodID == id);
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            IsBusy = true;
            HttpResponseMessage responseGPP = await gotoviPPService.GetActionResponse("ProizvodiByGID", GP.GotoviProizvodID.ToString());

            if (responseGPP.IsSuccessStatusCode)
            {
                Sastojci = JsonConvert.DeserializeObject<ObservableCollection<string>>(await responseGPP.Content.ReadAsStringAsync());
                SastojciVisina = Sastojci.Count * 50;
            }
            else
                await page.DisplayAlert(Messages.error, responseGPP.ReasonPhrase, Messages.ok);

            HttpResponseMessage reponseO = await ocjenaService.GetActionResponse("OcjenaUserProduct", Global.prijavnjeniKorisnik.KlijentID.ToString() + "/" + GP.GotoviProizvodID.ToString());

            if (reponseO.IsSuccessStatusCode)
            {
                var sliderValue = JsonConvert.DeserializeObject<Ocjena>(await reponseO.Content.ReadAsStringAsync());
                SliderValue = sliderValue.NumerickaOcjena;
                Komentar = sliderValue.Komentar;
            }
            else
                await page.DisplayAlert(Messages.error, reponseO.ReasonPhrase, Messages.ok);

            IsBusy = false;
        }

        private async Task Ocijeni()
        {
            Ocjena ocjena = new Ocjena()
            {
                GotoviProizvodID = GP.GotoviProizvodID,
                KlijentID = Global.prijavnjeniKorisnik.KlijentID,
                NumerickaOcjena = SliderValue,
                Komentar = Komentar
            };

            HttpResponseMessage reponseO = await ocjenaService.PostResponse(ocjena);

            if (reponseO.IsSuccessStatusCode)
                await page.DisplayAlert(Messages.success, Messages.success_rated, Messages.ok);
            else
                await page.DisplayAlert(Messages.error, reponseO.ReasonPhrase, Messages.ok);
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

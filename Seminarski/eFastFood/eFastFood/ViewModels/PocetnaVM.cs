using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Pages;

namespace eFastFood.ViewModels
{
    public class PocetnaVM : INotifyPropertyChanged
    {
        private APIHelper gotoviProizvidiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);
        private List<GotoviProizvod> _gpList { get; set; }

        private Page page { get; set; }

        //OBRISATI
        private APIHelper klijentService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);
        //OBRISATI


        public string Title { get; set; } = "Početna";

        public List<GotoviProizvod> GotoviProizvodiList
        {
            get { return _gpList; }
            set
            {
                _gpList = value;
                OnPropertyChanged();
            }
        }


        public Command AddToCart_Tapped { get; }

        public RelayCommand Cart_Clicked { get; }

        public Command OpisModal_Tapped { get; }

        public PocetnaVM() { }

        public PocetnaVM(Page page)
        {
            this.page = page;
            Cart_Clicked = new RelayCommand(async () => await page.Navigation.PushAsync(new Korpa()));
            AddToCart_Tapped = new Command<string>(AddToCart);
            OpisModal_Tapped = new Command(ModalDisplay);
            Task.Run(async () => await LoadProizvode());
        }

        private void ModalDisplay(object obj)
        {
            throw new NotImplementedException();
        }

        private void AddToCart(string id)
        {
            if (int.TryParse(id, out int rez))
            {
                //dodati taj proizvod u korpu
                rez++;
            }
            throw new NotImplementedException();
        }

        private async Task LoadProizvode()
        {
            //OBRISATI
            Global.prijavnjeniKorisnik = JsonConvert.DeserializeObject<Klijent>(await (await klijentService.GetResponse(2.ToString())).Content.ReadAsStringAsync());
            //OBRISATI


            if (Global.proizvodi == null)
            {
                IsBusy = true;
                HttpResponseMessage responseGP = await gotoviProizvidiService.GetActionResponse("GotoviProizvodMobile");

                if (responseGP.IsSuccessStatusCode)
                {
                    var gplista = JsonConvert.DeserializeObject<List<GotoviProizvod>>(await responseGP.Content.ReadAsStringAsync());
                    Global.proizvodi = gplista;
                    GotoviProizvodiList = Global.proizvodi;
                    IsBusy = false;
                }
                else
                {
                    IsBusy = false;
                    await page.DisplayAlert(Messages.error, responseGP.ReasonPhrase, Messages.ok);
                }
            }
            else
            {
                IsBusy = true;
                GotoviProizvodiList = Global.proizvodi;
                IsBusy = false;
            }
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

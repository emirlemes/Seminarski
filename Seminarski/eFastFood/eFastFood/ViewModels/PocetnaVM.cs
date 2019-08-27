using eFastFood.Pages;
using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    public class PocetnaVM : INotifyPropertyChanged
    {
        private APIHelper gotoviProizvidiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);

        private ObservableCollection<GotoviProizvod> _gpList { get; set; }
        private Page page { get; set; }
        private float _PriceOfCart { get; set; }
        //OBRISATI
        private APIHelper klijentService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);
        //OBRISATI

        public float PriceOfCart
        {
            get { return _PriceOfCart; }
            set { _PriceOfCart = value; OnPropertyChanged(); }
        }

        public string Title { get; set; } = "Početna";

        public ObservableCollection<GotoviProizvod> GotoviProizvodiList
        {
            get { return _gpList; }
            set { _gpList = value; OnPropertyChanged(); }
        }


        public Command AddToCart_Tapped { get; }

        public RelayCommand Cart_Clicked { get; }

        public PocetnaVM(Page page)
        {
            IsBusy = true;
            this.page = page;
            Cart_Clicked = new RelayCommand(async () => await page.Navigation.PushAsync(new Korpa()));
            AddToCart_Tapped = new Command<string>(AddToCart);
            PriceOfCart = Global.GetOrderPrice();
            Task.Run(async () => await LoadProizvode());
            IsBusy = false;
        }

        private void AddToCart(string id)
        {
            if (Int32.TryParse(id, out int a))
            {
                Global.AddToCart(a, 1);
                PriceOfCart = Global.GetOrderPrice();
            }
        }

        private async Task LoadProizvode()
        {
            PriceOfCart = Global.GetOrderPrice();

            HttpResponseMessage responseGP = await gotoviProizvidiService.GetActionResponse("Preporuka", Global.prijavnjeniKorisnik.KlijentID.ToString());
            if (responseGP.IsSuccessStatusCode)
            {
                var gplista = JsonConvert.DeserializeObject<List<int>>(await responseGP.Content.ReadAsStringAsync());
                GotoviProizvodiList = new ObservableCollection<GotoviProizvod>(Global.proizvodi.Where(x => gplista.Contains(x.GotoviProizvodID)));
            }
            else
                await page.DisplayAlert(Messages.error, responseGP.ReasonPhrase, Messages.ok);

        }

        private bool _HideContent;

        public bool HideContent
        {
            get { return _HideContent; }
            set { _HideContent = value; OnPropertyChanged(); }
        }

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                HideContent = !value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}

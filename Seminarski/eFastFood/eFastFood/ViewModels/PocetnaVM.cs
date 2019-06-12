using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
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
using XamarinApp.Pages;

namespace eFastFood.ViewModels
{
    public class PocetnaVM : INotifyPropertyChanged
    {
        private APIHelper gotoviProizvidiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);
        private bool _isBusy;
        private List<GotoviProizvod> _gpList { get; set; }

        public string Title { get; set; }

        public List<GotoviProizvod> GotoviProizvodiList
        {
            get { return _gpList; }
            set
            {
                _gpList = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command AddToCart_Tapped { get; }

        public Command Cart_Clicked { get; }

        public Command OpisModal_Tapped { get; }

        public PocetnaVM()
        {
            Cart_Clicked = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new Korpa()));
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
            if (Global.proizvodi == null)
            {
                IsBusy = true;
                HttpResponseMessage responseGP = await gotoviProizvidiService.GetResponse();

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
                    await Application.Current.MainPage.DisplayAlert(Messages.error, responseGP.ReasonPhrase, Messages.ok);
                }
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

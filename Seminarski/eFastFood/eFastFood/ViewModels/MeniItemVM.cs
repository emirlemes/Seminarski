using eFastFood.Pages;
using eFastFood_PCL.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    public class MeniItemVM : INotifyPropertyChanged
    {
        private Page page { get; set; }
        private List<GotoviProizvod> _GotoviProizvodiList { get; set; }
        private float _PriceOfCart { get; set; }

        public string Title { get; set; }

        public float PriceOfCart
        {
            get { return _PriceOfCart; }
            set { _PriceOfCart = value; OnPropertyChanged(); }
        }

        public List<GotoviProizvod> GotoviProizvodiList
        {
            get { return _GotoviProizvodiList; }
            set { _GotoviProizvodiList = value; OnPropertyChanged(); }
        }

        public RelayCommand<string> AddToCart_Tapped { get; set; }
        public RelayCommand Cart_Clicked { get; set; }

        public MeniItemVM() { }

        public MeniItemVM(Page page, string title)
        {
            AddToCart_Tapped = new RelayCommand<string>(AddToCart);
            Cart_Clicked = new RelayCommand(async () => await page.Navigation.PushAsync(new Korpa()));
            this.page = page;
            Title = title;
            GotoviProizvodiList = Global.proizvodi.Where(x => x.Kategorija.Naziv == Title).ToList();
        }

        private void AddToCart(string id)
        {
            int a = 0;
            if (Int32.TryParse(id, out a))
            {
                Global.AddToCart(a, 1);
                PriceOfCart = Global.GetOrderPrice();
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

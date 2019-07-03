using eFastFood_PCL.Models;
using GalaSoft.MvvmLight.Command;
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

        public Command AddToCart_Tapped { get; set; }

        public MeniItemVM() { }

        public MeniItemVM(Page page, string title)
        {
            AddToCart_Tapped = new Command<string>(AddToCart);
            this.page = page;
            Title = title;
            GotoviProizvodiList = new List<GotoviProizvod>();
            Task.Run(() => LoadData());
        }

        private void LoadData()
        {
            IsBusy = true;
            List<GotoviProizvod> gp = Global.proizvodi.Where(x => x.Kategorija.Naziv == Title).ToList();
            GotoviProizvodiList.AddRange(gp);
            IsBusy = false;
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


        private bool _IsBusyO;

        public bool IsBusyO
        {
            get { return _IsBusyO; }
            set
            {
                _IsBusyO = value;
                OnPropertyChanged();
            }
        }


        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                IsBusyO = !value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}

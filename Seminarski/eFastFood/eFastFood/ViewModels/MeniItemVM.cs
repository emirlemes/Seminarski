using eFastFood_PCL.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    class MeniItemVM : INotifyPropertyChanged
    {
        private Page page { get; set; }
        private List<GotoviProizvod> _GotoviProizvodiList { get; set; }

        public string Title { get; set; }

        public List<GotoviProizvod> GotoviProizvodiList
        {
            get { return _GotoviProizvodiList; }
            set { _GotoviProizvodiList = value; OnPropertyChanged(); }
        }

        public Command AddToCart_Tapped { get; set; }

        public MeniItemVM() { }

        public MeniItemVM(Page page, string title, List<GotoviProizvod> gpList)
        {
            AddToCart_Tapped = new Command<string>(AddToCart);
            this.page = page;
            GotoviProizvodiList = gpList;
            Title = title;
        }

        private void AddToCart(string id)
        {
            int a = 0;
            if (Int32.TryParse(id, out a))
                Global.AddToCart(a, 1);
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

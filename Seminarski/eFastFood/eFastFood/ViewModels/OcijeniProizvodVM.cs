using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    public class OcijeniProizvodVM : INotifyPropertyChanged
    {
        private Page page { get; set; }


        private bool _IsBusy;

        public OcijeniProizvodVM(Page page, int id)
        {
            this.page = page;
        }

        public OcijeniProizvodVM() { }


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

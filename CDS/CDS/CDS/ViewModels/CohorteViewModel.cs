namespace CDS.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Android.Widget;

    class CohorteViewModel : BaseViewModel
    {
        #region Commands
        public ICommand Cohorte5
        {
            get
            {
                return new RelayCommand(c5);
            }
        }
        private async void c5()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Grupo1());
        }
        
        #endregion
    }
}

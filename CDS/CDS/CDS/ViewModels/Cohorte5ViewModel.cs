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

    class Cohorte5ViewModel : BaseViewModel
    {
        #region Commands

        public ICommand Grupo1
        {
            get
            {
                return new RelayCommand(g1);
            }
        }

        private async void g1()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Grupo1());
        }


        #endregion
    }
}

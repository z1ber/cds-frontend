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

    class DocenteViewModel : BaseViewModel
    {
        #region Commands
        public ICommand Grupos
        {
            get
            {
                return new RelayCommand(Grupo);
            }
        }
        public ICommand Compañeros
        {
            get
            {
                return new RelayCommand(Compañero);
            }
        }
        private async void Grupo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CohortePage());
        }

        private async void Compañero()
        {
            //MainViewModel.GetInstance().Comp = new CompaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CompanierosPage());
        }

        #endregion
    }
}

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

    class AdministradorViewModel : BaseViewModel
    {
        #region Commands
        public ICommand Grupos
        {
            get
            {
                return new RelayCommand(Grupo);
            }
        }
        public ICommand CompañerosDos
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
            await Application.Current.MainPage.Navigation.PushAsync(new CompanierosAdminPage());
        }

        #endregion
    }
}

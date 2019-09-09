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
   
    internal class LoginViewModel : BaseViewModel
    {

        #region Atributes
        private string user;
        private string password;
        private bool isEnabled;


        #endregion

        #region Properties
        public string User
        {
            get { return this.user; }
            set { SetValue(ref this.user, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;


        }

        #endregion

        #region Commands
        public ICommand LoginComand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        public ICommand SalirCommand
        {
            get
            {
                return new RelayCommand(Salir);
            }
        }
        private async void Salir()
        {
            
           Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        
        private async void Login()
        {
            /*
            if (string.IsNullOrEmpty(this.User))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario no ingresado",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.User))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Contraseña no ingresado",
                    "Aceptar");
                return;
            }

            this.IsEnabled = false; 

            if (this.User == "P-KD001" && this.Password == "1234")
            {
               await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
                
            }
            else if (this.User == "D-MG001" && this.Password =="1234")
            {
               await Application.Current.MainPage.Navigation.PushAsync(new MasterPageDos());
            }
            else if (this.User == "A-US001" && this.Password == "1234")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MasterPageTres());
            }
            else
            {
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Correo o contraseña incorrectos",
                   "Aceptar");
                this.Password = string.Empty;
                return;
            }
            this.IsEnabled = true;
            this.User = string.Empty;
            this.Password = string.Empty;*/

        }
        #endregion
    }
}

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
    using CDS.Services;
    using CDS.Models;
    using Newtonsoft.Json.Linq;
    using System.Linq;

    internal class LoginViewModel : BaseViewModel
    {

        #region Atributes
        private DialogService _dialogService;
        private UsuarioService user;
        private string _usuario;
        private string _contra;
        #endregion


        #region Properties
        public string nombreLogin
        {
            get { return _usuario; }
            set { _usuario = value; OnPropertyChanged(); }
        }
        public string password
        {
            get { return _contra; }
            set { _contra = value; OnPropertyChanged(); }
        }        
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            user = new UsuarioService();
            _dialogService = new DialogService();
        }

        #endregion

        #region Commands
        public ICommand Ingresar
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
            try
            {
                if (string.IsNullOrEmpty(nombreLogin))
                {
                    await _dialogService.Message("Error", "El nombre de usuario es requerido");
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    await _dialogService.Message("Error", "No ha ingresado una contraseña");
                    return;
                }                

                Usuario usuario = new Usuario
                {
                    nombreLogin = this.nombreLogin,
                    password = this.password,
                };

                var ingresado = await user.LoginUsuarioAsync<Usuario>(usuario);

                if (!ingresado.isSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Error", ingresado.Message, "Ok");
                    return;
                }
                else
                {
                    var tipoRol = ingresado.Result;
                    
                    if (tipoRol.ToString() == "1")
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterPageTres());
                    }
                    else if (tipoRol.ToString() == "2")
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterPageDos());
                    }
                    else if (tipoRol.ToString() == "3")
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterPage());
                    }
                }
            }
            catch (Exception e)
            {

                await _dialogService.Message("Error",e.ToString());
            }
              

        }
        #endregion
    }
}

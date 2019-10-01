using CDS.Models;
using CDS.Services;
using CDS.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CDS.ViewModels
{
    public class AgregarUsuarioViewModel: BaseViewModel
    {
        #region Atributos
        private DialogService _dialogService;
        private UsuarioService user;
        private string _nombre;
        private string _apellido;
        private string _dui;
        private string _direccion;
        private string _telefono;
        private int _rol;
        #endregion

        #region Propiedades
        public string nombreUsuario
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }
        public string apellidoUsuario
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }
        public string dui
        {
            get { return _dui; }
            set { _dui = value; OnPropertyChanged(); }
        }
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; OnPropertyChanged(); }
        }
        public int idRol
        {
            get { return _rol; }
            set { _rol = value; OnPropertyChanged(); }
        }
        #endregion

        #region Constructor
        public AgregarUsuarioViewModel()
        {
            user = new UsuarioService();
            _dialogService = new DialogService();
        }
        #endregion

        #region Comandos
        public ICommand Guardar
        {
            get
            {
                return new RelayCommand(AgregarUsuario);
            }
        }
        #endregion

        private async void AgregarUsuario()
        {
            try
            {
                if (string.IsNullOrEmpty(nombreUsuario))
                {
                    await _dialogService.Message("Error", "El nombre es requerido");
                    return;
                }
                if (string.IsNullOrEmpty(apellidoUsuario))
                {
                    await _dialogService.Message("Error", "El apellido es requerido");
                    return;
                }
                if (string.IsNullOrEmpty(dui))
                {
                    await _dialogService.Message("Error", "El dui es requerida");
                    return;
                }
                if (string.IsNullOrEmpty(direccion))
                {
                    await _dialogService.Message("Error", "La direccion es requerida");
                    return;
                }
                if (string.IsNullOrEmpty(telefono))
                {
                    await _dialogService.Message("Error", "El telefono es requerido");
                    return;
                }
                if (idRol == -1)
                {
                    await _dialogService.Message("Error", "No ha elegido el rol del usuario");
                    return;
                }
                nombreUsuario.TrimStart();
                apellidoUsuario.TrimStart();
                string _password = nombreUsuario.Substring(0, 2) + apellidoUsuario.Substring(0, 2) + "2019FGKSA";
                _password = _password.ToUpper();
                Usuario usuario = new Usuario
                {
                    nombreLogin = "x",
                    nombreUsuario = nombreUsuario,
                    apellidoUsuario = apellidoUsuario,
                    password = _password,
                    dui = dui,
                    direccion = direccion,
                    telefono = telefono,
                    idRol = idRol+1
                };

                var ingresado = await user.AddUsuarioAsync<Usuario>(usuario);
                Usuario lista = (Usuario)ingresado.Result;
                if (!ingresado.isSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Error", ingresado.Message, "Ok");
                    return;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Exito", "Se creo el usuario " + lista.nombreLogin + " \nCon contraseña: " + lista.password, "Ok");
                    if (lista.idRol == 2)
                    {
                        Application.Current.MainPage = new NavigationPage(new AgregarDocentePage());
                    }
                    else if (lista.idRol == 3)
                    {
                        Application.Current.MainPage = new NavigationPage(new AgregarAlumnoPage());
                    }
                }
            }
            catch (Exception ex)
            {

                await _dialogService.Message("Error", ex.ToString());
            }
            
        }
        
    }
}

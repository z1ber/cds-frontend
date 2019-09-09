using CDS.Models;
using CDS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        UsuarioService usuarioService;
		public LoginPage ()
		{
			InitializeComponent ();
            usuarioService = new UsuarioService();
		}

        private async void Ingresar(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(user.Text) || string.IsNullOrWhiteSpace(pass.Text) || rol.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Campos vacios", "OK");
                return;
            }
            else
            {           
                int selectedin = rol.SelectedIndex + 1;
                Usuario newusuario = new Usuario
                {
                    nombreLogin = user.Text.Trim(),
                    password = pass.Text.Trim(),
                    idRol = selectedin
                };
                try
                {
                    user.Text = "";
                    pass.Text = "";
                    rol.SelectedIndex = -1;
                    await usuarioService.LoginUsuarioAsync(newusuario);
                    if (selectedin == 1)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MasterPageTres());
                    }
                    else if (selectedin == 2)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MasterPageDos());
                    }
                    else if (selectedin == 3)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "No existe el rol:" + selectedin + "", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Datos invalidos", "OK");
                }
            }
        }

        private void Salir(object sender, EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
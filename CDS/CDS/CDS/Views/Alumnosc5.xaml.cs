using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using CDS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using CDS.Services;

namespace CDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alumnosc5 : ContentPage
    {
        EstudianteService estudianteSer;
        List<Estudiante> lstAlumno;
        public Alumnosc5()
        {
            InitializeComponent();
            estudianteSer = new EstudianteService();
            cargar();
        }

        private void Listestudiante_Refreshing(object sender, EventArgs e)
        {
            cargar();
        }
        async void cargar()
        {
            lstAlumno = await estudianteSer.GetEstudianteGrupoAsync(1);
            cohorte5List.ItemsSource = lstAlumno.OrderBy(item => item.idEstudiante).ToList();

        }

        private void Cohorte5List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var alumno = e.SelectedItem as Estudiante;
            //DisplayAlert("Llevas", alumno.nombreMateria + "\n" + alumno.docente + "\n" + hora.horaInicio + " - " + hora.horaFin, "Aceptar");
            //CrossTextToSpeech.Current.Speak("Llevas" + hora.nombreMateria + " con " + hora.docente + " de " + hora.horaInicio + " a " + hora.horaFin);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new AgregarAlumnoPage());
        }
    }
}
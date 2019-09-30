using CDS.Models;
using CDS.Services;
using Plugin.TextToSpeech;
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
    public partial class Martes : ContentPage
    {
        public Martes()
        {
            InitializeComponent();
            BindingContext = new ViewModels.HorariosViewModel("Martes", 1);
        }

        private void HorarioList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var hora = e.SelectedItem as Horario;
            DisplayAlert("Llevas", hora.nombreMateria + "\n" + hora.docente + "\n" + hora.horaInicio + " - " + hora.horaFin, "Aceptar");
            CrossTextToSpeech.Current.Speak("Llevas" + hora.nombreMateria + " con " + hora.docente + " de " + hora.horaInicio + " a " + hora.horaFin);

        }
    }
}
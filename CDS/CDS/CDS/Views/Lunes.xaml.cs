using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDS.Services;
using CDS.Models;
using Plugin.TextToSpeech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lunes : ContentPage
	{
        HorarioService horSer;
        List<Horario> lstHorario;
		public Lunes ()
		{
			InitializeComponent ();
            horSer = new HorarioService();
            cargar();
		}
        /*private void Listhorario_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var studdent = e.Item as Horario;
            DisplayAlert("Horario", studdent.Nombrem + "\n" + studdent.Docente+"\n"+studdent.Hora, "Aceptar");
            CrossTextToSpeech.Current.Speak("llevas" + studdent.Nombrem + "con" + studdent.Docente + "de" + studdent.Hora);
        }*/

        private void Listhorario_Refreshing(object sender, EventArgs e)
        {
            cargar();
        }
        async void cargar()
        {
            lstHorario = await horSer.GetHorariosDiaAsync("Lunes",1);
            horarioList.ItemsSource = lstHorario.OrderBy(item => item.horaInicio).ToList();

        }

        private void HorarioList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var hora = e.SelectedItem as Horario;
            DisplayAlert("Llevas", hora.nombreMateria + "\n" + hora.docente + "\n" + hora.horaInicio + " - "+ hora.horaFin, "Aceptar");
            CrossTextToSpeech.Current.Speak("Llevas"+hora.nombreMateria+" con "+hora.docente+" de " + hora.horaInicio + " a " + hora.horaFin);

        }
    }
}
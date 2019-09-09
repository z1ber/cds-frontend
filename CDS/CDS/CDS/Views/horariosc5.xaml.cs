using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class horariosc5 : ContentPage
	{
		public horariosc5 ()
		{
			InitializeComponent ();
            cargar();
		}
        private void Listhorario_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var studdent = e.Item as Horario;
            DisplayAlert("Horario", studdent.Nombrem + "\n" + studdent.Docente + "\n" + studdent.Hora, "Aceptar");
        }

        private void Listhorario_Refreshing(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            var Horario1 = new List<Horario>()
            {
                new Horario
                {
                    foto = "calendar.png",
                    Nombrem = "Programacion",
                    Docente = "José Gudiel",
                    Hora = "7:10-8:50"
                },
                new Horario
                {
                    foto = "calendar.png",
                    Nombrem = "Habilidades blandas",
                    Docente = "Rogelio Gonzalez",
                    Hora = "9:20-11:50"
                },
                new Horario
                {
                     foto = "calendar.png",
                     Nombrem = "Programaccion",
                     Docente = "José Gudiel",
                     Hora = "1:10-2:50"
                },
                 new Horario
                {
                    foto = "calendar.png",
                    Nombrem = "Habilidades blandas",
                    Docente = "Monica Menjivar",
                    Hora = "3:20-5:00"
                },


            };
            Listhorario.ItemsSource = Horario1;
        }
    }
}
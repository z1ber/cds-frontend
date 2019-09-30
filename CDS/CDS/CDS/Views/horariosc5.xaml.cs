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
            //var studdent = e.Item as Horario;
            //DisplayAlert("Horario", studdent.Nombrem + "\n" + studdent.Docente + "\n" + studdent.Hora, "Aceptar");
        }

        private void Listhorario_Refreshing(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            
            
        }
    }
}
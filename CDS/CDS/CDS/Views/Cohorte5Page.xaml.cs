using Android.Widget;
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
	public partial class Cohorte5Page : ContentPage
	{
		public Cohorte5Page ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.Cohorte5ViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Toast.MakeText(Android.App.Application.Context, "Disponible Proximamente", ToastLength.Short).Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class karina 
	{
		public karina ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}
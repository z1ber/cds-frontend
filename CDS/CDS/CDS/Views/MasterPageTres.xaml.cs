using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDS.Models;
using CDS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
namespace CDS.Views
{
	public partial class MasterPageTres : MasterDetailPage
	{
        public List<MasterPageItemTres> MenuList { get; set; }

		public MasterPageTres ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#002361");
            MenuList = new List<MasterPageItemTres>();
            // Adding menu items to menuList and you can define title, page and icon
            MenuList.Add(new MasterPageItemTres()
            {
                Title = "Cerrar Sesión",
                Icon = "logout.png"
            });
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerListTres.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(AdministradorPage)));
        }
        private void NavigationDrawerListTres_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItemTres)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
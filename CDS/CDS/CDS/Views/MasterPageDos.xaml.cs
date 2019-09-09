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
	public partial class MasterPageDos : MasterDetailPage
	{
        public List<MasterPageITemDos> MenuList { get; set; }
		public MasterPageDos ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#002361");
            MenuList = new List<MasterPageITemDos>();
            // Adding menu items to menuList and you can define title, page and icon
            
            MenuList.Add(new MasterPageITemDos()
            {
                Title = "Cerrar Sesión",
                Icon = "logout.png"
            });
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerListDos.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DocentePage)));
        }

        private void NavigationDrawerListDos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageITemDos)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
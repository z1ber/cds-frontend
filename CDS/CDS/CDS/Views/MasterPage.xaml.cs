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
    public partial class MasterPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }

        public MasterPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#002361");
            MenuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
            
            MenuList.Add(new MasterPageItem()
            {
                Title = "Cerrar Sesión",
                Icon = "logout.png"
            });

            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HorariosPage)));

        }


        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(LoginPage)));
            IsPresented = false;
        }
    }
}
	

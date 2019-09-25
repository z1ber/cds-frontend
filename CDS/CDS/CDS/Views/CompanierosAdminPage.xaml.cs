using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDS.Models;
using CDS.Services;
using CDS.ViewModels;
using Plugin.TextToSpeech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanierosAdminPage : ContentPage
    {
        public CompanierosAdminPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CompaAdminViewModel();
        }
       
    }
    
}

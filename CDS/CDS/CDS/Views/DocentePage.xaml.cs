﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocentePage : ContentPage
    {
        public DocentePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.DocenteViewModel();
        }

       
    }
}
using CDS.Models;
using CDS.Services;
using GalaSoft.MvvmLight.Command;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CDS.ViewModels
{
    public class CompaViewModel: BaseViewModel 
    {
        private DialogService _dialogService;
        private DocenteService doc;
        private bool isRefreshing;
        private Docente obj;

        public Docente Obj
        {
            get { return obj; }
            set
            {
                obj = value; OnPropertyChanged();
                if (value != null)
                {
                    //Opcion();
                }
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCom

        {
            get
            {
                return new RelayCommand(Refrescar);
            }
        }

        private void Refrescar()
        {
            IsRefreshing = true;
            LoadDocentes();
            IsRefreshing = false;
        }

        public ObservableCollection<Docente> Docentes { get; set; }

        public CompaViewModel()
        {
            Docentes = new ObservableCollection<Docente>();
            _dialogService = new DialogService();
            doc = new DocenteService();
            LoadDocentes();
            isRefreshing = false;
        }

        private async void LoadDocentes()
        {
            var response = await doc.GetAll<Docente>("https://horario-cds.herokuapp.com/api/docente");
            if (!response.isSuccess)
            {
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Ok");
                return;
            }
            Docentes = (ObservableCollection<Docente>)response.Result;
            IsRefreshing = false;
        }
    }
}

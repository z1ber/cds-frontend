using CDS.Models;
using CDS.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CDS.ViewModels
{
    public class HorariosViewModel: BaseViewModel
    {
        #region Atributes
        private DialogService _dialogService;
        private HorarioService hora;
        private bool isRefreshing;
        private string _dia;
        private int _grupo;
        #endregion

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

        public ObservableCollection<Horario> Horarios { get; set; }

        private void Refrescar()
        {
            IsRefreshing = true;
            LoadHorarios(_dia, _grupo);
            IsRefreshing = false;
        }

        public HorariosViewModel(string dia, int grupo)
        {
            Horarios = new ObservableCollection<Horario>();
            _dialogService = new DialogService();
            hora = new HorarioService();
            _dia = dia;
            _grupo = grupo;
            LoadHorarios(_dia, _grupo);
            isRefreshing = false;
        }

        private async void LoadHorarios(string dia, int grupo)
        {
            var response = await hora.GetHorariosDiaAsync<Horario>(dia,grupo);
            if (!response.isSuccess)
            {
                IsRefreshing = false;
                //await App.Current.MainPage.DisplayAlert("Error", response.Message, "Ok");
                return;
            }
            Horarios = (ObservableCollection<Horario>)response.Result;
            IsRefreshing = false;
        }
    }
}

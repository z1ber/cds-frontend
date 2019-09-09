using CDS.Models;
using CDS.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CDS.ViewModels
{
    public class CompaViewModel: INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public ObservableCollection<Usuario> Users { get; }
        public CompaViewModel()
        {
            Users = new ObservableCollection<Usuario>();
            LoadUsers().GetAwaiter();
        }
        private async Task LoadUsers(List<Usuario> lista = null)
        {
            Users.Clear();
            var userAPI = RestService.For<IRestClientAPI>(RestEndPoints.BaseUrl);
            var result = await userAPI.GetAll();
            foreach (var user in result)
            {
                Users.Add(user);
            }
        }
    }
}

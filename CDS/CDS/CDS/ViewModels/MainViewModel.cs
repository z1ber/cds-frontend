 using System;
using System.Collections.Generic;
using System.Text;

namespace CDS.ViewModels
{
    class MainViewModel
    {
        #region
        public LoginViewModel Login
        {
            get;
            set;
        }
        public HorariosViewModel Horario
        {
            get;
            set;
        }
        public GruposViewModel Grupo
        {
            get;
            set;
        }
        public AlumnosViewModel Alumn
        {
            get;
            set;
        }
        public CompaViewModel Comp
        {
            get;
            set;
        }

        #endregion
        #region
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion
        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}

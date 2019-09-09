namespace CDS.Infrastructure
{
    using ViewModels;
    class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion
        #region
        public InstanceLocator()
        {
            this.Main = new MainViewModel();    
        }
        #endregion
    }
}

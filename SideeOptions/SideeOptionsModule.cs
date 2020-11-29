using SideeOptions.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace SideeOptions
{
    public class SideeOptionsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SideeOptionsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("FlyoutRegion", typeof(Side));
            _regionManager.RegisterViewWithRegion("FlyoutRegion", typeof(ReoGridFlyOut));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
using Core.ViewModels;
using MahApps.Metro.Controls;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideeOptions.ViewModels
{
    class ReoGridFlyOutViewModel : BindableBase, INavigationAware
    {
        private string header;
        public string Header
        {
            get { return this.header; }
            set { SetProperty(ref this.header, value); }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }

        private bool isOpen;
        public bool IsOpen
        {
            get { return this.isOpen; }
            set { SetProperty(ref this.isOpen, value); }
        }

        private Position position;
        private IEventAggregator ie;
        private IRegionManager region;

        public Position Position
        {
            get { return this.position; }
            set { SetProperty(ref this.position, value); }
        }


        private string data;

        public ReoGridFlyOutViewModel(IEventAggregator ie, IRegionManager iregionManager)
        {
            this.ie = ie;
            this.region = iregionManager;
            ie.GetEvent<MessageSentEvent>().Subscribe(OnMesageReceieved);
            this.Header = "Top";
            this.Position = Position.Top;
            Height = 500;
            //IsOpen = true;
        }

        private void OnMesageReceieved(string obj)
        {
            if (obj == "Top")
                data = obj;

            //var k = region.Regions["FlyoutRegion"].Views;
            //region.Regions["FlyoutRegion"].Activate(k.First());
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IsOpen = true;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //return true;
            return data != null;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}


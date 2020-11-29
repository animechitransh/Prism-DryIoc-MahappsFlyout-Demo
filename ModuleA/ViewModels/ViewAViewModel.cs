using Core.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _text = "Hello from ViewAViewModel";
        private readonly IEventAggregator _eventAggregator;
        IRegionManager iregionManager;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public DelegateCommand ClickCommand { get; set; }

        public ViewAViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            ClickCommand = new DelegateCommand(Click, CanClick);
            _eventAggregator = eventAggregator;
            iregionManager = regionManager;
        }

        private bool CanClick()
        {
            return true;
        }

        private void Click()
        {
            Text = "You Clicked me!";
            //
            // try deactivate this region
             _eventAggregator.GetEvent<MessageSentEvent>().Publish("Top");
            iregionManager.RequestNavigate("FlyoutRegion", "ReoGridFlyOut");

        }
    }
}

using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMultipleRegionApp.ViewModels
{
    public class ChildViewModel : BindableBase, INavigationAware
    {
        private IRegionManager RegionManager { get; set; }

        private IInteractionRequestAware InteractionRequestAware { get; set; }

        public DelegateCommand NavigateChildViewBCommand { get; }

        public ChildViewModel()
        {
            this.NavigateChildViewBCommand = new DelegateCommand(() =>
            {
                var param = new NavigationParameters();
                param.Add("RegionManager", this.RegionManager);
                param.Add("InteractionRequestAware", this.InteractionRequestAware);
                this.RegionManager.RequestNavigate("ChildMain", "ChildViewB", param);
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionManager = (IRegionManager)navigationContext.Parameters["RegionManager"];
            this.InteractionRequestAware = (IInteractionRequestAware)navigationContext.Parameters["InteractionRequestAware"];
        }
    }
}

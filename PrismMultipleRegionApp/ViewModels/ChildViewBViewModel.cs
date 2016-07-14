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
    public class ChildViewBViewModel : BindableBase, INavigationAware
    {
        private IRegionManager RegionManager { get; set; }

        private IInteractionRequestAware InteractionRequestAware { get; set; }

        public DelegateCommand CloseCommand { get; }

        public ChildViewBViewModel()
        {
            this.CloseCommand = new DelegateCommand(() => this.InteractionRequestAware.FinishInteraction());
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

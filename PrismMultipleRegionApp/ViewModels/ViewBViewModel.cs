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
    public class ViewBViewModel : BindableBase, IInteractionRequestAware
    {
        private IRegionManager currentRegionManager;

        public IRegionManager CurrentRegionManager
        {
            get { return this.currentRegionManager; }
            set { this.SetProperty(ref this.currentRegionManager, value); }
        }

        private INotification notification;

        public INotification Notification
        {
            get { return this.notification; }
            set
            {
                this.SetProperty(ref this.notification, value);
                // initialize
                var param = new NavigationParameters();
                param.Add("RegionManager", this.CurrentRegionManager);
                param.Add("InteractionRequestAware", this);
                this.CurrentRegionManager.RequestNavigate("ChildMain", "ChildView", param);
            }
        }


        public Action FinishInteraction { get; set; }

        public ViewBViewModel(IRegionManager regionManager)
        {
            this.CurrentRegionManager = regionManager.CreateRegionManager();            
        }
    }
}

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
    public class ViewAViewModel : BindableBase
    {
        private IRegionManager RegionManager { get; }

        public DelegateCommand ShowWindowCommand { get; }

        public InteractionRequest<Notification> ShowNewWindowRequest { get; } = new InteractionRequest<Notification>();

        public ViewAViewModel(IRegionManager regionManager)
        {
            this.RegionManager = regionManager;

            this.ShowWindowCommand = new DelegateCommand(this.ShowWindowExecute);
        }

        private void ShowWindowExecute()
        {
            this.ShowNewWindowRequest.Raise(new Notification { Title = "NewWindow", Content = "Sample" });
        }
    }
}

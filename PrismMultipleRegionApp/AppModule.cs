using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismMultipleRegionApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMultipleRegionApp
{
    class AppModule : IModule
    {
        private IUnityContainer Container { get; }

        private IRegionManager RegionManager { get; }

        public AppModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.Container = container;
            this.RegionManager = regionManager;
        }

        public void Initialize()
        {
            this.Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies()
                    .Where(x => x.Namespace == "PrismMultipleRegionApp.Views")
                    .Where(x => x.Name != "MainWindow"),
                _ => new[] { typeof(object) },
                WithName.TypeName,
                WithLifetime.PerResolve);

            this.RegionManager.RequestNavigate("Main", "ViewA");
        }
    }
}

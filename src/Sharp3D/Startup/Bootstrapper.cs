using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Sharp3D.UI.ViewModels;

namespace Sharp3D.Startup
{
    public class Bootstrapper : MefBootstrapper
    {
        [Import]
        public Lazy<ShellViewModel> Main { get; private set; }
        
        protected override DependencyObject CreateShell()
        {
            var view =  Main.Value.View;
            view.Show();

            return (DependencyObject) view;
        }

        protected override void ConfigureAggregateCatalog()
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var directoryCatalog = new DirectoryCatalog(path);
            var assemblyCatalog = new AssemblyCatalog(typeof(Bootstrapper).Assembly);

            AggregateCatalog.Catalogs.Add(directoryCatalog);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);
        }

        protected override CompositionContainer CreateContainer()
        {
            var container = new CompositionContainer(AggregateCatalog);
            container.ComposeParts(this);

            return container;
        }

        protected override void ConfigureContainer()
        {
            Container.ComposeExportedValue<ILoggerFacade>(Logger);
            Container.ComposeExportedValue<IModuleCatalog>(ModuleCatalog);
            Container.ComposeExportedValue<IServiceLocator>(new MefServiceLocatorAdapter(Container));
            Container.ComposeExportedValue<AggregateCatalog>(AggregateCatalog);
        }

        protected override void InitializeShell()
        {
            // Do nothing
        }
    }
}
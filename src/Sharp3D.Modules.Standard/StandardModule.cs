using System;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Sharp3D.Common;
using Sharp3D.Modules.Standard.UI;

namespace Sharp3D.Modules.Standard
{
    [ModuleExport(typeof(StandardModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class StandardModule : IModule
    {
        private readonly IRegionViewRegistry m_RegionViewRegistry;

        [ImportingConstructor]
        public StandardModule(IRegionViewRegistry regionViewRegistry)
        {
            m_RegionViewRegistry = regionViewRegistry;
        }

        public void Initialize()
        {
            m_RegionViewRegistry.RegisterViewWithRegion(Constants.MainRegion, typeof(ICompositeViewportView));
        }
    }
}
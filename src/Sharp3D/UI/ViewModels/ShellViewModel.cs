using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using Sharp3D.Common.UI;
using Sharp3D.Properties;

namespace Sharp3D.UI.ViewModels
{
    [Export]
    public class ShellViewModel : ViewModel
    {
        private readonly IShellView m_ShellView;

        [ImportingConstructor]
        public ShellViewModel(IShellView shellView, IRegionManager regionManager)
        {
            m_ShellView = shellView;
            m_ShellView.ViewModel = this;
        }

        public string DisplayName
        {
            get { return Strings.ShellView_DisplayName; }
        }

        public IShellView View
        {
            get { return m_ShellView; }
        }
    }
}
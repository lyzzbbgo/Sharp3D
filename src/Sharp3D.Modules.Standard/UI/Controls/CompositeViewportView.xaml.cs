using System;
using System.ComponentModel.Composition;

namespace Sharp3D.Modules.Standard.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [Export(typeof(ICompositeViewportView))]
    public partial class CompositeViewportView : ICompositeViewportView
    {
        public CompositeViewportView()
        {
            InitializeComponent();
        }
    }
}

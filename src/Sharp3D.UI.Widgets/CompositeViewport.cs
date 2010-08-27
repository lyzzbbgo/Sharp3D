using System.Windows;
using System.Windows.Controls;

namespace Sharp3D.UI.Widgets
{
    public class CompositeViewport : Control
    {
        static CompositeViewport()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Viewport), new FrameworkPropertyMetadata(typeof (CompositeViewport)));
        }
    }
}
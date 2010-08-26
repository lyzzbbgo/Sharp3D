using System;
using System.Windows;
using System.Windows.Controls;

namespace Sharp3D.UI.Widgets
{
    public class Viewport : Control
    {
        static Viewport()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Viewport), new FrameworkPropertyMetadata(typeof (Viewport)));
        }
    }
}

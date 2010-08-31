using System.Windows;
using System.Windows.Controls;
using Sharp3D.Scene;

namespace Sharp3D.UI.Widgets
{
    public class CompositeViewport : Control
    {
        static CompositeViewport()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CompositeViewport), new FrameworkPropertyMetadata(typeof(CompositeViewport)));
        }

        public static readonly DependencyProperty SceneProperty =
            DependencyProperty.Register("Scene", typeof(IScene), typeof(CompositeViewport),
                new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the scene. This is a dependency property.
        /// </summary>
        public IScene Scene
        {
            get { return (IScene)GetValue(SceneProperty); }
            set { SetValue(SceneProperty, value); }
        }
    }
}
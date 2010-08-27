using System;
using System.Windows;
using System.Windows.Controls;
using Sharp3D.Scene;

namespace Sharp3D.UI.Widgets
{
    public class Viewport : Control
    {
        static Viewport()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Viewport), new FrameworkPropertyMetadata(typeof (Viewport)));
        }

        public static readonly DependencyProperty SceneProperty =
            DependencyProperty.Register("Scene", typeof(IScene), typeof(Viewport),
                new UIPropertyMetadata(null, OnSceneChanged));

        /// <summary>
        /// Gets or sets the scene. This is a dependency property.
        /// </summary>
        public IScene Scene
        {
            get { return (IScene)GetValue(SceneProperty); }
            set { SetValue(SceneProperty, value); }
        }

        private static void OnSceneChanged(DependencyObject dp, DependencyPropertyChangedEventArgs args)
        {
            
        }
    }
}

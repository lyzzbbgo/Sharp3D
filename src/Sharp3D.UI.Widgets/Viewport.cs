using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Sharp3D.Scene;

namespace Sharp3D.UI.Widgets
{
    [TemplatePart(Name = PART_Viewport, Type = typeof(Viewport3D))]
    [TemplatePart(Name = PART_ManipulationArea, Type = typeof(FrameworkElement))]
    public class Viewport : Control
    {
        private const string PART_Viewport = "PART_Viewport";
        private const string PART_ManipulationArea = "PART_ManipulationArea";

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
            var viewport = (Viewport) dp;
            var scene = (IScene) args.NewValue;

            SceneServices.InitializeViewport(viewport.m_Viewport3D, scene);  
        }

        private Viewport3D m_Viewport3D;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var viewport3D = GetTemplateChild(PART_Viewport) as Viewport3D;
            var manipulationArea = GetTemplateChild(PART_ManipulationArea) as FrameworkElement;

            Debug.Assert(viewport3D != null);
            SceneServices.InitializeViewport(viewport3D, Scene);

            var helper = new ManipulationHelper();
            helper.EventSource = manipulationArea ?? viewport3D;
            viewport3D.Camera.Transform = helper.Transform;

            // Stash the viewport for later use
            m_Viewport3D = viewport3D;
        }
    }
}

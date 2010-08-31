using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Sharp3D.UI.Widgets
{
    public class ManipulationHelper
    {
        private readonly AxisAngleRotation3D m_Rotation = new AxisAngleRotation3D();
        private readonly ScaleTransform3D m_Scale = new ScaleTransform3D();
        private readonly TranslateTransform3D m_Translate = new TranslateTransform3D();
        private readonly Transform3DGroup m_Transform;
        
        private FrameworkElement m_EventSource;
        private Point m_PreviousPosition2D;
        private Vector3D m_PreviousPosition3D = new Vector3D(0, 0, 0);

        public ManipulationHelper()
        {
            m_Transform = new Transform3DGroup();
            m_Transform.Children.Add(m_Translate);
            m_Transform.Children.Add(m_Scale);
            m_Transform.Children.Add(new RotateTransform3D(m_Rotation));
        }

        /// <summary>
        /// A transform to move the camera or scene to the trackball's
        /// current orientation and scale.
        /// </summary>
        public Transform3D Transform
        {
            get { return m_Transform; }
        }

        #region Event Handling

        /// <summary>
        /// The FrameworkElement we listen to for mouse events.
        /// </summary>
        public FrameworkElement EventSource
        {
            get { return m_EventSource; }

            set
            {
                if (m_EventSource != null)
                {
                    m_EventSource.MouseDown -= OnMouseDown;
                    m_EventSource.MouseUp -= OnMouseUp;
                    m_EventSource.MouseMove -= OnMouseMove;
                }

                m_EventSource = value;

                m_EventSource.MouseDown += OnMouseDown;
                m_EventSource.MouseUp += OnMouseUp;
                m_EventSource.MouseMove += OnMouseMove;
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Mouse.Capture(EventSource, CaptureMode.Element);
            m_PreviousPosition2D = e.GetPosition(EventSource);
            m_PreviousPosition3D = ProjectToTrackball(
                EventSource.ActualWidth,
                EventSource.ActualHeight,
                m_PreviousPosition2D);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Mouse.Capture(EventSource, CaptureMode.None);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(EventSource);

            // Prefer tracking to zooming if both buttons are pressed.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Track(currentPosition);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                Zoom(currentPosition);
            }
            else if (e.MiddleButton == MouseButtonState.Pressed)
            {
                Pan(currentPosition);
            }

            m_PreviousPosition2D = currentPosition;
        }

        #endregion Event Handling

        private void Track(Point currentPosition)
        {
            Vector3D currentPosition3D = ProjectToTrackball(
                EventSource.ActualWidth, EventSource.ActualHeight, currentPosition);

            var axis = Vector3D.CrossProduct(m_PreviousPosition3D, currentPosition3D);
            var angle = Vector3D.AngleBetween(m_PreviousPosition3D, currentPosition3D);
            
            if (axis == new Vector3D(0, 0, 0) || angle == 0.0) return;
            
            var delta = new Quaternion(axis, -angle);
            var q = new Quaternion(m_Rotation.Axis, m_Rotation.Angle);

            // Compose the delta with the previous orientation
            q *= delta;

            // Write the new orientation back to the Rotation3D
            m_Rotation.Axis = q.Axis;
            m_Rotation.Angle = q.Angle;

            m_PreviousPosition3D = currentPosition3D;
        }

        private Vector3D ProjectToTrackball(double width, double height, Point point)
        {
            double x = point.X/(width/2); // Scale so bounds map to [0,0] - [2,2]
            double y = point.Y/(height/2);

            //x = x - 1;                           // Translate 0,0 to the center
            //y = 1 - y;                           // Flip so +Y is up instead of down
            y = y - 1;
            x = 1 - x;

            double z2 = 1 - x * x - y * y; // z^2 = 1 - x^2 - y^2
            double z = z2 > 0 ? Math.Sqrt(z2) : 0;

            return new Vector3D(x, y, z);
        }

        private void Zoom(Point currentPosition)
        {
            double yDelta = currentPosition.Y - m_PreviousPosition2D.Y;

            double scale = Math.Exp(yDelta/100); // e^(yDelta/100) is fairly arbitrary.

            m_Scale.ScaleX *= scale;
            m_Scale.ScaleY *= scale;
            m_Scale.ScaleZ *= scale;
        }

        private void Pan(Point currentPosition)
        {
            double xDelta = (currentPosition.X - m_PreviousPosition2D.X) * 0.05;
            double yDelta = (currentPosition.Y - m_PreviousPosition2D.Y) * 0.05;

            m_Translate.OffsetX += xDelta;
            m_Translate.OffsetY -= yDelta;
        }
    }
}
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Cameras
{
    public class StandardCamera : ICamera
    {
        public StandardCamera(Point3 position, Vector3 lookAt)
        {
            Position = position;
            LookAt = lookAt;

            NearPlaneDistance = 0.125;
            FarPlaneDistance = double.MaxValue;
            FieldOfView = 50;
        }

        public Point3 Position { get; set; }
        
        public Vector3 LookAt { get; set; }
        
        public double NearPlaneDistance { get; set; }
        
        public double FarPlaneDistance { get; set; }
        
        public double FieldOfView { get; set; }
    }
}
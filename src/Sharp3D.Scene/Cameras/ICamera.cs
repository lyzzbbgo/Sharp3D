using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Cameras
{
    public interface ICamera
    {
        Point3 Position { get; set; }

        Vector3 LookAt { get; set; }

        double NearPlaneDistance { get; set; }

        double FarPlaneDistance { get; set; }

        double FieldOfView { get; set; }
    }
}
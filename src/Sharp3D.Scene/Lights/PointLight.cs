using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Lights
{
    public class PointLight : LightBase
    {
        public PointLight(Color color, Point3 position) : base(color)
        {
        }

        public Point3 Position { get; set; }
    }
}
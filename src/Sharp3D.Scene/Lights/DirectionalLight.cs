using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Lights
{
    public class DirectionalLight : LightBase
    {
        public DirectionalLight(Color color, Vector3 direction) : base(color)
        {
            Direction = direction;
        }

        public Vector3 Direction { get; set; }
    }
}
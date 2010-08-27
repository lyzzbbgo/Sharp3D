using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Lights
{
    public abstract class LightBase : ILight
    {
        public Color Color { get; set; }
        
        public Point3 Position { get; set; }
        
        public double Attenuation { get; set; }
        
        public double Range { get; set; }
    }
}
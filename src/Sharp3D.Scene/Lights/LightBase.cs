using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Lights
{
    public abstract class LightBase : ILight
    {
        protected LightBase(Color color)
        {
            Color = color;
            Range = double.MaxValue;
            Attenuation = 3;
        }

        public Color Color { get; set; }
        
        public double Attenuation { get; set; }
        
        public double Range { get; set; }
    }
}
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Lights
{
    public interface ILight
    {
        Color Color { get; set; }
        
        double Attenuation { get; set; }

        double Range { get; set; }
    }
}
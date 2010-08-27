using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Materials
{
    public interface IMaterial
    {
        Color Diffuse { get; set; }

        Color Specular { get; set; }

        Color Emissive { get; set; }
    }
}
using Sharp3D.Scene.Materials;
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Models
{
    public interface IModel
    {
        Mesh Tesselate();

        IMaterial Material { get; set; }

        Point3 Position { get; set; }
    }
}
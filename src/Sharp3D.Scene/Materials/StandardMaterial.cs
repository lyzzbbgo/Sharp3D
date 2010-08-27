using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Materials
{
    public class StandardMaterial : IMaterial
    {
        public Color Diffuse { get; set; }
        
        public Color Specular { get; set; }
        
        public Color Emissive { get; set; }
    }
}
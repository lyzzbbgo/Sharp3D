using System;
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Models
{
    public class Sphere : ModelBase
    {
        public Sphere(double radius, Point3 position)
        {
            Radius = radius;
            Position = position;
        }
        
        public double Radius { get; set; }
        
        public override Mesh Tesselate()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using Sharp3D.Scene.Materials;
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Models
{
    public abstract class ModelBase : IModel
    {
        public abstract Mesh Tesselate();

        public IMaterial Material { get; set; }

        public Point3 Position { get; set; }
    }
}
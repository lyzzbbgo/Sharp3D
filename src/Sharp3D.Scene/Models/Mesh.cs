using System;
using System.Collections.Generic;
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene.Models
{
    public class Mesh : ModelBase
    {
        public IList<Point3> Positions { get; private set; }

        public IList<Point2> UV { get; private set; }

        public IList<int> TriangleIndices { get; private set; }

        public IList<Vector3> Normals { get; private set; }

        public Mesh()
        {
            Positions = new List<Point3>();
            UV = new List<Point2>();
            TriangleIndices = new List<int>();
            Normals = new List<Vector3>();
        }

        public override Mesh Tesselate()
        {
            return this;
        }

        public IEnumerable<Triangle> Triangles
        {
            get { yield break; }
        }
    }
}
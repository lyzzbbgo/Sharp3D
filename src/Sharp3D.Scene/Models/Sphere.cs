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
            Phi = Theta = 16;
        }
        
        public double Radius { get; set; }

        public int Phi { get; set; }

        public int Theta { get; set; }
        
        public override Mesh Tesselate()
        {
            double dt = DegToRad(360.0) / Theta;
            double dp = DegToRad(180.0) / Phi;

            var mesh = new Mesh();

            for (int pi = 0; pi <= Phi; pi++)
            {
                double phi = pi * dp;

                for (int ti = 0; ti <= Theta; ti++)
                {
                    // we want to start the mesh on the x axis
                    double theta = ti * dt;

                    mesh.Positions.Add(GetPosition(theta, phi, Radius));
                    mesh.Normals.Add(GetNormal(theta, phi));
                    mesh.UV.Add(GetTextureCoordinate(theta, phi));
                }
            }

            for (int pi = 0; pi < Phi; pi++)
            {
                for (int ti = 0; ti < Theta; ti++)
                {
                    int x0 = ti;
                    int x1 = (ti + 1);
                    int y0 = pi * (Theta + 1);
                    int y1 = (pi + 1) * (Phi + 1);

                    mesh.TriangleIndices.Add(x0 + y0);
                    mesh.TriangleIndices.Add(x0 + y1);
                    mesh.TriangleIndices.Add(x1 + y0);

                    mesh.TriangleIndices.Add(x1 + y0);
                    mesh.TriangleIndices.Add(x0 + y1);
                    mesh.TriangleIndices.Add(x1 + y1);
                }
            }

            return mesh;
        }

        #region Private helper methods

        private static Point3 GetPosition(double theta, double phi, double radius)
        {
            double x = radius * Math.Sin(theta) * Math.Sin(phi);
            double y = radius * Math.Cos(phi);
            double z = radius * Math.Cos(theta) * Math.Sin(phi);

            return new Point3(x, y, z);
        }

        private static Vector3 GetNormal(double theta, double phi)
        {
            return (Vector3) GetPosition(theta, phi, 1.0);
        }

        private static double DegToRad(double degrees)
        {
            return (degrees / 180.0) * Math.PI;
        }

        private static Point2 GetTextureCoordinate(double theta, double phi)
        {
            return new Point2(theta / (2 * Math.PI), phi / (Math.PI));
        }

        #endregion
    }
}
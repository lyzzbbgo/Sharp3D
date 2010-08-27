namespace Sharp3D.Scene.Primitives
{
    public struct Triangle
    {
        public Triangle(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3)
            : this(new Point3(x1, y1, z1), new Point3(x2, y2, z2), new Point3(x3, y3, z3))
        {
        }

        public Triangle(Point3 x, Point3 y, Point3 z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3 X { get; set; }

        public Point3 Y { get; set; }

        public Point3 Z { get; set; }
    }
}
namespace Sharp3D.Scene.Primitives
{
    public struct Point3
    {
        /// <summary>
        /// Gets or sets the X component.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y component.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the Z component.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3"/> structure.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static explicit operator Vector3(Point3 point3)
        {
            return new Vector3(point3.X, point3.Y, point3.Z);
        }
    }
}
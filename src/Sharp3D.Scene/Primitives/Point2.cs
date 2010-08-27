namespace Sharp3D.Scene.Primitives
{
    public struct Point2
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
        /// Initializes a new instance of the <see cref="Point2"/> structure.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2(double x, double y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
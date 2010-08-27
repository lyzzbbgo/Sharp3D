using System;

namespace Sharp3D.Scene.Primitives
{
    /// <summary>
    /// Represents a three component vector.
    /// </summary>
    public struct Vector3
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
        /// The zero vector.
        /// </summary>
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        /// The infinite vector.
        /// </summary>
        public static readonly Vector3 Infinate = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> structure.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> structure.
        /// </summary>
        /// <param name="v">Source vector.</param>
        public Vector3(Vector3 v) : this(v.X, v.Y, v.Z)
        {
        }

        public Vector3 Normalize()
        {
            var magnitude = Magnitude();
            return new Vector3(X / magnitude, Y / magnitude, Z / magnitude);
        }

        public static Vector3 operator +(Vector3 v, Vector3 w)
        {
            return new Vector3(w.X + v.X, w.Y + v.Y, w.Z + v.Z);
        }

        public static Vector3 operator -(Vector3 v, Vector3 w)
        {
            return new Vector3(v.X - w.X, v.Y - w.Y, v.Z - w.Z);
        }

        public static Vector3 operator *(Vector3 v, Vector3 w)
        {
            return new Vector3(v.X * w.X, v.Y * w.Y, v.Z * w.Z);
        }

        public static Vector3 operator *(Vector3 v, double f)
        {
            return new Vector3(v.X * f, v.Y * f, v.Z * f);
        }

        public static Vector3 operator /(Vector3 v, double f)
        {
            return new Vector3(v.X / f, v.Y / f, v.Z / f);
        }

        public double Dot(Vector3 w)
        {
            return X * w.X + Y * w.Y + Z * w.Z;
        }

        public Vector3 Cross(Vector3 w)
        {
            return new Vector3(-Z * w.Y + Y * w.Z, Z * w.X - X * w.Z, -Y * w.X + X * w.Y);
        }

        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}
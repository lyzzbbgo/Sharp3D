using System;

namespace Sharp3D.Scene.Primitives
{
    /// <summary>
    /// Represents a color.
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> structure.
        /// </summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        public Color(byte r, byte g, byte b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Gets or sets the sRGB alpha channel value of the color.
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Gets or sets the sRGB red channel value of the color.
        /// </summary>
        public byte R { get; set; }
        
        /// <summary>
        /// Gets or sets the sRGB green channel value of the color.
        /// </summary>
        public byte G { get; set; }
        
        /// <summary>
        /// Gets or sets the sRGB blue channel value of the color.
        /// </summary>
        public byte B { get; set; }
    }
}
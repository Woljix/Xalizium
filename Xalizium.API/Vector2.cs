using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API
{
    public struct Vector2
    {
        public int X { get; set; } 
        public int Y { get; set; }

        //public Vector2() { X = 0; Y = 0; }
        public Vector2(int X, int Y) { this.X = X; this.Y = Y; }
        public Vector2(Vector2 Other) { this.X = Other.X; this.Y = Other.Y; }

        public static readonly Vector2 Zero = new Vector2(0, 0);

        // Never Eat Sea Weed (North East South West)

        /// <summary>
        /// Shorthand for (0, -1) (UP)
        /// </summary>
        public static readonly Vector2 North = new Vector2(0, -1);
        /// <summary>
        /// Shorthand for (0, 1) (DOWN)
        /// </summary>
        public static readonly Vector2 South = new Vector2(0, 1);
        /// <summary>
        /// Shorthand for (-1, 0) (LEFT)
        /// </summary>
        public static readonly Vector2 West = new Vector2(-1, 0);
        /// <summary>
        /// Shorthand for (1, 0) (RIGHT)
        /// </summary>
        public static readonly Vector2 East = new Vector2(1, 0); 

        public static Vector2 operator +(Vector2 a, Vector2 b) { return new Vector2(a.X + b.X, a.Y + b.Y); }
        public static Vector2 operator -(Vector2 a, Vector2 b) { return new Vector2(a.X - b.X, a.Y - b.Y); }

        public static bool AreEqual(Vector2 A, Vector2 B)
        {
            try
            {
                if (A.GetHashCode() == B.GetHashCode())
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            return AreEqual(this, (Vector2)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
        public override string ToString()
        {
            return string.Format("(X: {0}, Y: {1})", X, Y);
        }
    }
}

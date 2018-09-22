using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API
{
    public class Vector2
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Vector2() { }
        public Vector2(int X, int Y) { this.X = X; this.Y = Y; }
        public Vector2(Vector2 other) { this.X = other.X; this.Y = other.Y; }

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

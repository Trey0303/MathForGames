using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
    public class Vector2
    {
        // fields for storing values on each dimension
        public float x, y;

        // default constructor (no parameters)
        public Vector2()
        {
            // left intentionally blank -- x and y will be default initialized
            x = 0;
            y = 0;
        }

        // parameterized constructor - the two float values will initialized
        // the x and y fields respectively
        public Vector2(float xArg, float yArg)
        {
            x = xArg;
            y = yArg;
        }

        public float Magnitude()
        {
            float sqLen = MagnitudeSqr();
            return (float)Math.Sqrt(sqLen);
        }

        public float MagnitudeSqr()
        {
            float sqLen = x * x + y * y;
            return sqLen;
        }

        public void Normalize()
        {
            float length = Magnitude();

            x /= length;
            y /= length;
        }

        public Vector2 GetNormalized()
        {
            float length = Magnitude();
            return new Vector2(x / length, y / length);
        }

        public float Dot(Vector2 other)
        {
            return x * other.x + y * other.y;
        }

        public Vector2 Cross(Vector2 other)
        {
            return new Vector2(y * other.x - x * other.y,
                               x * other.y - y * other.x);
        }

        public float AngleBetween(Vector2 other)
        {
            Vector2 a = GetNormalized();
            Vector2 b = other.GetNormalized();

            float d = a.Dot(b);

            return (float)Math.Acos(d);
        }

        // defines an operator for allowing subtraction between a Vector2 and Vector2
        //
        // the order does matter - this only works if there is a Vector2 and
        // Vector2 on the left and right-hand side respectively
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            Vector2 result = new Vector2();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;

            return result;
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            Vector2 result = new Vector2();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;

            return result;
        }
        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            Vector2 scaled = new Vector2(lhs.x * scalar,
                                         lhs.y * scalar);

            return scaled;
        }

        public static Vector2 operator *(float scalar, Vector2 rhs)
        {
            return rhs * scalar;
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            Vector2 scaled = new Vector2(lhs.x / scalar,
                                           lhs.y / scalar);

            return scaled;
        }

        //my math to system
        public static implicit operator System.Numerics.Vector2(Vector2 source)
        {
            return new System.Numerics.Vector2(source.x, source.y);
        }
        //system to my math
        public static implicit operator Vector2(System.Numerics.Vector2 source)
        {
            return new Vector2(source.X, source.Y);
        }
    }
}

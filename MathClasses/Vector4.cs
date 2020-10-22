using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
    public class Vector4
    {
        public float x, y, z, w;

        // default constructor (no parameters)
        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        // parameterized constructor - the two float values will initialized
        // the x and y fields respectively
        public Vector4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public float Magnitude()
        {
            float sqLen = MagnitudeSqr();
            return (float)Math.Sqrt(sqLen);
        }

        public float MagnitudeSqr()
        {
            float sqLen = x * x + y * y + z * z + w * w;
            return sqLen;
        }

        public void Normalize()
        {
            float length = Magnitude();

            x /= length;
            y /= length;
            z /= length;
            w /= length;
        }

        public Vector4 GetNormalized()
        {
            float length = Magnitude();
            return new Vector4(x / length, y / length, z / length, w / length);
        }

        public float Dot(Vector4 other)
        {
            return x * other.x + y * other.y + z * other.z + w * other.w;
        }

        public Vector4 Cross(Vector4 other)
        {
            return new Vector4(y * other.z - z * other.y,
                               z * other.x - x * other.z,
                               x * other.y - y * other.x,
                               0);
        }

        public float AngleBetween(Vector4 other)
        {
            Vector4 a = GetNormalized();
            Vector4 b = other.GetNormalized();

            float d = a.Dot(b);

            return (float)Math.Acos(d);
        }


        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            result.z = lhs.z + rhs.z;
            result.w = lhs.w + rhs.w;

            return result;
        }
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            result.z = lhs.z - rhs.z;
            result.w = lhs.w - rhs.w;

            return result;
        }

        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            Vector4 scaled = new Vector4(lhs.x * scalar,
                                         lhs.y * scalar,
                                         lhs.z * scalar,
                                         lhs.w * scalar);

            return scaled;
        }

        public static Vector4 operator *(float scalar, Vector4 rhs)
        {
            return rhs * scalar;
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            Vector4 scaled = new Vector4(lhs.x / scalar,
                                         lhs.y / scalar,
                                         lhs.z / scalar,
                                         lhs.w / scalar);

            return scaled;
        }

        //my math to system
        public static implicit operator System.Numerics.Vector4(Vector4 source)
        {
            return new System.Numerics.Vector4(source.x, source.y, source.z, source.w);
        }
        //system to my math
        public static implicit operator Vector4(System.Numerics.Vector4 source)
        {
            return new Vector4(source.X, source.Y, source.Z, source.W);
        }
    }
}

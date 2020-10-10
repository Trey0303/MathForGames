﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Vector3
    {
        public float x, y, z;

        // default constructor (no parameters)
        public Vector3()
        {

        }

        // parameterized constructor - the two float values will initialized
        // the x and y fields respectively
        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public float Magnitude()
        {
            float sqLen = MagnitudeSqr();
            return (float)Math.Sqrt(sqLen);
        }

        public float MagnitudeSqr()
        {
            float sqLen = x * x + y * y + z * z;
            return sqLen;
        }

        public void Normalize()
        {
            float length = Magnitude();

            x /= length;
            y /= length;
            z /= length;
        }

        public Vector3 GetNormalized()
        {
            float length = Magnitude();
            return new Vector3(x / length, y / length, z / length);
        }

        public float Dot(Vector3 other)
        {
            return x * other.x + y * other.y + z * other.z;
        }

        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(y * other.z - z * other.y,
                               z * other.x - x * other.z,
                               x * other.y - y * other.x);
        }

        public float AngleBetween(Vector3 other)
        {
            Vector3 a = GetNormalized();
            Vector3 b = other.GetNormalized();

            float d = a.Dot(b);

            return (float)Math.Acos(d);
        }


        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = lhs.x + rhs.x;
            result.y = lhs.y + rhs.y;
            result.z = lhs.z + rhs.z;

            return result;
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();
            result.x = lhs.x - rhs.x;
            result.y = lhs.y - rhs.y;
            result.z = lhs.z - rhs.z;

            return result;
        }

        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            Vector3 scaled = new Vector3(lhs.x * scalar,
                                         lhs.y * scalar,
                                         lhs.z * scalar);

            return scaled;
        }

        public static Vector3 operator *(float scalar, Vector3 rhs)
        {
            return rhs * scalar;
        }

        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            Vector3 scaled = new Vector3(lhs.x / scalar,
                                           lhs.y / scalar,
                                           lhs.z / scalar);

            return scaled;
        }
    }
}

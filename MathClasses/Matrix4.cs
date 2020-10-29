using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
        public Matrix4()
        {
            m1 = 1; m5 = 0; m9 = 0; m13 = 0;
            m2 = 0; m6 = 1; m10 = 0; m14 = 0;
            m3 = 0; m7 = 0; m11 = 1; m15 = 0;
            m4 = 0; m8 = 0; m12 = 0; m16 = 1;
        }

        public Matrix4(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            m1 = a1;
            m2 = a2;
            m3 = a3;
            m4 = a4;
            m5 = a5;
            m6 = a6;
            m7 = a7;
            m8 = a8;
            m9 = a9;
            m10 = a10;
            m11 = a11;
            m12 = a12;
            m13 = a13;
            m14 = a14;
            m15 = a15;
            m16 = a16;
        }
        public static Matrix4 CreateIdentity()
        {
            return new Matrix4(1.0f, 0.0f, 0.0f, 0.0f,
                               0.0f, 1.0f, 0.0f, 0.0f,
                               0.0f, 0.0f, 1.0f, 0.0f,
                               0.0f, 0.0f, 0.0f, 1.0f);
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m5 = 0; m9 = 0; m13 = 0;
            m2 = 0; m6 = y; m10 = 0; m14 = 0;
            m3 = 0; m7 = 0; m11 = z; m15 = 0;
            m4 = 0; m8 = 0; m12 = 0; m16 = 1;
        }

        public void Set(Matrix4 m)
        {
            
        }
        public void Set(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            //update the values of the matrix to the values of the input matrix.
            m1 = a1;
            m2 = a2;
            m3 = a3;
            m4 = a4;
            m5 = a5;
            m6 = a6;
            m7 = a7;
            m8 = a8;
            m9 = a9;
            m10 = a10;
            m11 = a11;
            m12 = a12;
            m13 = a13;
            m14 = a14;
            m15 = a15;
            m16 = a16;
        }

        public void SetRotateX(double radians)
        {
            Set(
            1, 0, 0, 0,
            0, (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
            0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
            0, 0, 0, 1);
        }
        public void SetRotateY(double radians)
        {
            Set(
                (float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }
        public void SetRotateZ(double radians)
        {
            Set(
                (float)Math.Cos(radians), (float)-Math.Sin(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        public void SetTranslation(float x, float y, float z)
        {
            m13 = x; m14 = y; m15 = z; m16 = 1;
        }
        public void Translate(float x, float y, float z)
        {
            // apply vector offset
            m13 += x; m14 += y; m15 += z;
        }
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                //m11
                rhs.m1 * lhs.m1 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m9 + rhs.m4 * lhs.m13,
                //m12
                rhs.m1 * lhs.m2 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m10 + rhs.m4 * lhs.m14,
                //m13
                rhs.m1 * lhs.m3 + rhs.m2 * lhs.m7 + rhs.m3 * lhs.m11 + rhs.m4 * lhs.m15,
                //m14
                rhs.m1 * lhs.m4 + rhs.m2 * lhs.m8 + rhs.m3 * lhs.m12 + rhs.m4 * lhs.m16,
                //m21
                rhs.m5 * lhs.m1 + rhs.m6 * lhs.m5 + rhs.m7 * lhs.m9 + rhs.m8 * lhs.m13,
                //m22
                rhs.m5 * lhs.m2 + rhs.m6 * lhs.m6 + rhs.m7 * lhs.m10 + rhs.m8 * lhs.m14,
                //m23
                rhs.m5 * lhs.m3 + rhs.m6 * lhs.m7 + rhs.m7 * lhs.m11 + rhs.m8 * lhs.m15,
                //m24
                rhs.m5 * lhs.m4 + rhs.m6 * lhs.m8 + rhs.m7 * lhs.m12 + rhs.m8 * lhs.m16,
                //m31
                rhs.m9 * lhs.m1 + rhs.m10 * lhs.m5 + rhs.m11 * lhs.m9 + rhs.m12 * lhs.m13,
                //m32
                rhs.m9 * lhs.m2 + rhs.m10 * lhs.m6 + rhs.m11 * lhs.m10 + rhs.m12 * lhs.m14,
                //m33
                rhs.m9 * lhs.m3 + rhs.m10 * lhs.m7 + rhs.m11 * lhs.m11 + rhs.m12 * lhs.m15,
                //m34
                rhs.m9 * lhs.m4 + rhs.m10 * lhs.m8 + rhs.m11 * lhs.m12 + rhs.m12 * lhs.m16,
                //m41
                rhs.m13 * lhs.m1 + rhs.m14 * lhs.m5 + rhs.m15 * lhs.m9 + rhs.m16 * lhs.m13,
                //m42
                rhs.m13 * lhs.m2 + rhs.m14 * lhs.m6 + rhs.m15 * lhs.m10 + rhs.m16 * lhs.m14,
                //m43
                rhs.m13 * lhs.m3 + rhs.m14 * lhs.m7 + rhs.m15 * lhs.m11 + rhs.m16 * lhs.m15,
                //m44
                rhs.m13 * lhs.m4 + rhs.m14 * lhs.m8 + rhs.m15 * lhs.m12 + rhs.m16 * lhs.m16);
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w),
                               (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w),
                               (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w),
                               (lhs.m4 * rhs.y) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w));
        }
    }
}

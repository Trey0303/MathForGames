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
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        //public static Matrix4 CreateIdentity()
        //{
        //    return new Matrix4(1.0f, 0.0f, 0.0f, 0.0f,
        //                       0.0f, 1.0f, 0.0f, 0.0f,
        //                       0.0f, 0.0f, 1.0f, 0.0f,
        //                       0.0f, 0.0f, 0.0f, 1.0f);
        //}

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        public void Set(Matrix4 m)
        {
            //update the values of the matrix to the values of the input matrix.
            //Matrix3 result = new Matrix3();


            //return result;
        }
        public void Set(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            //update the values of the matrix to the values of the input matrix.
            //Matrix3 result = new Matrix3();
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

            //return result;
        }

        public void SetRotateX(double radians)
        {
            Set(
            1, 0, 0, 0,
            0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
            0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
            0, 0, 0, 1);
        }

        public void SetTranslation(float x, float y, float z)
        {
            m13 = z; m14 = y; m15 = z; m16 = 1;
        }

        void Translate(float x, float y, float z)
        {
            // apply vector offset
            m13 += z; m14 += y; m15 += z;
        }

        //public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        //{
        //    return new Matrix4(rhs.m1 * lhs.m1 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m9 + rhs.m4 * lhs.m13,
        //                       rhs.m1 * lhs.m2 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m10 + rhs.m4 * lhs.m14,
        //                       rhs.m1 * lhs.m3 + rhs.m2 * lhs.m7 + rhs.m3 * lhs.m11 + rhs.m4 * lhs.m15,
        //                       rhs.m1 * lhs.m4 + rhs.m2 * lhs.m8 + rhs.m3 * lhs.m12 + rhs.m4 * lhs.m16);
        //}

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4((rhs.x * lhs.m1) + (rhs.y * lhs.m5) + (rhs.z * lhs.m9) + (rhs.w * lhs.m13),
                               (rhs.x * lhs.m2) + (rhs.y * lhs.m6) + (rhs.z * lhs.m10) + (rhs.w * lhs.m14),
                               (rhs.x * lhs.m3) + (rhs.y * lhs.m5) + (rhs.z * lhs.m11) + (rhs.w * lhs.m15),
                               (rhs.x * lhs.m4) + (rhs.y * lhs.m8) + (rhs.z * lhs.m12) + (rhs.w * lhs.m16));
        }
    }
}

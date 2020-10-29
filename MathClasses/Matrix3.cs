using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace MathClasses
{
    public class Matrix3
    {
        
        public readonly static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        public Matrix3()
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }

        public Matrix3(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9)
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
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m4 = 0; m7 = 0;
            m2 = 0; m5 = y; m8 = 0;
            m3 = 0; m6 = 0; m9 = z;
        }


        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        public void Set(Matrix3 m)
        {
            
        }
        public void Set(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9)
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
        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians),
                0, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }

        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians),
                0, 1, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians));
        }
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
               (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
               0, 0, 1);
        }
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }

        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }

        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
            // combine rotations in a specific order
            Set(z * y * x);
        }

        Matrix3 GetTransposed()
        {
            //flip row and column
            return new Matrix3(m1, m4, m7,
                               m2, m5, m8,
                               m3, m6, m9);
        }

        public void SetTranslation(float x, float y)
        {
            m7 = x; m8 = y; m9 = 1;
        }

        public void Translate(float x, float y)
        {
            // apply vector offset
            m7 += x; m8 += y;
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                               (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                               (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
            //m11
             lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
             //m12
             lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
             //m13
             lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,
             //m21
             lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
             //m22
             lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
             //m23
             lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,
             //m31
             lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
             //m32
             lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
             //m33
             lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9 ); 
        }
    }
}

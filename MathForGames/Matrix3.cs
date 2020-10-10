using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MathForGames
{
    class Matrix3
    {
        //public readonly static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }

        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = v.z;
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }

        //void Scale(Vector3 v)
        //{
        //    Matrix3 m = new Matrix3();
        //    m.SetScaled(v.x, v.y, v.z);
        //    Set(this * m);
        //}

        //public void Scale(float x, float y, float z)
        //{
        //    Matrix3 m = new Matrix3();
        //    m.SetScaled(x, y, z);
        //    Set(this * m);
        //}

        public void Set(Matrix3 m)
        {
            //update the values of the matrix to the values of the input matrix.
        }

        public void SetRotateX(double radians)
        {
            //Set(1, 0, 0,
            //    0, (float)Math.Cos(radians), (float)Math.Sin(radians),
            //    0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }

        private void SetRotateZ(double radians)
        {

        }

        private void SetRotateY(double radians)
        {

        }

        //public void RotateX(double radians)
        //{
        //    Matrix3 m = new Matrix3();
        //    m.SetRotateX(radians);
        //    Set(this * m);
        //}

        //void SetEuler(float pitch, float yaw, float roll)
        //{
        //    Matrix3 x = new Matrix3();
        //    Matrix3 y = new Matrix3();
        //    Matrix3 z = new Matrix3();
        //    x.SetRotateX(pitch);
        //    y.SetRotateY(yaw);
        //    z.SetRotateZ(roll);
        //    // combine rotations in a specific order
        //    Set(z * y * x);
        //}

        //Matrix3 GetTransposed()
        //{
        //    // flip row and column
        //   //return new Matrix3(m1, m4, m7,
        //   //                   m2, m5, m8,
        //   //                   m3, m6, m9);
        //}

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                               (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                               (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
        }

        //public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        //{
        //    //return new Matrix3(
        //    // lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
        //    // lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
        //    // lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
        //}
    }
}

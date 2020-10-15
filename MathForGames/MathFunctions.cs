using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    struct Point2D
    {
        public float x;
        public float y;
    }

    struct Point3D
    {
        public float x;
        public float y;
        public float z;
    }

    struct Plane
    {
        public float a;
        public float b;
        public float c;
        public float d;
    }

    class MathFunctions
    {
        public float BasicQuadratic(float x)
        {
            // Quadratic Function
            // ax^2 + bx + c = 0
            //
            // In this method, a, b, and c are known - only x will change
            return x * x + 2 * x - 7;
        }

        public float[] QuadraticRoot(float a, float b, float c)
        {
            // Calculating the roots of a quadratic curve when given coefficents

            float discrimnant = (float)Math.Sqrt(b * b - 4 * a * c);

            // if d > 0, we have two solutions
            if (discrimnant > 0)
            {
                float rootA = -b + discrimnant / 2 * a;
                float rootB = -b - discrimnant / 2 * a;

                // inline array initialization - note: not standard for students
                return new[] { rootA, rootB };
            }

            // if d is negative, we have no solution (according to the problem)
            return null;
        }

        public float Lerp(float start, float end, float time)
        {
            // one of many ways to implement this...

            float diff = end - start;
            return start + diff * time;
        }

        public float Distance(Point2D p1, Point2D p2)
        {
            float xDiffSq = (p2.x - p1.x);
            float yDiffSq = (p2.y - p1.y);

            return (float)Math.Sqrt(xDiffSq * xDiffSq + yDiffSq * yDiffSq);
        }

        public float InnerProduct(Point3D p, Point3D q)
        {
            // aka dot product

            return p.x * q.x + p.y * p.y + p.z * p.z;
        }

        public float DistanceFromPlaneToPoint(Plane plane, Point3D point)
        {
            // distance from, 

            return (plane.a * point.x + plane.b * point.y + plane.c * point.z + plane.d) /
                (float)Math.Sqrt(plane.a * plane.a + plane.b * plane.b + plane.c * plane.c);
        }

        public float CubicBezierCube(float x, float y)
        {
            return ((1 - x) * (1 - x) * (1 - x) * y + 3 * (1 - x) * (1 - x) * x * y + 3 * (1 - x) * x * x * x + x * x * x * y);
        }
    }
}

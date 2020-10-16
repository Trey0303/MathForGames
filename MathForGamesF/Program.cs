using System;
using System.Diagnostics;

namespace MathForGamesF
{
    class Program
    {
        //a
        //𝑓(𝑥) = 𝑥^2 + 2𝑥 – 7
        static float BasicQuadratic(float x)
        {
            float total = x * x + (2 * x) - 7;
            return total;
        }

        //b
        static double QuadraticAdd(float a, float b, float c)
        {
           return (float)(-b + Math.Sqrt((b * b) - (4 * a * c)) / 2 * a);
        }

        static double QuadraticSub(double a, double b, double c)
        {
            return (float)(-b - Math.Sqrt((b * b) - (4 * a * c)) / 2 * a);
        }

        //c
        //𝐿(𝑠, 𝑒,𝑡) = 𝑠 + 𝑡(𝑒 − 𝑠)
        static float BasicLinearBlend(float s, float e, float t)
        {
            return s + t * (e - s);
        }

        //d
        //This function takes in two points – P1 and P2, each made up of x1, y1, and x2, y2 respectively.
        //This function calculates the distance between the two points
        static float DistanceTwoPoints(float xOne, float yOne, float xTwo, float yTwo)
        {
            float x = xTwo - xOne;
            float y = yTwo - yTwo;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        //e
        //This is the equation for the inner product of two points, P and Q. Each point has an x, y, and z
        //static float Inner()
        //{

        //}

        //static void Main(string[] args)
        //{
        //    //a
        //    Debug.Assert(BasicQuadratic(3) == 8, "BasicQuadratic broke");
        //    //c
        //    Debug.Assert(BasicLinearBlend(3, 5, 6) == 15, "BasicLinearBlend broke");
        //}
    }
}

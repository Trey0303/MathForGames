using System;
using System.Diagnostics;

namespace MathForGames
{
    class Program
    {
        //𝑓(𝑥) = 𝑥^2 + 2𝑥 – 7
        static float BasicQuadratic(float x)
        {
            float total = x * x + (2 * x) - 7;
            return total;
        }

        static float QuadraticAdd(float a, float b, float c)
        {
           return (float)(-b + Math.Sqrt((b * b) - (4 * a * c)) / 2 * a);
        }

        static float QuadraticSub(double a, double b, double c)
        {
            return (float)(-b - Math.Sqrt((b * b) - (4 * a * c)) / 2 * a);
        }


        static void Main(string[] args)
        {
            Debug.Assert(BasicQuadratic(3) == 8, "BasicQuadratic broke");
        }
    }
}

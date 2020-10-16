using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGamesF
{
    class Trigonometry
    {
        static double Degrees(double x)
        {
            return (x / 180) * Math.PI;
        }

        static double Radians(double x)
        {
            return (x / Math.PI) * 180;
        }
    }
}

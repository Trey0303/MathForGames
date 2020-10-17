using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace MathClasses
{
    

    class MagnitudeAndNormalisation
    {
        static void Main(string[] args)
        {
            Vector3 positionA = new Vector3();
            positionA.x = 3;
            positionA.y = 4;
            positionA.z = 5;

            Vector3 positionB = new Vector3();
            positionB.x = 6;
            positionB.y = 7;
            positionB.z = 8;

            Vector3 result = positionA + positionB;

        }
    }
}

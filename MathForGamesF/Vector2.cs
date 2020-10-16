using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGamesF
{
    class Vector2
    {
            // fields for storing values on each dimension
            public float x, y;

            // default constructor (no parameters)
            public Vector2()
            {
                // left intentionally blank -- x and y will be default initialized
            }

            // parameterized constructor - the two float values will initialized
            // the x and y fields respectively
            public Vector2(float xArg, float yArg)
            {
                x = xArg;
                y = yArg;
            }

            // defines an operator for allowing subtraction between a Vector2 and Vector2
            //
            // the order does matter - this only works if there is a Vector2 and
            // Vector2 on the left and right-hand side respectively
            public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
            {
                return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
            }
    }
}

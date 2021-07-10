using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public static class CustFunctions
{
    public static float Dist(float xp1, float yp1, float xp2, float yp2)
    {
        float a = xp1 - xp2;
        float b = yp1 - yp2;
        return (float)Math.Sqrt(a*a + b*b);
    }
}

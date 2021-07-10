using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;                                // GXPEngine contains the engine

class SpaceBackground : GameObject
{
    Canvas space1 = new Canvas("SpaceStrip.png", false);
    Canvas space2 = new Canvas("SpaceStrip.png", false);

    public SpaceBackground(int inpX, int inpY) : base()
    {
        AddChild(space1);
        AddChild(space2);

        x = inpX;
        y = inpY;

        space1.x = 0;
        space1.y = 0;

        space2.x = 0;
        space2.y = -space2.height;
    }

    void Update() 
    {
        space1.y += Globals.gameSpeed;
        space2.y += Globals.gameSpeed;

        if (space1.y > space2.height)
        {
            space1.y = -space2.height;
        }

        if (space2.y > space1.height)
        {
            space2.y = -space1.height;
        }
    }
}


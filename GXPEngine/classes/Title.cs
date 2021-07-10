using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class Title : AnimationSprite
{
    int timer;
    int maxTime;
    bool growing;
    float growth = 0.005f;

    public Title(int inpX, int inpY) : base("Title.png", 1, 10, 10, true, false) 
    {
        x = inpX;
        y = inpY;

        SetOrigin(width / 2, height / 2);
        SetCycle(1, 10, 2, false);
        scale = 1.75f;
    }

    public void Update()
    {
        if (growing)
        {
            y += growth*100;
            scale += growth;
            if (scale > 2) 
            {
                growing = false;
            }
        }
        else 
        {
            y -= growth*100;
            scale -= growth;
            if (scale < 1.75)
            {
                growing = true;
            }
        }

        if (timer > maxTime)
        {
            Animate();

            if (timer > maxTime + 17)
            {
                timer = 0;
                maxTime = 240;
            }
        }
        else
        {
            SetFrame(0);
        }

        timer++;
    }
}


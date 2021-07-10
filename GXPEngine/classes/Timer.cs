using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Timer : GameObject
{  
    float second;
    int framesCounter;
    bool active;
    
    public float seconds 
    {
        get { return second; }
    }

    public Timer() : base()
    {
        start();
    }

    public void start()
    {
        second = 0;
        framesCounter = 0;
        active = true;
    }

    public void stop()
    {
        active = false;
    }

    public void Update()
    {
        if (active)
        {
            if (framesCounter >= 3)
            {
                framesCounter = 0;
                second += 0.05f;
            }
            else
            {
                framesCounter++;
            }
        }
    }
}


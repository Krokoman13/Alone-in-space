using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Dynamic : GameObject
{
    protected double xSpeed = 0;
    protected double ySpeed = 0;
    protected double xAcc = 0;
    protected double yAcc = 0;
    protected double turn = 0;

    protected Sprite body;

    public Dynamic(string filename) : base(true)
    {
        body = new Sprite(filename, false);
        AddChild(body);
    }

    public void stop() {
        xSpeed = 0;
        ySpeed = 0;
        xAcc = 0;
        yAcc = 0;
    }

    virtual public int width
    {
        get
        {
            return body.width;
        }
        set
        {
            body.width = value;
        }
    }

    virtual public int height
    {
        get
        {
            return body.height;
        }
        set
        {
            body.height = value;
        }
    }

    protected void Update()
    {
        TurnControls();
        MoveControls();
    }

    protected void TurnControls()
    {
        Turn((float)turn);
    }

    protected void MoveControls()
    {
        xSpeed += xAcc;
        ySpeed += yAcc;

        MoveUntilCollision((float)xSpeed, (float)ySpeed);
    }
}


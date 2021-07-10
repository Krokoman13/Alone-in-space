using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;                                // GXPEngine contains the engine

public class Astroid : Sprite
{
    float dx = 0;
    float dy = 5;

    public Astroid(float inpX, float inpY, float xSpeed, float ySpeed, float inpScale) : base("astroid small1.png", true)
    {
        SetOrigin(width / 2, height / 2);

        dx = xSpeed;
        dy = ySpeed;

        scale = inpScale;
        SetXY(inpX, inpY);
    }

    public Astroid() : base("astroid small1.png", true)
    {
        SetOrigin(width / 2, height / 2);
        reset();
    }

    public void reset()
    {
        x = Globals.random.Next(-game.width / 2, game.width / 2);    //The X position is based on a little added randomness
        y = -(game.height / 2 + Globals.random.Next(game.height));  //The Y position is based on a little added randomness

        dx = Globals.random.Next(-2, 2);
        dy = 5 + Globals.random.Next(-2, 2);

        scale = (float)Globals.random.Next(10, 100) / 80;  //Randomly generate the size
    }

    void Update()
    {
        Move(dx, dy);

        if (scale < 0.2)
        {
            LateDestroy();
        }

        if (y > game.height / 2)
        {
            LateDestroy();
        }
    }

    void split()
    {
        game.LateAddChild(new Astroid(x, y, dx - 1.5f, dy, scale / 2));
        game.LateAddChild(new Astroid(x, y, dx + 1.5f, dy, scale / 2));
        LateDestroy();
    }

    public void OnCollision(GameObject other)
    {
        if (other is Bullet)
        {
            if (other.scale > 0.90)
            {
                other.LateDestroy();
                split();
            }
        }
    }
}

public class Cluster : GameObject
{
    int amount;

    public Cluster(int amountInp) {
        amount = amountInp;

        x = 0;
        y = 0;
    }

    void Update()
    {
        if (GetChildren(true).Count < amount)
        {
            AddChild(new Astroid());
        }
    }
}


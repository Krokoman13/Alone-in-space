using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;                                // GXPEngine contains the engine

class Bullet : Sprite
{
    protected float speed;
    protected readonly int lifespan = 150;
    protected int age;

    float damage;

    public Bullet() : base("bullet.png", true)
    {
    }

    public Bullet(float inpX, float inpY, float inpRotation, float inpSize, float inpSpeed, float inpDamage) : base("bullet.png", true)
    {
        x = inpX;
        y = inpY;

        damage = inpDamage;

        rotation = inpRotation - 90f;
        scale = inpSize;
        speed = inpSpeed;

        //SetOrigin(width/2, height/2);
    }

    void Update()
    {
        age++;
        if (age >= lifespan)
        {
            LateDestroy();
        }

        y = y + Globals.gameSpeed;
        Move(0, speed);
        //MoveUntilCollision(-(float)(speed * Math.Sin((rotation * (Math.PI / 180) * -1))), -(float)(speed * Math.Cos((rotation * (Math.PI / 180) * -1))), new GameObject[1] { new Astroid() });
    }

    public void OnCollision(GameObject other)
    {
       if (other is Astroid)
        {
            if (other.scale < 0.90) 
            {
                LateDestroy();
                other.scale -= damage / 10;
            }
        }
    }
}

class BadBullet : Bullet
{
    public BadBullet(float inpX, float inpY, float inpRotation, float inpSize, float inpSpeed, float inpDamage) : base(inpX, inpY, inpRotation, inpSize, inpSpeed, inpDamage)
    { 
    }

    void Update()
    {
        if (age >= lifespan)
        {
            LateDestroy();
        }
        Move(0, speed);
    }
}


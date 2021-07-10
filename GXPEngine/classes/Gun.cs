using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class GoodGun : Sprite 
{
    protected int cooldown;
    protected int time;

    protected float damage;
    protected float bulletSize;
    protected float bulletSpeed;

    public GoodGun(string filename) : base(filename, false) 
    {
        SetOrigin(width / 2, (height / 3) * 2);
        cooldown = 30;
        damage = 2f;
        bulletSize = 4;
        bulletSpeed = 30;
        time = cooldown;
    }

    public void Update() 
    {
        if (time < cooldown) 
        {
            time++;
        }
    }

    public virtual void fire(float inpRotation)
    {
        if (time >= cooldown)
        {
            Sound laser;
            laser = new Sound("lazer.mp3", false, false);
            laser.Play(false, 0, 0.5f, 0);

            game.CurrentLevel.AddChild(new Bullet(parent.x, parent.y, inpRotation, bulletSize, bulletSpeed, damage));
            time = 0;
        }
    }
}

class BadGun : GoodGun 
{
    public BadGun() : base("SmallLaser.png")
    {
        cooldown = 90;
        damage = 2f;
        bulletSize = 4;
        bulletSpeed = 5;
    }

    public override void fire(float inpRotation)
    {
        if (time >= cooldown)
        {
            Sound laser;
            laser = new Sound("lazer.mp3", false, false);
            laser.Play(false, 0, 0.5f, 0);

            game.CurrentLevel.AddChild(new BadBullet(parent.x, parent.y, inpRotation, bulletSize, bulletSpeed, damage));
            time = 0;
        }
    }
}

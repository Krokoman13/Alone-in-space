using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Enemy : AnimationSprite
{
    LevelEmtpy myWorld;
    BadGun myGun;
    Player target;

    public Enemy(int inpX, int inpY, LevelEmtpy level) : base("UFO.png", 1, 2, 2, true)
    {
        x = inpX;
        y = inpY;

        myWorld = level;
        target = myWorld.player;

        myGun = new BadGun();
        AddChild(myGun);

        SetOrigin(width / 2, height / 2);
        SetCycle(0, 2, 15, true);
    }

    public void Update() 
    {
        Animate();
        handleGun();
    }

    private void handleGun()
    {
        double angle;
        angle = Math.Atan2(target.x - x, target.y - y);
        angle = (angle * (180 / Math.PI) * -1) + 180;
        myGun.rotation = (float)angle;

        myGun.fire((float)angle - 90f);
    }
}


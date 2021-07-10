using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : Dynamic
{
    public bool wPressed;
    public bool aPressed;
    public bool sPressed;
    public bool dPressed;
    public bool mousePressed;

    private readonly float maxPower = 0.1f;
    private double power = 0;

    Sprite fire = new Sprite("twinfire.png", false);
    Sprite engines = new Sprite("engines.png", false);
    GoodGun mainGun = new GoodGun("Laser.png");
    PlayerCollider playerCollider;

    public Player() : base("triangle.png")
    {
        playerCollider = new PlayerCollider(width, height);
        body.SetOrigin(width / 2, (height / 3)*2);
        fire.SetOrigin(fire.width / 2, (fire.height / 3)*2);
        engines.SetOrigin(fire.width / 2, (fire.height / 3)*2);

        AddChild(playerCollider);
        AddChild(fire);
        AddChild(engines);
        AddChild(mainGun);

        scale = 1.1f;
        SetXY(0, 0);
    }

    public new void Update()
    {
        getWASDKeys();
        TurnControls();
        MoveControls();
        handleGun();
    }

    private void handleGun()
    {
        double angle;
        angle = Math.Atan2(Input.mouseX - 1920/2 - x, Input.mouseY - 1080/2 - y);
        angle = (angle * (180 / Math.PI) * -1) + 180;

        mainGun.rotation = (float)angle - rotation;

        if (Input.GetMouseButton(0))
        {
            mainGun.fire((float)angle - 90f);
        }
    }

    private new void TurnControls()
    {
        if (dPressed)
        {
            turn += maxPower * 2;
        }
        else if (aPressed)
        {
            turn -= maxPower * 2;
        }

        turn *= 0.96;

        base.TurnControls();
    }

    private new void MoveControls()
    {
        fire.y = 0;

        if (wPressed || sPressed)
        {
            if (wPressed)
            {
                if (power < maxPower) power += 0.01;
                fire.y = (float)power*70;
            }
            else if (sPressed)
            {
                if (power > -maxPower) power -= 0.01;
                fire.y = (float)power*50;
            }
            xAcc = Mathf.Cos((rotation - 90) * Mathf.PI / 180f) * power;
            yAcc = Mathf.Sin((rotation - 90) * Mathf.PI / 180f) * power;
        }
        else
        {
            power = 0;
            xAcc = 0;
            yAcc = 0;
        }

        boundries();

        base.MoveControls();
    }

    void boundries()
    {
        if (y < -(game.height / 2))
        {
            ySpeed = 0;
            y = -game.height / 2;
        }
        else if (y > (game.height / 2) - height)
        {
            ySpeed = 0;
            y = game.height / 2 - height - 1;
        }

        if (x < -(game.width / 2))
        {
            xSpeed = 0;
            x = -game.width / 2;
        }
        else if (x > (game.width / 2))
        {
            xSpeed = 0;
            x = game.width / 2;
        }
    }

    void getWASDKeys()
    {
        if (Input.GetKeyDown(Key.W))    //When e is pressed...
        {
            wPressed = true;
        }
        else if (Input.GetKeyUp(Key.W))
        {
            wPressed = false;
        }

        if (Input.GetKeyDown(Key.A))   //When a is pressed...
        {
            aPressed = true;
        }
        else if (Input.GetKeyUp(Key.A))
        {
            aPressed = false;
        }

        if (Input.GetKeyDown(Key.S))   //When s is pressed...
        {
            sPressed = true;
        }
        else if (Input.GetKeyUp(Key.S))
        {
            sPressed = false;
        }

        if (Input.GetKeyDown(Key.D))    //When d is pressed...
        {
            dPressed = true;
        }
        else if (Input.GetKeyUp(Key.D))
        {
            dPressed = false;
        }
    }
}

class PlayerCollider : Canvas
{
    public PlayerCollider(int width, int height) : base(width, height, true)
    {
        SetOrigin(width / 2, height / 2);
    }

    public void OnCollision(GameObject other)
    {
        if (other is Astroid || other is BadBullet)
        {
            Sound laser;
            laser = new Sound("crash.mp3", false, false);
            laser.Play(false, 0, 0.5f, 0);

            Console.WriteLine("Ohw noes! I got hit");
            game.levelManager.lstLevel();
        }
    }
}

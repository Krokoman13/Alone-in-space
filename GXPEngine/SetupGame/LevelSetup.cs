using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class LevelEmtpy : Level
{
    public Player player;
    public Camera mainCam;
    protected Timer timer;
    protected Canvas HUD;

    public LevelEmtpy(string name) : base(name)
    {
    }

    public override void onLoad()
    {
        base.onLoad();
        AddChild(new SpaceBackground(-width / 2, -height / 2));

        player = new Player();
        player.y = 300;

        mainCam = new Camera(0, 0, game.width, game.height);

        timer = new Timer();
        timer.start();

        AddChild(player);
        AddChild(timer);
        AddChild(mainCam);
    }
}

class LevelOne : LevelEmtpy
{
    bool ClusterLoaded;
    public LevelOne() : base("Level One")
    {
    }

    public override void Update()
    {
        HUD.graphics.Clear(Color.Empty);
        //Console.WriteLine(20 - (int)timer.seconds);

        if (timer.seconds > 5 && !ClusterLoaded)
        {
            AddChild(new Cluster(3));
            ClusterLoaded = true;
        }
        if (timer.seconds > 15)
        {
            var _newFont = new Font("DS Pixel Cyr", 40);
            HUD.graphics.DrawString("You've passed Level One in: " + (20 - (int)timer.seconds), _newFont, Brushes.Green, 100, 100);
        }
        if (timer.seconds > 20)
        {
            game.levelManager.setLevel("Menu");
        }
    }

    public override void onLoad()
    {
        base.onLoad();
        ClusterLoaded = false;
        HUD = new Canvas(width, height);
        AddChild(HUD);
    }
}

class LevelTwo : LevelEmtpy
{
    bool ClusterLoaded;
    bool EnemiesLoaded;

    public LevelTwo() : base("Level Two")
    {
    }

    public override void Update()
    {
        HUD.graphics.Clear(Color.Empty);

        if (timer.seconds > 2 && !ClusterLoaded)
        {
            AddChild(new Cluster(4));
            ClusterLoaded = true;
        }
        if (timer.seconds > 20)
        {
            if (!EnemiesLoaded)
            {
                AddChild(new Enemy(-750, -400, this));
                AddChild(new Enemy(750, -400, this));
                EnemiesLoaded = true;
            }

            var _newFont = new Font("DS Pixel Cyr", 40);
            HUD.graphics.DrawString("You've passed Level One in: " + (30 - (int)timer.seconds), _newFont, Brushes.Green, 50, 50);
        }
        if (timer.seconds > 30)
        {
            game.levelManager.setLevel("Menu");
        }
    }

    public override void onLoad()
    {
        base.onLoad();
        EnemiesLoaded = false;
        ClusterLoaded = false;
        HUD = new Canvas(width, height);
        AddChild(HUD);
    }
}



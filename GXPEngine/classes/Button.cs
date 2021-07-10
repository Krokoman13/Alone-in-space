using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class MenuButton : Button
{
    public MenuButton(float inpX, float inpY) : base(inpX, inpY)
    {
        text = "Main Menu";
    }
    protected override void click()
    {
        game.levelManager.frstLevel();
    }
}

class BackButton : Button
{
    public BackButton(float inpX, float inpY) : base(inpX, inpY)
    {
        text = "Try again";
    }
    protected override void click()
    {
        game.levelManager.gotoPreviousLevel();
    }
}

class LvSwtchButton : Button
{
    private Level nextLevel;

    public Level level
    {
        set { nextLevel = value; }
    }

    public LvSwtchButton(float inpX, float inpY, Level nextLevelInp) : base(inpX, inpY)
    {
        nextLevel = nextLevelInp;
        text = nextLevelInp.name;
    }

    public LvSwtchButton(int inpX, int inpY) : base(inpX, inpY)
    {
    }

    protected override void click()
    {
        if (nextLevel != null)
        {
            game.CurrentLevel = nextLevel;
        }
        else
        {
            base.click();
        }
    }
}

public class Button : AnimationSprite
{
    private Canvas overlay;
    int timer;
    int maxTime;
    protected string text;

    public Button(float inpX, float inpY) : base("Button.png", 1, 10, 10, false)
    {
        overlay = new Canvas(width, height);
        overlay.SetOrigin(overlay.width / 2, overlay.height / 2);
        AddChild(overlay);

        x = inpX;
        y = inpY;
        SetOrigin(width/2, height/2);

        text = "UNKNOWN";
        
        SetCycle(1, 9, 2, false);
    }

    protected virtual void click()
    { 
    }

    public void Update()
    {
        var _newFont = new Font("DS Pixel Cyr", 40);
        overlay.graphics.Clear(Color.Empty);
        overlay.graphics.DrawString(text, _newFont, Brushes.White, 90, 50);

        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(0);
            if (Input.GetMouseButton(0))
            {
                click();
            }
        }
        else if (timer > maxTime)
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
            SetFrame(1);
        }

        timer++;
    }
}


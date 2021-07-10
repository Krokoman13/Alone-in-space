using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class GameOverScreen : Screen
{
    public GameOverScreen() : base("Game Over", "spaceStrip.png")
    { 
    }

    public override void onLoad()
    {
        base.onLoad();

        AddChild(new BackButton(width / 2 - 300, height - 200));
        AddChild(new MenuButton(width / 2 + 300, height - 200));
    }
}

class MainMenu : Screen
{
    LvSwtchButton toLevelOne;
    LvSwtchButton toLevelTwo;
    LvSwtchButton toLevelThree;

    Level levelOne;
    Level levelTwo;
    Level levelThree;

    public MainMenu(Level one, Level two, Level three) : base("Menu", "spaceStrip.png")
    {
        levelOne = one;
        levelTwo = two;
        levelThree = three;
    }

    public override void onLoad()
    {
        base.onLoad();

        toLevelOne = new LvSwtchButton(width / 2 - 500, height - 200, levelOne);
        toLevelTwo = new LvSwtchButton(width / 2, height - 200, levelTwo);
        toLevelThree = new LvSwtchButton(width / 2 + 500, height - 200, levelThree);

        AddChild(toLevelOne);
        AddChild(toLevelTwo);
        AddChild(toLevelThree);

        AddChild(new Title(width / 2, 300));
    }
}

class Screen : Level
{
    public Screen(string name, string fileName) : base(name, fileName)
    { 
    }
}


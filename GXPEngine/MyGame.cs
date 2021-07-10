using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

static class Globals
{
    public static Random random = new Random();  //Needed to generate random numbers
    public static int gameSpeed = 5;
}

public class MyGame : Game
{
    public MyGame() : base(1920, 1080, false, false)       // Create a window that's 1920x1080 and NOT fullscreen
    {
        targetFps = 60;

        LevelOne levelOne = new LevelOne();
        LevelTwo levelTwo = new LevelTwo();
        MainMenu mainMenu = new MainMenu(levelOne, levelTwo, new LevelEmtpy("UNKNOWN"));
        GameOverScreen gameOver = new GameOverScreen();

        levelManager.addLevel(mainMenu);
        levelManager.addLevel(levelOne);
        levelManager.addLevel(levelTwo);
        levelManager.addLevel(gameOver);

        levelManager.setLevel(mainMenu);
    }

    void Update()
    {
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();
    }
}
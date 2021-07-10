using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level : Canvas
    {
        private bool _loaded;

        public bool loaded 
        {
            get { return _loaded; }
        }

        public Level(string levelName) : base(1920, 1080, false)
        {
            name = levelName;
            SetOrigin(width / 2, height / 2);
            x = 0;
            y = 0;
        }

        public Level(string levelName, string backgroundImageFile) : base(backgroundImageFile, false)
        {
            name = levelName;
            //SetOrigin(width / 2, height / 2);
            x = 0;
            y = 0;
        }

        public virtual void Update()
        {
        }

        public virtual void onLoad()
        {
            _loaded = true;
            game.LateAddChild(this);
        }

        public virtual void onLeave()
        {
            _loaded = false;

            foreach (GameObject other in GetChildren(false))
            {
                other.LateDestroy();
            }

            this.LateRemove();
        }

        public string getLevelName()
        {     //Get the name of the Level
            return name;
        }
    }

    public class LevelManager
    {
        private List<Level> Levels;
        int currentLevelNumber;
        Level previousLevel;

        public LevelManager() 
        {
            reset();
        }

        public void addLevel(Level Level)
        {
            Levels.Add(Level);

            if (Levels.Count == 1)
            {
                Level.onLoad();
            }
        }

        public void setLevel(Level level)
        {
            setLevel(level.name);
        }

        public void setLevel(string level)
        {
            gotoLevel(findLevel(level));
        }

        public void frstLevel()
        {
            gotoLevel(0);
        }

        public void lstLevel()
        {
            gotoLevel(Levels.Count - 1);
        }

        private void gotoLevel(int nextLevel)
        {
            if (currentLevelNumber != nextLevel)
            {
                Levels[currentLevelNumber].onLeave();
                previousLevel = Levels[currentLevelNumber];

                currentLevelNumber = nextLevel;

                if (!Levels[currentLevelNumber].loaded)
                {
                    Levels[currentLevelNumber].onLoad();
                }
            }
        }

        public int findLevel(string Level)
        {
            for (int i = 0; i < Levels.Count(); i++)
            {
                if (Levels[i].name == Level)
                {
                    return i;
                }
            }
            Console.WriteLine("Could not find Level: " + Level);
            return currentLevelNumber;
        }

        public void gotoNextLevel(Level Level)
        {
            getCurrentLevel().onLeave();
            if (Levels.Count() > 1)
            {
                getCurrentLevel().onLeave();
                currentLevelNumber += 1;
            }
        }

        public void gotoPreviousLevel()
        {
            if (previousLevel != null)
            {
                setLevel(previousLevel);
            }
        }

        public Level getCurrentLevel()
        {
            return Levels[currentLevelNumber];
        }

        public void updateLevel()
        {
            if (Levels.Count() > 0)
            {
                getCurrentLevel().Update();
            }
        }

        public void reset()
        {
            Levels = new List<Level>();
            currentLevelNumber = 0;
        }
    }
}

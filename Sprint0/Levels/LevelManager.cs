using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Items;
using System.Collections.Generic;

namespace Sprint0.Levels
{
    public class LevelManager
    {
        private LevelLoader LevelLoader;
        private List<Level> Levels;

        private Level CurrentLevel;

        public LevelManager()
        {
            LevelLoader = new LevelLoader(this);
            Levels = new List<Level>();
        }

        public void TransitionRooms()
        {
            
        }
        
        public void LoadLevel(string levelName)
        {
            CurrentLevel = LevelLoader.LoadLevelFromFile(levelName);
        }
        public void Update(GameTime gameTime)
        {
            foreach (Level level in Levels)
            {
                level.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch sb)
        {
            CurrentLevel.Draw(sb);
        }
    }
}

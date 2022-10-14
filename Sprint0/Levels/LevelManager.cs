using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using System.Collections.Generic;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using static Sprint0.Types;

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
        
        public List<IBlock> GetCurrentRoomBlocks()
        {
            return CurrentLevel.CurrentRoom.Blocks;
        }
        public void MakeRoomTransition(RoomTransition direction)
        {
            CurrentLevel.MakeRoomTransition(direction);
        }
        public void LoadLevel(string levelName)
        {
            CurrentLevel = LevelLoader.LoadLevelFromDir(levelName);
        }
        public void Update(GameTime gameTime)
        {
            CurrentLevel.Update(gameTime);
        }
        public void Draw(SpriteBatch sb)
        {
            CurrentLevel.Draw(sb);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Items;
using System.Collections.Generic;

namespace Sprint0.Levels
{
    // Many things have been ommented out for now to fix errors caused by things that aren't implemented yet
    public class LevelManager
    {
        private LevelLoader LevelLoader;
        private List<Level> Levels;

        public LevelManager()
        {
            //LevelLoader = new LevelLoader(this);
            Levels = new List<Level>();
        }

        public void AddRoomToLevel()
        {
            // implement this.
        }
        public void Update(GameTime gameTime)
        {
            /*foreach (Level level in Levels)
            {
                level.Update();
            }

            foreach (ICharacter character in LevelCharacters)
            {
                character.Update(gameTime);
            }*/
        }
        public void Draw(SpriteBatch sb)
        {
            /*foreach (IBlock block in LevelBlocks)
            {
                block.Draw(sb);
            }

            foreach (ICharacter character in LevelCharacters)
            {
                character.Draw(sb);
            }*/
        }
    }
}

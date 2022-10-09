using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Levels
{
    public class LevelManager
    {
        private LevelLoader LevelLoader;
        private List<IBlock> LevelBlocks;
        private List<ICharacter> LevelCharacters;
        public LevelManager()
        {
            LevelBlocks = new List<IBlock>();
            LevelCharacters = new List<ICharacter>();
            LevelLoader = new LevelLoader(this);
        }

        public void AddBlock(Types.Block block, Vector2 position)
        {
            LevelBlocks.Add(BlockFactory.GetInstance().GetBlock(block, position));
        }
        public void AddCharacter(Types.Character character, Vector2 position)
        {
            LevelCharacters.Add(CharacterFactory.GetInstance().GetCharacter(character, position));
        }

        public void Update(GameTime gameTime)
        {
            foreach (IBlock block in LevelBlocks)
            {
                block.Update();
            }

            foreach (ICharacter character in LevelCharacters)
            {
                character.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (IBlock block in LevelBlocks)
            {
                block.Draw(sb);
            }

            foreach (ICharacter character in LevelCharacters)
            {
                character.Draw(sb);
            }
        }
    }
}

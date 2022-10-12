using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Items;
using System.Collections.Generic;

namespace Sprint0.Levels
{
    public class Room
    {
        private List<IBlock> RoomBlocks;
        private List<ICharacter> RoomCharacters;
        private List<IItem> RoomItems;
        public void AddBlockToRoom(Types.Block block, Vector2 position)
        {
            RoomBlocks.Add(BlockFactory.GetInstance().GetBlock(block, position));
        }
        public void AddCharacterToRoom(Types.Character character, Vector2 position)
        {
            RoomCharacters.Add(CharacterFactory.GetInstance().GetCharacter(character, position));
        }

        public void RemoveItemFromRoom(IItem item) 
        {
            RoomItems.Remove(item);
        }

        public void Update(GameTime gameTime)
        {
            foreach(IBlock block in RoomBlocks)
            {
                block.Update();
            }
            foreach(ICharacter character in RoomCharacters)
            {
                character.Update(gameTime);
            }
            foreach(IBlock item in RoomItems)
            {
                item.Update();
            }
        }
    }
}

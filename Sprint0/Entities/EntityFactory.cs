using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Characters.Utils;
using Sprint0.Items;
using Sprint0.Items.Utils;
using Sprint0.Levels;
using Sprint0.Levels.Utils;
using System;

namespace Sprint0.Entities
{
    public class EntityFactory
    {
        private static EntityFactory Instance;

        private EntityFactory() { }
        /// <summary>
        /// Creates and returns an entity. May also add the entity to a collection which corresponds to its specific type. (E.G. a 'Block' entity may be added to room.Blocks).
        /// </summary>
        /// <param name="room"></param>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public IEntity GetEntity(Level level, string roomName, string category, string type, string name, Vector2 position)
        {
            // Find the correct room from the specified name.
            Room room = level.Rooms.Find(room => room.Name == roomName);
            switch (category)
            {
                case "block":
                    Types.Block blockType = LevelResources.GetInstance().BlockMap[type];
                    IBlock block = BlockFactory.GetInstance().GetBlock(blockType, position);
                    block.Parent = room;
                    block.Name = name;
                    room.AddBlockToRoom(block);
                    return block;

                case "item":
                    Types.Item itemType = LevelResources.GetInstance().ItemMap[type];
                    IItem item = ItemFactory.GetInstance().GetItem(itemType, position);
                    item.Parent = room;
                    item.Name = name;
                    return item;

                case "character":
                    Types.Character characterType = LevelResources.GetInstance().CharacterMap[type];
                    ICharacter character = CharacterFactory.GetInstance().GetCharacter(characterType, position);
                    character.Parent = room;
                    character.Name = name;
                    room.AddCharacterToRoom(character);
                    return character;
                default:
                    Console.Error.Write("Failed to create entity type from category: " + category 
                        + " of string type: " + type + ".\n" + "This could be caused by a typo in the relevant Entities.csv file.");
                    return null;
            } 
        }
        public static EntityFactory GetInstance()
        {
            Instance ??= new EntityFactory();
            return Instance;
        }
    }
}

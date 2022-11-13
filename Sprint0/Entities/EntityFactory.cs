using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Items;
using Sprint0.Items.Utils;
using Sprint0.Levels;
using Sprint0.Levels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Room room = level.Rooms.Find(room => room.RoomName == roomName);
            switch (category)
            {
                case "block":
                    Types.Block blockType = LevelResources.GetInstance().BlockMap[type];
                    IBlock block = BlockFactory.GetInstance().GetBlock(blockType, position);
                    block.SetParent(room);
                    block.SetName(name);
                    room.AddBlockToRoom(block);
                    return block;

                case "item":
                    Types.Item itemType = LevelResources.GetInstance().ItemMap[type];
                    IItem item = ItemFactory.GetInstance().GetItem(itemType, position);
                    item.SetParent(room);
                    item.SetName(name);
                    return item;
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

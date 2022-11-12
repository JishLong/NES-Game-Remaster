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
    public static class EntityUtils
    {
        public static void CreateEntity(Room room, string category, string type, string name, Vector2 position)
        {
            switch (category)
            {
                case "block":
                    Types.Block blockType = LevelResources.GetInstance().BlockMap[type];
                    IBlock block = BlockFactory.GetInstance().GetBlock(blockType, position);
                    block.SetName(name);
                    room.AddBlockToRoom(block);
                    room.AddEntityToRoom(block); // Blocks are also inherently entities.
                    break;

                case "item":
                    Types.Item itemType = LevelResources.GetInstance().ItemMap[type];
                    IItem item = ItemFactory.GetInstance().GetItem(itemType, position);
                    item.SetName(name);
                    room.AddEntityToRoom(item);
                    break;
            } 
        }
    }
}

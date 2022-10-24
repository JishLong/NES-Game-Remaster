using Microsoft.Xna.Framework;
using Sprint0.Blocks.Blocks;
using Sprint0.Blocks.PushableBlocks;
using System;

namespace Sprint0.Blocks.Utils
{
    public class BlockFactory
    {
        private static BlockFactory Instance;

        private BlockFactory() { }

        public IBlock GetBlock(Types.Block blockType, Vector2 position)
        {
            switch (blockType)
            {
                case Types.Block.WATER:
                    return new Water(position);
                case Types.Block.BLUE_SAND:
                    return new BlueSand(position);
                case Types.Block.BLUE_STAIRS:
                    return new BlueStairs(position);
                case Types.Block.BLUE_STATUE_LEFT:
                    return new BlueStatueLeft(position);
                case Types.Block.BLUE_STATUE_RIGHT:
                    return new BlueStatueRight(position);
                case Types.Block.BLUE_TILE:
                    return new BlueTile(position);
                case Types.Block.BLUE_WALL:
                    return new BlueWall(position);
                case Types.Block.GREY_BRICKS:
                    return new GreyBricks(position);
                case Types.Block.LADDER:
                    return new Ladder(position);
                case Types.Block.WHITE_BARS:
                    return new WhiteBars(position);
                case Types.Block.PUSHABLE_BLOCK_UP:
                    return new PushableBlockUp(position);
                case Types.Block.BORDER_BLOCK:
                    return new BorderBlock(position);
                default:
                    Console.Error.Write("The block of type " + blockType.ToString() + 
                        " could not be instantiated by the Block Factory. Does this type exist?");
                    return null;
            }
        }

        public static BlockFactory GetInstance()
        {
            Instance ??= new BlockFactory();
            return Instance;
        }
    }
}

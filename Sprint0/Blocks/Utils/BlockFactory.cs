using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Blocks.Utils
{
    public class BlockFactory
    {
        private Types.Block[] blocks = (Types.Block[])Enum.GetValues(typeof(Types.Block));
        private int index = 0;

        private static BlockFactory instance;

        private BlockFactory()
        {

        }

        public IBlock GetBlock(Types.Block blockType, Vector2 position)
        {
            switch (blockType)
            {
                case Types.Block.BLUE_GAP:
                    return new BlueGap(position);
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
                case Types.Block.FIRE_BLOCK:
                    return new FireBlock(position);
                case Types.Block.GREY_BRICKS:
                    return new GreyBricks(position);
                case Types.Block.LADDER_BLOCK:
                    return new LadderBlock(position);
                case Types.Block.WHITE_BARS:
                    return new WhiteBars(position);
                default:
                    Console.Error.Write("The concrete type " + blockType + " could not be instantiated by the Block Factory. Does this type exist?");
                    return null;
            }
        }

        public IBlock GetNextBlock(Vector2 position)
        {
            index = (index + 1) % blocks.Length;
            return GetBlock(blocks[index], position);
        }

        public IBlock GetPrevBlock(Vector2 position)
        {
            index = (index - 1 + blocks.Length) % blocks.Length;
            return GetBlock(blocks[index], position);
        }

        public static BlockFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new BlockFactory();
            }
            return instance;
        }
    }
}

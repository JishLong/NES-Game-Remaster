using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Blocks.Utils
{
    public class BlockFactory
    {
        public static readonly Vector2 DefaultBlockPosition = new Vector2(100, 200);

        // Single point of use
        private static BlockFactory Instance;

        // Used for switching between different blocks in-game
        private Types.Block[] Blocks = (Types.Block[])Enum.GetValues(typeof(Types.Block));
        private int CurrentBlock = 0;

        private BlockFactory() { }

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
                    Console.Error.Write("The block of type " + blockType.ToString() + 
                        " could not be instantiated by the Block Factory. Does this type exist?");
                    return null;
            }
        }

        // Returns an instance of the next block type in the [Blocks] array
        public IBlock GetNextBlock(Vector2 position)
        {
            CurrentBlock = (CurrentBlock + 1) % Blocks.Length;
            return GetBlock(Blocks[CurrentBlock], position);
        }

        // Returns an instance of the previous block type in the [Blocks] array
        public IBlock GetPrevBlock(Vector2 position)
        {
            CurrentBlock = (CurrentBlock - 1 + Blocks.Length) % Blocks.Length;
            return GetBlock(Blocks[CurrentBlock], position);
        }

        public static BlockFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BlockFactory();
            }
            return Instance;
        }
    }
}

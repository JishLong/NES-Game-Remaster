using Microsoft.Xna.Framework;
using Sprint0.Blocks.Blocks;
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
                case Types.Block.PUSHABLE_BLOCK:
                    return new PushableBlock(position);
                case Types.Block.BORDER_BLOCK:
                    return new BorderBlock(position);
                case Types.Block.LEFT_DOOR_WAY_BLOCK:
                    return new LeftDoorWayBlock(position);
                case Types.Block.RIGHT_DOOR_WAY_BLOCK:
                    return new RightDoorWayBlock(position);
                case Types.Block.ROOM_TRANSITION_BLOCK:
                    return new RoomTransitionBlock(position);
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

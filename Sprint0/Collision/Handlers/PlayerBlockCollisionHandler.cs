using Sprint0.Commands.Levels;
using Sprint0.Commands.Player;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Player.State;
using Sprint0.Blocks;
using Microsoft.Xna.Framework;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class PlayerBlockCollisionHandler
    {
        private Room Room;

        public PlayerBlockCollisionHandler(Room room) 
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) isn't actually needed here -
         * at least I think... I'll keep it in the parameters for a while just in case...
         * 
         * itemSide is the effected side of the reciever and impacting colider would be the opposite side
         * would want to set the players X value 
         * 
         * both block and player
         * 
         * block: if pushable -> block.push
         * 
         * player not running into block: switch case for hitting top,bottom,left and right of block and reset x and y values accordingly 
         * 
         */
        public void HandleCollision(IPlayer player, IBlock block, Types.Direction itemSide, Room room) 
        {
            //int blockX = block.GetHitbox().X;
            //int blockY = block.GetHitbox().Y;
            //Vector2 blockV = new Vector2(blockX, blockY);

            new PlayerStopActionCommand(player).Execute();
            
            //switch (itemSide)
            //{
                
            //    case (Types.Direction.DOWN):
            //        //player.y = item.y
            //        //^swap player y with block y
            //        break;
            //    case (Types.Direction.UP):
            //        //player.y = item.y
            //        //^swap player y with block y
            //        break;
            //    case (Types.Direction.RIGHT):
            //        //player.x = item.x
            //        //^swap player x with block x
            //        break;
            //    default:
            //        //(LEFT)
            //        //player.x = item.x
            //        //^swap player x with block x
            //        break;
            //    //block: if pushable -> block.push
            //}
        }
    }
}

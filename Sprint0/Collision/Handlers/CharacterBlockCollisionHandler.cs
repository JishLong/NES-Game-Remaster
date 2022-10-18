using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Characters;
using Sprint0.Characters.Enemies;
using Sprint0.Blocks;
using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class CharacterBlockCollisionHandler
    {
        private Room Room;
        IEnemyState enemyState;

        public CharacterBlockCollisionHandler(Room room) 
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) isn't actually needed here -
         * at least I think... I'll keep it in the parameters for a while just in case...
         * 
         * 
         * start here
         * FOR CLARITY: Direction.UP indicates the top side, and Direction.DOWN indicates the bottom side
         * 
         * 
         * do not have to deal with pushable block
         * just switch case for which side of the block the enemy hits the block
         * -> then reset the enemy's x and y accordingly
         * 
         * 
         */
        public void HandleCollision(ICharacter character, IBlock block, Types.Direction itemSide, Room room) 
        {
            
            //int blockX = block.GetHitbox().X;
            //int blockY = block.GetHitbox().Y;
            //Vector2 blockV = new Vector2(blockX, blockY);

            enemyState.Freeze();
            switch (itemSide)
            { 
                case (Types.Direction.DOWN):
                    //enemy.y = item.y
                    //^swap enemy y with block y            
                    break;
                case (Types.Direction.UP):
                    //enemy.y = item.y
                    //^swap enemy y with block y       
                    break;
                case (Types.Direction.RIGHT):
                    //enemy.x = item.x
                    //^swap enemy x with block x    
                    break;
                default:
                    //(LEFT)
                    //enemy.x = item.x
                    //^swap enemy x with block x 
                    break;
            }
            //enemy.Update() --- not too sure but ill keep it commented until level loading is in
        }
    }
}

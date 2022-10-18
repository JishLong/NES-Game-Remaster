﻿using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Blocks;
using Sprint0.Characters;
using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses;
using Sprint0.Characters.Enemies;
using Sprint0.Commands.Characters;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class CharacterBlockCollisionHandler
    {
        private Room Room;

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
            //x,y,vector of block's hitbox
            int blockX = block.GetHitbox().X;
            int blockY = block.GetHitbox().Y;
            Vector2 blockV = new Vector2(blockX, blockY);

            //types of blocks character cannot walk through
            if (block.GetType().IsAssignableTo(typeof(BlueWall)) ||
                block.GetType().IsAssignableTo(typeof(BlueStatueLeft)) ||
                block.GetType().IsAssignableTo(typeof(BlueStatueRight)) ||
                block.GetType().IsAssignableTo(typeof(BlueGap)))
            {
                //if (character.GetType().IsAssignableTo(typeof(IEnemy)))
                //{
                //    //cast character as IEnemy   
                //}
                //else if (character.GetType().IsAssignableTo(typeof(IBoss)))
                //{
                //    //cast character as IBoss  
                //}
                //switch (itemSide)
                //{
                //    case (Types.Direction.DOWN):
                //        //enemy.y = item.y
                //        //^swap enemy y with block y            
                //        break;
                //    case (Types.Direction.UP):
                //        //enemy.y = item.y
                //        //^swap enemy y with block y       
                //        break;
                //    case (Types.Direction.RIGHT):
                //        //enemy.x = item.x
                //        //^swap enemy x with block x    
                //        break;
                //    default:
                //        //(LEFT)
                //        //enemy.x = item.x
                //        //^swap enemy x with block x 
                //        break;
                //}
            }
        }
    }
}

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Items;

namespace Sprint0.Collision
{
    /* DEV NOTES:
     * 
     * The collision detector's job is to obtain a list of everything currently on screen (or more specifically, in the
     * current room) that is collidable and determine every collision that is occurring between the objects in this list
     *  
     * Upon finding a collision, information about it is extracted and sent over to the collision delegator for the collision response.
     */
    public class CollisionDetector
    {
        private readonly CollisionDelegator CollisionDelegator;
        private readonly Game1 Game;

        private List<ICollidable> Collidables;
    
        public CollisionDetector(Game1 game) 
        {
            Game = game;
            CollisionDelegator = new CollisionDelegator();
        }       

        public void Update() 
        {
            // Get a list of every collidable in the current room
            // Very inefficient - could add a separate "collidables" list into room that is handled separately and simply get that
            Collidables = new List<ICollidable>();
            foreach (var player in Game.PlayerManager)
            {
                Collidables.Add(player);
            }
            Collidables.AddRange(Game.LevelManager.CurrentLevel.CurrentRoom.Characters);
            Collidables.AddRange(Game.LevelManager.CurrentLevel.CurrentRoom.Projectiles.GetProjectiles());
            Collidables.AddRange(Game.LevelManager.CurrentLevel.CurrentRoom.DoorHandler.GetBlocks());
            Collidables.AddRange(Game.LevelManager.CurrentLevel.CurrentRoom.Blocks);
            Collidables.AddRange(Game.LevelManager.CurrentLevel.CurrentRoom.Items);

            // Each pair of collidables is only looked at ONCE; also, collidables will not be paired with themselves
            for (int i = 0; i < Collidables.Count - 1; i++) 
            { 
                ICollidable CollidableA = Collidables[i];
                Rectangle HitboxA = CollidableA.GetHitbox();

                for (int j = i + 1; j < Collidables.Count; j++) 
                {
                    ICollidable CollidableB = Collidables[j];
                    Rectangle HitboxB = CollidableB.GetHitbox();

                    if (HitboxA.Intersects(HitboxB))
                    {
                        FormatCollidables(CollidableA, CollidableB);
                        CollisionDelegator.DelegateCollision(CollidableA, CollidableB,
                            GetCollisionSide(HitboxA, HitboxB), Game);
                    }
                }
            }
        }

        /* Returns the side of object A that is involved in the given collision case
         * 
         * FOR CLARITY: Direction.UP indicates the top side, and Direction.DOWN indicates the bottom side
         */
        private Types.Direction GetCollisionSide(Rectangle hitboxA, Rectangle hitboxB)
        {
            Types.Direction CollisionSide;

            /* This involves something called Minkowski Addition - it's some mathy stuff that's pretty interesting.
             * Look it up on google (I read about it on wikipedia) if you want, it's pretty cool. */
            float wy = (hitboxA.Width + hitboxB.Width) * (hitboxA.Center.Y - hitboxB.Center.Y);
            float hx = (hitboxA.Height + hitboxB.Height) * (hitboxA.Center.X - hitboxB.Center.X);

            if (wy > hx)
            {
                CollisionSide = (wy > -hx) ? Types.Direction.UP : Types.Direction.RIGHT;
            }
            else
            {
                CollisionSide = (wy > -hx) ? Types.Direction.LEFT : Types.Direction.DOWN;
            }

            return CollisionSide;
        }    

        /* Formats pairs of collidables so that they can only appear in a certain order - this knowledge helps the delegator deal with less cases.
         * 
         * For example, if there are two collidables, A and B, where one is a player and the other is an item, this method
         * guarantees that CollidableA refers to the player and CollidableB refers to the item. Now, there is no confusion as to
         * which is which.
         * 
         * The pairings are such that the higher-priority object is set as CollidableA and the lower-priority object is set to
         * CollidableB. From highest to lowest priority:
         * 
         * Player, Character, Projectile, Block, Item
         */
        private void FormatCollidables(ICollidable CollidableA, ICollidable CollidableB)
        {
            if (CollidableB is IPlayer)
            {
                (_, _) = (CollidableA, CollidableB);
            }
            else if (CollidableA is IItem)
            {
                (_, _) = (CollidableA, CollidableB);
            }
            else if (CollidableB is ICharacter && CollidableA is not IPlayer)
            {
                (_, _) = (CollidableA, CollidableB);
            }
            else if (CollidableB is IProjectile && (CollidableA is IBlock || CollidableA is IItem))
            {
                (_, _) = (CollidableA, CollidableB);
            }
        }
    }
}

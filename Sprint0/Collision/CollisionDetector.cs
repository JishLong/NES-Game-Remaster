using Sprint0.Levels;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint0.Player;
using Sprint0.Projectiles;

namespace Sprint0.Collision
{
    /* DEV NOTES:
     * 
     * The collision detector's job is to obtain a list of everything currently on screen (or more specifically, in the
     * current room) that is collidable and determine every collision that is occurring between the objects in this list
     *  
     * Upon finding a collision and determining the objects A and B that were involved, the detector then finds which side 
     * of hitbox A was involved. The two objects and this side are then sent off to the Collision Manager for the collision
     * response.
     */
    public class CollisionDetector
    {
        private List<ICollidable> Collidables;
        private CollisionManager CollisionManager;

        // Setting the current room essentially sets the list of collidables the detector deals with
        public Room CurrentRoom { get;  set; }
        private IPlayer Player;

        public CollisionDetector(Room room, IPlayer player) 
        {
            CurrentRoom = room;
            Player = player;
            CollisionManager = new CollisionManager(room);
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

        public void Update() 
        {
            Collidables = new List<ICollidable>();
            Collidables.Add(Player);
            Collidables.AddRange(CurrentRoom.Characters);
            Collidables.AddRange(CurrentRoom.Projectiles.GetProjectiles());
            Collidables.AddRange(CurrentRoom.Blocks);
            Collidables.AddRange(CurrentRoom.Items);

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
                        CollisionManager.HandleCollision(CollidableA, CollidableB,
                            GetCollisionSide(HitboxA, HitboxB), CurrentRoom);
                    }
                }
            }
        }
    }
}

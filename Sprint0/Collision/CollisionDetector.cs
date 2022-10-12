﻿using Sprint0.Levels;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Collision
{
    /* DEV NOTES:
     * 
     * The collision detector's job is to obtain a list of everything currently on screen (or more specifically, in the
     * current room) that is collidable and determine every collision that is occurring between the objects in this list
     * 
     * The detector distinguishes between two different objects in each collision case:
     *   - The "affected" object - the object that will be affected or changed in some way by the collision
     *   - The "acting" object - the object that is "doing" the colliding (and in turn, affecting the "affected" object in some way)
     *       - The acting object should NOT be affected or changed in any way by the collision
     *   
     * Upon finding a collision and determining the affected vs. acting objects, the detector then finds which side of the affected
     * object is involved. The two objects and this side are then sent off to the Collision Manager for the collision response.
     * 
     */
    public class CollisionDetector
    {
        private List<ICollidable> Collidables;
        private CollisionManager CollisionManager;

        // Setting the current room essentially sets the list of collidables the detector deals with
        public Room CurrentRoom { get;  set; }

        public CollisionDetector(Room room) 
        {
            CurrentRoom = room;
            CollisionManager = new CollisionManager(room);
        }

        /* Returns the side of the affected object that is involved in the given collision case
         * 
         * FOR CLARITY: Direction.UP indicates the top side, and Direction.DOWN indicates the bottom side
         * 
         */
        private Types.Direction GetCollisionSide(Rectangle affectedHitbox, Rectangle actingHitbox) 
        {
            Types.Direction CollisionSide;

            /* This involves something called Minkowski Addition - it's some mathy stuff that's pretty interesting.
             * Look it up on google (I read about it on wikipedia) if you want, it's pretty cool. */
            float wy = (affectedHitbox.Width + actingHitbox.Width) * (affectedHitbox.Center.Y - actingHitbox.Center.Y);
            float hx = (affectedHitbox.Height + actingHitbox.Height) * (affectedHitbox.Center.X - actingHitbox.Center.X);

            if (wy > hx)
            {
                CollisionSide = (wy > -hx) ? Types.Direction.UP : Types.Direction.LEFT;
            }
            else 
            {
                CollisionSide = (wy > -hx) ? Types.Direction.RIGHT : Types.Direction.DOWN;
            }

            return CollisionSide;
        }

        public void Update() 
        {
            //List<Collidables> = room.GetCollidables(); ???? woah woah looks like we prolly need this guy

            /* NOTE: due to the logic of this nested loop, every colliding object is always involved in a pair of collision
             * cases - one in which it is the affected object, and one in which it is the acting object
             * 
             */
            foreach (ICollidable affectedCollidable in Collidables) 
            {
                foreach (ICollidable actingCollidable in Collidables) 
                {
                    if (affectedCollidable != actingCollidable) 
                    {
                        Rectangle AffectedHitbox = affectedCollidable.getHitbox();
                        Rectangle ActingHitbox = actingCollidable.getHitbox();

                        if (AffectedHitbox.Intersects(ActingHitbox)) 
                        {
                            CollisionManager.HandleCollision(affectedCollidable, actingCollidable,
                                GetCollisionSide(AffectedHitbox, ActingHitbox));
                        }
                    }
                }
            }
        }
    }
}

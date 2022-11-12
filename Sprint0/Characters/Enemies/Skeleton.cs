﻿using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.SkeletonStates;
using static Sprint0.Characters.Utils.CharacterUtils;

namespace Sprint0.Characters.Enemies
{
    public class Skeleton : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1500;    // Change direction every this many milliseconds.

        public Skeleton(Vector2 position)
        {
            // State
            State = new SkeletonMovingUpState(this);
            // Combat
            Health = 2;
            Damage = 1;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            DirectionTimer += elapsedTime;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}

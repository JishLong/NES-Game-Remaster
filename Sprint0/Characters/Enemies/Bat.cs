using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States.BatStates;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies
{
    public class Bat : AbstractEnemy
    {
        private double DirectionTimer = 0;
        private double DirectionDelay = 1000;    // Change direction every this many milliseconds.
        public float MovementSpeed { get; set; }
        public Bat(Vector2 position)
        {
            // State
            State = new BatMovingUpState(this);

            // Combat
            Health = 1;

            // Movement
            Position = position;
            MovementSpeed = 2;
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

            State.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            State.Draw(sb, Position);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Utils;
using System;
using Sprint0.Sprites.Enemies;

namespace Sprint0.Enemies
{
    public class Gel : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;

        public Gel(Vector2 position, int updateTimer = 1000)
        {
            // Combat
            this.Health = 1;

            // Movement
            this.Position = position;
            this.DirectionName = "UP";
            this.MovementSpeed = 1;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.Sprite = new GelSprite();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
                Direction = EnemyUtils.RandOrthogDirection(ref DirectionName);
            }

            Position += (this.Direction * this.MovementSpeed);
            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

    }
}

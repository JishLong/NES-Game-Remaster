using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;
using System;
using Sprint0.Enemies.Utils;

namespace Sprint0.Enemies
{
    public class Goriya : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;
        public Goriya(Vector2 position, int updateTimer = 1000) 
        {
            // Combat
            this.Health = 1;

            // Movement
            this.CanMove = true;
            this.Position = position;
            this.DirectionName = "RIGHT";
            this.MovementSpeed = 2;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.sprite = new GoriyaSprite();
           
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

            // Move the skeleton.
            Position += (this.Direction * this.MovementSpeed);
            sprite.SetAnim(DirectionName);
            sprite.Update(gameTime);
        }
        public override void Draw(SpriteBatch sb)
        {

        }
    }
}

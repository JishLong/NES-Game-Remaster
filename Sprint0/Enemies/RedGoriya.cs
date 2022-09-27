using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;
using System;
using Sprint0.Enemies.Utils;

namespace Sprint0.Enemies
{
    public class RedGoriya : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;
        public RedGoriya(Vector2 position, int updateTimer = 1000) 
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
            this.Sprite = new RedGoriyaRightSprite();
           
        }

        public void ChangeSprite(string directionName)
        {
            switch (directionName)
            {
                case "RIGHT":
                    this.Sprite = new RedGoriyaRightSprite();
                    break;
                case "LEFT":
                    this.Sprite = new RedGoriyaLeftSprite();
                    break;
                case "UP":
                    this.Sprite = new RedGoriyaUpSprite();
                    break;
                case "DOWN":
                    this.Sprite = new RedGoriyaDownSprite();
                    break;
            }
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

                ChangeSprite(DirectionName);
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

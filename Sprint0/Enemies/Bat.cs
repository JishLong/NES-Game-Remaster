using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{

    public class Bat : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;
        public Bat(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 1;
            // Movement
            this.CanMove = true;
            this.Position = position;
            this.DirectionName = "UP"; // Starts moving up.
            this.MovementSpeed = 2;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.Sprite = new Sprites.Enemies.BatSprite();
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
                Direction = EnemyUtils.RandDirection(ref DirectionName);
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

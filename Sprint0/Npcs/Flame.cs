using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Sprint0.Sprites.Npcs;

namespace Sprint0.Npcs
{
    public class Flame : AbstractNpc
    {
        int ElapsedTime;
        int UpdateTimer;
        bool isProjectile;
        public Flame(Vector2 position, int updateTimer = 1000)
        {
            // Movement
            Position = position;
            Direction = new Vector2(0, 0);

            // Update
            UpdateTimer = updateTimer;
            Sprite = new Sprites.Npcs.FlameSprite();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
            }
            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Bosses
{
    // This class is currently not used at the moment, but may be useful in the future
    public class AquamentusFlame : AbstractBoss
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        public AquamentusFlame(Vector2 position, int updateTimer = 1000)
        {
            Health = 9999;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 1;    // Damage dealt
            CanMove = true;
            Position = position;
            Direction = new Vector2(0, 0); 
            MovementSpeed = 3;
            UpdateTimer = updateTimer;
            Sprite = new BossProjSprite();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            Sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

    }
}

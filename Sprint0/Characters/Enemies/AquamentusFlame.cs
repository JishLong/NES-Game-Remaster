using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Bosses;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Characters.Enemies
{
    // This class is currently not used at the moment, but may be useful in the future
    public class AquamentusFlame : AbstractCharacter
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        public AquamentusFlame(Vector2 position, int updateTimer = 1000)
        {
            Health = 9999;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 1;    // Damage dealt

            Position = position;
            //Direction = new Vector2(0, 0); 
            // MovementSpeed = 3;
            UpdateTimer = updateTimer;
            Sprite = new BossProjSprite();
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            Sprite.Update();
        }
    }
}

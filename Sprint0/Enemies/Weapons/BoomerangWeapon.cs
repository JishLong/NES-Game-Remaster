using Sprint0.Sprites.Enemies;
using Sprint0.Sprites.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemies.Weapons
{
    public class BoomerangWeapon : IWeapon
    {
        private IWeaponSprite Sprite;
        private Vector2 Position;
        public BoomerangWeapon()
        {
            Sprite = new BoomerangSprite();
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}

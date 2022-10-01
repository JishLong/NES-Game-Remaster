using Sprint0.Sprites.Enemies;
using Sprint0.Sprites.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies.Weapons
{
    public class BoomerangWeapon : IWeapon
    {
        private double ElapsedTime;
        private double UpdateTimer;

        private IWeaponSprite Sprite;
        private bool Enabled;
        private float ProjectileSpeed;
        private Vector2 Position;
        private Direction Direction;
        private Vector2 DirectionVector;
        public BoomerangWeapon(Vector2 position, Direction direction)
        {
            ElapsedTime = 0;
            UpdateTimer = 1000;

            Enable();
            Position = position;
            Direction = direction;
            DirectionVector = ToVector(Direction);
            ProjectileSpeed = 5f;
            Sprite = new BoomerangSprite();
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public bool IsEnabled()
        {
            return Enabled;
        }

        public void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            bool ThrowOutInterval = (ElapsedTime - (UpdateTimer / 2)) < 0;
            bool ReturnInterval = (ElapsedTime - (UpdateTimer / 2)) > 0 && ((ElapsedTime - UpdateTimer) < 0);

            Sprite.Update(gameTime); 
            if (ThrowOutInterval)   // Time before it starts to return.
            {
                Position += (DirectionVector * ProjectileSpeed);
            } else if (ReturnInterval)
            {
                Position -= (DirectionVector * ProjectileSpeed);
            }
            else
            {
                Disable();
            }
        }
        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}

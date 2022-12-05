using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.Collision;
using Sprint0.Items;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles;

namespace Sprint0.Projectiles
{
    public class BoomerangProjectile : AbstractProjectile
    {
        private bool IsReturning;
        private IItem HeldItem;
        private readonly Types.Direction Direction;

        public BoomerangProjectile(ICollidable player, Types.Direction direction) :
            base(new BoomerangProjectileSprite(), player, direction, new Vector2(7, 7))
        {
            MaxFramesAlive = 70;
            IsReturning = false;
            Direction = direction;
            Damage = 1;
        }

        public void ReturnBoomerang()
        {
            if (!IsReturning)
            {
                FramesPassed = MaxFramesAlive - FramesPassed;
                IsReturning = true;
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.ARROW_EXPLOSION_PARTICLE, this, Direction);
            }
        }

        public void HoldItem(IItem item) 
        {
            HeldItem = item;
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            Vector2 EndPos = Utils.CenterRectangles(User.GetHitbox(), GetHitbox().Width, GetHitbox().Height);

            if (FramesPassed < MaxFramesAlive / 2)
            {
                Position += Velocity;
            }
            else if (FramesPassed >= MaxFramesAlive / 2)
            {
                if (!IsReturning) IsReturning = true;
                Position += (EndPos - Position) / (MaxFramesAlive - FramesPassed);
            }

            if (HeldItem != null) 
            {
                HeldItem.Position = Utils.CenterRectangles(GetHitbox(), HeldItem.GetHitbox().Width, HeldItem.GetHitbox().Height);
            }

            // Boomerang spinning noise
            if (IsFromPlayer() && FramesPassed % 10 == 0) 
            {
                AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().ProjectileShoot);
            }
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}

using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Items;
using Sprint0.Sprites.Projectiles;

namespace Sprint0.Projectiles
{
    public class BoomerangProjectile : AbstractProjectile
    {
        private bool IsReturning;
        private IItem HeldItem;

        public BoomerangProjectile(ICollidable player, Types.Direction direction) :
            base(new BoomerangSprite(), player, direction, new Vector2(10, 10))
        {
            MaxFramesAlive = 30;
            IsReturning = false;
            AudioManager.GetInstance().PlayOnce(Resources.ArrowBoomerangShoot);
        }

        public void ReturnBoomerang()
        {
            if (!IsReturning)
            {
                FramesPassed = MaxFramesAlive - FramesPassed;
                IsReturning = true;
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
            IsReturning = false;

            Vector2 EndPos = Utils.CenterRectangles(User.GetHitbox(), GetHitbox().Width, GetHitbox().Height);

            if (FramesPassed < MaxFramesAlive / 2)
            {
                Position += Velocity;
            }
            else if (FramesPassed >= MaxFramesAlive / 2)
            {
                Position += (EndPos - Position) / (MaxFramesAlive - FramesPassed);
            }

            if (HeldItem != null) 
            {
                HeldItem.Position = Utils.CenterRectangles(GetHitbox(), HeldItem.GetHitbox().Width, HeldItem.GetHitbox().Height);
            }

            // Boomerang spinning noise
            if (FramesPassed % 8 == 0) 
            {
                AudioManager.GetInstance().PlayOnce(Resources.ArrowBoomerangShoot);
            }
        }
    }
}

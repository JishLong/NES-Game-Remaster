using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Character;
using System;
using static Sprint0.Types;

namespace Sprint0.Projectiles.Character_Projectiles
{
    public class OldManProjectile : AbstractProjectile
    {
        private static readonly Random RNG = new Random();

        public OldManProjectile(ICollidable user) :
            base(new BossProjectileSprite(), user, Types.Direction.NO_DIRECTION, Vector2.Zero)
        {
            Velocity = new Vector2(RNG.NextSingle() * 2 - 1, RNG.NextSingle()) * new Vector2(10, 10);
            Rectangle TempHitbox = Sprite.GetDrawbox(Vector2.Zero);
            Position = Utils.CenterRectangles(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height);
            MaxFramesAlive = 180;
            Damage = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            // Invisible
        }

        public override void DeathAction()
        {
            // Nothing here!
        }

        public override void Update()
        {
            FramesPassed++;

            Position += Velocity;

            if (RNG.NextSingle() < 0.1)
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOMB_PROJ, this, Types.Direction.DOWN);
        }
    }
}

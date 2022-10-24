﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles.Tools;
using static Sprint0.Types;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);
        private readonly Types.Direction Direction;

        public BlueArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction)
        {
            Sprite = new BlueArrowProjSprite(direction);
            FramesAlive = 40;
            Direction = direction;
        }

        public override void DeathAction()
        {
            Rectangle r = Resources.ArrowExplosionParticle;
            Rectangle ParticleHitbox = new Rectangle(r.X, r.Y, (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale));

            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.ARROWEXPLOSIONPARTICLE,
                Utils.CenterOnEdge(Sprite.GetDrawbox(Position), ParticleHitbox, Direction),
                Direction);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White);
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}

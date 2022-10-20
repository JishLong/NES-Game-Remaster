using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingRightState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private IProjectile Boomerang;
        private Vector2 BoomerangPosition;
        
        public RedGoriyaAttackingRightState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaRightSprite();
            BoomerangPosition = Goriya.Position;

            Boomerang = ProjectileFactory.GetInstance().GetProjectile(
                Types.Projectile.GORIYABOOMERANGPROJ, BoomerangPosition, Types.Direction.RIGHT);
        }
        
        public override void Attack()
        {
            // Already attacking.
        }

        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingRightState(Goriya);
        }

        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenRightState(Goriya);
        }
        public override void ChangeDirection()
        {
            // Do nothing, cant change direction while attacking.
        }

        public override void Update(GameTime gameTime)
        {
            Boomerang.Update();
            if (Boomerang.TimeIsUp())
            {
                Move(); // Resume moving.
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Goriya.Position);
            Boomerang.Draw(sb);
        }
    }
}

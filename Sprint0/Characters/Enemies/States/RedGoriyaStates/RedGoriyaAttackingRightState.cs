using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Character;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingRightState : AbstractEnemyState
    {
        private RedGoriya Goriya;
        private IProjectile Boomerang;
        private Vector2 BoomerangPosition;
        private Vector2 BoomerangVelocity;
        
        public RedGoriyaAttackingRightState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaRightSprite();
            BoomerangPosition = Goriya.Position;
            BoomerangVelocity = ToVector(Direction.Right);
            Boomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANGPROJ, BoomerangPosition, BoomerangVelocity);
            ProjectileManager.GetInstance().AddProjectile(Boomerang);
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

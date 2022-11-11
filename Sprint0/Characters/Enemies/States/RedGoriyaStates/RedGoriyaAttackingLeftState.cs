using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingLeftState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private readonly IProjectile UnseenBoomerang;

        public RedGoriyaAttackingLeftState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaLeftSprite();
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOOMERANG_PROJ, Goriya, Types.Direction.LEFT);
            UnseenBoomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANG_PROJ, Goriya, Types.Direction.LEFT);
        }
        
        public override void Attack()
        {
            // Already attacking.
        }

        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingLeftState(Goriya);
        }

        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenLeftState(Goriya);
        }
        public override void ChangeDirection()
        {
            // Do nothing, cant change direction while attacking.
        }

        public override void Update(GameTime gameTime)
        {
            UnseenBoomerang.Update();
            if (UnseenBoomerang.TimeIsUp())
            {
                Move(); // Resume moving.
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Goriya.Position);
        }
    }
}

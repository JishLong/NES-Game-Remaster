using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingDownState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private readonly IProjectile UnseenBoomerang;

        public RedGoriyaAttackingDownState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaDownSprite();
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOOMERANG_PROJ, Goriya, Types.Direction.DOWN);
            UnseenBoomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANG_PROJ, Goriya, Types.Direction.DOWN);
        }
        
        public override void Attack()
        {
            // Already attacking.
        }

        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingDownState(Goriya);
        }

        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenDownState(Goriya);
        }
        public override void ChangeDirection()
        {
            // Do nothing, cant change direction while attacking.
        }

        public override void Update(GameTime gameTime)
        {
            UnseenBoomerang.Update();
            if (UnseenBoomerang.IsTimeUp())
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

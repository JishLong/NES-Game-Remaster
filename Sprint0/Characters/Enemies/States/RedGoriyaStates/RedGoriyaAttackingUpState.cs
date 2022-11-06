using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingUpState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private readonly IProjectile UnseenBoomerang;
        
        public RedGoriyaAttackingUpState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaUpSprite();
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOOMERANG_PROJ, Goriya, Types.Direction.UP);
            UnseenBoomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANG_PROJ, Goriya, Types.Direction.UP);
        }
        
        public override void Attack()
        {
            // Already attacking.
        }

        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingUpState(Goriya);
        }

        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenUpState(Goriya);
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

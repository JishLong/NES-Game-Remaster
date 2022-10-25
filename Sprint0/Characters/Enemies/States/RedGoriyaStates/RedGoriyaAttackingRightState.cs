using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingRightState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private int BoomerangFrames;
        
        public RedGoriyaAttackingRightState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaRightSprite();
            BoomerangFrames = 0;
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.GORIYA_BOOMERANG_PROJ, Goriya.Position, Types.Direction.RIGHT, Goriya);
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
            BoomerangFrames++;
            // Hard-coded value :(
            if (BoomerangFrames == 300)
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

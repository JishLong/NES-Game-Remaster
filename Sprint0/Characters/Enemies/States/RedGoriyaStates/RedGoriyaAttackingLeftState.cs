using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingLeftState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private int BoomerangFrames;
        
        public RedGoriyaAttackingLeftState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaLeftSprite();
            BoomerangFrames = 0;
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.GORIYABOOMERANGPROJ, Goriya.Position, Types.Direction.LEFT);
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
            // Hard-coded value :(
            BoomerangFrames++;
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

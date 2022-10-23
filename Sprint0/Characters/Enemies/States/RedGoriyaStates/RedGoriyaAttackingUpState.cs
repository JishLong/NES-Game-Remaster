using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingUpState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private int BoomerangFrames;
        
        public RedGoriyaAttackingUpState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaUpSprite();
            BoomerangFrames = 0;
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.GORIYABOOMERANGPROJ, Goriya.Position, Types.Direction.RIGHT);
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

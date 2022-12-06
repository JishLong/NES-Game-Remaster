using Microsoft.Xna.Framework;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Characters.Enemies.States
{
    public class RedGoriyaAttackState : AbstractCharacterState
    {
        private Types.Direction ResumeMovementDirection;
        private IProjectile UnseenBoomerang;

        public RedGoriyaAttackState(AbstractCharacter character) : base(character) { }

        public override void Attack()
        {
            // Already attacking
        }

        public override void ChangeDirection()
        {
            // Can't change direction while attacking
        }

        public override void Freeze(bool frozenForever)
        {
            if (frozenForever && Character.FrozenForeverState != null)
            {
                Character.FrozenForeverState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.FrozenForeverState;
            }
            else if (!frozenForever && Character.FrozenTemporarilyState != null)
            {
                Character.FrozenTemporarilyState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.FrozenTemporarilyState;
            }
        }

        public override void SetUp(Types.Direction direction)
        {
            Character.SetSprite(direction);
            ResumeMovementDirection = direction;

            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOOMERANG_PROJ, Character, direction);
            UnseenBoomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANG_PROJ, Character, direction);
        }

        public override void Unfreeze()
        {
            // Already unfrozen!
        }

        public override void Update(GameTime gameTime)
        {
            // Resume moving if boomerang is done boomeranging (or rather, if it would be - we don't actually see it!)
            UnseenBoomerang.Update();
            if (UnseenBoomerang.TimeIsUp() && Character.MovingState != null) 
            {
                Character.MovingState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.MovingState;
            } 

            Character.Sprite.Update();
        }
    }
}

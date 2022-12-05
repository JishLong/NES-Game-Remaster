using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.RedGoriyaStates;
using Sprint0.GameModes;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingState : AbstractCharacterState
    {
        private readonly Types.Direction ResumeMovementDirection;
        private readonly IProjectile UnseenBoomerang;

        public RedGoriyaAttackingState(AbstractCharacter character, Types.Direction direction) : base(character)
        {
            ResumeMovementDirection = direction;

            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOOMERANG_PROJ, Character, direction);
            UnseenBoomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANG_PROJ, Character, direction);
        }

        public override void Attack()
        {
            // Already attacking.
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new RedGoriyaFrozenState(Character, ResumeMovementDirection, frozenForever);
        }

        public override void ChangeDirection()
        {
            // Do nothing, cant change direction while attacking.
        }

        public override void Unfreeze()
        {
            // Already unfrozen
        }

        public override void Update(GameTime gameTime)
        {
            // Resume moving if boomerang is done boomeranging (or rather, if it would be - we don't actually see it!)
            UnseenBoomerang.Update();
            if (UnseenBoomerang.TimeIsUp()) Character.State = new RedGoriyaMovingState(Character, ResumeMovementDirection);

            Character.Sprite.Update();
        }
    }
}

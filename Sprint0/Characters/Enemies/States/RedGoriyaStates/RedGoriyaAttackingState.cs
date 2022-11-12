using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaAttackingState : AbstractCharacterState
    {
        private readonly static ISprite[] Sprites = {
            new RedGoriyaUpSprite(), new RedGoriyaDownSprite(), new RedGoriyaLeftSprite(), new RedGoriyaRightSprite()
        };

        private readonly Types.Direction ResumeMovementDirection;
        private readonly IProjectile UnseenBoomerang;

        public RedGoriyaAttackingState(AbstractCharacter character, Types.Direction direction) : base(character)
        {
            Sprite = Sprites[(int)direction];
            ResumeMovementDirection = direction;

            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOOMERANG_PROJ, Character, Types.Direction.DOWN);
            UnseenBoomerang = ProjectileFactory.GetInstance().GetProjectile(Types.Projectile.BOOMERANG_PROJ, Character, Types.Direction.DOWN);
        }

        public override void Attack()
        {
            // Already attacking.
        }

        public override void Move()
        {
            Character.State = new RedGoriyaMovingState(Character, ResumeMovementDirection);
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
            UnseenBoomerang.Update();
            if (UnseenBoomerang.TimeIsUp())
            {
                Move(); // Resume moving.
            }
            Sprite.Update();
        }
    }
}

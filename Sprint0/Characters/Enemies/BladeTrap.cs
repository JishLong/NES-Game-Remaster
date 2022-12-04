using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;
using Sprint0.Levels;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies
{
    public class BladeTrap : AbstractCharacter
    {
        private static Vector2 AttackMovementSpeed = new(5, 5);
        private static Vector2 ReturnMovementSpeed = new(2, 2);

        private Types.Direction MovementDirection;

        /* State pattern turns out to introduce very bad coupling issues with this particular enemy's behavior, so lets do this:
         * 
         * 0: still state - looking for the player
         * 1: attack state - zooming towards the player
         * 2: return state - going back to its original position
         */
        private int CurrentState;

        public BladeTrap(Vector2 position)
        {
            // State
            CurrentState = 0;

            // The blade trap sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = new BladeTrapSprite();

            // Movement
            Position = position;

            // Combat
            Health = int.MaxValue;
            Damage = 1;
        }

        public void Attack(Types.Direction direction) 
        {
            // If the blade trap is waiting, it's allowed to attack
            if (CurrentState == 0) 
            {
                CurrentState = 1;
                MovementDirection = direction;
            }
        }

        public void RespondToBladeTrap() 
        {
            // If the blade trap is attacking, make it return back
            if (CurrentState == 1)
            {
                CurrentState = 2;
                MovementDirection = Sprint0.Utils.GetOppositeDirection(MovementDirection);
            }
        }

        public void RespondToWall() 
        {
            // if the blade trap is attacking, make it return back
            if (CurrentState == 1)
            {
                CurrentState = 2;
                MovementDirection = Sprint0.Utils.GetOppositeDirection(MovementDirection);
            }

            // If the blade trap is returning, make it stop and wait for another attack
            else if (CurrentState == 2) 
            {
                CurrentState = 0;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Sprint0.Utils.LinkToCamera(Position), Color.White, Sprint0.Utils.CharacterLayerDepth);
        }

        public override Rectangle GetHitbox() 
        {
            return Sprite.GetDrawbox(Position);
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // Blade trap is invincibile bwahahahaha
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();

            // If the blade trap is waiting for an attack, have it spawn these projectiles that trigger an attack when the player walks into them
            if (CurrentState == 0) 
            {
                ProjectileManager PM = ProjectileManager.GetInstance();

                PM.AddProjectile(Types.Projectile.BLADE_TRAP_TRIGGER, this, Types.Direction.LEFT);
                PM.AddProjectile(Types.Projectile.BLADE_TRAP_TRIGGER, this, Types.Direction.RIGHT);
                PM.AddProjectile(Types.Projectile.BLADE_TRAP_TRIGGER, this, Types.Direction.UP);
                PM.AddProjectile(Types.Projectile.BLADE_TRAP_TRIGGER, this, Types.Direction.DOWN);
            }

            // Otherwise, the blade trap should be moving in some direction
            else if (CurrentState == 1) Position += Sprint0.Utils.DirectionToVector(MovementDirection) * AttackMovementSpeed;
            else if (CurrentState == 2) Position += Sprint0.Utils.DirectionToVector(MovementDirection) * ReturnMovementSpeed;
        }
    }
}

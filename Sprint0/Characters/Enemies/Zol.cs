using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.ZolStates;
using Sprint0.Levels;

namespace Sprint0.Characters.Enemies
{
    public class Zol : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.
        public float MovementSpeed { get; set; }
        public Zol(Vector2 position)
        {
            // State
            State = new ZolMovingUpState(this);
            // Combat
            Health = 1;
            Damage = 2;

            // Movement
            Position = position;
            MovementSpeed = 1;
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            DirectionTimer += elapsedTime;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            if (damage > 1) 
            {
                Vector2 gel1Position = Sprint0.Utils.CenterOnEdge(GetHitbox(), GetHitbox().Width, GetHitbox().Height, Types.Direction.LEFT);
                Vector2 gel2Position = Sprint0.Utils.CenterOnEdge(GetHitbox(), GetHitbox().Width, GetHitbox().Height, Types.Direction.RIGHT);
                room.AddCharacterToRoom(Types.Character.GEL, gel1Position);
                room.AddCharacterToRoom(Types.Character.GEL, gel2Position);
            }
            DeathAction();
            room.RemoveCharacterFromRoom(this);
        }
    }
}

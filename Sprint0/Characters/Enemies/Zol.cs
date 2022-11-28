using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.ZolStates;
using Sprint0.Levels;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Zol : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Zol(Vector2 position)
        {
            // The zol sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = new ZolSprite();

            // State
            State = new ZolMovingState(this);

            // Combat
            Health = 1;
            Damage = 2;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // If a zol isn't killed in one hit, it splits into two gels
            if (damage <= 1) 
            {
                Vector2 gel1Position = Sprint0.Utils.CenterOnEdge(GetHitbox(), GetHitbox().Width, GetHitbox().Height, Types.Direction.LEFT);
                Vector2 gel2Position = Sprint0.Utils.CenterOnEdge(GetHitbox(), GetHitbox().Width, GetHitbox().Height, Types.Direction.RIGHT);
                room.AddCharacterToRoom(Types.Character.GEL, gel1Position);
                room.AddCharacterToRoom(Types.Character.GEL, gel2Position);
            }
            DeathAction(room);
            room.RemoveCharacterFromRoom(this);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States.BladeTrapStates;
using Sprint0.Levels;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class BladeTrap : AbstractCharacter
    {
        public BladeTrap(Vector2 position)
        {
            // The blade trap sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = new BladeTrapSprite();

            // State
            State = new BladeTrapStillState(this);

            // Movement
            Position = position;

            // Combat
            Health = int.MaxValue;
            Damage = 1;
        }

        public override void Draw(SpriteBatch sb)
        {
            State.Draw(sb, Position, Color.White);
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // Blade trap is invincibile bwahahahaha
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
        }
    }
}

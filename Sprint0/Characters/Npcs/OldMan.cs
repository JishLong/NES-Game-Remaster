using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Characters;
using Sprint0.Levels;

namespace Sprint0.Npcs
{
	public class OldMan : AbstractCharacter
	{
		public OldMan(Vector2 position)
		{
			Health = 1;
			Position = position;
			Sprite = new OldManSprite();
		}

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // Super pops is invincible, he is literally god
        }

        public override void Update(GameTime gameTime)
		{
			Sprite.Update();
		}

		public override void Draw(SpriteBatch sb)
		{
			Sprite.Draw(sb, Position);
		}

		public override Rectangle GetHitbox() 
		{
			return Sprite.GetDrawbox(Position);
		}
	}
}

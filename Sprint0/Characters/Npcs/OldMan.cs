using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Characters;
using Sprint0.Levels;

namespace Sprint0.Npcs
{
	public class OldMan : AbstractCharacter
	{
		public OldMan(Vector2 position)
		{
            Sprite = new OldManSprite();

            Health = 1;
			Position = position;		
		}

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // Super pops is invincible, he is literally god
        }

        public override void Update(GameTime gameTime)
		{
			Sprite.Update();
		}

		public override Rectangle GetHitbox() 
		{
			return Sprite.GetDrawbox(Position);
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Bosses
{
	public interface IBossSprite
	{
		void Update(GameTime gameTime);
		void Draw(SpriteBatch sb, Vector2 position);
	}
}
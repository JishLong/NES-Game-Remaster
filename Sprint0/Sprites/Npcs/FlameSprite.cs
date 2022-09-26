using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Npcs
{
	public class FlameSprite : INpcSprite
	{
		private Texture2D Sheet;

		private int Width = 16;
		private int Height = 16;
		private int SpriteScale = 3;

		private Rectangle Target;
		private Rectangle Source;

		private Animation MovAnimation;
		private int AnimationSpd = 1;

		public FlameSprite()
		{
			Sheet = Resources.NpcsSpriteSheet;
			MovAnimation = new Animation(Width, Height, AnimationSpd);
			MovAnimation.AddFrame(52, 11);
			MovAnimation.AddFrame(69, 11);
		}
		public void Update(GameTime gameTime)
		{
			MovAnimation.Update(gameTime);
		}
		public void Draw(SpriteBatch sb, Vector2 position)
		{
			Target = new Rectangle((int)position.X, (int)position.Y, Width * SpriteScale, Height * SpriteScale);
			Source = MovAnimation.CurrentRect();
			if (MovAnimation.CurrentFrame == 0 & false)
			{

			}
			else
			{
				sb.Draw(Sheet, Target, Source, Color.White);
			}
		}

	}
}
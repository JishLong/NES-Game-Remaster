using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Sprint0.Sprites.Characters.Npcs;

namespace Sprint0.Npcs
{
	public class OldMan : AbstractNpc
	{
		int ElapsedTime;
		int UpdateTimer;

		public OldMan(Vector2 position, int updateTimer = 1000)
		{
			Health = 1;
			Position = position;
			Direction = new Vector2(0, 0);
			UpdateTimer = updateTimer;
			sprite = new OldManSprite();
		}

		public override void Destroy()
		{
			throw new NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
			if (ElapsedTime > UpdateTimer)
			{
				ElapsedTime = 0;
			}
			sprite.Update();
		}

		public override void Draw(SpriteBatch sb)
		{
			sprite.Draw(sb, Position);
		}
	}
}

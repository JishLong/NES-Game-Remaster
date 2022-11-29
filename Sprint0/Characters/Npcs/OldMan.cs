using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Characters;
using Sprint0.Levels;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.GameModes;
using static Sprint0.Types;

namespace Sprint0.Npcs
{
	public class OldMan : AbstractCharacter
	{
        public bool WasAttacked { get; private set; }

		public OldMan(Vector2 position)
		{
            Sprite = Sprite = GameModeManager.GetInstance().GameMode.GetOldManSprite();

            Health = 1;
			Position = position;	
            WasAttacked = false;
		}

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Utils.LinkToCamera(Position), Color.White, Utils.CharacterLayerDepth);
        }

        public override Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            WasAttacked = true;
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            Sprite = newGameMode.GetOldManSprite();
        }

        public override void Update(GameTime gameTime)
		{
			Sprite.Update();

            if (WasAttacked) 
            {
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.OLDMAN_PROJ, this, Types.Direction.NO_DIRECTION);
            }
		}
	}
}

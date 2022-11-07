using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Projectiles.Tools;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class PlayingState : AbstractGameState
    {
        public PlayingState() 
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetPlayingStateMappings(Game, Game.Player, this)),
                new MouseController(MouseMappings.GetInstance().PlayingStateMappings),
                new ProjectileController(Game.LevelManager),
                new CollisionController(Game)
            };
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
            Game.HUD.Draw(sb);
            Camera.Reset();
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            Game.Player.Update();
            base.Update(gameTime);
            Game.LevelManager.Update(gameTime);
        }
    }
}

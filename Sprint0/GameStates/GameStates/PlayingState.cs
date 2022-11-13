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
        private static readonly int HudAreaHeight = 44;

        public PlayingState(Game1 game) : base(game) 
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
            Camera.GetInstance().Move(Types.Direction.UP, (int)(HudAreaHeight * Utils.GameScale));
            Game.Player.HUD.Draw(sb);

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(HudAreaHeight * Utils.GameScale));
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            // Player must be updated before user input
            Game.Player.Update();

            // Controllers should be updated before everything else
            base.Update(gameTime);

            Game.LevelManager.Update(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Input.ClientInputHandlers;
using Sprint0.Input;
using Sprint0.Projectiles.Tools;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class PlayingState : AbstractGameState
    {
        private static readonly int HudAreaHeight = 56;
        private readonly IInputHandler clientInputHandler;

        public PlayingState(Game1 game) : base(game) 
        {
            clientInputHandler = new PlayingClientInputHandler(game);
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetPlayingStateMappings(Game, Game.PlayerManager.GetDefaultPlayer(), this)),
                new MouseController(MouseMappings.GetInstance().PlayingStateMappings),
                new ProjectileController(Game.LevelManager),
                new CollisionController(Game)
            };
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(HudAreaHeight * Utils.GameScale));
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(HudAreaHeight * Utils.GameScale));
            Game.LevelManager.Draw(sb);
            Game.PlayerManager.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            // Player must be updated before user input
            Game.PlayerManager.Update();

            // Controllers should be updated before everything else
            clientInputHandler.Update();
            base.Update(gameTime);

            Game.LevelManager.Update(gameTime);
        }

        public override void HandleClientInput(dynamic input, string id)
        {
            clientInputHandler.HandleInput(input, id);
        }
    }
}

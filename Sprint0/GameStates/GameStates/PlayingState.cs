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
        private static readonly int HUDHeight = (int)(56 * GameWindow.ResolutionScale);

        private readonly IInputHandler ClientInputHandler;

        public PlayingState(Game1 game) : base(game) 
        {        
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetPlayingStateMappings(Game, Game.PlayerManager.GetDefaultPlayer(), this)),
                new MouseController(MouseMappings.GetInstance().PlayingStateMappings),
                new ProjectileController(Game.LevelManager),
                new CollisionController(Game)
            };

            ClientInputHandler = new PlayingClientInputHandler(game);
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draw the HUD
            Camera.GetInstance().Move(Types.Direction.UP, HUDHeight);
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.DOWN, HUDHeight);

            // Draw the game
            Game.LevelManager.Draw(sb);
            Game.PlayerManager.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            // Players must be updated before user input
            Game.PlayerManager.Update();

            // Controllers should be updated before everything else
            base.Update(gameTime);
            ClientInputHandler.Update();

            Game.LevelManager.Update(gameTime);
        }

        public override void HandleClientInput(dynamic input, string id)
        {
            ClientInputHandler.HandleInput(input, id);
        }
    }
}

using System;
using System.Collections.Generic;
using Sprint0.Commands;
using Sprint0.Commands.Player;

namespace Sprint0.Input.ClientInputHandlers
{
	public class PlayingClientInputHandler : AbstractClientInputHandler
	{
        private Game1 game;
        public PlayingClientInputHandler(Game1 game1)
		{
            game = game1;
            buttonPressMap = new Dictionary<string, ITargetedCommand>()
            {
                // player movement
                { "w", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.UP) },
                { "a", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.LEFT) },
                { "s", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.DOWN) },
                { "d", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.RIGHT) },
                { "arrow up", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.UP) },
                { "arrow left", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.LEFT) },
                { "arrow down", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.DOWN) },
                { "arrow right", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.RIGHT) },

                // player attack
                { "z", new PlayerSwordAttackCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "n", new PlayerSwordAttackCommand(game1.PlayerManager.GetDefaultPlayer()) },
            };

            buttonReleaseMap = new Dictionary<string, ITargetedCommand>()
            {
                // stop moving
                { "w", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "a", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "s", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "d", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow up", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow left", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow down", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow right", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) }
            };
        }

        public override void Update()
        {
            foreach (var dispatch in keysPressed)
            {
                if (buttonPressMap.ContainsKey(dispatch.input))
                {
                    buttonPressMap[dispatch.input].SetTarget(game.PlayerManager.GetById(dispatch.inputId));
                    buttonPressMap[dispatch.input].Execute();
                }
            }

            foreach (var dispatch in this.GetStagedKeyReleases())
            {
                if (buttonReleaseMap.ContainsKey(dispatch.input))
                {
                    buttonReleaseMap[dispatch.input].SetTarget(game.PlayerManager.GetById(dispatch.inputId));
                    buttonReleaseMap[dispatch.input].Execute();
                }
            }
            keysPressed.Load();
        }
    }
}


using System;
using Sprint0.Assets;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class StartGameCommand : ITargetedCommand
    {
        private readonly Game1 Game;

        public StartGameCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            AudioManager.GetInstance().StopAudio();
            AudioManager.GetInstance().PlayLooped(AudioMappings.GetInstance().MusicGame);
            Game.CurrentState = new PlayingState(Game);
        }

        public void SetTarget<T>(T target)
        {
            throw new Exception("This command should never modify target");
        }
    }
}

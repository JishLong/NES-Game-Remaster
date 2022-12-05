using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Misc
{
    public class CommandLineReleaseKeyCommand : ICommand
    {
        private readonly IGameState CommandLineState;

        public CommandLineReleaseKeyCommand(IGameState commandLineState)
        {
            CommandLineState = commandLineState;
        }

        public void Execute()
        {
            (CommandLineState as CommandLineState).ReleaseKey();
        }
    }
}

using Microsoft.Xna.Framework.Input;
using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Misc
{
    public class CommandLineTypeKeyCommand : ICommand
    {
        private readonly IGameState CommandLineState;
        private Keys KeyTyped;

        public CommandLineTypeKeyCommand(IGameState commandLineState)
        {
            CommandLineState = commandLineState;
        }

        public void Execute()
        {
            (CommandLineState as CommandLineState).TypeKey((char)KeyTyped);
        }

        public void SetKeyTyped(Keys key) 
        {
            KeyTyped = key;
        }
    }
}

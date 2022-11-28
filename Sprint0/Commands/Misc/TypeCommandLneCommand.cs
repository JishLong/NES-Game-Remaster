using Microsoft.Xna.Framework.Input;
using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Misc
{
    public class TypeCommandLineCommand : ICommand
    {
        private readonly IGameState CommandLineState;
        private Keys KeyTyped;

        public TypeCommandLineCommand(IGameState commandLineState)
        {
            CommandLineState = commandLineState;
        }

        public void Execute()
        {
            string KeyString = KeyTyped.ToString();
            (CommandLineState as CommandLineState).AddToCommand(KeyString);
        }

        public void SetKeyTyped(Keys key) 
        {
            KeyTyped = key;
        }
    }
}

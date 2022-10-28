using Sprint0.Commands;
using Sprint0.Commands.Levels;
using System.Collections.Generic;

namespace Sprint0.Input
{
    public class MouseMappings
    {
        private static MouseMappings Instance;

        public Dictionary<string, ICommand> PlayingStateMappings { get; private set; }

        private MouseMappings() { }

        public static MouseMappings GetInstance()
        {
            Instance ??= new MouseMappings();
            return Instance;
        }

        public void InitializeMappings(Game1 game)
        {
            PlayingStateMappings = new Dictionary<string, ICommand>() { 
                { "left", new PreviousRoomCommand(game) },
                { "right", new NextRoomCommand(game) },
            };
        }
    }
}

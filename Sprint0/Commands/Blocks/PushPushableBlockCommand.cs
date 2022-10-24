using Sprint0.Blocks;
using Sprint0.Levels;

namespace Sprint0.Commands.Blocks
{
    public class PushPushableBlockCommand : ICommand
    {
        private AbstractPushableBlock Block;

        public PushPushableBlockCommand(AbstractPushableBlock block) 
        {
            Block = block;
        }

        public void Execute() 
        {
            Block.Push();
        }
    }
}

using Sprint0.Blocks;

namespace Sprint0.Commands.Blocks
{
    public class PushPushableBlockCommand : ICommand
    {
        private readonly AbstractPushableBlock Block;

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
